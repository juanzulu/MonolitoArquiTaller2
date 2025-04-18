using MonolitoTaller.Models.Entities;
using Microsoft.Data.SqlClient;
using MonolitoTaller.Models.ViewModels;


namespace MonolitoTaller.Models.DAO
{
    public class NotaDAO
    {
        private readonly string connectionString;

        public NotaDAO(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Nota> ObtenerTodas()
        {
            var lista = new List<Nota>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_nota, id_estudiante, id_asignatura, valor, fecha_registro FROM Nota", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Nota
                    {
                        Id = (int)reader["id_nota"],
                        IdEstudiante = (int)reader["id_estudiante"],
                        IdAsignatura = (int)reader["id_asignatura"],
                        Valor = Convert.ToDecimal(reader["valor"]),
                        FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                    });
                }
            }
            return lista;
        }

        public Nota ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_nota, id_estudiante, id_asignatura, valor, fecha_registro FROM Nota WHERE id_nota = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Nota
                    {
                        Id = (int)reader["id_nota"],
                        IdEstudiante = (int)reader["id_estudiante"],
                        IdAsignatura = (int)reader["id_asignatura"],
                        Valor = Convert.ToDecimal(reader["valor"]),
                        FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                    };
                }
            }
            return null;
        }

        public void Crear(Nota nota)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Nota (id_estudiante, id_asignatura, valor, fecha_registro) VALUES (@idEst, @idAsig, @valor, @fecha)", conn);
                cmd.Parameters.AddWithValue("@idEst", nota.IdEstudiante);
                cmd.Parameters.AddWithValue("@idAsig", nota.IdAsignatura);
                cmd.Parameters.AddWithValue("@valor", nota.Valor);
                cmd.Parameters.AddWithValue("@fecha", nota.FechaRegistro);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Nota nota)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Nota SET id_estudiante = @idEst, id_asignatura = @idAsig, valor = @valor, fecha_registro = @fecha WHERE id_nota = @id", conn);
                cmd.Parameters.AddWithValue("@id", nota.Id);
                cmd.Parameters.AddWithValue("@idEst", nota.IdEstudiante);
                cmd.Parameters.AddWithValue("@idAsig", nota.IdAsignatura);
                cmd.Parameters.AddWithValue("@valor", nota.Valor);
                cmd.Parameters.AddWithValue("@fecha", nota.FechaRegistro);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Nota WHERE id_nota = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<NotaVistaViewModel> ObtenerNotasParaVista()
        {
            var lista = new List<NotaVistaViewModel>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT 
                n.id_nota,
                e.documento AS DocumentoEstudiante,
                a.codigo AS CodigoAsignatura,
                n.valor,
                n.fecha_registro
            FROM Nota n
            INNER JOIN Estudiante e ON n.id_estudiante = e.id_estudiante
            INNER JOIN Asignatura a ON n.id_asignatura = a.id_asignatura", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new NotaVistaViewModel
                    {
                        IdNota = (int)reader["id_nota"],
                        DocumentoEstudiante = reader["DocumentoEstudiante"].ToString(),
                        CodigoAsignatura = reader["CodigoAsignatura"].ToString(),
                        Valor = (decimal)reader["valor"],
                        FechaRegistro = (DateTime)reader["fecha_registro"]
                    });
                }
            }

            return lista;
        }
    }
}

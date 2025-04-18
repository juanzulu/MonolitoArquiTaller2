using MonolitoTaller.Models.Entities;
using Microsoft.Data.SqlClient;
using MonolitoTaller.Models.ViewModels;


namespace MonolitoTaller.Models.DAO
{
    public class EstudianteDAO
    {
        private readonly string connectionString;

        public EstudianteDAO(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Estudiante> ObtenerTodos()
        {
            var lista = new List<Estudiante>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_estudiante, nombre, apellido, correo, documento FROM Estudiante", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Estudiante
                    {
                        Id = (int)reader["id_estudiante"],
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Documento = reader["documento"].ToString()
                    });
                }
            }
            return lista;
        }

        public Estudiante ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_estudiante, nombre, apellido, correo, documento FROM Estudiante WHERE id_estudiante = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Estudiante
                    {
                        Id = (int)reader["id_estudiante"],
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Documento = reader["documento"].ToString()
                    };
                }
            }
            return null;
        }

        public void Crear(Estudiante e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Estudiante (nombre, apellido, correo, documento) VALUES (@nombre, @apellido, @correo, @documento)", conn);
                cmd.Parameters.AddWithValue("@nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@apellido", e.Apellido);
                cmd.Parameters.AddWithValue("@correo", e.Correo);
                cmd.Parameters.AddWithValue("@documento", e.Documento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Estudiante e)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Estudiante SET nombre = @nombre, apellido = @apellido, correo = @correo, documento = @documento WHERE id_estudiante = @id", conn);
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@nombre", e.Nombre);
                cmd.Parameters.AddWithValue("@apellido", e.Apellido);
                cmd.Parameters.AddWithValue("@correo", e.Correo);
                cmd.Parameters.AddWithValue("@documento", e.Documento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Primero elimina las notas asociadas
                var eliminarNotas = new SqlCommand("DELETE FROM Nota WHERE id_estudiante = @id", conn);
                eliminarNotas.Parameters.AddWithValue("@id", id);
                eliminarNotas.ExecuteNonQuery();

                // Luego elimina el estudiante
                var eliminarEstudiante = new SqlCommand("DELETE FROM Estudiante WHERE id_estudiante = @id", conn);
                eliminarEstudiante.Parameters.AddWithValue("@id", id);
                eliminarEstudiante.ExecuteNonQuery();
            }
        }

        public List<AsignaturaNota> ObtenerAsignaturasYNotasPorEstudiante(int estudianteId)
        {
            var lista = new List<AsignaturaNota>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
            SELECT a.nombre AS AsignaturaNombre, a.codigo, a.creditos, n.valor, n.fecha_registro
            FROM Nota n
            INNER JOIN Asignatura a ON n.id_asignatura = a.id_asignatura
            WHERE n.id_estudiante = @idEstudiante", conn);

                cmd.Parameters.AddWithValue("@idEstudiante", estudianteId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new AsignaturaNota
                    {
                        AsignaturaNombre = reader["AsignaturaNombre"].ToString(),
                        Codigo = reader["codigo"].ToString(),
                        Creditos = (int)reader["creditos"],
                        Valor = (decimal)reader["valor"],
                        FechaRegistro = (DateTime)reader["fecha_registro"]
                    });
                }
            }

            return lista;
        }

    }
}

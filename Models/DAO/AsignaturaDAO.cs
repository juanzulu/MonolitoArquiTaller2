using MonolitoTaller.Models.Entities;
using Microsoft.Data.SqlClient; 


namespace MonolitoTaller.Models.DAO
{
    public class AsignaturaDAO
    {
        private readonly string connectionString;

        public AsignaturaDAO(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Asignatura> ObtenerTodas()
        {
            var lista = new List<Asignatura>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_asignatura, nombre, codigo, creditos FROM Asignatura", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Asignatura
                    {
                        Id = (int)reader["id_asignatura"],
                        Nombre = reader["nombre"].ToString(),
                        Codigo = reader["codigo"].ToString(),
                        Creditos = (int)reader["creditos"]
                    });
                }
            }
            return lista;
        }

        public Asignatura ObtenerPorId(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT id_asignatura, nombre, codigo, creditos FROM Asignatura WHERE id_asignatura = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Asignatura
                    {
                        Id = (int)reader["id_asignatura"],
                        Nombre = reader["nombre"].ToString(),
                        Codigo = reader["codigo"].ToString(),
                        Creditos = (int)reader["creditos"]
                    };
                }
            }
            return null;
        }

        public void Crear(Asignatura a)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Asignatura (nombre, codigo, creditos) VALUES (@nombre, @codigo, @creditos)", conn);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@codigo", a.Codigo);
                cmd.Parameters.AddWithValue("@creditos", a.Creditos);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Asignatura a)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Asignatura SET nombre = @nombre, codigo = @codigo, creditos = @creditos WHERE id_asignatura = @id", conn);
                cmd.Parameters.AddWithValue("@id", a.Id);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@codigo", a.Codigo);
                cmd.Parameters.AddWithValue("@creditos", a.Creditos);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Asignatura WHERE id_asignatura = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

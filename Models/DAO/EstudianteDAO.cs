using MonolitoTaller.Models.Entities;
using Microsoft.Data.SqlClient; 


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
                var cmd = new SqlCommand("DELETE FROM Estudiante WHERE id_estudiante = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

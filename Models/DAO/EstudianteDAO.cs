using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MonolitoArquiTaller2.Models.Entities;

namespace MonolitoArquiTaller2.Models.DAO
{
    public class EstudianteDAO
    {
        // Cambia esto según tu configuración local o contenedor Docker
        private string connectionString = "Server=localhost;Database=GestionAcademica;User Id=sa;Password=StrongPass123!;";

        public List<Estudiante> ObtenerTodos()
        {
            var lista = new List<Estudiante>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_estudiante, nombre, apellido, correo, documento FROM Estudiante";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var estudiante = new Estudiante
                    {
                        Id = Convert.ToInt32(reader["id_estudiante"]),
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Documento = reader["documento"].ToString()
                    };
                    lista.Add(estudiante);
                }
            }
            return lista;
        }

        public Estudiante ObtenerPorId(int id)
        {
            Estudiante estudiante = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_estudiante, nombre, apellido, correo, documento FROM Estudiante WHERE id_estudiante = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    estudiante = new Estudiante
                    {
                        Id = Convert.ToInt32(reader["id_estudiante"]),
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        Correo = reader["correo"].ToString(),
                        Documento = reader["documento"].ToString()
                    };
                }
            }
            return estudiante;
        }

        public void Crear(Estudiante estudiante)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Estudiante (nombre, apellido, correo, documento)
                                 VALUES (@nombre, @apellido, @correo, @documento)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@documento", estudiante.Documento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Estudiante estudiante)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Estudiante SET nombre = @nombre, apellido = @apellido, correo = @correo, documento = @documento
                                 WHERE id_estudiante = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", estudiante.Id);
                cmd.Parameters.AddWithValue("@nombre", estudiante.Nombre);
                cmd.Parameters.AddWithValue("@apellido", estudiante.Apellido);
                cmd.Parameters.AddWithValue("@correo", estudiante.Correo);
                cmd.Parameters.AddWithValue("@documento", estudiante.Documento);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Estudiante WHERE id_estudiante = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

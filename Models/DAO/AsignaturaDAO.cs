using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MonolitoArquiTaller2.Models.Entities;

namespace MonolitoArquiTaller2.Models.DAO
{
    public class AsignaturaDAO
    {
        private string connectionString = "Server=localhost;Database=GestionAcademica;User Id=sa;Password=StrongPass123!;";

        public List<Asignatura> ObtenerTodas()
        {
            var lista = new List<Asignatura>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_asignatura, nombre, codigo, creditos FROM Asignatura";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Asignatura
                    {
                        Id = Convert.ToInt32(reader["id_asignatura"]),
                        Nombre = reader["nombre"].ToString(),
                        Codigo = reader["codigo"].ToString(),
                        Creditos = Convert.ToInt32(reader["creditos"])
                    });
                }
            }
            return lista;
        }

        public Asignatura ObtenerPorId(int id)
        {
            Asignatura a = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_asignatura, nombre, codigo, creditos FROM Asignatura WHERE id_asignatura = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = new Asignatura
                    {
                        Id = Convert.ToInt32(reader["id_asignatura"]),
                        Nombre = reader["nombre"].ToString(),
                        Codigo = reader["codigo"].ToString(),
                        Creditos = Convert.ToInt32(reader["creditos"])
                    };
                }
            }
            return a;
        }

        public void Crear(Asignatura asignatura)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Asignatura (nombre, codigo, creditos) VALUES (@nombre, @codigo, @creditos)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", asignatura.Nombre);
                cmd.Parameters.AddWithValue("@codigo", asignatura.Codigo);
                cmd.Parameters.AddWithValue("@creditos", asignatura.Creditos);
                cmd.ExecuteNonQuery();
            }
        }

        public void Actualizar(Asignatura asignatura)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Asignatura SET nombre = @nombre, codigo = @codigo, creditos = @creditos WHERE id_asignatura = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", asignatura.Id);
                cmd.Parameters.AddWithValue("@nombre", asignatura.Nombre);
                cmd.Parameters.AddWithValue("@codigo", asignatura.Codigo);
                cmd.Parameters.AddWithValue("@creditos", asignatura.Creditos);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Asignatura WHERE id_asignatura = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MonolitoArquiTaller2.Models.Entities;

namespace MonolitoArquiTaller2.Models.DAO
{
    public class NotaDAO
    {
        private string connectionString = "Server=localhost;Database=GestionAcademica;User Id=sa;Password=StrongPass123!;";

        public List<Nota> ObtenerTodas()
        {
            var lista = new List<Nota>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_nota, id_estudiante, id_asignatura, valor, fecha_registro FROM Nota";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Nota
                    {
                        Id = Convert.ToInt32(reader["id_nota"]),
                        IdEstudiante = Convert.ToInt32(reader["id_estudiante"]),
                        IdAsignatura = Convert.ToInt32(reader["id_asignatura"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                    });
                }
            }
            return lista;
        }

        public Nota ObtenerPorId(int id)
        {
            Nota nota = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Nota WHERE id_nota = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nota = new Nota
                    {
                        Id = Convert.ToInt32(reader["id_nota"]),
                        IdEstudiante = Convert.ToInt32(reader["id_estudiante"]),
                        IdAsignatura = Convert.ToInt32(reader["id_asignatura"]),
                        Valor = Convert.ToDecimal(reader["valor"]),
                        FechaRegistro = Convert.ToDateTime(reader["fecha_registro"])
                    };
                }
            }
            return nota;
        }

        public void Crear(Nota nota)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Nota (id_estudiante, id_asignatura, valor, fecha_registro)
                                 VALUES (@id_estudiante, @id_asignatura, @valor, @fecha)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_estudiante", nota.IdEstudiante);
                cmd.Parameters.AddWithValue("@id_asignatura", nota.IdAsignatura);
                cmd.Parameters.AddWithValue("@valor", nota.Valor);
                cmd.Parameters.AddWithValue("@fecha", nota.FechaRegistro);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Nota WHERE id_nota = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

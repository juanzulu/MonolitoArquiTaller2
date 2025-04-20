using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MonolitoTaller.Utils;

public static class DatabaseInitializer
{
    public static void VerificarYCrearBase(string masterConnection, string dbName, string scriptPath, ILogger logger)
    {
        try
        {
            using (var conn = new SqlConnection(masterConnection))
            {
                conn.Open();
                var checkDbCmd = new SqlCommand($"IF DB_ID('{dbName}') IS NULL CREATE DATABASE [{dbName}];", conn);
                checkDbCmd.ExecuteNonQuery();
                logger.LogInformation($"✔️ Base de datos '{dbName}' verificada o creada.");
            }

            var fullConnection = masterConnection.Replace("Database=master", $"Database={dbName}");
            var script = File.ReadAllText(scriptPath);

            using (var conn = new SqlConnection(fullConnection))
            {
                conn.Open();
                var cmd = new SqlCommand(script, conn);
                cmd.ExecuteNonQuery();
                logger.LogInformation("✔️ Script SQL ejecutado correctamente.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"❌ Error al ejecutar el script SQL: {ex.Message}");
        }
    }
}

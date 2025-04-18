namespace MonolitoTaller.Models.Entities
{
    public class Asignatura
    {
        // id_asignatura en BD
        public int Id { get; set; }         
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
    }
}

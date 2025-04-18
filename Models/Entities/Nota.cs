namespace MonolitoTaller.Models.Entities
{
    public class Nota
    {
        public int Id { get; set; }                     // id_nota
        public int IdEstudiante { get; set; }           // FK
        public int IdAsignatura { get; set; }           // FK
        public decimal Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

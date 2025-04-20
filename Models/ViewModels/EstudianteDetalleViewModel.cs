using MonolitoTaller.Models.Entities;

namespace MonolitoTaller.Models.ViewModels
{
    public class EstudianteDetalleViewModel
    {
        public Estudiante Estudiante { get; set; }
        public List<AsignaturaNota> AsignaturasNotas { get; set; }
    }

    public class AsignaturaNota
    {
        public string AsignaturaNombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

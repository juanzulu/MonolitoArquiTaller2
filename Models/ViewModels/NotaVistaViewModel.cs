namespace MonolitoTaller.Models.ViewModels
{
    public class NotaVistaViewModel
    {
        public int IdNota { get; set; }
        public string DocumentoEstudiante { get; set; }
        public string CodigoAsignatura { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
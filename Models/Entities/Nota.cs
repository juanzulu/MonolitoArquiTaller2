using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonolitoArquiTaller2.Models.Entities
{
    public class Nota
    {
        // id_nota
        public int Id { get; set; }                
        public int IdEstudiante { get; set; }
        public int IdAsignatura { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
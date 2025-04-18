using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonolitoArquiTaller2.Models.Entities
{
    public class Asignatura
    {
        // Equivale a id_asignatura
        public int Id { get; set; }            
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Creditos { get; set; }
    }
}

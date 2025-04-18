using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonolitoArquiTaller2.Models.Entities
{
    public class Estudiante
    {
        // Equivale a id_estudiante en la BD
        public int Id { get; set; }              
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }
    }
}

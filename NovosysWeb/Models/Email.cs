using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovosysWeb.Models
{
    public class Email
    {

        public string NombreVar { get; set; }
        public string ApellidoVar { get; set; }
        public string DireccionVar { get; set; }
        public string TelefonoVar { get; set; }
        public string CorreoVar { get; set; }
        public string MensajeVar { get; set; }
        public DateTime? FechaAltaDate { get; set; } = DateTime.Now;
        public string OrigenVar { get; set; }
        public string DescripcionObraVar { get; set; }
        public string MtsCuadradosInt { get; set; }
        public string EstadoVar { get; set; }
        public string AreaInteresVar { get; set; }
        public string ExperienciaVar { get; set; }
        public string NombreProductoVar { get; set; }

    }
}
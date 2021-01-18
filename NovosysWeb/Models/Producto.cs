using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovosysWEB.Models
{
    public class Producto
    {
        public int CveProductoInt { get; set; }
        public string ClaseVar { get; set; }
        public string SubclaseVar { get; set; }
        public string NombreVar { get; set; }
        public string DescripcionLargaVar { get; set; }
        public string RutaImagenVar { get; set; }
        public string AltImagenVar { get; set; }
        public string MetaTagProdVar { get; set; }
        public int? EstatusInt { get; set; }
        public int? OrdenInt { get; set; }

    }
}
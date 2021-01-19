using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovosysWeb.Models
{
    public class Producto
    {

        [Key]
        [Display(Name = "Clave Producto")]
        public int CveProductoInt { get; set; }

        [Display(Name = "Clase")]
        public string ClaseVar { get; set; }
        public string SubclaseVar { get; set; }

        [Display(Name = "Nombre")]
        public string NombreVar { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionLargaVar { get; set; }

        [Display(Name = "Ruta Imágen")]
        public string RutaImagenVar { get; set; }

        [Display(Name = "Imágen")]
        public string AltImagenVar { get; set; }
        public string MetaTagProdVar { get; set; }

        [Display(Name = "Estatus")]
        public int? EstatusInt { get; set; }
        public int? OrdenInt { get; set; }

    }
}
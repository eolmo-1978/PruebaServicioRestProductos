using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Interview.Models
{
    public class DtoProducto
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Añada informacion adicional")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Introduce la categoria")]
        public string Categoria { get; set; }
    }
}
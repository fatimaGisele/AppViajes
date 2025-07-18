using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class OpcionesDePago
    {
        [Key]
        public int Id {  get; set; }
        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tipo { get; set; } = null!;
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Descripcion { get; set; } = null!;
    }
}

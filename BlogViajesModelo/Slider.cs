using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class Slider
    {
        [Key]
        public int Id {  get; set; }
        [Required(ErrorMessage ="Nombre requerido")]
        public string Nombre {  get; set; } = null!;
        [Required]
        public bool Estado {  get; set; } = false;
        [DataType(DataType.ImageUrl)]
        [Display(Name ="Imagen")]
        public string? Url { get; set; } 
    }
}

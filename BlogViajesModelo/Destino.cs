using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class Destino
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del destino es requerido")]
        public string NombreDestino { get; set; } = null!;
        [Required(ErrorMessage = "El precio es requerido")]
        public double Precio { get; set; }
    }
}

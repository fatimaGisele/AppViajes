using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class Carrito
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClienteId { get; set; } = string.Empty;
        [Required]
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; } = null!;

        public virtual ICollection<CarritoDetalle> Detalles { get; set; } = new List<CarritoDetalle>();

        [Required]
        public double Total { get; set; }
      
    }
}

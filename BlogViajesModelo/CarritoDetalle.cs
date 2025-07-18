using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class CarritoDetalle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CarritoId { get; set; }
        [ForeignKey("CarritoId")]
        public virtual Carrito Carrito { get; set; } = null!;

        [Required]
        public int PaqueteDeViajeId { get; set; }
        [ForeignKey("PaqueteDeViajeId")]
        public virtual PaqueteDeViaje PaqueteDeViaje { get; set; } = null!;

        [Required]
        public int Cantidad { get; set; }
    }
}

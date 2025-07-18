using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class CompraDetalle
    {
        public int Id { get; set; }
        public int PaqueteDeViajeId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public int CompraId { get; set; }

        [ForeignKey("CompraId")]
        public virtual Compra Compra { get; set; } = null!;

        [ForeignKey("PaqueteDeViajeId")]
        public virtual PaqueteDeViaje PaqueteDeViaje { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class Compra
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public DateTime FechaCompra { get; set; }
        public double Total { get; set; }
        public virtual ICollection<CompraDetalle> CompraDetalles { get; set; }
    }
}

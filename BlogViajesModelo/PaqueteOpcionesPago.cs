using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class PaqueteOpcionesPago
    {
        [Key]
        public int Id { get; set; }
        public int IdPaqueteDeViaje { get; set; }
        public int IdOpcionesDePago { get; set; }
        public virtual PaqueteDeViaje IdPaqueteDeViajeNavigation { get; set; } = null!;

        public virtual OpcionesDePago IdOpcionesDePagoNavigation { get; set; } = null!;
    }
}

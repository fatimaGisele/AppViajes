using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class ViajeDestino
    {
        [Key] 
        public int Id { get; set; }
        public int IdPaqueteViaje {  get; set; }
        public int IdDestino {  get; set; }
        public int CantidadDias { get; set; }
        public virtual PaqueteDeViaje IdPaqueteNavigation { get; set; } = null!;
        public virtual Destino IdDestinoNavigation { get; set; } = null!;
    }
}

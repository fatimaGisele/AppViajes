using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo.ViewModels
{
    public class DestinoView
    {
        public int DestinoId { get; set; }
        [Range(1, 365)]
        public int CantidadDias { get; set; }
    }
}

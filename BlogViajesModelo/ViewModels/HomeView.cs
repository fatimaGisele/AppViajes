using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo.ViewModels
{
    public class HomeView
    {
        public IEnumerable<Slider> sliders { get; set; }
        public IEnumerable<PaqueteDeViaje> paquetes { get; set; }
    }
}

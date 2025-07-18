using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class SliderRepository : Repository<Slider> , ISliderRepository 
    {
        private readonly ApplicationDbContext _context;

        public SliderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Slider slider)
        {
            var s = _context.Slider.Find(slider.Id);
            if (s != null) { 
                s.Nombre = slider.Nombre;
                s.Estado = slider.Estado;
                s.Url = slider.Url;

                _context.SaveChanges();
            }
        }

    }
}

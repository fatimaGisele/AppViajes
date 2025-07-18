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
    public class ViajeDestinoRepository : Repository<ViajeDestino> , IViajeDestinoRepository
    {
        private readonly ApplicationDbContext _context;

        public ViajeDestinoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ViajeDestino viajeDestino)
        {
            var vd = _context.ViajeDestino.Find(viajeDestino.Id);

            if (vd != null) { 
                vd.IdPaqueteViaje = viajeDestino.IdPaqueteViaje;
                vd.IdDestino = viajeDestino.IdDestino;
                vd.CantidadDias = viajeDestino.CantidadDias;
                vd.IdPaqueteNavigation = viajeDestino.IdPaqueteNavigation;
                vd.IdDestinoNavigation = viajeDestino.IdDestinoNavigation;

                _context.SaveChanges();
            }
        }
    }
}

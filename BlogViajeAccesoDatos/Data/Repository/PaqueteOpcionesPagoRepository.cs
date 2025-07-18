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
    public class PaqueteOpcionesPagoRepository : Repository<PaqueteOpcionesPago> ,IPaqueteOpcionesPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public PaqueteOpcionesPagoRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        public void Update(PaqueteOpcionesPago paqueteOpcionesPago)
        {
            var pop = _context.PaqueteOpcionesPagos.FirstOrDefault(i=>i.Id==paqueteOpcionesPago.Id);
            if (pop!=null) {
                pop.IdOpcionesDePago = paqueteOpcionesPago.IdOpcionesDePago;
                pop.IdOpcionesDePagoNavigation = paqueteOpcionesPago.IdOpcionesDePagoNavigation;
                pop.IdPaqueteDeViaje = paqueteOpcionesPago.IdPaqueteDeViaje;
                pop.IdPaqueteDeViajeNavigation = paqueteOpcionesPago.IdPaqueteDeViajeNavigation;

                _context.SaveChanges();
            }

        }
    }
}

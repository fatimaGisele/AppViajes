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
    class CompraDetalleRepository : Repository<CompraDetalle>, ICompraDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraDetalleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CompraDetalle compraDetalle)
        {
            var cd = _context.CompraDetalle.FirstOrDefault(i => i.Id == compraDetalle.Id);
            if (cd != null)
            {
                cd.Compra = compraDetalle.Compra;
                cd.CompraId = compraDetalle.CompraId;
                cd.Cantidad = compraDetalle.Cantidad;
                cd.PaqueteDeViajeId = compraDetalle.PaqueteDeViajeId;
                cd.PaqueteDeViaje = compraDetalle.PaqueteDeViaje;

                _context.SaveChanges();
            }

        }
    }
}

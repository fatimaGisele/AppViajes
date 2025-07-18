using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class CarritoDetalleRepository : Repository<CarritoDetalle>, ICarritoDetalleRepository
    {
        private readonly ApplicationDbContext _context;

        public CarritoDetalleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    
        public void Update(CarritoDetalle carritoDetalle)
        {
            var carritoActualizado = _context.CarritoDetalle.FirstOrDefault(c => c.Id == carritoDetalle.Id);

            if (carritoActualizado != null)
            {
                carritoActualizado.CarritoId = carritoDetalle.CarritoId;
                carritoActualizado.Carrito = carritoDetalle.Carrito;
                carritoActualizado.Cantidad = carritoDetalle.Cantidad;
                carritoActualizado.PaqueteDeViaje = carritoDetalle.PaqueteDeViaje;
                carritoActualizado.PaqueteDeViajeId = carritoDetalle.PaqueteDeViajeId;

                _context.SaveChanges();
            }
        }
    }
}

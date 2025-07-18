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
    class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly ApplicationDbContext _context;

        public CompraRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Compra compra)
        {
            var c = _context.Compra.FirstOrDefault(c=>c.Id == compra.Id);
            if (c != null) { 
                c.ClienteId = compra.ClienteId;
                c.Total = compra.Total;
                c.FechaCompra = compra.FechaCompra;
                

                foreach (var itemExistente in compra.CompraDetalles)
                {
                    if (!compra.CompraDetalles.Any(i => i.Id == itemExistente.Id))
                    {
                        _context.Remove(itemExistente);
                    }
                }

                foreach (var item in compra.CompraDetalles)
                {
                    var itemExistente = c.CompraDetalles.FirstOrDefault(i => i.Id == item.Id);
                    if (itemExistente != null)
                    {
                        itemExistente.Cantidad = item.Cantidad;
                        itemExistente.PaqueteDeViajeId = item.PaqueteDeViajeId;
                        itemExistente.PrecioUnitario = item.PrecioUnitario; 
                        itemExistente.CompraId = item.CompraId;
                        itemExistente.Compra = item.Compra;
                    }

                    else
                    {
                        c.CompraDetalles.Add(item);
                    }
                }

                _context.SaveChanges();
            }
        }
    }
}

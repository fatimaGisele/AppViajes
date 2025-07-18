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
    public class CarritoRepository : Repository<Carrito>, ICarritoRepository
    {
        private readonly ApplicationDbContext _context;

        public CarritoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Carrito carrito)
        {
            var carritoActualizado = _context.Carrito.Include(c => c.Detalles).FirstOrDefault(c => c.Id == carrito.Id);

            if (carritoActualizado != null)
            {
                carritoActualizado.ClienteId = carrito.ClienteId;
                carritoActualizado.Total = carrito.Total;

                //elimina lo q ya no esta
                foreach (var itemExistente in carrito.Detalles)
                {
                    if (!carrito.Detalles.Any(i => i.Id == itemExistente.Id))
                    {
                        _context.Remove(itemExistente);
                    }
                }

                //actualizamos
                foreach (var item in carrito.Detalles)
                {
                    var itemExistente = carritoActualizado.Detalles.FirstOrDefault(i => i.Id == item.Id);
                    if (itemExistente != null)
                    {
                        itemExistente.Cantidad = item.Cantidad;
                        itemExistente.PaqueteDeViajeId = item.PaqueteDeViajeId;
                    }

                    else
                    {
                        // Agregar
                        carritoActualizado.Detalles.Add(item);
                    }
                    }

                    _context.SaveChanges();
                }
            else
            {
              throw new InvalidOperationException($"No se encontró un carrito con ID {carrito.Id}.");
            }
            }
        }
    }
           

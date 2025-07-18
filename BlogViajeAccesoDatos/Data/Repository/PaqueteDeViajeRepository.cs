using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using BlogViajesModelo.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class PaqueteDeViajeRepository : Repository<PaqueteDeViaje> , IPaqueteDeViajeRepository
    {
        private readonly ApplicationDbContext _context;

        public PaqueteDeViajeRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void CrearNuevoPaquete(PaqueteDeViajeView model)
        {
            
            var destinos = _context.Destino
                .Where(d => model.DestinosSeleccionados.Select(m => m.DestinoId).Contains(d.Id))
                .ToList();

            double precioTotal = 0;
            int cantDiasTotal = 0;


            foreach (var d in model.DestinosSeleccionados) {
                Console.WriteLine($"Seleccionado: ID={d.DestinoId}, Días={d.CantidadDias}");
                var destino = destinos.FirstOrDefault(i => i.Id == d.DestinoId);
                if (destino != null) {
                    precioTotal += destino.Precio * d.CantidadDias;
                    cantDiasTotal += d.CantidadDias;
                }
            }
            // Crear el paquete
            var nuevoPaquete = new PaqueteDeViaje
            {
                Nombre = model.Nombre,
                Tipo = model.Tipo,
                Detalle=model.Detalle,
                Disponibilidad = model.Disponibilidad,
                CantidadDias = cantDiasTotal,
                Precio = precioTotal,
            };
            try
            {
                Console.WriteLine($"Lpm ahhhh Paquete: {nuevoPaquete.Nombre}, Total: {nuevoPaquete.Precio}, Días: {nuevoPaquete.CantidadDias}");
                _context.PaqueteDeViajes.Add(nuevoPaquete);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("ERROR al guardar en base de datos:");
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
             var viajeDestino = model.DestinosSeleccionados
                   .Select(d => new ViajeDestino
                   {
                       IdDestino = d.DestinoId,
                       IdPaqueteViaje = nuevoPaquete.Id,
                       IdPaqueteNavigation = nuevoPaquete
                   }).ToList();
            try {
                _context.ViajeDestino.AddRange(viajeDestino);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("ERROR al guardar en base de datos en el segundo tryCatch:");
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            


        }
        public void Update(PaqueteDeViajeView paqueteDeViaje)
        {
            Console.WriteLine($"ID recibido: {paqueteDeViaje.Id}");

            var pv = _context.PaqueteDeViajes.Include(c => c.Destino).
                FirstOrDefault(c => c.Id == paqueteDeViaje.Id);
            
            if (pv != null)
            {
           
                pv.Detalle = paqueteDeViaje.Detalle;
                pv.Nombre = paqueteDeViaje.Nombre;
                pv.Tipo = paqueteDeViaje.Tipo;
                pv.Disponibilidad = paqueteDeViaje.Disponibilidad;
                pv.CantidadDias = paqueteDeViaje.CantidadDias;

                _context.ViajeDestino.RemoveRange(pv.Destino);

                var destinosDesdeDb = _context.Destino
               .Where(d => paqueteDeViaje.DestinosSeleccionados.Select(v => v.DestinoId).Contains(d.Id))
               .ToList();

                double nuevoPrecio = 0;
                int nuevaCantidadDias = 0;


                var destinos = paqueteDeViaje.DestinosSeleccionados.Select(ds =>
                {
                    var destino = destinosDesdeDb.FirstOrDefault(i => i.Id == ds.DestinoId);
                    if(destino == null) { throw new Exception("Destino inválido"); }

                    nuevoPrecio += destino.Precio * ds.CantidadDias;
                    nuevaCantidadDias += ds.CantidadDias;

                    return new ViajeDestino
                    {
                        IdPaqueteViaje = pv.Id,
                        IdDestino = ds.DestinoId,
                        
                    };
                }).ToList();

                pv.Destino = destinos;
                pv.CantidadDias = nuevaCantidadDias;
                pv.Precio = nuevoPrecio;
                
                _context.SaveChanges();
            }
        }

        public void UpdateDisponibilidad(int paqueteId, int nuevaDisponibilidad)
        {
            var paquete = _context.PaqueteDeViajes.FirstOrDefault(p => p.Id == paqueteId);
            if (paquete != null)
            {
                paquete.Disponibilidad = nuevaDisponibilidad;
                _context.SaveChanges();
            }
        }
    }
}

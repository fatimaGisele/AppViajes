using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using BlogViajesModelo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class PaqueteDeViajeController : Controller
    {
        private readonly IContainerT _container;
        

        public PaqueteDeViajeController(IContainerT container)
        {
            _container = container;
            
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public IActionResult Create()
        {
            var model = new PaqueteDeViajeView
            {
                DestinosDisponibles = _container.destinoRepository.GetAll()
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.NombreDestino} - ${x.Precio}"
                }).ToList(),

                DestinosSeleccionados = new List<DestinoView>
                {
                    new(), new(), new()
                }
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PaqueteDeViajeView pdv)
        {
            
            if (ModelState.IsValid) {
                _container.paqueteDeViajeRepository.CrearNuevoPaquete(pdv);
                _container.Save();
                Console.WriteLine("en el if del controlador.... ");
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"[ModelState] {key}: {error.ErrorMessage}");
                    }
                }
            }

                return View(pdv);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PaqueteDeViajeView nuevaView)
        {
            if (ModelState.IsValid)
            {
                _container.paqueteDeViajeRepository.Update(nuevaView);
                _container.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(nuevaView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var pdv = _container.paqueteDeViajeRepository.GetAll(filter:
                p=>p.Id==id, includeProperties: "Destino.IdDestinoNavigation").FirstOrDefault();

            if (pdv == null)
            {
                return NotFound();
            }

            var nuevaView = new PaqueteDeViajeView
            {
                Id = pdv.Id,
                Nombre = pdv.Nombre,
                Tipo = pdv.Tipo,
                Detalle = pdv.Detalle,
                Disponibilidad = pdv.Disponibilidad,
                CantidadDias = pdv.CantidadDias,
                Precio = pdv.Precio,
                DestinosSeleccionados = pdv.Destino.Select(d => new DestinoView
                {
                    DestinoId = d.IdDestino,
                    CantidadDias = d.CantidadDias
                }).ToList(),
                DestinosDisponibles = _container.destinoRepository.GetAll().Select(d=>new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.NombreDestino
                }).ToList()
            };
            return View(nuevaView);
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodosLosPaquetes()
        {
            var paquetes = _container.paqueteDeViajeRepository.GetAll(includeProperties: "Destino.IdDestinoNavigation")
                            .Select(p=>new
                            {
                                id = p.Id,
                                nombre = p.Nombre,
                                tipo = p.Tipo,
                                detalle = p.Detalle,
                                disponibilidad = p.Disponibilidad,
                                cantidadDias = p.CantidadDias,
                                destinos = p.Destino
                                .Where(d => d.IdDestinoNavigation != null)
                                .Select(d => new {
                                    nombreDestino = d.IdDestinoNavigation.NombreDestino
                                }).ToList(),
                                precio = p.Precio
                            }).ToList();
            return Json(new { data = paquetes });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var element = _container.paqueteDeViajeRepository.GetById(id);
            if (element == null)
            {
                return Json(new { success = false, message = "Error, no se encontro el paquete a eliminar" });
            }
            _container.paqueteDeViajeRepository.Delete(element);
            _container.Save();
            return Json(new { success = true, message = "Paquete eliminado" });


        }
        #endregion
    }
}

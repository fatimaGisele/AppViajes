using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using BlogViajesModelo.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogViajes.Areas.RegularUser.Controllers
{
    [Area("RegularUser")]
    [Authorize]
    public class CarritoController : Controller
    {
        private readonly IContainerT _container;
        private readonly UserManager<Cliente> _userManager;

        public CarritoController(IContainerT container, UserManager<Cliente> userManager)
        {
            _container = container;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            var carrito = _container.carrito.GetFirstOrDefault(c => c.ClienteId == usuario.Id, 
                includeProperties: "Detalles.PaqueteDeViaje");

            if (carrito == null)
            {
                carrito = new Carrito { ClienteId = usuario.Id, Detalles = new List<CarritoDetalle>() };
                _container.carrito.Add(carrito);
                _container.Save();
            }
            var carritoVw = new CarritoView { carrito = carrito };
            return View(carritoVw);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Compra", new { area = "RegularUser" });
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int PaqueteId, int Cantidad)
        {
            Console.WriteLine("entrando al controlador");
            var clienteActual = await _userManager.GetUserAsync(User);
            Console.WriteLine("cliente: "+clienteActual?.Email);
            if (clienteActual == null) return Challenge();
            var carrito = _container.carrito.GetFirstOrDefault(c => c.ClienteId == clienteActual.Id, 
                includeProperties: "Detalles");

            if (carrito == null) {

                Console.WriteLine("creando nuevo carrito....");
                carrito = new Carrito
                {
                    ClienteId = clienteActual.Id,
                    Detalles = new List<CarritoDetalle>(),
                };
                
                _container.carrito.Add(carrito);
                _container.Save();

            };

            var paquete = _container.paqueteDeViajeRepository.GetById(PaqueteId);
            if (paquete == null) { 
                return NotFound();
            }

            //ve si el paquete ya esta en el carrito
            var detalleExiste = _container.carritoDetalle.GetFirstOrDefault(d => d.CarritoId == carrito.Id
                                && d.PaqueteDeViajeId == paquete.Id);
            if (detalleExiste != null) { 
                detalleExiste.Cantidad += Cantidad;
                _container.carritoDetalle.Update(detalleExiste);
            }
            else
            {
                Console.WriteLine("creando nuevo carrito....");
                var nuevoCarritoDetalle = new CarritoDetalle
                {
                    PaqueteDeViajeId = PaqueteId,
                    CarritoId = carrito.Id,
                    Cantidad = Cantidad

                };
                _container.carritoDetalle.Add(nuevoCarritoDetalle);
            }
            _container.Save();

            return RedirectToAction("Index", "Carrito", new { area = "RegularUser" });
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var detallito = _container.carritoDetalle.GetById(id);
            if (detallito != null) {
                _container.carritoDetalle.Delete(id);
                _container.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizarCompra()
        {
            var cliente = await _userManager.GetUserAsync(User);
            if (cliente == null) return Challenge();

            var carrito = _container.carrito.GetFirstOrDefault(
                c => c.ClienteId == cliente.Id,
                includeProperties: "Detalles.PaqueteDeViaje"
            );

            if (carrito == null || !carrito.Detalles.Any())
                return RedirectToAction(nameof(Index));

            double total = 0;

            foreach (var detalle in carrito.Detalles)
            {
                var paquete = detalle.PaqueteDeViaje;

              
                if (paquete.Disponibilidad < detalle.Cantidad)
                {
                    TempData["Error"] = $"No hay disponibilidad suficiente para {paquete.Nombre}.";
                    return RedirectToAction(nameof(Index));
                }

                
                paquete.Disponibilidad -= detalle.Cantidad;
               
                _container.paqueteDeViajeRepository.UpdateDisponibilidad(paquete.Id, paquete.Disponibilidad); 

                // saco el total...ponele
                total += detalle.Cantidad * paquete.Precio;
            }

            
            var compra = new Compra
            {
                ClienteId = cliente.Id,
                FechaCompra = DateTime.Now,
                Total = total,
                CompraDetalles = carrito.Detalles.Select(d => new CompraDetalle
                {
                    PaqueteDeViajeId = d.PaqueteDeViajeId,
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PaqueteDeViaje.Precio
                }).ToList()
            };

            _container.compraRepository.Add(compra);

            foreach (var detalle in carrito.Detalles)
            {
                _container.carritoDetalle.Delete(detalle);
            }

            _container.Save();

            return RedirectToAction("Index", "Compra", new { area = "RegularUser" });
        }

        #region
        [HttpGet]
        public IActionResult ObtenerCarrito()
        {
            var userId = _userManager.GetUserId(User);
            var carrito =_container.carrito
                .GetAll(c => c.ClienteId == userId, includeProperties: "Detalles.PaqueteDeViaje")
                .FirstOrDefault();

            if (carrito == null) return Json(new { data = new List<object>() });

            var detalles = carrito.Detalles.Select(d => new {
                id = d.Id,
                nombre = d.PaqueteDeViaje.Nombre,
                precio = d.PaqueteDeViaje.Precio,
                cantidad = d.Cantidad,
                total = d.PaqueteDeViaje.Precio * d.Cantidad
            });

            return Json(new { data = detalles });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ActualizarCantidad(int id, int cantidad)
        {
            var detalle = _container.carritoDetalle.GetById(id);
            if (detalle == null)
            {
                return NotFound();
            }
            detalle.Cantidad = cantidad;
            _container.carritoDetalle.Update(detalle);
            _container.Save();

            var carritoId = detalle.CarritoId;
            var detalles = _container.carritoDetalle.GetAll(c => c.CarritoId == carritoId, includeProperties: "PaqueteDeViaje");

            double nuevoTotal = detalles.Sum(d => d.Cantidad * d.PaqueteDeViaje.Precio);

            return Json(new { success = true, total = nuevoTotal.ToString("0.00") });

        }
        #endregion

    }
}

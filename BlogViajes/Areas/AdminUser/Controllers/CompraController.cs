using BlogViajesAccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class CompraController : Controller
    {
        private readonly IContainerT _container;

        public CompraController(IContainerT container)
        {
            _container = container;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerCompras()
        {
            var compra = _container.compraRepository.
                GetAll(includeProperties: "CompraDetalles.PaqueteDeViaje").Select(c=>new
                {
                    c.Id,
                    fechaCompra = c.FechaCompra.ToString("dd/MM/yyyy HH:mm"),
                    total = c.Total,
                    cantidadPaquetes = c.CompraDetalles.Sum(cd => cd.Cantidad),
                    detalles = c.CompraDetalles.Select(cd => new
                    {
                        paquete = cd.PaqueteDeViaje.Nombre,
                        cantidad = cd.Cantidad,
                        precio = cd.PrecioUnitario
                    })
                }).ToList();
            return Json(new { data = compra });

        }
        #endregion
    }
}

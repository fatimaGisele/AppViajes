using BlogViajesAccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IContainerT _container;

        public ClienteController(IContainerT container)
        {
            _container = container;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodosLosClientes()
        {
            var clientes = _container.clienteRepository.GetAll().Select(c => new
            {
                id=c.Id,
                nombre=c.Nombre,
                apellido=c.Apellido,
                usuario= c.UserName,
                telefono=c.PhoneNumber,
                email=c.Email
                
            }).ToList();
                return Json(new { data = clientes });
        }
        #endregion
    }
}

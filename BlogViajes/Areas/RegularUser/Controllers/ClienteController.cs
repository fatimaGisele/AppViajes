using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.RegularUser.Controllers
{
    [Area("RegularUser")]
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IContainerT _container;
        private readonly UserManager<Cliente> _userManager;

        public ClienteController(IContainerT container, UserManager<Cliente> userManager)
        {
            _container = container;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodosLosClientes()
        {
            return Json(new { data = _container.clienteRepository.GetAll() });
        }
        #endregion

    }
}

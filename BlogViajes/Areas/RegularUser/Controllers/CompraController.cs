using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.RegularUser.Controllers
{
    [Area("RegularUser")]
    [Authorize]
    public class CompraController : Controller
    {
        private readonly IContainerT _container;
        private readonly UserManager<Cliente> _userManager;

        public CompraController(IContainerT containerT, UserManager<Cliente> userManager)
        {
            _container = containerT;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cliente = await _userManager.GetUserAsync(User);
            if (cliente == null) return Challenge();

            var compra = _container.compraRepository.GetAll(filter: c => c.ClienteId == cliente.Id,
                            includeProperties: "CompraDetalles.PaqueteDeViaje"
                            ).ToList();

            return View(compra);
            
        }
    }
}

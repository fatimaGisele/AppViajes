using BlogViajes.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo.ViewModels;


namespace BlogViajes.Areas.RegularUser.Controllers
{
    [Area("RegularUser")]
    public class HomeController : Controller
    {
        private readonly IContainerT _container;

        public HomeController(IContainerT containerT)
        {
            _container = containerT; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeView hv = new HomeView()
            {
                sliders = _container.sliderRepository.GetAll(),
                paquetes = _container.paqueteDeViajeRepository.GetAll()
            };

            ViewBag.IsHome = true;
            return View(hv);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var paqueteDb = _container.paqueteDeViajeRepository.GetAll(filter: p => p.Id == id,
                            includeProperties: "Destino.IdDestinoNavigation"
                            ).FirstOrDefault();
            if(paqueteDb != null)
            {
                return View(paqueteDb);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

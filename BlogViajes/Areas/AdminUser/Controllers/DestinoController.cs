using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class DestinoController : Controller
    {
        private readonly IContainerT _container;

        public DestinoController(IContainerT container)
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Destino d)
        {
            if (ModelState.IsValid)
            {
                _container.destinoRepository.Add(d);
                _container.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        [HttpGet]
        public IActionResult Edit(int id) { 
            Destino d = new Destino();
            d = _container.destinoRepository.GetById(id);
            if (d == null) {
                return NotFound();
            }
            return View(d);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Destino d)
        {
            if (ModelState.IsValid)
            {
                _container.destinoRepository.Update(d);
                _container.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(d);
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodosLosDestinos()
        {
            return Json(new { data = _container.destinoRepository.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var element = _container.destinoRepository.GetById(id);
            if (element == null)
            {
                return Json(new { success = false, message = "Error, no se encontro el destino a eliminar" });
            }
            _container.destinoRepository.Delete(element);
            _container.Save();
            return Json(new { success = true, message = "Destino eliminado" });


        }

        #endregion
    }
}

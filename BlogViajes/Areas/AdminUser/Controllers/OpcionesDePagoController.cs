using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class OpcionesDePagoController : Controller
    {
        private readonly IContainerT _container;

        public OpcionesDePagoController(IContainerT container)
        {
            _container = container;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //previene ataques xss
        public IActionResult Create(OpcionesDePago op)
        {
            if (ModelState.IsValid)
            {
                _container.OpcionesDePagoRepository.Add(op);
                _container.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(op);
        }


        // GET: OpcionesDePagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OpcionesDePagoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OpcionesDePagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OpcionesDePagoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region
        [HttpGet]
        public IActionResult ObtenerOpcionesDePago()
        {
            return Json(new { data = _container.OpcionesDePagoRepository.GetAll() });
        }
        #endregion
    }

}

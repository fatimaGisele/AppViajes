using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System;

namespace BlogViajes.Areas.AdminUser.Controllers
{
    [Area("AdminUser")]
    [Authorize]
    public class SliderController : Controller
    {
        private readonly IContainerT _container;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SliderController(IContainerT container, IWebHostEnvironment webHostEnvironment)
        {
            _container = container;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            Console.WriteLine("🚨 ENTRÓ AL MÉTODO CREATE");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine("❌ Error en ModelState: " + error.ErrorMessage);
            }

            if (ModelState.IsValid)
            {
                string ruta = _webHostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files["archivo"];
                Console.WriteLine(archivo);
                if (archivo != null)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var carpeta = Path.Combine(ruta, "imagenes", "sliders");

                    if (!Directory.Exists(carpeta))
                    {
                        Directory.CreateDirectory(carpeta);
                    }

                    var ext = Path.GetExtension(archivo.FileName);
                    string rutaArchivo = Path.Combine(carpeta, nombreArchivo + ext);


                    using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        archivo.CopyTo(fileStream);
                    }

                    slider.Url = Path.Combine("imagenes", "sliders", nombreArchivo + ext).Replace("\\", "/");
                    Console.WriteLine(slider.Url);
                    _container.sliderRepository.Add(slider);
                    _container.Save();

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ModelState.AddModelError("archivo", "Debes seleccionar una imagen");
                    slider.Url = "";
                }
            }
            return View(slider);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id != null)
            {
                var editSlider = _container.sliderRepository.GetById(id);
                return View(editSlider);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string ruta = _webHostEnvironment.WebRootPath;
                var archivo = HttpContext.Request.Form.Files["archivo"];
                var sliderDb = _container.sliderRepository.GetById(slider.Id);

                if (archivo != null)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var carpeta = Path.Combine(ruta, @"imagenes\sliders");

                    if (!Directory.Exists(carpeta))
                    {
                        Directory.CreateDirectory(carpeta);
                    }

                    var ext = Path.GetExtension(archivo.FileName);
                    var rutaImg = Path.Combine(ruta, sliderDb.Url.TrimStart('\\') );

                    if (System.IO.File.Exists(rutaImg))
                    {
                        System.IO.File.Delete(rutaImg);
                    }

                    string rutaArchivo = Path.Combine(carpeta, nombreArchivo + ext);


                    using (var fileStream = new FileStream(rutaArchivo, FileMode.Create))
                    {
                        archivo.CopyTo(fileStream);
                    }
                    slider.Url = Path.Combine(@"imagenes\sliders", nombreArchivo + ext).Replace("\\", "/");

                    _container.sliderRepository.Update(slider);
                    _container.Save();

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    slider.Url = sliderDb.Url;
                }
                _container.sliderRepository.Update(slider);
                _container.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }

        #region
        [HttpGet]
        public IActionResult ObtenerTodosLosSliders()
        {
            return Json(new { data = _container.sliderRepository.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var element = _container.sliderRepository.GetById(id);
            string ruta = _webHostEnvironment.WebRootPath;
            var rutaImg = Path.Combine(ruta, element.Url.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImg))
            {
                System.IO.File.Delete(rutaImg);
                
            }
            if (element == null)
            {
                return Json(new { success = false, message = "Error, no se encontro el slider a eliminar" });
            }
            _container.sliderRepository.Delete(element);
            _container.Save();
            return Json(new { success = true, message = "slider eliminado" });


        }

        #endregion
    }
}

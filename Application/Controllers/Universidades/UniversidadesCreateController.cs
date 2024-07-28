using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Universidades
{
    public class UniversidadesCreateController : Controller
    {
        private readonly IUniversidadRepository _universidadRepository;

        public UniversidadesCreateController(IUniversidadRepository universidadService)
        {
            _universidadRepository = universidadService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Universidad universidad)
        {
            if (ModelState.IsValid)
            {
                _universidadRepository.AddUniversidad(universidad);
                return RedirectToAction("Index", "Universidades");
            }
            return View(universidad);
        }
    }

}
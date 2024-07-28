using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Universidades
{
    public class UniversidadesUpdateController : Controller
    {
        private readonly IUniversidadRepository _universidadRepository;

        public UniversidadesUpdateController(IUniversidadRepository universidadService)
        {
            _universidadRepository = universidadService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Universidad universidad)
        {
            if (id != universidad.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _universidadRepository.UpdateUniversidad(universidad);
                return RedirectToAction("Index", "Universidades");
            }
            return View(universidad);
        }
    }

}
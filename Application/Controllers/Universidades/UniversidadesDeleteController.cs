using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Universidades
{
   public class UniversidadesDeleteController : Controller
    {
        private readonly IUniversidadRepository _universidadRepository;

        public UniversidadesDeleteController(IUniversidadRepository universidadService)
        {
            _universidadRepository = universidadService;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _universidadRepository.DeleteUniversidad(id);
            return RedirectToAction("Index", "Universidades");
        }
    }

}
using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Services;
using HTML_Componentes.Application.Interfaces;

namespace HTML_Componentes.Application.Controllers.Estudiantes
{
   public class EstudiantesCreateController : Controller
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudiantesCreateController(IEstudianteRepository estudianteService)
        {
            _estudianteRepository = estudianteService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _estudianteRepository.AddEstudiante(estudiante);
                return RedirectToAction("Index", "Estudiantes");
            }
            return View(estudiante);
        }
    }

}
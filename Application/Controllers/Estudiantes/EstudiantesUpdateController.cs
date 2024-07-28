using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Estudiantes
{
    public class EstudiantesUpdateController : Controller
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudiantesUpdateController(IEstudianteRepository estudianteService)
        {
            _estudianteRepository = estudianteService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _estudianteRepository.UpdateEstudiante(estudiante);
                return RedirectToAction("Index", "Estudiantes");
            }
            return View(estudiante);
        }
    }
}
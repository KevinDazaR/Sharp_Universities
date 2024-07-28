using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;
public class EstudiantesDeleteController : Controller
{
    private readonly IEstudianteRepository _estudianteRepository;

    public EstudiantesDeleteController(IEstudianteRepository estudianteService)
    {
        _estudianteRepository = estudianteService;
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _estudianteRepository.DeleteEstudiante(id);
        return RedirectToAction("Index", "Estudiantes");
    }
}

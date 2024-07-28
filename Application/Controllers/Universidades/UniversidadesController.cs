using Microsoft.AspNetCore.Mvc;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Universidades
{
    public class UniversidadesController : Controller
    {
        private readonly IUniversidadRepository _universidadRepository;

        public UniversidadesController(IUniversidadRepository universidadService)
        {
            _universidadRepository = universidadService;
        }

        public IActionResult Index()
        {
            var universidades = _universidadRepository.GetAllUniversidadesAsync();
            return View(universidades);
        }

        public IActionResult Details(int id)
        {
            var universidad = _universidadRepository.GetUniversidadById(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var universidad = _universidadRepository.GetUniversidadById(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }

        public IActionResult Delete(int id)
        {
            var universidad = _universidadRepository.GetUniversidadById(id);
            if (universidad == null)
            {
                return NotFound();
            }
            return View(universidad);
        }
    }

}
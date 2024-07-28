using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HTML_Componentes.Application.Controllers
{
    public class InscripcionesController : Controller
    {
        private readonly IInscripcionRepository _inscripcionRepository;

        public InscripcionesController(IInscripcionRepository inscripcionRepository)
        {
            _inscripcionRepository = inscripcionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inscripciones = await _inscripcionRepository.GetAllInscripcionesAsync();
            return View(inscripciones);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var inscripcion = await _inscripcionRepository.GetInscripcionByIdAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            return View(inscripcion);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                await _inscripcionRepository.AddInscripcionAsync(inscripcion);
                await _inscripcionRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscripcion);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var inscripcion = await _inscripcionRepository.GetInscripcionByIdAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            return View(inscripcion);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Inscripcion inscripcion)
        {
            if (id != inscripcion.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _inscripcionRepository.UpdateInscripcionAsync(inscripcion);
                await _inscripcionRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscripcion);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var inscripcion = await _inscripcionRepository.GetInscripcionByIdAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            return View(inscripcion);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _inscripcionRepository.DeleteInscripcionAsync(id);
            await _inscripcionRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTML_Componentes.Application.Controllers
{
    public class SemestreController : Controller
    {
        private readonly ISemestreRepository _semestreRepository;

        public SemestreController(ISemestreRepository semestreRepository)
        {
            _semestreRepository = semestreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var semestres = await _semestreRepository.GetAllSemestresAsync();
            return View(semestres);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                await _semestreRepository.AddSemestreAsync(semestre);
                await _semestreRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semestre);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var semestre = await _semestreRepository.GetSemestreByIdAsync(id);
            if (semestre == null)
            {
                return NotFound();
            }
            return View(semestre);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Semestre semestre)
        {
            if (ModelState.IsValid)
            {
                await _semestreRepository.UpdateSemestreAsync(semestre);
                await _semestreRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(semestre);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var semestre = await _semestreRepository.GetSemestreByIdAsync(id);
            if (semestre == null)
            {
                return NotFound();
            }
            return View(semestre);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _semestreRepository.DeleteSemestreAsync(id);
            await _semestreRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

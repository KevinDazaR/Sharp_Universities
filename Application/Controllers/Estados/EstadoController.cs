using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HTML_Componentes.Application.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estados = await _estadoRepository.GetAllEstadosAsync();
            return View(estados);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Estado estado)
        {
            if (ModelState.IsValid)
            {
                await _estadoRepository.AddEstadoAsync(estado);
                await _estadoRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var estado = await _estadoRepository.GetEstadoByIdAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Estado estado)
        {
            if (ModelState.IsValid)
            {
                await _estadoRepository.UpdateEstadoAsync(estado);
                await _estadoRepository.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var estado = await _estadoRepository.GetEstadoByIdAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _estadoRepository.DeleteEstadoAsync(id);
            await _estadoRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

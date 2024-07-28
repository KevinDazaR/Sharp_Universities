using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HTML_Componentes.Application.Interfaces;
using System;

namespace HTML_Componentes.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelRepository _excelRepository;

        public ExcelController(IExcelRepository excelRepository)
        {
            _excelRepository = excelRepository;
        }

        // Acción para mostrar la vista de subida de archivos
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        // Acción para manejar la subida de archivos
        [HttpPost]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            try
            {
                await _excelRepository.ProcessExcelFile(file);
                return Ok("File processed successfully.");
            }
            catch (Exception ex)
            {


                // Return an error response
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;
using HTML_Componentes.Models;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Application.Services;

namespace HTML_Componentes.Application.Controllers.Estudiantes
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudianteRepository _estudianteRepository;

        public EstudiantesController(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Por favor seleccione un archivo Excel.");
                return View();
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Asumiendo que los datos están en la primera hoja
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++) // Empezar desde la fila 2 para saltar el encabezado
                    {
                        var estudiante = new Estudiante
                        {   
                            Nombres = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Apellidos = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            Correo = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Telefono = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Universidad_Id = int.Parse(worksheet.Cells[row, 5].Value.ToString().Trim())
                        };
                        _estudianteRepository.AddEstudiante(estudiante);
                    }
                }
            }

            return RedirectToAction("Index"); // O la vista que desees mostrar después de la carga
        }
    }
}
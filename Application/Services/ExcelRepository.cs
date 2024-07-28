using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using HTML_Componentes.Application.Interfaces;
using HTML_Componentes.Utils.Functions;
using HTML_Componentes.Models;
using System;
using System.Linq;

namespace HTML_Componentes.Application.Services
{
    public class ExcelRepository : IExcelRepository
    {
        private readonly IEstudianteRepository _estudianteRepository;
        private readonly IUniversidadRepository _universidadRepository;
        private readonly ICarreraRepository _carreraRepository;
        private readonly IProfesorRepository _profesorRepository;
        private readonly IMateriaRepository _materiaRepository;
        private readonly ISemestreRepository _semestreRepository;
        private readonly IInscripcionRepository _inscripcionRepository;

        public ExcelRepository(
            IEstudianteRepository estudianteRepository,
            IUniversidadRepository universidadRepository,
            ICarreraRepository carreraRepository,
            IProfesorRepository profesorRepository,
            IMateriaRepository materiaRepository,
            ISemestreRepository semestreRepository,
            IInscripcionRepository inscripcionRepository)
        {
            _estudianteRepository = estudianteRepository;
            _universidadRepository = universidadRepository;
            _carreraRepository = carreraRepository;
            _profesorRepository = profesorRepository;
            _materiaRepository = materiaRepository;
            _semestreRepository = semestreRepository;
            _inscripcionRepository = inscripcionRepository;
        }

        public async Task ProcessExcelFile(IFormFile file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    await ImportDataFromExcelAsync(stream);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                // _logger.LogError(ex, "An error occurred while processing the Excel file in the repository.");

                // Rethrow the exception to be handled by the controller
                throw new Exception("An error occurred while processing the Excel file in the repository.", ex);
            }
        }

        private async Task ImportDataFromExcelAsync(Stream fileStream)
        {
            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                {
                    var universidadNombre = worksheet.Cells[row, 15].Text; // Universidad
                    var universidades = await _universidadRepository.GetAllUniversidadesAsync();
                    var universidad = universidades.FirstOrDefault(u => u.Nombre == universidadNombre);
                    if (universidad == null)
                    {
                        universidad = new Universidad 
                        { 
                            Nombre = universidadNombre,
                            Decano = worksheet.Cells[row, 14].Text // decano_universidad
                        };
                        await _universidadRepository.AddUniversidad(universidad);
                    }
                    else
                    {
                        universidad.Decano = worksheet.Cells[row, 14].Text; // Actualizar decano
                        await _universidadRepository.UpdateUniversidad(universidad);
                    }

                    var carreraNombre = worksheet.Cells[row, 16].Text; // Carrera
                    var carreras = await _carreraRepository.GetAllCarrerasAsync();
                    var carrera = carreras.FirstOrDefault(c => c.Nombre == carreraNombre);
                    if (carrera == null)
                    {
                        carrera = new Carrera
                        {
                            Nombre = carreraNombre
                        };
                        await _carreraRepository.AddCarreraAsync(carrera);
                    }

                    var estudianteNombre = worksheet.Cells[row, 1].Text; // Estudiante
                    var estudiantes = await _estudianteRepository.GetAllEstudiantesAsync();
                    var estudiante = estudiantes.FirstOrDefault(e => e.Nombres == estudianteNombre);
                    if (estudiante == null)
                    {
                        estudiante = new Estudiante
                        {
                            Nombres = estudianteNombre,
                            Apellidos = worksheet.Cells[row, 2].Text,
                            // Otras propiedades del estudiante
                        };
                        await _estudianteRepository.AddEstudiante(estudiante);
                    }
                    else
                    {
                        estudiante.Apellidos = worksheet.Cells[row, 2].Text; // Actualizar apellido
                        // Actualizar otras propiedades si es necesario
                        await _estudianteRepository.UpdateEstudiante(estudiante);
                    }

                    var profesor = new Profesor
                    {
                        Nombres = worksheet.Cells[row, 10].Text, // nombre_profesor
                        Apellidos = worksheet.Cells[row, 11].Text, // apellido_profesor
                        Correo = worksheet.Cells[row, 12].Text, // correo_profesor
                        Telefono = PhoneNumberUtils.CleanPhoneNumber(worksheet.Cells[row, 13].Text), // telefono_profesor
                        Universidad_Id = universidad?.Id ?? 0 // Usa 0 como valor predeterminado si universidad.Id es null
                    };

                    await _profesorRepository.AddProfesorAsync(profesor);

                    var materiaNombre = worksheet.Cells[row, 7].Text; // nombre_materia
                    var materias = await _materiaRepository.GetAllMateriasAsync();
                    var materia = materias.FirstOrDefault(m => m.Nombre == materiaNombre);
                    if (materia == null)
                    {
                        materia = new Materia { Nombre = materiaNombre };
                        await _materiaRepository.AddMateriaAsync(materia);
                    }

                    var semestreNumero = worksheet.Cells[row, 8].Text; // semestre
                    if (!int.TryParse(semestreNumero, out int semestreNum))
                    {
                        // Manejo del error en caso de que la conversión falle
                        throw new FormatException($"Invalid semester number: {semestreNumero}");
                    }

                    var añoTexto = worksheet.Cells[row, 9].Text; // año
                    if (!int.TryParse(añoTexto, out int año))
                    {
                        // Manejo del error en caso de que la conversión falle
                        throw new FormatException($"Invalid year: {añoTexto}");
                    }

                    var semestres = await _semestreRepository.GetAllSemestresAsync();
                    var semestre = semestres.FirstOrDefault(s => s.Numero == semestreNum && s.Año == año);
                    if (semestre == null)
                    {
                        semestre = new Semestre
                        {
                            Numero = semestreNum,
                            Año = año
                        };
                        await _semestreRepository.AddSemestreAsync(semestre);
                    }

                    var estadoInscripcionTexto = worksheet.Cells[row, 16].Text; // Estado de inscripcion
                    if (!int.TryParse(estadoInscripcionTexto, out int estadoInscripcionId))
                    {
                        // Manejo del error en caso de que la conversión falle
                        throw new FormatException($"Invalid status ID: {estadoInscripcionTexto}");
                    }

                    var inscripcion = new Inscripcion
                    {
                        Estudiante_Id = estudiante.Id,
                        Carrera_Id = carrera?.Id ?? 0, // Usa 0 como valor predeterminado si carrera.Id es null
                        Profesor_Id = profesor.Id,
                        Materia_Id = materia?.Id ?? 0, // Usa 0 como valor predeterminado si materia.Id es null
                        Semestre_Id = semestre.Id,
                        Fecha_Inscripcion = DateTime.Now, // Puedes ajustar esto si tienes una columna de fecha en el Excel
                        Estado_Inscripcion_Id = estadoInscripcionId
                    };

                    await _inscripcionRepository.AddInscripcionAsync(inscripcion);
                }

                await _estudianteRepository.SaveChangesAsync();
                await _universidadRepository.SaveChangesAsync();
                await _profesorRepository.SaveChangesAsync();
                await _materiaRepository.SaveChangesAsync();
                await _carreraRepository.SaveChangesAsync();
                await _inscripcionRepository.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using OfficeOpenXml;


namespace HTML_Componentes.Application.Interfaces
{
    public interface IExcelRepository
    {
        Task ProcessExcelFile(IFormFile file);
    }
}

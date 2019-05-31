using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PeopleSearch.Business.Interfaces
{
    public interface IFileService
    {
        Task CopyToFilePathAsync(IFormFile formFile, string path);
    }
}
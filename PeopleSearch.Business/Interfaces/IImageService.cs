using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PeopleSearch.Business.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile formFile);
    }
}
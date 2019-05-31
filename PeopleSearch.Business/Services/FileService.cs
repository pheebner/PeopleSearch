using Microsoft.AspNetCore.Http;
using PeopleSearch.Business.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace PeopleSearch.Business.Services
{
    public class FileService : IFileService
    {
        public async Task CopyToFilePathAsync(IFormFile formFile, string path)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
        }
    }
}

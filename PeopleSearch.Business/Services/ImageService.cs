using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Business.Interfaces;

namespace PeopleSearch.Business.Services
{
    public class ImageService : IImageService
    {
        private const string USER_IMAGE_FOLDER = "user-images";

        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UploadAsync(IFormFile formFile)
        {
            var relativeFilePath = GetUniqueRelativeFilePath(formFile);
            var absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);

            using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return relativeFilePath;
        }

        private static string GetUniqueRelativeFilePath(IFormFile formFile)
        {
            var fileExtension = formFile.FileName.Split('.').Last();
            var newFileName = $"{Guid.NewGuid().ToString()}.{fileExtension}";
            return Path.Combine(USER_IMAGE_FOLDER, newFileName);
        }
    }
}

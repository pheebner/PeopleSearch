using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PeopleSearch.Business.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Business.Services
{
    public class ImageService : IImageService
    {
        private const string USER_IMAGE_FOLDER = "user-images";

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileService _fileService;

        public ImageService(IHostingEnvironment hostingEnvironment, IFileService fileService)
        {
            _hostingEnvironment = hostingEnvironment;
            _fileService = fileService;
        }

        public async Task<string> UploadAsync(IFormFile formFile)
        {
            var relativeFilePath = GetUniqueRelativeFilePath(formFile);
            var absoluteFilePath = Path.Combine(_hostingEnvironment.WebRootPath, relativeFilePath);

            await _fileService.CopyToFilePathAsync(formFile, absoluteFilePath);

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

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length == 0)
            {
                return BadRequest("File length is zero");
            }

            var fileExtension = file.FileName.Split('.').Last();
            var newFileName = $"{Guid.NewGuid().ToString()}.{fileExtension}";
            var simpleFilePath = Path.Combine("user-images", newFileName);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, simpleFilePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { pictureUrl = simpleFilePath });
        }
    }
}

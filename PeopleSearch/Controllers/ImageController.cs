using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Business.Interfaces;
using System.Threading.Tasks;

namespace PeopleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file.Length == 0)
            {
                const string FILE_LENGTH_ZERO = "File length is zero";
                return base.BadRequest(FILE_LENGTH_ZERO);
            }

            var relativeFilePath = await _imageService.UploadAsync(file);

            return Ok(new { pictureUrl = relativeFilePath });
        }
    }
}

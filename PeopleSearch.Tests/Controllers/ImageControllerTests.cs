using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Controllers;
using BadRequestObjectResult = Microsoft.AspNetCore.Mvc.BadRequestObjectResult;

namespace PeopleSearch.Tests.Controllers
{
    [TestFixture]
    public class ImageControllerTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task Upload_WhenFileLengthIsZero_ThenReturnsBadRequest()
        {
            var imageServiceMock = new Mock<IImageService>();
            var formFile = new Mock<IFormFile>();
            formFile.Setup(ff => ff.Length).Returns(0);
            var sut = new ImageController(imageServiceMock.Object);

            var actionResult = await sut.Upload(formFile.Object);

            imageServiceMock.Verify(s => s.UploadAsync(It.IsAny<IFormFile>()), Times.Never);
            actionResult.Should().BeOfType<BadRequestObjectResult>();
            var value = ((BadRequestObjectResult)actionResult).Value;
            value.Should().BeOfType<string>();
            const string FILE_ZERO_ERROR_MESSAGE = "File length is zero";
            ((string)value).Should().Be(FILE_ZERO_ERROR_MESSAGE);
        }

        [Test]
        public async Task Upload_WhenFileLengthIsNotZero_ThenUploadsFileAndReturnsOkWithRelativePathAsPictureUrl()
        {
            var relativePath = _fixture.Create<string>();
            var imageServiceMock = new Mock<IImageService>();
            var formFile = new Mock<IFormFile>();
            imageServiceMock.Setup(s => s.UploadAsync(formFile.Object)).ReturnsAsync(relativePath).Verifiable();
            formFile.Setup(ff => ff.Length).Returns(1);
            var sut = new ImageController(imageServiceMock.Object);

            var actionResult = await sut.Upload(formFile.Object);

            imageServiceMock.Verify();
            actionResult.Should().BeOfType<OkObjectResult>();
            var value = ((OkObjectResult)actionResult).Value;
            const string PICTURE_URL_PROPERTY_NAME = "pictureUrl";
            var pictureUrl = value.GetType().GetProperty(PICTURE_URL_PROPERTY_NAME).GetValue(value);
            pictureUrl.Should().BeOfType<string>();
            ((string)pictureUrl).Should().Be(relativePath);
        }
    }
}

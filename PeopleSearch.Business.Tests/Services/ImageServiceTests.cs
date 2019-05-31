using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Services;
using System.Threading.Tasks;

namespace PeopleSearch.Business.Tests.Services
{
    [TestFixture]
    public class ImageServiceTests
    {
        private const string USER_IMAGES_FOLDER = "user-images";
        private const string FILE_EXTENSION = "png";
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task UploadAsync_CopiesFileToWebRootUserImagesDirectoryAndReturnsRelativeFilePath()
        {
            var webRootPath = _fixture.Create<string>();
            var hostingEnvironmentMock = new Mock<IHostingEnvironment>();
            hostingEnvironmentMock.Setup(he => he.WebRootPath).Returns(webRootPath).Verifiable();
            var formFile = new Mock<IFormFile>();
            var fileName = $"{_fixture.Create<string>()}.{FILE_EXTENSION}";
            formFile.Setup(f => f.FileName).Returns(fileName).Verifiable();
            var fileServiceMock = new Mock<IFileService>();
            fileServiceMock.Setup(fs => fs.CopyToFilePathAsync(formFile.Object,
                                                               It.Is<string>(s => s.StartsWith($"{webRootPath}\\{USER_IMAGES_FOLDER}\\") &&
                                                                                  s.EndsWith($".{FILE_EXTENSION}"))))
                           .Returns(Task.CompletedTask).Verifiable();
            var sut = new ImageService(hostingEnvironmentMock.Object, fileServiceMock.Object);

            var relativeFilePath = await sut.UploadAsync(formFile.Object);

            hostingEnvironmentMock.Verify();
            formFile.Verify();
            fileServiceMock.Verify();
            relativeFilePath.Should().StartWith($"{USER_IMAGES_FOLDER}\\");
            relativeFilePath.Should().EndWith($".{FILE_EXTENSION}");
        }
    }
}

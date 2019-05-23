using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Controllers;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleSearch.Tests.Controllers
{
    [TestFixture]
    public class PersonControllerTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task SearchByName_CallsServiceAndReturnsMappedServiceResult()
        {
            var searchText = _fixture.Create<string>();
            var expectedPeople = _fixture.CreateMany<Domain.Dto.Person>().ToList();
            var personServiceMock = new Mock<IPersonService>();
            personServiceMock.Setup(s => s.SearchByNameAsync(searchText)).ReturnsAsync(expectedPeople).Verifiable();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Models.Person>(It.IsAny<Domain.Dto.Person>()))
                .Returns<Domain.Dto.Person>(p => _fixture.Build<Models.Person>().With(mp => mp.FirstName, p.FirstName).Create())
                .Verifiable();
            var sut = new PersonController(personServiceMock.Object, mapperMock.Object);

            var actualPeople = await sut.SearchByName(searchText);

            personServiceMock.Verify();
            mapperMock.Verify();
            var actualFirstNames = actualPeople.Select(p => p.FirstName).ToList();
            var expectedFirstNames = expectedPeople.Select(p => p.FirstName).ToList();
            actualFirstNames.Should().BeEquivalentTo(expectedFirstNames);
        }
    }
}

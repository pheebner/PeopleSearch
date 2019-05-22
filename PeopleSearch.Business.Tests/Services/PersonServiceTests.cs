using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Services;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using BusinessModels = PeopleSearch.Business.Models;
using Entities = PeopleSearch.Persistence.Entities;

namespace PeopleSearch.Business.Tests.Services
{
    [TestFixture]
    public class PersonServiceTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task SearchByNameAsync_CallsRepositoryAndMapsEachEntityToBusinessModel()
        {
            var searchText = _fixture.Create<string>();
            var people = _fixture.CreateMany<Entities.Person>().ToList();
            var personRepositoryMock = new Mock<IPersonRepository>();
            personRepositoryMock.Setup(r => r.SearchByNameAsync(searchText)).ReturnsAsync(people).Verifiable();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<BusinessModels.Person>(It.IsAny<Entities.Person>()))
                .Returns<Entities.Person>(p => new BusinessModels.Person { FirstName = p.FirstName })
                .Verifiable();
            var sut = new PersonService(personRepositoryMock.Object, mapperMock.Object);

            var mappedPeople = await sut.SearchByNameAsync(searchText);

            personRepositoryMock.Verify();
            mapperMock.Verify();
            var expectedFirstNames = people.Select(p => p.FirstName).ToList();
            var actualFirstNames = mappedPeople.Select(p => p.FirstName).ToList();
            expectedFirstNames.Should().BeEquivalentTo(actualFirstNames);
        }
    }
}

using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Services;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using PeopleSearch.Domain.Dto;

namespace PeopleSearch.Business.Tests.Services
{
    [TestFixture]
    public class PersonServiceTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task SearchByNameAsync_CallsRepositoryAndReturnsRepositoryResults()
        {
            var searchText = _fixture.Create<string>();
            var expectedPeople = _fixture.CreateMany<Person>().ToList();
            var personRepositoryMock = new Mock<IPersonRepository>();
            personRepositoryMock.Setup(r => r.SearchByNameAsync(searchText)).ReturnsAsync(expectedPeople).Verifiable();
            var sut = new PersonService(personRepositoryMock.Object);

            var actualPeople = await sut.SearchByNameAsync(searchText);

            personRepositoryMock.Verify();
            actualPeople.Should().BeEquivalentTo(expectedPeople);
        }
    }
}

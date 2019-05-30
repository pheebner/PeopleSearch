using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Services;
using PeopleSearch.Domain.Dto;
using PeopleSearch.Persistence.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

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

        [Test]
        public async Task CreatePersonAsync_CallsRepositoryWithPassedInPersonObject()
        {
            var person = _fixture.Create<Person>();
            var personRepositoryMock = new Mock<IPersonRepository>();
            personRepositoryMock.Setup(r => r.CreatePersonAsync(person)).Returns(Task.CompletedTask).Verifiable();
            var sut = new PersonService(personRepositoryMock.Object);

            await sut.CreatePersonAsync(person);

            personRepositoryMock.Verify();
        }
    }
}

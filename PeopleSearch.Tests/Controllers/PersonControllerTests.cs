using AutoFixture;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PeopleSearch.Business.Interfaces;
using PeopleSearch.Business.Models;
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
        public async Task SearchByName_CallsServiceAndReturnsServiceResult()
        {
            var searchText = _fixture.Create<string>();
            var expectedPeople = _fixture.CreateMany<Person>().ToList();
            var personServiceMock = new Mock<IPersonService>();
            personServiceMock.Setup(s => s.SearchByNameAsync(searchText)).ReturnsAsync(expectedPeople).Verifiable();
            var sut = new PersonController(personServiceMock.Object);

            var actualPeople = await sut.SearchByName(searchText);

            personServiceMock.Verify();
            actualPeople.Should().BeEquivalentTo(expectedPeople);
        }
    }
}

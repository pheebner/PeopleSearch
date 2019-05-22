using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PeopleSearch.Persistence;
using PeopleSearch.Persistence.Entities;
using PeopleSearch.Persistence.Repositories;
using PeopleSearch.Persistence.Tests.DbSetMocking;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task SearchByNameAsync_WhenSearchTextIsFromFirstName_ThenFiltersByFirstName()
        {
            var personList = _fixture.CreateMany<Person>().ToList();
            var peopleMock = new Mock<DbSet<Person>>();
            DbSetMockHelper.SetupMockDbSet(personList.AsQueryable(), peopleMock);

            var peopleSearchContextMock = new Mock<IPeopleSearchContext>();
            peopleSearchContextMock.Setup(c => c.People).Returns(peopleMock.Object);

            var sut = new PersonRepository(peopleSearchContextMock.Object);
            var expectedPerson = personList.First();

            var result = await sut.SearchByNameAsync(expectedPerson.FirstName.Substring(0, 5));

            result.First().Should().BeEquivalentTo(expectedPerson);
            result.Count().Should().Be(1);
        }

        [Test]
        public async Task SearchByNameAsync_WhenSearchTextIsFromLastName_ThenFiltersByLastName()
        {
            var personList = _fixture.CreateMany<Person>().ToList();
            var peopleMock = new Mock<DbSet<Person>>();
            DbSetMockHelper.SetupMockDbSet(personList.AsQueryable(), peopleMock);

            var peopleSearchContextMock = new Mock<IPeopleSearchContext>();
            peopleSearchContextMock.Setup(c => c.People).Returns(peopleMock.Object);

            var sut = new PersonRepository(peopleSearchContextMock.Object);
            var expectedPerson = personList.First();

            var result = await sut.SearchByNameAsync(expectedPerson.LastName.Substring(0, 5));

            result.First().Should().BeEquivalentTo(expectedPerson);
            result.Count().Should().Be(1);
        }
    }
}
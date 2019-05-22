using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PeopleSearch.Persistence.Repositories;
using PeopleSearch.Persistence.Tests.DbSetMocking;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace PeopleSearch.Persistence.Tests.Repositories
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private readonly IFixture _fixture = new Fixture();

        [Test]
        public async Task SearchByNameAsync_WhenSearchTextIsFromFirstName_ThenFiltersByFirstNameAndMapsToDto()
        {
            var personList = _fixture.CreateMany<Entities.Person>().ToList();
            var peopleMock = new Mock<DbSet<Entities.Person>>();
            DbSetMockHelper.SetupMockDbSet(personList.AsQueryable(), peopleMock);

            var peopleSearchContextMock = new Mock<IPeopleSearchContext>();
            peopleSearchContextMock.Setup(c => c.People).Returns(peopleMock.Object).Verifiable();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Domain.Dto.Person>(It.IsAny<Entities.Person>())).Returns<Entities.Person>(p => new Domain.Dto.Person
                                                                                                                       {
                                                                                                                           FirstName = p.FirstName
                                                                                                                       }).Verifiable();

            var sut = new PersonRepository(peopleSearchContextMock.Object, mapperMock.Object);
            var expectedPerson = personList.First();

            var result = (await sut.SearchByNameAsync(expectedPerson.FirstName.Substring(0, 5))).ToList();

            peopleSearchContextMock.Verify();
            mapperMock.Verify();
            result.First().FirstName.Should().BeEquivalentTo(expectedPerson.FirstName);
            result.Count.Should().Be(1);
        }

        [Test]
        public async Task SearchByNameAsync_WhenSearchTextIsFromLastName_ThenFiltersByLastNameAndMapsToDto()
        {
            var personList = _fixture.CreateMany<Entities.Person>().ToList();
            var peopleMock = new Mock<DbSet<Entities.Person>>();
            DbSetMockHelper.SetupMockDbSet(personList.AsQueryable(), peopleMock);

            var peopleSearchContextMock = new Mock<IPeopleSearchContext>();
            peopleSearchContextMock.Setup(c => c.People).Returns(peopleMock.Object).Verifiable();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Domain.Dto.Person>(It.IsAny<Entities.Person>())).Returns<Entities.Person>(p => new Domain.Dto.Person
                                                                                                                       {
                                                                                                                           FirstName = p.FirstName
                                                                                                                       }).Verifiable();

            var sut = new PersonRepository(peopleSearchContextMock.Object, mapperMock.Object);
            var expectedPerson = personList.First();

            var result = (await sut.SearchByNameAsync(expectedPerson.LastName.Substring(0, 5))).ToList();

            peopleSearchContextMock.Verify();
            mapperMock.Verify();
            result.First().FirstName.Should().BeEquivalentTo(expectedPerson.FirstName);
            result.Count.Should().Be(1);
        }
    }
}
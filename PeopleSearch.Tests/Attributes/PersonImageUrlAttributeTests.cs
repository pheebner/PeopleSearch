using FluentAssertions;
using NUnit.Framework;
using PeopleSearch.Attributes;

namespace PeopleSearch.Tests.Attributes
{
    [TestFixture]
    public class PersonImageUrlAttributeTests
    {
        [Test]
        public void IsValid_WhenStartsWithUserImagesFolder_ThenReturnsTrue()
        {
            var sut = new PersonImageUrlAttribute();

            var result = sut.IsValid("user-images\\some-pic.jpg");

            result.Should().BeTrue();
        }

        [Test]
        public void IsValid_WhenDoesNotStartWithUserImagesFolder_ThenReturnsFalse()
        {
            var sut = new PersonImageUrlAttribute();

            var result = sut.IsValid("puppy-images\\husky.jpg");

            result.Should().BeFalse();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Moq;
using PeopleSearch.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Persistence.Tests.DbSetMocking
{
    // We made this idea into a nuget package at my current workplace since it's pretty useful
    // Used this stack overflow answer as reference: https://stackoverflow.com/a/40491640
    // Modified for generics
    internal static class DbSetMockHelper
    {
        internal static void SetupMockDbSet<T>(IQueryable<T> backingQueryable, Mock<DbSet<T>> mockDbSet) where T : class
        {
            mockDbSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<T>(backingQueryable.GetEnumerator()));

            mockDbSet.As<IQueryable<Person>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(backingQueryable.Provider));

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(backingQueryable.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(backingQueryable.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => backingQueryable.GetEnumerator());
        }
    }
}

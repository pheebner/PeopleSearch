using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleSearch.Persistence
{
    public interface IPeopleSearchContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Person> People { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
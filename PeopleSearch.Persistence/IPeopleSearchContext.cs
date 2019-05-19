using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;

namespace PeopleSearch.Persistence
{
    public interface IPeopleSearchContext
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<Interest> Interests { get; set; }
        DbSet<Person> People { get; set; }
    }
}
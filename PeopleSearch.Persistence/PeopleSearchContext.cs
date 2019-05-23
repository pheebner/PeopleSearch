using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using PeopleSearch.Persistence.Seeding;

namespace PeopleSearch.Persistence
{
    public class PeopleSearchContext : DbContext, IPeopleSearchContext
    {
        public PeopleSearchContext(DbContextOptions<PeopleSearchContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbSeeder.Seed(modelBuilder);

            modelBuilder.Entity<Person>().HasIndex(p => p.FirstName);
            modelBuilder.Entity<Person>().HasIndex(p => p.LastName);
        }
    }
}

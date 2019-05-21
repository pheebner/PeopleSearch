using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PeopleSearch.Persistence.Seeding
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var personBuilders = new List<PersonBuilder>
            {
                PersonBuilder.BuildPerson(1)
                    .Name("Peter", "Parker")
                    .Age(15)
                    .Interests("Physics, Voluneer work, Girls")
                    .PictureUrl("image/peter_parker.png")
                    .Street("738 Winter Garden DriveForest Hills")
                    .City("Queens")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("11375"),
                PersonBuilder.BuildPerson(2)
                    .Name("Tony", "Stark")
                    .Age(40)
                    .Interests("Mechanical Engineering, Physics, Reading")
                    .PictureUrl("image/tony_stark.png")
                    .Street("10880 Malibu Point")
                    .City("Malibu")
                    .State("CA")
                    .Country("United States")
                    .ZipCode("90265"),
                PersonBuilder.BuildPerson(3)
                    .Name("Thor", "Odinson")
                    .Age(2600)
                    .Interests("Honor, Glory, Beer")
                    .PictureUrl("image/thor_odinson.png")
                    .Street("Asgardian Palace")
                    .City("Asgard")
                    .State("AG")
                    .Country("Asgard")
                    .ZipCode("?????"),
                PersonBuilder.BuildPerson(4)
                    .Name("Bruce", "Banner")
                    .Age(38)
                    .Interests("Physics, Anger management, Sunsets")
                    .PictureUrl("image/bruce_banner.png")
                    .Street("544 Smashing lane")
                    .City("New York")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("90000"),
                PersonBuilder.BuildPerson(5)
                    .Name("Steve", "Rogers")
                    .Age(15)
                    .Interests("Honor, Patriotism, Time travel")
                    .PictureUrl("image/steve_rogers.png")
                    .Street("1776 American Way")
                    .City("New York")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("60419"),
            };

            modelBuilder.Entity<Person>().HasData(personBuilders.Select(pb => pb.GetPerson()));
            modelBuilder.Entity<Address>().HasData(personBuilders.Select(pb => pb.GetAddress()));
        }
    }
}

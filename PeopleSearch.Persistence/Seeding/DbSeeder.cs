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
                    .PictureUrl("images/peter_parker.png")
                    .Street("738 Winter Garden DriveForest Hills")
                    .City("Queens")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("11375"),
                PersonBuilder.BuildPerson(2)
                    .Name("Tony", "Stark")
                    .Age(49)
                    .Interests("Mechanical Engineering, Physics, Reading")
                    .PictureUrl("images/tony_stark.png")
                    .Street("10880 Malibu Point")
                    .City("Malibu")
                    .State("CA")
                    .Country("United States")
                    .ZipCode("90265"),
                PersonBuilder.BuildPerson(3)
                    .Name("Thor", "Odinson")
                    .Age(2600)
                    .Interests("Honor, Glory, Beer")
                    .PictureUrl("images/thor_odinson.png")
                    .Street("Asgardian Palace")
                    .City("Asgard")
                    .State("AG")
                    .Country("Asgard")
                    .ZipCode("?????"),
                PersonBuilder.BuildPerson(4)
                    .Name("Bruce", "Banner")
                    .Age(45)
                    .Interests("Physics, Anger management, Sunsets")
                    .PictureUrl("images/bruce_banner.png")
                    .Street("544 Smashing lane")
                    .City("New York")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("90000"),
                PersonBuilder.BuildPerson(5)
                    .Name("Steve", "Rogers")
                    .Age(101)
                    .Interests("Honor, Patriotism, Time travel")
                    .PictureUrl("images/steve_rogers.png")
                    .Street("1776 American Way")
                    .City("New York")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("60419"),
                PersonBuilder.BuildPerson(6)
                    .Name("Clint", "Barton")
                    .Age(35)
                    .Interests("Sharpshooting, Family")
                    .PictureUrl("images/clint_barton.png")
                    .Street("789 Archery Way")
                    .City("Waverly")
                    .State("IA")
                    .Country("United States")
                    .ZipCode("50677"),
                PersonBuilder.BuildPerson(7)
                    .Name("Natasha", "Romanova")
                    .Age(30)
                    .Interests("Large men, Second chances, Espionage")
                    .PictureUrl("images/natasha_romanova.png")
                    .Street("456 Stalingrad Lane")
                    .City("Manhattan")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("10024"),
                PersonBuilder.BuildPerson(8)
                    .Name("Nick", "Fury")
                    .Age(53)
                    .Interests("Leadership, Facilitation, Defense")
                    .PictureUrl("images/nick_fury.png")
                    .Street("???")
                    .City("???")
                    .State("??")
                    .Country("United States")
                    .ZipCode("?????"),
                PersonBuilder.BuildPerson(9)
                    .Name("Loki", "Odinson")
                    .Age(1048)
                    .Interests("Trickery, Power, Mischief")
                    .PictureUrl("images/loki_odinson.png")
                    .Street("Asgardian Palace")
                    .City("Asgard")
                    .State("AG")
                    .Country("Asgard")
                    .ZipCode("?????"),
                PersonBuilder.BuildPerson(10)
                    .Name("T'Challa", string.Empty)
                    .Age(25)
                    .Interests("Management, Diplomacy, State-building")
                    .PictureUrl("images/t_challa.png")
                    .Street("Wakandan Palace")
                    .City("Wakanda")
                    .State("WK")
                    .Country("Wakanda")
                    .ZipCode("?????"),
                PersonBuilder.BuildPerson(11)
                    .Name("Scott", "Lang")
                    .Age(42)
                    .Interests("Parenting, Arthropods")
                    .PictureUrl("images/scott_lang.png")
                    .Street("37 Thieve's Way")
                    .City("Brooklyn")
                    .State("NY")
                    .Country("United States")
                    .ZipCode("11213"),
            };

            modelBuilder.Entity<Person>().HasData(personBuilders.Select(pb => pb.GetPerson()));
            modelBuilder.Entity<Address>().HasData(personBuilders.Select(pb => pb.GetAddress()));
        }
    }
}

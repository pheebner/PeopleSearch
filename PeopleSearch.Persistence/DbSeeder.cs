using Microsoft.EntityFrameworkCore;
using PeopleSearch.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleSearch.Persistence
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    Age = 15,
                    Interests = "Physics, Volunteer work, Girls",
                    PictureUrl = "images/peter_parker.png"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Tony",
                    LastName = "Stark",
                    Age = 40,
                    Interests = "Mechanical Engineering, Women, Reading",
                    PictureUrl = "images/tony_stark.png"
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Thor",
                    LastName = "Odinson",
                    Age = 2000,
                    Interests = "Honor, Glory, Beer",
                    PictureUrl = "images/thor_odinson.png"
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Bruce",
                    LastName = "Banner",
                    Age = 38,
                    Interests = "Anger, Smashing things, Screaming",
                    PictureUrl = "images/bruce_banner.png"
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Age = 96,
                    Interests = "Honor, Patriotism, Time travel",
                    PictureUrl = "images/steve_rogers.png"
                });
        }
    }
}

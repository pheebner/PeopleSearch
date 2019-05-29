﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeopleSearch.Persistence;

namespace PeopleSearch.Persistence.Migrations
{
    [DbContext(typeof(PeopleSearchContext))]
    [Migration("20190528183518_LongerUrl")]
    partial class LongerUrl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PeopleSearch.Persistence.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<int>("PersonId");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Queens",
                            Country = "United States",
                            PersonId = 1,
                            State = "NY",
                            Street = "738 Winter Garden DriveForest Hills",
                            ZipCode = "11375"
                        },
                        new
                        {
                            Id = 2,
                            City = "Malibu",
                            Country = "United States",
                            PersonId = 2,
                            State = "CA",
                            Street = "10880 Malibu Point",
                            ZipCode = "90265"
                        },
                        new
                        {
                            Id = 3,
                            City = "Asgard",
                            Country = "Asgard",
                            PersonId = 3,
                            State = "AG",
                            Street = "Asgardian Palace",
                            ZipCode = "?????"
                        },
                        new
                        {
                            Id = 4,
                            City = "New York",
                            Country = "United States",
                            PersonId = 4,
                            State = "NY",
                            Street = "544 Smashing lane",
                            ZipCode = "90000"
                        },
                        new
                        {
                            Id = 5,
                            City = "New York",
                            Country = "United States",
                            PersonId = 5,
                            State = "NY",
                            Street = "1776 American Way",
                            ZipCode = "60419"
                        },
                        new
                        {
                            Id = 6,
                            City = "Waverly",
                            Country = "United States",
                            PersonId = 6,
                            State = "IA",
                            Street = "789 Archery Way",
                            ZipCode = "50677"
                        },
                        new
                        {
                            Id = 7,
                            City = "Manhattan",
                            Country = "United States",
                            PersonId = 7,
                            State = "NY",
                            Street = "456 Stalingrad Lane",
                            ZipCode = "10024"
                        },
                        new
                        {
                            Id = 8,
                            City = "???",
                            Country = "United States",
                            PersonId = 8,
                            State = "??",
                            Street = "???",
                            ZipCode = "?????"
                        },
                        new
                        {
                            Id = 9,
                            City = "Asgard",
                            Country = "Asgard",
                            PersonId = 9,
                            State = "AG",
                            Street = "Asgardian Palace",
                            ZipCode = "?????"
                        },
                        new
                        {
                            Id = 10,
                            City = "Wakanda",
                            Country = "Wakanda",
                            PersonId = 10,
                            State = "WK",
                            Street = "Wakandan Palace",
                            ZipCode = "?????"
                        },
                        new
                        {
                            Id = 11,
                            City = "Brooklyn",
                            Country = "United States",
                            PersonId = 11,
                            State = "NY",
                            Street = "37 Thieve's Way",
                            ZipCode = "11213"
                        });
                });

            modelBuilder.Entity("PeopleSearch.Persistence.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Interests")
                        .IsRequired()
                        .HasColumnType("Text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("FirstName");

                    b.HasIndex("LastName");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 15,
                            FirstName = "Peter",
                            Interests = "Physics, Voluneer work, Girls",
                            LastName = "Parker",
                            PictureUrl = "images/peter_parker.png"
                        },
                        new
                        {
                            Id = 2,
                            Age = 49,
                            FirstName = "Tony",
                            Interests = "Mechanical Engineering, Physics, Reading",
                            LastName = "Stark",
                            PictureUrl = "images/tony_stark.png"
                        },
                        new
                        {
                            Id = 3,
                            Age = 2600,
                            FirstName = "Thor",
                            Interests = "Honor, Glory, Beer",
                            LastName = "Odinson",
                            PictureUrl = "images/thor_odinson.png"
                        },
                        new
                        {
                            Id = 4,
                            Age = 45,
                            FirstName = "Bruce",
                            Interests = "Physics, Anger management, Sunsets",
                            LastName = "Banner",
                            PictureUrl = "images/bruce_banner.png"
                        },
                        new
                        {
                            Id = 5,
                            Age = 101,
                            FirstName = "Steve",
                            Interests = "Honor, Patriotism, Time travel",
                            LastName = "Rogers",
                            PictureUrl = "images/steve_rogers.png"
                        },
                        new
                        {
                            Id = 6,
                            Age = 35,
                            FirstName = "Clint",
                            Interests = "Sharpshooting, Family",
                            LastName = "Barton",
                            PictureUrl = "images/clint_barton.png"
                        },
                        new
                        {
                            Id = 7,
                            Age = 30,
                            FirstName = "Natasha",
                            Interests = "Large men, Second chances, Espionage",
                            LastName = "Romanova",
                            PictureUrl = "images/natasha_romanova.png"
                        },
                        new
                        {
                            Id = 8,
                            Age = 53,
                            FirstName = "Nick",
                            Interests = "Leadership, Facilitation, Defense",
                            LastName = "Fury",
                            PictureUrl = "images/nick_fury.png"
                        },
                        new
                        {
                            Id = 9,
                            Age = 1048,
                            FirstName = "Loki",
                            Interests = "Trickery, Power, Mischief",
                            LastName = "Odinson",
                            PictureUrl = "images/loki_odinson.png"
                        },
                        new
                        {
                            Id = 10,
                            Age = 25,
                            FirstName = "T'Challa",
                            Interests = "Management, Diplomacy, State-building",
                            LastName = "",
                            PictureUrl = "images/t_challa.png"
                        },
                        new
                        {
                            Id = 11,
                            Age = 42,
                            FirstName = "Scott",
                            Interests = "Parenting, Arthropods",
                            LastName = "Lang",
                            PictureUrl = "images/scott_lang.png"
                        });
                });

            modelBuilder.Entity("PeopleSearch.Persistence.Entities.Address", b =>
                {
                    b.HasOne("PeopleSearch.Persistence.Entities.Person")
                        .WithOne("Address")
                        .HasForeignKey("PeopleSearch.Persistence.Entities.Address", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

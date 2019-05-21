using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Persistence.Migrations
{
    public partial class FiveMorePeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 49);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "Age",
                value: 45);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "Age",
                value: 101);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Age", "FirstName", "Interests", "LastName", "PictureUrl" },
                values: new object[,]
                {
                    { 6, 35, "Clint", "Sharpshooting, Family", "Barton", "images/clint_barton.png" },
                    { 7, 30, "Natasha", "Large men, Second chances, Espionage", "Romanova", "images/natasha_romanova.png" },
                    { 8, 53, "Nick", "Leadership, Facilitation, Defense", "Fury", "images/nick_fury.png" },
                    { 9, 1048, "Loki", "Trickery, Power, Mischief", "Odinson", "images/loki_odinson.png" },
                    { 10, 25, "T'Challa", "Management, Diplomacy, State-building", "", "images/t_challa.png" },
                    { 11, 42, "Scott", "Parenting, Arthropods", "Lang", "images/scott_lang.png" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PersonId", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 6, "Waverly", "United States", 6, "IA", "789 Archery Way", "50677" },
                    { 7, "Manhattan", "United States", 7, "NY", "456 Stalingrad Lane", "10024" },
                    { 8, "???", "United States", 8, "??", "???", "?????" },
                    { 9, "Asgard", "Asgard", 9, "AG", "Asgardian Palace", "?????" },
                    { 10, "Wakanda", "Wakanda", 10, "WK", "Wakandan Palace", "?????" },
                    { 11, "Brooklyn", "United States", 11, "NY", "37 Thieve's Way", "11213" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 40);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                column: "Age",
                value: 38);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                column: "Age",
                value: 15);
        }
    }
}

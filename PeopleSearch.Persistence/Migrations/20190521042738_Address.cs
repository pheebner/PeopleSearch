using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearch.Persistence.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                maxLength: 2,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "PersonId", "State", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Queens", "United States", 1, "NY", "738 Winter Garden DriveForest Hills", "11375" },
                    { 2, "Malibu", "United States", 2, "CA", "10880 Malibu Point", "90265" },
                    { 3, "Asgard", "Asgard", 3, "AG", "Asgardian Palace", "?????" },
                    { 4, "New York", "United States", 4, "NY", "544 Smashing lane", "90000" },
                    { 5, "New York", "United States", 5, "NY", "1776 American Way", "60419" }
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Physics, Voluneer work, Girls", "image/peter_parker.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Mechanical Engineering, Physics, Reading", "image/tony_stark.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "PictureUrl" },
                values: new object[] { 2600, "image/thor_odinson.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Physics, Anger management, Sunsets", "image/bruce_banner.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "PictureUrl" },
                values: new object[] { 15, "image/steve_rogers.png" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Physics, Volunteer work, Girls", "images/peter_parker.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Mechanical Engineering, Women, Reading", "images/tony_stark.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Age", "PictureUrl" },
                values: new object[] { 2000, "images/thor_odinson.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Interests", "PictureUrl" },
                values: new object[] { "Anger, Smashing things, Screaming", "images/bruce_banner.png" });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Age", "PictureUrl" },
                values: new object[] { 96, "images/steve_rogers.png" });
        }
    }
}

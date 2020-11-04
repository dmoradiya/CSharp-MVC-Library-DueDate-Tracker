using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    public partial class SeedAuthorData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "ID", "DateOfBirth", "DeathDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edith Eva Eger" },
                    { 2, new DateTime(1960, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Mitchell" },
                    { 3, new DateTime(1960, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abhijit V. Banerjee" },
                    { 4, new DateTime(1960, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John M. Barry" },
                    { 5, new DateTime(1960, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Iger" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}

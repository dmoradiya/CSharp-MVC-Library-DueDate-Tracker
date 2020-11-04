using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    public partial class SeedBookData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Choice" },
                    { 2, 2, new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cloud Atlas" },
                    { 3, 3, new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Economics for Hard Times" },
                    { 4, 4, new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Influenza" },
                    { 5, 5, new DateTime(2015, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ride of a Lifetime" },
                    { 6, 3, new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Economics for Hard Times part 2" },
                    { 7, 3, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good Economics for Hard Times" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}

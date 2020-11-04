using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    public partial class SeedBorrowData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "ChechedOutDate", "DueDate", "ReturnedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: 7);
        }
    }
}

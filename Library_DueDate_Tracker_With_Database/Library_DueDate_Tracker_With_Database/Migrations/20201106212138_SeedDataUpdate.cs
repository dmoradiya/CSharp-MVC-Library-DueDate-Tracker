using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    public partial class SeedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author",
                table: "book");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "borrow",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "author",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "ID", "DateOfBirth", "DeathDate", "Name" },
                values: new object[,]
                {
                    { -1, new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Edith Eva Eger" },
                    { -2, new DateTime(1960, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "David Mitchell" },
                    { -3, new DateTime(1960, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Abhijit V. Banerjee" },
                    { -4, new DateTime(1960, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "John M. Barry" },
                    { -5, new DateTime(1960, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert Iger" }
                });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "ChechedOutDate", "DueDate", "ReturnedDate" },
                values: new object[,]
                {
                    { -11, 1, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -22, 2, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -33, 3, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -44, 4, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -55, 5, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -66, 6, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { -77, 7, new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 1,
                column: "AuthorID",
                value: -1);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 2,
                column: "AuthorID",
                value: -2);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 3,
                column: "AuthorID",
                value: -3);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 4,
                column: "AuthorID",
                value: -4);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 5,
                column: "AuthorID",
                value: -5);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 6,
                column: "AuthorID",
                value: -3);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "AuthorID", "Title" },
                values: new object[] { -3, "Good Economics for Hard Times part 3" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author",
                table: "book",
                column: "AuthorID",
                principalTable: "author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author",
                table: "book");

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "author",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -77);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -66);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -55);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -44);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -33);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "borrow",
                keyColumn: "ID",
                keyValue: -11);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReturnedDate",
                table: "borrow",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "author",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 1,
                column: "AuthorID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 2,
                column: "AuthorID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 3,
                column: "AuthorID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 4,
                column: "AuthorID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 5,
                column: "AuthorID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 6,
                column: "AuthorID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "AuthorID", "Title" },
                values: new object[] { 3, "Good Economics for Hard Times" });

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author",
                table: "book",
                column: "AuthorID",
                principalTable: "author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

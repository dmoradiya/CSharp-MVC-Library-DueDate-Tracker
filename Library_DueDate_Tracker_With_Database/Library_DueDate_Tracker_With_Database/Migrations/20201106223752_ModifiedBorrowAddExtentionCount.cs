using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    public partial class ModifiedBorrowAddExtentionCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChechedOutDate",
                table: "borrow",
                newName: "CheckedOutDate");

            migrationBuilder.AddColumn<int>(
                name: "ExtensionCount",
                table: "borrow",
                type: "int(10)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtensionCount",
                table: "borrow");

            migrationBuilder.RenameColumn(
                name: "CheckedOutDate",
                table: "borrow",
                newName: "ChechedOutDate");
        }
    }
}

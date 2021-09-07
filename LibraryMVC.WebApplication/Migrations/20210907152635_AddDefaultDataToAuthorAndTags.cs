using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMVC.WebApplication.Migrations
{
    public partial class AddDefaultDataToAuthorAndTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Biography", "FirstName", "LastName" },
                values: new object[] { 1, "none", "none", "none" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Other" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Other" });

            migrationBuilder.InsertData(
                table: "TypeOfBooks",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeOfBooks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryMVC.WebApplication.Migrations
{
    public partial class AddColumnIsLocalAccountToCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocalAccount",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocalAccount",
                table: "Customers");
        }
    }
}

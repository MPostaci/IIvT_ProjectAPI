using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class mig_address_softdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");
        }
    }
}

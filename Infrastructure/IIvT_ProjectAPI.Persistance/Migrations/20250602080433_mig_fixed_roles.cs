using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class mig_fixed_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleEndpoints_AspNetRoles_RoleId1",
                table: "IdentityRoleEndpoints");

            migrationBuilder.DropIndex(
                name: "IX_IdentityRoleEndpoints_RoleId1",
                table: "IdentityRoleEndpoints");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "IdentityRoleEndpoints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "IdentityRoleEndpoints",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleEndpoints_RoleId1",
                table: "IdentityRoleEndpoints",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleEndpoints_AspNetRoles_RoleId1",
                table: "IdentityRoleEndpoints",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

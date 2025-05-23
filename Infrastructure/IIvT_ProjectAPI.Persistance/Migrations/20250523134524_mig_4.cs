using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class mig_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItems_CategoryId",
                table: "NewsItems",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CategoryId",
                table: "Announcements",
                column: "CategoryId",
                unique: true);
        }
    }
}

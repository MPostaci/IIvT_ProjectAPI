using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class mig_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Neighborhoods_DistrictId",
                table: "Neighborhoods",
                newName: "IX_Neighborhood_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                newName: "IX_District_CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Neighborhood_DistrictId",
                table: "Neighborhoods",
                newName: "IX_Neighborhoods_DistrictId");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityId",
                table: "Districts",
                newName: "IX_Districts_CityId");
        }
    }
}

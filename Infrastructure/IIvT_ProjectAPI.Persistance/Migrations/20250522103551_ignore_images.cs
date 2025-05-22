using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class ignore_images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_NewsItems_NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Products_ProductId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_ProductId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MediaFiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NewsItemId",
                table: "MediaFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "MediaFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_NewsItemId",
                table: "MediaFiles",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ProductId",
                table: "MediaFiles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_NewsItems_NewsItemId",
                table: "MediaFiles",
                column: "NewsItemId",
                principalTable: "NewsItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Products_ProductId",
                table: "MediaFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}

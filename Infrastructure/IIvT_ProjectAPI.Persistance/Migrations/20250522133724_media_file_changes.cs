using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class media_file_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_MediaFiles_ImageId",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_ImageId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "OwnerType",
                table: "MediaFiles",
                newName: "FileTpye");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "NewsItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AnnouncementId",
                table: "MediaFiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MediaFiles",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<bool>(
                name: "ProductMediaFile_Showcase",
                table: "MediaFiles",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Showcase",
                table: "MediaFiles",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Announcements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_AnnouncementId",
                table: "MediaFiles",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_NewsItemId",
                table: "MediaFiles",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaFiles_ProductId",
                table: "MediaFiles",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Announcements_AnnouncementId",
                table: "MediaFiles",
                column: "AnnouncementId",
                principalTable: "Announcements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_NewsItems_NewsItemId",
                table: "MediaFiles",
                column: "NewsItemId",
                principalTable: "NewsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MediaFiles_Products_ProductId",
                table: "MediaFiles",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Announcements_AnnouncementId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_NewsItems_NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_MediaFiles_Products_ProductId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_AnnouncementId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropIndex(
                name: "IX_MediaFiles_ProductId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "AnnouncementId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "NewsItemId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "ProductMediaFile_Showcase",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Showcase",
                table: "MediaFiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Announcements");

            migrationBuilder.RenameColumn(
                name: "FileTpye",
                table: "MediaFiles",
                newName: "OwnerType");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "MediaFiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Announcements",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_ImageId",
                table: "Announcements",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_MediaFiles_ImageId",
                table: "Announcements",
                column: "ImageId",
                principalTable: "MediaFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

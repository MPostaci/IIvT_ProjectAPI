using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IIvT_ProjectAPI.Persistence.Migrations
{
    public partial class mig_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AnnouncementMediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnnouncementId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementMediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementMediaFiles_Announcements_AnnouncementId",
                        column: x => x.AnnouncementId,
                        principalTable: "Announcements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnouncementMediaFiles_MediaFiles_Id",
                        column: x => x.Id,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PublisherId = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_AspNetUsers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsItemMediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Showcase = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItemMediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsItemMediaFiles_MediaFiles_Id",
                        column: x => x.Id,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsItemMediaFiles_NewsItems_NewsItemId",
                        column: x => x.NewsItemId,
                        principalTable: "NewsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Showcase = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductMediaFiles_MediaFiles_Id",
                        column: x => x.Id,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMediaFiles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventMediaFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMediaFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventMediaFiles_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMediaFiles_MediaFiles_Id",
                        column: x => x.Id,
                        principalTable: "MediaFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementMediaFiles_AnnouncementId",
                table: "AnnouncementMediaFiles",
                column: "AnnouncementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventMediaFiles_EventId",
                table: "EventMediaFiles",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PublisherId",
                table: "Events",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsItemMediaFiles_NewsItemId",
                table: "NewsItemMediaFiles",
                column: "NewsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMediaFiles_ProductId",
                table: "ProductMediaFiles",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnouncementMediaFiles");

            migrationBuilder.DropTable(
                name: "EventMediaFiles");

            migrationBuilder.DropTable(
                name: "NewsItemMediaFiles");

            migrationBuilder.DropTable(
                name: "ProductMediaFiles");

            migrationBuilder.DropTable(
                name: "Events");

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
    }
}

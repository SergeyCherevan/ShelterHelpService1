using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShelterHelpService1.Migrations
{
    public partial class AdTimelinePostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimelinePostTables",
                columns: table => new
                {
                    AuthorIdFkId = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    DatePublicating = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActual = table.Column<bool>(type: "INTEGER", nullable: false),
                    HtmlPage = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<decimal>(type: "TEXT", nullable: false),
                    XmlComments = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TimelinePostTables_AspNetUsers_AuthorIdFkId",
                        column: x => x.AuthorIdFkId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimelinePostTables_AuthorIdFkId",
                table: "TimelinePostTables",
                column: "AuthorIdFkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimelinePostTables");
        }
    }
}

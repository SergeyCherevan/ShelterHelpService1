using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShelterHelpService1.Migrations
{
    public partial class AddCorrespondence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeBannedTo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastPaymentDate",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "СorrespondenceTable",
                columns: table => new
                {
                    UserId1FkId = table.Column<string>(type: "TEXT", nullable: true),
                    UserId2FkId = table.Column<string>(type: "TEXT", nullable: true),
                    XmlMessages = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_СorrespondenceTable_AspNetUsers_UserId1FkId",
                        column: x => x.UserId1FkId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_СorrespondenceTable_AspNetUsers_UserId2FkId",
                        column: x => x.UserId2FkId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СorrespondenceTable_UserId1FkId",
                table: "СorrespondenceTable",
                column: "UserId1FkId");

            migrationBuilder.CreateIndex(
                name: "IX_СorrespondenceTable_UserId2FkId",
                table: "СorrespondenceTable",
                column: "UserId2FkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СorrespondenceTable");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastPaymentDate",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeBannedTo",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

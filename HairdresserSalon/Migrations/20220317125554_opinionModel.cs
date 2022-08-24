using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdresserSalon.Migrations
{
    public partial class opinionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OpinionId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpinionModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HairdresserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpinionModel_Hairdressers_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdressers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_OpinionId",
                table: "Visits",
                column: "OpinionId");

            migrationBuilder.CreateIndex(
                name: "IX_OpinionModel_HairdresserId",
                table: "OpinionModel",
                column: "HairdresserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_OpinionModel_OpinionId",
                table: "Visits",
                column: "OpinionId",
                principalTable: "OpinionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_OpinionModel_OpinionId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "OpinionModel");

            migrationBuilder.DropIndex(
                name: "IX_Visits_OpinionId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "OpinionId",
                table: "Visits");
        }
    }
}

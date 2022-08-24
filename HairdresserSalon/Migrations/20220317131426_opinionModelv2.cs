using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdresserSalon.Migrations
{
    public partial class opinionModelv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpinionModel_Hairdressers_HairdresserId",
                table: "OpinionModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_OpinionModel_OpinionId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpinionModel",
                table: "OpinionModel");

            migrationBuilder.RenameTable(
                name: "OpinionModel",
                newName: "Opinions");

            migrationBuilder.RenameIndex(
                name: "IX_OpinionModel_HairdresserId",
                table: "Opinions",
                newName: "IX_Opinions_HairdresserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Hairdressers_HairdresserId",
                table: "Opinions",
                column: "HairdresserId",
                principalTable: "Hairdressers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Opinions_OpinionId",
                table: "Visits",
                column: "OpinionId",
                principalTable: "Opinions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Hairdressers_HairdresserId",
                table: "Opinions");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Opinions_OpinionId",
                table: "Visits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opinions",
                table: "Opinions");

            migrationBuilder.RenameTable(
                name: "Opinions",
                newName: "OpinionModel");

            migrationBuilder.RenameIndex(
                name: "IX_Opinions_HairdresserId",
                table: "OpinionModel",
                newName: "IX_OpinionModel_HairdresserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpinionModel",
                table: "OpinionModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OpinionModel_Hairdressers_HairdresserId",
                table: "OpinionModel",
                column: "HairdresserId",
                principalTable: "Hairdressers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_OpinionModel_OpinionId",
                table: "Visits",
                column: "OpinionId",
                principalTable: "OpinionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdresserSalon.Migrations
{
    public partial class newvisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Visits");

            migrationBuilder.AddColumn<Guid>(
                name: "DateId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DateId",
                table: "Visits",
                column: "DateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Hours_DateId",
                table: "Visits",
                column: "DateId",
                principalTable: "Hours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Hours_DateId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_DateId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "DateId",
                table: "Visits");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Visits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

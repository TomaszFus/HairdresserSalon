using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdresserSalon.Migrations
{
    public partial class customers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Hairdressers_hairdresserId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Services_serviceId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "serviceId",
                table: "Visits",
                newName: "ServiceId");

            migrationBuilder.RenameColumn(
                name: "hairdresserId",
                table: "Visits",
                newName: "HairdresserId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_serviceId",
                table: "Visits",
                newName: "IX_Visits_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_hairdresserId",
                table: "Visits",
                newName: "IX_Visits_HairdresserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_CustomerId",
                table: "Visits",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Customers_CustomerId",
                table: "Visits",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Hairdressers_HairdresserId",
                table: "Visits",
                column: "HairdresserId",
                principalTable: "Hairdressers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Services_ServiceId",
                table: "Visits",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Customers_CustomerId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Hairdressers_HairdresserId",
                table: "Visits");

            migrationBuilder.DropForeignKey(
                name: "FK_Visits_Services_ServiceId",
                table: "Visits");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Visits_CustomerId",
                table: "Visits");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Visits",
                newName: "serviceId");

            migrationBuilder.RenameColumn(
                name: "HairdresserId",
                table: "Visits",
                newName: "hairdresserId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_ServiceId",
                table: "Visits",
                newName: "IX_Visits_serviceId");

            migrationBuilder.RenameIndex(
                name: "IX_Visits_HairdresserId",
                table: "Visits",
                newName: "IX_Visits_hairdresserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Visits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Hairdressers_hairdresserId",
                table: "Visits",
                column: "hairdresserId",
                principalTable: "Hairdressers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_Services_serviceId",
                table: "Visits",
                column: "serviceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

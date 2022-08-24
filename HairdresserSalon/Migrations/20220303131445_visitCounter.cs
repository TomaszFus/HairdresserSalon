using Microsoft.EntityFrameworkCore.Migrations;

namespace HairdresserSalon.Migrations
{
    public partial class visitCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitsCounter",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisitsCounter",
                table: "Customers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class additionalsappointments_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Additional",
                table: "Appointments",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Additional",
                table: "Appointments");
        }
    }
}

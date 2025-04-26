using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class appointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SignUps",
                table: "SignUps");

            migrationBuilder.RenameTable(
                name: "SignUps",
                newName: "Appointments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "SignUps");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SignUps",
                table: "SignUps",
                column: "Id");
        }
    }
}

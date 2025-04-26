using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class haircutstyleupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Hair Styles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Hair Styles",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Hair Styles");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Hair Styles");
        }
    }
}

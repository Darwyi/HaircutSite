using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Migrations
{
    /// <inheritdoc />
    public partial class edit_signups_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignUps_Hair Styles_HaircutStyleId",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "HaircutStyleId",
                table: "SignUps",
                newName: "haircutStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_SignUps_HaircutStyleId",
                table: "SignUps",
                newName: "IX_SignUps_haircutStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignUps_Hair Styles_haircutStyleId",
                table: "SignUps",
                column: "haircutStyleId",
                principalTable: "Hair Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignUps_Hair Styles_haircutStyleId",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "haircutStyleId",
                table: "SignUps",
                newName: "HaircutStyleId");

            migrationBuilder.RenameIndex(
                name: "IX_SignUps_haircutStyleId",
                table: "SignUps",
                newName: "IX_SignUps_HaircutStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignUps_Hair Styles_HaircutStyleId",
                table: "SignUps",
                column: "HaircutStyleId",
                principalTable: "Hair Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

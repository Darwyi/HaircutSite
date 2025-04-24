using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Migrations
{
    /// <inheritdoc />
    public partial class edit_signups_config1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignUps_Hair Styles_haircutStyleId",
                table: "SignUps");

            migrationBuilder.DropIndex(
                name: "IX_SignUps_haircutStyleId",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SignUps",
                newName: "haircutStyle_Name");

            migrationBuilder.RenameColumn(
                name: "haircutStyleId",
                table: "SignUps",
                newName: "HaircutStyle Id");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "SignUps",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "haircutStyle_Description",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "haircutStyle_Description",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "haircutStyle_Name",
                table: "SignUps",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HaircutStyle Id",
                table: "SignUps",
                newName: "haircutStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_SignUps_haircutStyleId",
                table: "SignUps",
                column: "haircutStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignUps_Hair Styles_haircutStyleId",
                table: "SignUps",
                column: "haircutStyleId",
                principalTable: "Hair Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

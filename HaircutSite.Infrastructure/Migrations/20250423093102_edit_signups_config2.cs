using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaircutSite.Migrations
{
    /// <inheritdoc />
    public partial class edit_signups_config2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaircutStyle Id",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "User",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "User_CreatedAt",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "User_Password",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "User_UpdatedAt",
                table: "SignUps");

            migrationBuilder.DropColumn(
                name: "haircutStyle_Description",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "haircutStyle_Name",
                table: "SignUps",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "Haircut StyleId",
                table: "SignUps",
                type: "INTEGER",
                maxLength: 100,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Haircut StyleId",
                table: "SignUps");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "SignUps",
                newName: "haircutStyle_Name");

            migrationBuilder.AddColumn<int>(
                name: "HaircutStyle Id",
                table: "SignUps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "SignUps",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "User_CreatedAt",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "User_Id",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "User_Password",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "User_UpdatedAt",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "haircutStyle_Description",
                table: "SignUps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}

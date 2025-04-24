using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HaircutSite.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hair Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hair Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(name: "Created At", type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    Updatedat = table.Column<DateTime>(name: "Updated at", type: "TEXT", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HaircutStyleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    User_CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    User_Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    User_Password = table.Column<string>(type: "TEXT", nullable: false),
                    User_UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignUps_Hair Styles_HaircutStyleId",
                        column: x => x.HaircutStyleId,
                        principalTable: "Hair Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hair Styles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "empty", "Long" },
                    { 2, "empty", "Short" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SignUps_HaircutStyleId",
                table: "SignUps",
                column: "HaircutStyleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignUps");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Hair Styles");
        }
    }
}

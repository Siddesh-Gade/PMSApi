using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMSWebApi.Migrations
{
    /// <inheritdoc />
    public partial class firstbuild5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "KPIs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "KPIs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "KPIs");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "KPIs");
        }
    }
}

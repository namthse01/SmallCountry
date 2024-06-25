using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountryAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPopulationField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "District",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Town",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Commune",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Population",
                table: "City");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "District");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Town");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "Commune");
        }
    }
}

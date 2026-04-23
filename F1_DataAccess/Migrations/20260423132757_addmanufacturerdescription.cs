using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addmanufacturerdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Manufacturers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Official tyre supplier for Formula 1, providing high-performance compounds designed for speed, durability, and race strategy.");

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Develops advanced electronic control systems and telemetry solutions used across Formula 1 for precision performance and data analysis.");

            migrationBuilder.UpdateData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "World-leading manufacturer of high-performance braking systems, delivering reliability and extreme stopping power in Formula 1.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Manufacturers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace F1_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Tyres_ProductId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderDetails",
                newName: "TyresId");

            migrationBuilder.InsertData(
                table: "ECUs",
                columns: new[] { "Id", "Limit", "Name", "Version" },
                values: new object[,]
                {
                    { 4, "2", "2JZ", "T32" },
                    { 5, "2", "RB26", "5.6" },
                    { 6, "2", "B58", "2.2V" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ECUs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "TyresId",
                table: "OrderDetails",
                newName: "ProductId");

            migrationBuilder.InsertData(
                table: "ECUs",
                columns: new[] { "Id", "Limit", "Name", "Version" },
                values: new object[,]
                {
                    { 1, "2", "2JZ", "T32" },
                    { 2, "2", "RB26", "5.6" },
                    { 3, "2", "B58", "2.2V" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Tyres_ProductId",
                table: "OrderDetails",
                column: "ProductId",
                principalTable: "Tyres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

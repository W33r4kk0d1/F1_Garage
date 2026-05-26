using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class cartUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_OrderHeaderId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "OrderHeaderId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItems",
                newName: "TyreId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CartItems",
                newName: "ECUId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ApplicationUserId",
                table: "CartItems",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ECUId",
                table: "CartItems",
                column: "ECUId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_TyreId",
                table: "CartItems",
                column: "TyreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ApplicationUsers_ApplicationUserId",
                table: "CartItems",
                column: "ApplicationUserId",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_ECUs_ECUId",
                table: "CartItems",
                column: "ECUId",
                principalTable: "ECUs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Tyres_TyreId",
                table: "CartItems",
                column: "TyreId",
                principalTable: "Tyres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ApplicationUsers_ApplicationUserId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_ECUs_ECUId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Tyres_TyreId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ApplicationUserId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ECUId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_TyreId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "TyreId",
                table: "CartItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "ECUId",
                table: "CartItems",
                newName: "ItemId");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemType",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderHeaderId",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_OrderHeaderId",
                table: "CartItems",
                column: "OrderHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id");
        }
    }
}

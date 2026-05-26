using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace F1_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class kkkkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderHeaderId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderHeaderId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_OrderHeaders_OrderHeaderId",
                table: "CartItems",
                column: "OrderHeaderId",
                principalTable: "OrderHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

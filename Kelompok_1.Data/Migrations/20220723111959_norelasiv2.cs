using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelompok_1.Data.Migrations
{
    public partial class norelasiv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProdukId",
                table: "Carts",
                column: "ProdukId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Produks_ProdukId",
                table: "Carts",
                column: "ProdukId",
                principalTable: "Produks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Produks_ProdukId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ProdukId",
                table: "Carts");
        }
    }
}

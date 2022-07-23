using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelompok_1.Data.Migrations
{
    public partial class norelasiv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transaksis_UserId",
                table: "Transaksis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksis_Users_UserId",
                table: "Transaksis",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaksis_Users_UserId",
                table: "Transaksis");

            migrationBuilder.DropIndex(
                name: "IX_Transaksis_UserId",
                table: "Transaksis");
        }
    }
}

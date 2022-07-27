using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kelompok_1.Data.Migrations
{
    public partial class norelasiv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Tanggal",
                table: "Transaksis",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transaksis_CartId",
                table: "Transaksis",
                column: "CartId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaksis_Carts_CartId",
                table: "Transaksis",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaksis_Carts_CartId",
                table: "Transaksis");

            migrationBuilder.DropIndex(
                name: "IX_Transaksis_CartId",
                table: "Transaksis");

            migrationBuilder.DropColumn(
                name: "Tanggal",
                table: "Transaksis");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addcirculationkopyabirim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KopyaBirimId",
                table: "Oduncler",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oduncler_KopyaBirimId",
                table: "Oduncler",
                column: "KopyaBirimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oduncler_KopyaBirimler_KopyaBirimId",
                table: "Oduncler",
                column: "KopyaBirimId",
                principalTable: "KopyaBirimler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Oduncler_KopyaBirimler_KopyaBirimId",
                table: "Oduncler");

            migrationBuilder.DropIndex(
                name: "IX_Oduncler_KopyaBirimId",
                table: "Oduncler");

            migrationBuilder.DropColumn(
                name: "KopyaBirimId",
                table: "Oduncler");
        }
    }
}

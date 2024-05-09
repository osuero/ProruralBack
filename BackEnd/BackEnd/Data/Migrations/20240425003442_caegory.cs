using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class caegory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CategoryId",
                table: "Organizations",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_ProductionCategories_CategoryId",
                table: "Organizations",
                column: "CategoryId",
                principalTable: "ProductionCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_ProductionCategories_CategoryId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_CategoryId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Organizations");
        }
    }
}

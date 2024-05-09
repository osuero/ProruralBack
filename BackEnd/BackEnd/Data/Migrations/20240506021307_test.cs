using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_FinancingGroup_FinancingGroupId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_FinancingGroupId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "FinancingGroupId",
                table: "Project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FinancingGroupId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_FinancingGroupId",
                table: "Project",
                column: "FinancingGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_FinancingGroup_FinancingGroupId",
                table: "Project",
                column: "FinancingGroupId",
                principalTable: "FinancingGroup",
                principalColumn: "Id");
        }
    }
}

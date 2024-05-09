using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class financimentGropo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FinancingGroupId",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "GorbermentFunds",
                table: "Project",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinancingGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancingGroup", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_FinancingGroup_FinancingGroupId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "FinancingGroup");

            migrationBuilder.DropIndex(
                name: "IX_Project_FinancingGroupId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "FinancingGroupId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "GorbermentFunds",
                table: "Project");
        }
    }
}

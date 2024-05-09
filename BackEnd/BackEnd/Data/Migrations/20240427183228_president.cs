using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class president : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PresidentName",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "PresidentPhone",
                table: "Organizations",
                newName: "OrganizationNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "PresidentId",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PresidentId1",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PresidentId1",
                table: "Organizations",
                column: "PresidentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId1",
                table: "Organizations",
                column: "PresidentId1",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId1",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PresidentId1",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PresidentId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PresidentId1",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "OrganizationNumber",
                table: "Organizations",
                newName: "PresidentPhone");

            migrationBuilder.AddColumn<string>(
                name: "PresidentName",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

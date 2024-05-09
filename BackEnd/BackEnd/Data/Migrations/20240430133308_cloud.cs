using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class cloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId1",
                table: "Beneficiaries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_OrganizationId1",
                table: "Beneficiaries",
                column: "OrganizationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId1",
                table: "Beneficiaries",
                column: "OrganizationId1",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class org : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus");

            migrationBuilder.RenameTable(
                name: "ProjectStatus",
                newName: "ProjectStatuses");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId1",
                table: "Beneficiaries",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatuses_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatuses_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStatuses",
                table: "ProjectStatuses");

            migrationBuilder.DropColumn(
                name: "OrganizationId1",
                table: "Beneficiaries");

            migrationBuilder.RenameTable(
                name: "ProjectStatuses",
                newName: "ProjectStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStatus",
                table: "ProjectStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Organizations_OrganizationId",
                table: "Beneficiaries",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

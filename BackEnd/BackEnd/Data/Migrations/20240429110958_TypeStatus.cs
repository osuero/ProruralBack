using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TypeStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId1",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Provinces_ProvinceId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PresidentId1",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "PresidentId1",
                table: "Organizations");

            migrationBuilder.AddColumn<decimal>(
                name: "CreditFunds",
                table: "Project",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OrganizationFunds",
                table: "Project",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectStatusId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectTypeId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProruralFunds",
                table: "Project",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectTypeId",
                table: "Project",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PresidentId",
                table: "Organizations",
                column: "PresidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId",
                table: "Organizations",
                column: "PresidentId",
                principalTable: "Beneficiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Provinces_ProvinceId",
                table: "Organizations",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project",
                column: "ProjectStatusId",
                principalTable: "ProjectStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectType_ProjectTypeId",
                table: "Project",
                column: "ProjectTypeId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Provinces_ProvinceId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectType_ProjectTypeId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectStatusId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectTypeId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_PresidentId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "CreditFunds",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OrganizationFunds",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectStatusId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProruralFunds",
                table: "Project");

            migrationBuilder.AddColumn<Guid>(
                name: "PresidentId1",
                table: "Organizations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_PresidentId1",
                table: "Organizations",
                column: "PresidentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Beneficiaries_PresidentId1",
                table: "Organizations",
                column: "PresidentId1",
                principalTable: "Beneficiaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Provinces_ProvinceId",
                table: "Organizations",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Regions_RegionId",
                table: "Organizations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id");
        }
    }
}

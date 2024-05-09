using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class icv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IcvTypeId",
                table: "Beneficiaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IcvTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcvTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_IcvTypeId",
                table: "Beneficiaries",
                column: "IcvTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_IcvTypes_IcvTypeId",
                table: "Beneficiaries",
                column: "IcvTypeId",
                principalTable: "IcvTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_IcvTypes_IcvTypeId",
                table: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "IcvTypes");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_IcvTypeId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "IcvTypeId",
                table: "Beneficiaries");
        }
    }
}

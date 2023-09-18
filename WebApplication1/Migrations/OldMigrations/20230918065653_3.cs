using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Skills_skillsid",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_skillsid",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "skillsid",
                table: "Persons");

            migrationBuilder.AddColumn<long>(
                name: "Personid",
                table: "Skills",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Personid",
                table: "Skills",
                column: "Personid");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Persons_Personid",
                table: "Skills",
                column: "Personid",
                principalTable: "Persons",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Persons_Personid",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_Personid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Personid",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "skillsid",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_skillsid",
                table: "Persons",
                column: "skillsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Skills_skillsid",
                table: "Persons",
                column: "skillsid",
                principalTable: "Skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

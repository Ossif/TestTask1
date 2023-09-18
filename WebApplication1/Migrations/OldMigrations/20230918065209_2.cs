using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "skills",
                table: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "skillsid",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Skills_skillsid",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Persons_skillsid",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "skillsid",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "skills",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

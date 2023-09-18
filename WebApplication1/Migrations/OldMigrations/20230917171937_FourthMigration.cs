using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<byte>(type: "tinyint", nullable: false),
                    Personid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.id);
                    table.ForeignKey(
                        name: "FK_Skill_Persons_Personid",
                        column: x => x.Personid,
                        principalTable: "Persons",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skill_Personid",
                table: "Skill",
                column: "Personid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skill");
        }
    }
}

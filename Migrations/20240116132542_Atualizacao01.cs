using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApresentaçãoAlunos.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    RespostaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Resp1 = table.Column<string>(type: "TEXT", nullable: false),
                    Resp2 = table.Column<string>(type: "TEXT", nullable: false),
                    Resp3 = table.Column<string>(type: "TEXT", nullable: false),
                    Resp4 = table.Column<string>(type: "TEXT", nullable: false),
                    Resp5 = table.Column<string>(type: "TEXT", nullable: false),
                    Resp6 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.RespostaId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");
        }
    }
}

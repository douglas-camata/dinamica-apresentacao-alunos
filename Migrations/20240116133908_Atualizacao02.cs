using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApresentaçãoAlunos.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sorteado",
                table: "Respostas",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sorteado",
                table: "Respostas");
        }
    }
}

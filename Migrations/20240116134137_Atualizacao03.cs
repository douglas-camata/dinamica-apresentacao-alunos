using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApresentaçãoAlunos.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "Respostas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IP",
                table: "Respostas");
        }
    }
}

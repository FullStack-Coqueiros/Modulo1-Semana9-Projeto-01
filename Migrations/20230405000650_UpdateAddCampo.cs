using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meu_primiro_projeto_ef.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Semana",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Semana");
        }
    }
}

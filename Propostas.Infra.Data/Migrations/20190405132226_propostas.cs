using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class propostas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataPropostaAlteracao",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Proposta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPropostaAlteracao",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Proposta");
        }
    }
}

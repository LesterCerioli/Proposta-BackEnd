using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class proposta_numero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "codigo",
                table: "Template",
                newName: "Codigo");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Proposta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Proposta");

            migrationBuilder.RenameColumn(
                name: "Codigo",
                table: "Template",
                newName: "codigo");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class urlPdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlPdf",
                table: "Proposta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlPdf",
                table: "Proposta");
        }
    }
}

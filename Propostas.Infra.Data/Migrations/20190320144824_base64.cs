using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class base64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecaoTagId",
                table: "PropostaTag");

            migrationBuilder.AddColumn<string>(
                name: "Base64",
                table: "PropostaTag",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64",
                table: "PropostaTag");

            migrationBuilder.AddColumn<int>(
                name: "SecaoTagId",
                table: "PropostaTag",
                nullable: false,
                defaultValue: 0);
        }
    }
}

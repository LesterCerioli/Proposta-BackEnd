using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Contato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Funcao",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoContatoId",
                table: "Contato",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TiposContatoId",
                table: "Contato",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Cliente",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "Cliente",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "Cliente",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_ClienteId",
                table: "Contato",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contato_TiposContatoId",
                table: "Contato",
                column: "TiposContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_TiposContato_TiposContatoId",
                table: "Contato",
                column: "TiposContatoId",
                principalTable: "TiposContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_Cliente_ClienteId",
                table: "Contato");

            migrationBuilder.DropForeignKey(
                name: "FK_Contato_TiposContato_TiposContatoId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_ClienteId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_TiposContatoId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Funcao",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "TipoContatoId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "TiposContatoId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "Cliente");
        }
    }
}

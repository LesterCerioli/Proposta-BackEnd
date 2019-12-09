using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class eliminacaodascolunaspropostas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposta_Recurso_LiderPropostaId",
                table: "Proposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposta_Recurso_LiderSolucaoId",
                table: "Proposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposta_Moeda_MoedaId",
                table: "Proposta");

            migrationBuilder.DropIndex(
                name: "IX_Proposta_LiderPropostaId",
                table: "Proposta");

            migrationBuilder.DropIndex(
                name: "IX_Proposta_LiderSolucaoId",
                table: "Proposta");

            migrationBuilder.DropIndex(
                name: "IX_Proposta_MoedaId",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "CustoTotal",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "DataEncerramentoOportunidade",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "DataEnvioPerguntas",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "DataEnvioProposta",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "DataPropostaAlteracao",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "LiderPropostaId",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "LiderSolucaoId",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "MoedaId",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "ObjetivoProposta",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "PrecoTotal",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "TempoDuracao",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Proposta");

            migrationBuilder.RenameColumn(
                name: "UrlPdf",
                table: "Proposta",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Proposta",
                newName: "UrlPdf");

            migrationBuilder.AddColumn<decimal>(
                name: "CustoTotal",
                table: "Proposta",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEncerramentoOportunidade",
                table: "Proposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnvioPerguntas",
                table: "Proposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEnvioProposta",
                table: "Proposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPropostaAlteracao",
                table: "Proposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LiderPropostaId",
                table: "Proposta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiderSolucaoId",
                table: "Proposta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedaId",
                table: "Proposta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoProposta",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoTotal",
                table: "Proposta",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TempoDuracao",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Proposta",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Proposta",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_LiderPropostaId",
                table: "Proposta",
                column: "LiderPropostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_LiderSolucaoId",
                table: "Proposta",
                column: "LiderSolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_MoedaId",
                table: "Proposta",
                column: "MoedaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposta_Recurso_LiderPropostaId",
                table: "Proposta",
                column: "LiderPropostaId",
                principalTable: "Recurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposta_Recurso_LiderSolucaoId",
                table: "Proposta",
                column: "LiderSolucaoId",
                principalTable: "Recurso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposta_Moeda_MoedaId",
                table: "Proposta",
                column: "MoedaId",
                principalTable: "Moeda",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

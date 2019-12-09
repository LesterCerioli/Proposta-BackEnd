using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class proposta4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Proposta_ClienteId",
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

            migrationBuilder.DropIndex(
                name: "IX_Proposta_TemplateId",
                table: "Proposta");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ClienteId",
                table: "Proposta",
                column: "ClienteId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_TemplateId",
                table: "Proposta",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Proposta_ClienteId",
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

            migrationBuilder.DropIndex(
                name: "IX_Proposta_TemplateId",
                table: "Proposta");

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_ClienteId",
                table: "Proposta",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_LiderPropostaId",
                table: "Proposta",
                column: "LiderPropostaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_LiderSolucaoId",
                table: "Proposta",
                column: "LiderSolucaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_MoedaId",
                table: "Proposta",
                column: "MoedaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proposta_TemplateId",
                table: "Proposta",
                column: "TemplateId",
                unique: true);
        }
    }
}

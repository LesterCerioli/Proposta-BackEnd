using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class proposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proposta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Titulo = table.Column<string>(nullable: true),
                    CustoTotal = table.Column<string>(nullable: true),
                    DataPropostaAlteracao = table.Column<DateTime>(nullable: false),
                    DataEnvioPerguntas = table.Column<DateTime>(nullable: false),
                    DataEnvioProposta = table.Column<DateTime>(nullable: false),
                    DataEncerramentoOportunidade = table.Column<DateTime>(nullable: false),
                    ObjetivoProposta = table.Column<DateTime>(nullable: false),
                    TempoDuracao = table.Column<int>(nullable: false),
                    PrecoTotal = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    LiderPropostaId = table.Column<int>(nullable: false),
                    LiderSolucaoId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    MoedaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposta_Recurso_LiderPropostaId",
                        column: x => x.LiderPropostaId,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposta_Recurso_LiderSolucaoId",
                        column: x => x.LiderSolucaoId,
                        principalTable: "Recurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposta_Moeda_MoedaId",
                        column: x => x.MoedaId,
                        principalTable: "Moeda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proposta_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proposta");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}

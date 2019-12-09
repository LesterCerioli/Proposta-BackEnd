using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class secaoarquivotagmap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecaoArquivoTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Tipo = table.Column<string>(nullable: true),
                    Chave = table.Column<string>(nullable: true),
                    Valor = table.Column<string>(nullable: true),
                    PropostaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecaoArquivoTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecaoArquivoTag_Proposta_PropostaId",
                        column: x => x.PropostaId,
                        principalTable: "Proposta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecaoArquivoTag_PropostaId",
                table: "SecaoArquivoTag",
                column: "PropostaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecaoArquivoTag");
        }
    }
}

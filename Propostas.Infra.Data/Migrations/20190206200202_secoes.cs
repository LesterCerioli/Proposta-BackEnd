using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class secoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Secao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Editavel",
                table: "Secao",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "LinguagemId",
                table: "Secao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Secao",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "Secao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublicoAlvoId",
                table: "Secao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoSecaoId",
                table: "Secao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracaoId",
                table: "Secao",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecaoArquivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    SecaoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Publicado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecaoArquivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecaoArquivo_Secao_SecaoId",
                        column: x => x.SecaoId,
                        principalTable: "Secao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Nome = table.Column<string>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    TipoTemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Template_TipoTemplate_TipoTemplateId",
                        column: x => x.TipoTemplateId,
                        principalTable: "TipoTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Secao_LinguagemId",
                table: "Secao",
                column: "LinguagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Secao_PublicoAlvoId",
                table: "Secao",
                column: "PublicoAlvoId");

            migrationBuilder.CreateIndex(
                name: "IX_Secao_TipoSecaoId",
                table: "Secao",
                column: "TipoSecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_SecaoArquivo_SecaoId",
                table: "SecaoArquivo",
                column: "SecaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Template_TipoTemplateId",
                table: "Template",
                column: "TipoTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Secao_Linguagem_LinguagemId",
                table: "Secao",
                column: "LinguagemId",
                principalTable: "Linguagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Secao_PublicoAlvo_PublicoAlvoId",
                table: "Secao",
                column: "PublicoAlvoId",
                principalTable: "PublicoAlvo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Secao_TipoSecao_TipoSecaoId",
                table: "Secao",
                column: "TipoSecaoId",
                principalTable: "TipoSecao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secao_Linguagem_LinguagemId",
                table: "Secao");

            migrationBuilder.DropForeignKey(
                name: "FK_Secao_PublicoAlvo_PublicoAlvoId",
                table: "Secao");

            migrationBuilder.DropForeignKey(
                name: "FK_Secao_TipoSecao_TipoSecaoId",
                table: "Secao");

            migrationBuilder.DropTable(
                name: "SecaoArquivo");

            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DropIndex(
                name: "IX_Secao_LinguagemId",
                table: "Secao");

            migrationBuilder.DropIndex(
                name: "IX_Secao_PublicoAlvoId",
                table: "Secao");

            migrationBuilder.DropIndex(
                name: "IX_Secao_TipoSecaoId",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "Editavel",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "LinguagemId",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "PublicoAlvoId",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "TipoSecaoId",
                table: "Secao");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "Secao");
        }
    }
}

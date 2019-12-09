using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class tag_map : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecaoArquivoTag_Proposta_PropostaId",
                table: "SecaoArquivoTag");

            migrationBuilder.DropColumn(
                name: "Chave",
                table: "SecaoArquivoTag");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "SecaoArquivoTag");

            migrationBuilder.RenameColumn(
                name: "PropostaId",
                table: "SecaoArquivoTag",
                newName: "TagId");

            migrationBuilder.RenameIndex(
                name: "IX_SecaoArquivoTag_PropostaId",
                table: "SecaoArquivoTag",
                newName: "IX_SecaoArquivoTag_TagId");

            migrationBuilder.AddColumn<int>(
                name: "SecaoArquivoId",
                table: "SecaoArquivoTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropostaId",
                table: "PropostaTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecaoArquivoTagId",
                table: "PropostaTag",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecaoTagId",
                table: "PropostaTag",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "PropostaTag",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    Chave = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecaoArquivoTag_SecaoArquivoId",
                table: "SecaoArquivoTag",
                column: "SecaoArquivoId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaTag_PropostaId",
                table: "PropostaTag",
                column: "PropostaId");

            migrationBuilder.CreateIndex(
                name: "IX_PropostaTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Chave",
                table: "Tag",
                column: "Chave",
                unique: true,
                filter: "[Chave] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_Proposta_PropostaId",
                table: "PropostaTag",
                column: "PropostaId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId",
                principalTable: "SecaoArquivoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SecaoArquivoTag_SecaoArquivo_SecaoArquivoId",
                table: "SecaoArquivoTag",
                column: "SecaoArquivoId",
                principalTable: "SecaoArquivo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecaoArquivoTag_Tag_TagId",
                table: "SecaoArquivoTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_Proposta_PropostaId",
                table: "PropostaTag");

            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.DropForeignKey(
                name: "FK_SecaoArquivoTag_SecaoArquivo_SecaoArquivoId",
                table: "SecaoArquivoTag");

            migrationBuilder.DropForeignKey(
                name: "FK_SecaoArquivoTag_Tag_TagId",
                table: "SecaoArquivoTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_SecaoArquivoTag_SecaoArquivoId",
                table: "SecaoArquivoTag");

            migrationBuilder.DropIndex(
                name: "IX_PropostaTag_PropostaId",
                table: "PropostaTag");

            migrationBuilder.DropIndex(
                name: "IX_PropostaTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.DropColumn(
                name: "SecaoArquivoId",
                table: "SecaoArquivoTag");

            migrationBuilder.DropColumn(
                name: "PropostaId",
                table: "PropostaTag");

            migrationBuilder.DropColumn(
                name: "SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.DropColumn(
                name: "SecaoTagId",
                table: "PropostaTag");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "PropostaTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "SecaoArquivoTag",
                newName: "PropostaId");

            migrationBuilder.RenameIndex(
                name: "IX_SecaoArquivoTag_TagId",
                table: "SecaoArquivoTag",
                newName: "IX_SecaoArquivoTag_PropostaId");

            migrationBuilder.AddColumn<string>(
                name: "Chave",
                table: "SecaoArquivoTag",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "SecaoArquivoTag",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SecaoArquivoTag_Proposta_PropostaId",
                table: "SecaoArquivoTag",
                column: "PropostaId",
                principalTable: "Proposta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

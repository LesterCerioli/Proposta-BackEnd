using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class base64_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId",
                principalTable: "SecaoArquivoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId",
                principalTable: "SecaoArquivoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

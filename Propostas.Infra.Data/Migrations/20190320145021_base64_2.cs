using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class base64_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.AlterColumn<int>(
                name: "SecaoArquivoTagId",
                table: "PropostaTag",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId",
                principalTable: "SecaoArquivoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag");

            migrationBuilder.AlterColumn<int>(
                name: "SecaoArquivoTagId",
                table: "PropostaTag",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PropostaTag_SecaoArquivoTag_SecaoArquivoTagId",
                table: "PropostaTag",
                column: "SecaoArquivoTagId",
                principalTable: "SecaoArquivoTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

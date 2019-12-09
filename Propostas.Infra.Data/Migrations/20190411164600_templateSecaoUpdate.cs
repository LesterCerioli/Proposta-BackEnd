using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class templateSecaoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSecao_Secao_SecaoId",
                table: "TemplateSecao");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSecao_Template_TemplateId",
                table: "TemplateSecao");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSecao_Secao_SecaoId",
                table: "TemplateSecao",
                column: "SecaoId",
                principalTable: "Secao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSecao_Template_TemplateId",
                table: "TemplateSecao",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSecao_Secao_SecaoId",
                table: "TemplateSecao");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateSecao_Template_TemplateId",
                table: "TemplateSecao");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSecao_Secao_SecaoId",
                table: "TemplateSecao",
                column: "SecaoId",
                principalTable: "Secao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateSecao_Template_TemplateId",
                table: "TemplateSecao",
                column: "TemplateId",
                principalTable: "Template",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

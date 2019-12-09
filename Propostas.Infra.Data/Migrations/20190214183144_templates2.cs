using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class templates2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateSecao",
                table: "TemplateSecao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateSecao",
                table: "TemplateSecao",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSecao_TemplateId",
                table: "TemplateSecao",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateSecao",
                table: "TemplateSecao");

            migrationBuilder.DropIndex(
                name: "IX_TemplateSecao_TemplateId",
                table: "TemplateSecao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateSecao",
                table: "TemplateSecao",
                columns: new[] { "TemplateId", "SecaoId" });
        }
    }
}

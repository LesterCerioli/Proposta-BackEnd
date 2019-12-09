using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class templates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateSecao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    TemplateId = table.Column<int>(nullable: false),
                    SecaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSecao", x => new { x.TemplateId, x.SecaoId });
                    table.ForeignKey(
                        name: "FK_TemplateSecao_Secao_SecaoId",
                        column: x => x.SecaoId,
                        principalTable: "Secao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TemplateSecao_Template_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSecao_SecaoId",
                table: "TemplateSecao",
                column: "SecaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateSecao");
        }
    }
}

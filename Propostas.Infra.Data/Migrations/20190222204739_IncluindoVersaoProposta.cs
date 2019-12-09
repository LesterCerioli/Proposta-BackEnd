using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class IncluindoVersaoProposta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Codigo",
                table: "Proposta",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Versao",
                table: "Proposta",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Proposta");

            migrationBuilder.DropColumn(
                name: "Versao",
                table: "Proposta");
        }
    }
}

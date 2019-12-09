using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class proposta3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ObjetivoProposta",
                table: "Proposta",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ObjetivoProposta",
                table: "Proposta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

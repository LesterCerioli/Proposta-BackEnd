using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class Versaotemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Versao",
                table: "Template",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<Guid>(
                name: "codigo",
                table: "Template",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "codigo",
                table: "Template");

            migrationBuilder.AlterColumn<int>(
                name: "Versao",
                table: "Template",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}

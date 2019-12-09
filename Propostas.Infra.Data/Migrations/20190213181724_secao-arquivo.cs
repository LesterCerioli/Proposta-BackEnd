using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class secaoarquivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Arquivo",
                table: "SecaoArquivo");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "SecaoArquivo");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SecaoArquivo",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
            
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "SecaoArquivo",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "SecaoArquivo",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "SecaoArquivo",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "SecaoArquivo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "SecaoArquivo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "SecaoArquivo",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "SecaoArquivo",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Base64Arquivo",
                table: "SecaoArquivo",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Codigo",
                table: "SecaoArquivo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class secoesupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "SecaoArquivo",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "Base64Arquivo",
                table: "SecaoArquivo",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Codigo",
                table: "SecaoArquivo",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "SecaoArquivo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Arquivo",
                table: "SecaoArquivo");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "SecaoArquivo");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "SecaoArquivo");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "SecaoArquivo",
                newName: "Usuario");
        }
    }
}

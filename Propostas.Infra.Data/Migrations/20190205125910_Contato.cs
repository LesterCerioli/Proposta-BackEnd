using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class Contato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_TiposContato_TiposContatoId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_TiposContatoId",
                table: "Contato");

            migrationBuilder.DropColumn(
                name: "TiposContatoId",
                table: "Contato");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Funcao",
                table: "Contato",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contato",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Contato",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_TipoContatoId",
                table: "Contato",
                column: "TipoContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_TiposContato_TipoContatoId",
                table: "Contato",
                column: "TipoContatoId",
                principalTable: "TiposContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contato_TiposContato_TipoContatoId",
                table: "Contato");

            migrationBuilder.DropIndex(
                name: "IX_Contato_TipoContatoId",
                table: "Contato");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Funcao",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Celular",
                table: "Contato",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "TiposContatoId",
                table: "Contato",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contato_TiposContatoId",
                table: "Contato",
                column: "TiposContatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contato_TiposContato_TiposContatoId",
                table: "Contato",
                column: "TiposContatoId",
                principalTable: "TiposContato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

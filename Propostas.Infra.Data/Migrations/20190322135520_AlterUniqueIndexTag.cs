using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class AlterUniqueIndexTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tag_Chave",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Chave_Tipo",
                table: "Tag",
                columns: new[] { "Chave", "Tipo" },
                unique: true,
                filter: "[Chave] IS NOT NULL AND [Tipo] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tag_Chave_Tipo",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Chave",
                table: "Tag",
                column: "Chave",
                unique: true,
                filter: "[Chave] IS NOT NULL");
        }
    }
}

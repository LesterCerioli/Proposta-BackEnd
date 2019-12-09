using Microsoft.EntityFrameworkCore.Migrations;

namespace Propostas.Infra.Data.Migrations
{
    public partial class AlteringTypesPropostaCustoTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TempoDuracao",
                table: "Proposta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "PrecoTotal",
                table: "Proposta",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "CustoTotal",
                table: "Proposta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TempoDuracao",
                table: "Proposta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PrecoTotal",
                table: "Proposta",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "CustoTotal",
                table: "Proposta",
                nullable: true,
                oldClrType: typeof(decimal));
        }
    }
}

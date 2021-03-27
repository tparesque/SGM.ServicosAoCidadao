using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class AjusteCamposSolicitacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "SolicitacaoReparo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EstadoNome",
                table: "SolicitacaoReparo",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Solicitacao",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "EstadoNome",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Solicitacao");
        }
    }
}

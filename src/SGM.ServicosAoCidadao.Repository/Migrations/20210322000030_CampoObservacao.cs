using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class CampoObservacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "SolicitacaoIsencao",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "SolicitacaoIsencao");
        }
    }
}

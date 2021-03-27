using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class CampoJustificativaPrefeitura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JustificativaPrefeitura",
                table: "SolicitacaoIsencao",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JustificativaPrefeitura",
                table: "SolicitacaoIsencao");
        }
    }
}

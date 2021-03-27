using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class TabelaHistorico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoSolicitacao",
                columns: table => new
                {
                    HistoricoSolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioAlteracaoNome = table.Column<string>(type: "varchar(150)", nullable: false),
                    SituacaoId = table.Column<int>(type: "int", nullable: false),
                    SolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSolicitacao", x => x.HistoricoSolicitacaoId);
                    table.ForeignKey(
                        name: "FK_HistoricoSolicitacao_Situacao_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoSolicitacao_Solicitacao_SolicitacaoId",
                        column: x => x.SolicitacaoId,
                        principalTable: "Solicitacao",
                        principalColumn: "SolicitacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSolicitacao_SituacaoId",
                table: "HistoricoSolicitacao",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSolicitacao_SolicitacaoId",
                table: "HistoricoSolicitacao",
                column: "SolicitacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoSolicitacao");
        }
    }
}

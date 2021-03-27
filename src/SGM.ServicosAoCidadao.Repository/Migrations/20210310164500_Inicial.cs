using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Situacao",
                columns: table => new
                {
                    SituacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacao", x => x.SituacaoId);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    SolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoSolicitacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SituacaoAtualSituacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.SolicitacaoId);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Situacao_SituacaoAtualSituacaoId",
                        column: x => x.SituacaoAtualSituacaoId,
                        principalTable: "Situacao",
                        principalColumn: "SituacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoIsencao",
                columns: table => new
                {
                    SolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatriculaImovel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoIsencao", x => x.SolicitacaoId);
                    table.ForeignKey(
                        name: "FK_SolicitacaoIsencao_Solicitacao_SolicitacaoId",
                        column: x => x.SolicitacaoId,
                        principalTable: "Solicitacao",
                        principalColumn: "SolicitacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitacaoReparo",
                columns: table => new
                {
                    SolicitacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoReparo", x => x.SolicitacaoId);
                    table.ForeignKey(
                        name: "FK_SolicitacaoReparo_Solicitacao_SolicitacaoId",
                        column: x => x.SolicitacaoId,
                        principalTable: "Solicitacao",
                        principalColumn: "SolicitacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SituacaoAtualSituacaoId",
                table: "Solicitacao",
                column: "SituacaoAtualSituacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitacaoIsencao");

            migrationBuilder.DropTable(
                name: "SolicitacaoReparo");

            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Situacao");
        }
    }
}

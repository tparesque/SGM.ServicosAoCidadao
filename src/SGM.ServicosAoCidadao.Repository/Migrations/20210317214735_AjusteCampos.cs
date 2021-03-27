using Microsoft.EntityFrameworkCore.Migrations;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    public partial class AjusteCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Situacao_SituacaoAtualSituacaoId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_SituacaoAtualSituacaoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "SituacaoAtualSituacaoId",
                table: "Solicitacao");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "SolicitacaoReparo",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "SolicitacaoReparo",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "SolicitacaoReparo",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SolicitacaoReparo",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "SolicitacaoReparo",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "SolicitacaoReparo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MunicipioNome",
                table: "SolicitacaoReparo",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "SolicitacaoReparo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SituacaoId",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SituacaoId",
                table: "Solicitacao",
                column: "SituacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Situacao_SituacaoId",
                table: "Solicitacao",
                column: "SituacaoId",
                principalTable: "Situacao",
                principalColumn: "SituacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Situacao_SituacaoId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_SituacaoId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "MunicipioNome",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SolicitacaoReparo");

            migrationBuilder.DropColumn(
                name: "SituacaoId",
                table: "Solicitacao");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "SolicitacaoReparo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "SolicitacaoReparo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "SolicitacaoReparo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "SolicitacaoReparo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddColumn<int>(
                name: "SituacaoAtualSituacaoId",
                table: "Solicitacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SituacaoAtualSituacaoId",
                table: "Solicitacao",
                column: "SituacaoAtualSituacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Situacao_SituacaoAtualSituacaoId",
                table: "Solicitacao",
                column: "SituacaoAtualSituacaoId",
                principalTable: "Situacao",
                principalColumn: "SituacaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

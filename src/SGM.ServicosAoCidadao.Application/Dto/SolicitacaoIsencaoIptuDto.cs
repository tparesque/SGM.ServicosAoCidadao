using System;
using System.Collections.Generic;

namespace SGM.ServicosAoCidadao.Application.Dto
{
	public class SolicitacaoIsencaoIptuDto
	{
		public Guid SolicitacaoId { get; set; }
		public Guid UsuarioId { get; set; }
		public string UsuarioNome { get; set; }
		public string Observacao { get; set; }
		public string JustificativaPrefeitura { get; set; }
		public int SituacaoId { get; set; }
		public string SituacaoNome { get; set; }
		public string DataCadastro { get; set; }
		public string Matricula { get; set; }

		public List<HistoricoSolicitacaoDto> HistoricoSolicitacoes { get; set; } = new List<HistoricoSolicitacaoDto>();

	}
}

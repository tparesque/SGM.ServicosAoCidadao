using System;
using System.Collections.Generic;

namespace SGM.ServicosAoCidadao.Domain.Entities
{
	public class Solicitacao
	{       
		public Guid SolicitacaoId { get; set; }

		public TipoSolicitacaoEnum TipoSolicitacao { get; set; }
		public DateTime DataCadastro { get; set; }
		public Guid UsuarioId { get; set; }
		public string UsuarioNome { get; set; }
		public int SituacaoId { get; set; }
		public virtual Situacao SituacaoAtual { get; set; }
		public virtual List<HistoricoSolicitacao> HistoricoSolicitacoes { get; set; } = new List<HistoricoSolicitacao>();
			

		public void AtualizarSituacaoAtual(int situacaoId)
		{
			SituacaoId = situacaoId;
		}

		public void AdicionarHistorico(HistoricoSolicitacao historicoSolicitacao)
		{
			HistoricoSolicitacoes.Add(historicoSolicitacao);
		}
	}
}

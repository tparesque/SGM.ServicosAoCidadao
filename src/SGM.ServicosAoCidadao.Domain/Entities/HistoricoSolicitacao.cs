using System;

namespace SGM.ServicosAoCidadao.Domain.Entities
{
	public class HistoricoSolicitacao
	{
		public Guid HistoricoSolicitacaoId { get; set; }		
		public DateTime DataAlteracao { get; set; }
		public Guid UsuarioAlteracaoId { get; set; }
		public string UsuarioAlteracaoNome { get; set; }
		public int SituacaoId { get; set; }
		public virtual Situacao Situacao { get; set; }		
	}
}

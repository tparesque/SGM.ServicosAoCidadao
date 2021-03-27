namespace SGM.ServicosAoCidadao.Domain.Entities
{
	public class SolicitacaoIsencao : Solicitacao
	{
		public string MatriculaImovel { get; set; }
		public string Observacao { get; set; }
		public string JustificativaPrefeitura { get; set; }
	}
}

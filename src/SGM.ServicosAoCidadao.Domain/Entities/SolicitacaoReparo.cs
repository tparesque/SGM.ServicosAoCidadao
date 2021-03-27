namespace SGM.ServicosAoCidadao.Domain.Entities
{
	public class SolicitacaoReparo : Solicitacao
	{
		public string Logradouro { get; set; }
		public int Numero { get; set; }
		public string CEP { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public int MunicipioId { get; set; }
		public string MunicipioNome { get; set; }
		public int EstadoId { get; set; }
		public string EstadoNome { get; set; }
		public string Observacao { get; set; }
	}
}

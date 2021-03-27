using System;
using System.Collections.Generic;

namespace SGM.ServicosAoCidadao.Application.Dto
{
	public class SolicitarConcertoIluminacaoDto
	{
		public Guid SolicitacaoId { get; set; }
		public Guid UsuarioId { get; set; }
		public string UsuarioNome { get; set; }
		public string Observacao { get; set; }
		public int SituacaoId { get; set; }
		public string SituacaoNome { get; set; }		
		public string DataCadastro { get; set; }
		public string Logradouro { get; set; }
		public int Numero { get; set; }
		public string CEP { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public int MunicipioId { get; set; }
		public string MunicipioNome { get; set; }
		public int EstadoId { get; set; }
		public string EstadoNome { get; set; }
		public List<HistoricoSolicitacaoDto> HistoricoSolicitacoes { get; set; } = new List<HistoricoSolicitacaoDto>();
	}
}

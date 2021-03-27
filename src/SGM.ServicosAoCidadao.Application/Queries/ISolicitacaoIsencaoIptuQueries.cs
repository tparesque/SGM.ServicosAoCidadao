using SGM.ServicosAoCidadao.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Application.Queries
{
	public interface ISolicitacaoIsencaoIptuQueries
	{
		Task<IEnumerable<SolicitacaoIsencaoIptuDto>> ObterTodos();

	}
}

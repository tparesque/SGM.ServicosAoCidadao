using SGM.ServicosAoCidadao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Domain.Interfaces.Repository
{
	public interface ISolicitacaoIsencaoRepository : IRepository<SolicitacaoIsencao>
	{
		Task<SolicitacaoIsencao> ObterPorId(Guid solicitacaoId);
	}
}

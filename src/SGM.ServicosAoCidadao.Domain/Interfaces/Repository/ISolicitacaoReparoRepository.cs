using SGM.ServicosAoCidadao.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Domain.Interfaces.Repository
{
    public interface ISolicitacaoReparoRepository : IRepository<SolicitacaoReparo>
    {
        Task<SolicitacaoReparo> ObterPorId(Guid solicitacaoId);
    }
}

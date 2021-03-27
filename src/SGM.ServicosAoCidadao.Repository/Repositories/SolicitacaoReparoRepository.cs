using Microsoft.EntityFrameworkCore;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Repository.Repositories
{
    public class SolicitacaoReparoRepository : Repository<SolicitacaoReparo>, ISolicitacaoReparoRepository
    {
        public SolicitacaoReparoRepository(ServicosAoCidadaoContext context) : base(context)
        {            
        }

        public async Task<SolicitacaoReparo> ObterPorId(Guid solicitacaoId)
        {
            return await _context.Set<SolicitacaoReparo>()
                .Where(x => x.SolicitacaoId == solicitacaoId)
                .Include(x => x.HistoricoSolicitacoes)
                .Include(x => x.SituacaoAtual)
                .FirstOrDefaultAsync();
        }
    }
}

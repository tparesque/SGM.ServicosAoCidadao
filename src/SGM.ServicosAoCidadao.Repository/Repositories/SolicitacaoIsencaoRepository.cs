using Microsoft.EntityFrameworkCore;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Repository.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Repository.Repositories
{
    public class SolicitacaoIsencaoRepository : Repository<SolicitacaoIsencao>, ISolicitacaoIsencaoRepository
    {
        public SolicitacaoIsencaoRepository(ServicosAoCidadaoContext context) : base(context)
        {
        }

        public async Task<SolicitacaoIsencao> ObterPorId(Guid solicitacaoId)
        {
            return await _context.Set<SolicitacaoIsencao>()
                .Where(x => x.SolicitacaoId == solicitacaoId)
                .Include(x => x.HistoricoSolicitacoes)
                .Include(x => x.SituacaoAtual)
                .FirstOrDefaultAsync();
        }
    }
}

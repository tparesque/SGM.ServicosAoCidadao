using Microsoft.EntityFrameworkCore;
using SGM.ServicosAoCidadao.Domain.Entities;

namespace SGM.ServicosAoCidadao.Repository.Context
{
	public class ServicosAoCidadaoContext : DbContext
	{
		public DbSet<Solicitacao> Solicitacao { get; set; }
		public DbSet<SolicitacaoReparo> SolicitacaoReparo { get; set; }
		public DbSet<SolicitacaoIsencao> SolicitacaoIsencao { get; set; }
		public DbSet<HistoricoSolicitacao> HistoricoSolicitacao { get; set; }
		public DbSet<Situacao> Situacao { get; set; }

		public ServicosAoCidadaoContext(DbContextOptions<ServicosAoCidadaoContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServicosAoCidadaoContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

	}

}

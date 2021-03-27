using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.ServicosAoCidadao.Domain.Entities;

namespace SGM.ServicosAoCidadao.Repository.Mappings
{
	public class HistoricoSolicitacaoConfig : IEntityTypeConfiguration<HistoricoSolicitacao>
	{
		public void Configure(EntityTypeBuilder<HistoricoSolicitacao> builder)
		{
			builder.ToTable("HistoricoSolicitacao");

			builder.HasKey(x=> x.HistoricoSolicitacaoId);
			builder.Property(x => x.HistoricoSolicitacaoId).ValueGeneratedNever();

			builder.Property(x=> x.DataAlteracao);
			builder.Property(x=> x.UsuarioAlteracaoId);

			builder.Property(x => x.UsuarioAlteracaoNome)
			   .HasColumnType("varchar(150)")
			   .IsRequired();

			builder.HasOne(x => x.Situacao);			
		}
	}	
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.ServicosAoCidadao.Domain.Entities;
using System;

namespace SGM.ServicosAoCidadao.Repository.Mappings
{
	public class SolicitacaoConfig : IEntityTypeConfiguration<Solicitacao>
	{
		public void Configure(EntityTypeBuilder<Solicitacao> builder)
		{
			builder.ToTable("Solicitacao");

			builder.HasKey(x=> x.SolicitacaoId);

			builder.Property(x=> x.DataCadastro);
			builder.Property(x=> x.UsuarioId);

			builder.Property(x => x.UsuarioNome)
			   .HasColumnType("varchar(150)")
			   .IsRequired();

			builder.Property(x => x.TipoSolicitacao)
				.IsRequired()
				.HasMaxLength(50)
				.HasConversion(v => v.ToString(), v => (TipoSolicitacaoEnum)Enum.Parse(typeof(TipoSolicitacaoEnum), v));

			builder.HasOne(x => x.SituacaoAtual);

			builder
				.HasMany(x => x.HistoricoSolicitacoes)
				.WithOne()
				.HasForeignKey("SolicitacaoId"); 

		}
	}	
}

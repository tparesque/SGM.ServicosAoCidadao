using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.ServicosAoCidadao.Domain.Entities;
using System;

namespace SGM.ServicosAoCidadao.Repository.Mappings
{
	public class SolicitacaoIsencaoConfig : IEntityTypeConfiguration<SolicitacaoIsencao>
	{
		public void Configure(EntityTypeBuilder<SolicitacaoIsencao> builder)
		{
			builder.ToTable("SolicitacaoIsencao");

			builder.Property(s=> s.MatriculaImovel);
		}
	}	
}

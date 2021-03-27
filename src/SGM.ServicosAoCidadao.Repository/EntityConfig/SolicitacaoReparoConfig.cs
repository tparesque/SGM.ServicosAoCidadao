using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGM.ServicosAoCidadao.Domain.Entities;
using System;

namespace SGM.ServicosAoCidadao.Repository.Mappings
{
	public class SolicitacaoReparoConfig : IEntityTypeConfiguration<SolicitacaoReparo>
	{
		public void Configure(EntityTypeBuilder<SolicitacaoReparo> builder)
		{
			builder.ToTable("SolicitacaoReparo");

            builder.Property(x => x.Logradouro)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.Property(x => x.Bairro)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(x => x.Complemento)
               .HasColumnType("varchar(150)");

            builder.Property(s => s.Observacao)
                .HasColumnType("varchar(500)");

            builder.Property(x => x.MunicipioId)
               .IsRequired();

            builder.Property(x => x.MunicipioNome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(x => x.EstadoId)
               .IsRequired();

            builder.Property(x => x.EstadoNome)
               .HasColumnType("varchar(150)")
               .IsRequired();

        }
	}
}

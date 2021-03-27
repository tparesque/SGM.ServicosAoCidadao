﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SGM.ServicosAoCidadao.Repository.Context;

namespace SGM.ServicosAoCidadao.Repository.Migrations
{
    [DbContext(typeof(ServicosAoCidadaoContext))]
    [Migration("20210323140121_TabelaHistorico")]
    partial class TabelaHistorico
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.HistoricoSolicitacao", b =>
                {
                    b.Property<Guid>("HistoricoSolicitacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("SituacaoId")
                        .HasColumnType("int");

                    b.Property<Guid?>("SolicitacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsuarioAlteracaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioAlteracaoNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("HistoricoSolicitacaoId");

                    b.HasIndex("SituacaoId");

                    b.HasIndex("SolicitacaoId");

                    b.ToTable("HistoricoSolicitacao");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.Situacao", b =>
                {
                    b.Property<int>("SituacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SituacaoId");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", b =>
                {
                    b.Property<Guid>("SolicitacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int>("SituacaoId")
                        .HasColumnType("int");

                    b.Property<string>("TipoSolicitacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("SolicitacaoId");

                    b.HasIndex("SituacaoId");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoIsencao", b =>
                {
                    b.HasBaseType("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao");

                    b.Property<string>("MatriculaImovel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("SolicitacaoIsencao");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoReparo", b =>
                {
                    b.HasBaseType("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("EstadoNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("MunicipioNome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(500)");

                    b.ToTable("SolicitacaoReparo");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.HistoricoSolicitacao", b =>
                {
                    b.HasOne("SGM.ServicosAoCidadao.Domain.Entities.Situacao", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", null)
                        .WithMany("HistoricoSolicitacoes")
                        .HasForeignKey("SolicitacaoId");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", b =>
                {
                    b.HasOne("SGM.ServicosAoCidadao.Domain.Entities.Situacao", "SituacaoAtual")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SituacaoAtual");
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoIsencao", b =>
                {
                    b.HasOne("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", null)
                        .WithOne()
                        .HasForeignKey("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoIsencao", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoReparo", b =>
                {
                    b.HasOne("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", null)
                        .WithOne()
                        .HasForeignKey("SGM.ServicosAoCidadao.Domain.Entities.SolicitacaoReparo", "SolicitacaoId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SGM.ServicosAoCidadao.Domain.Entities.Solicitacao", b =>
                {
                    b.Navigation("HistoricoSolicitacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

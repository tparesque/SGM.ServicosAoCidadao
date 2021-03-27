using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SGM.ServicosAoCidadao.Api.Services;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Application.Handlers;
using SGM.ServicosAoCidadao.Core.Mediator;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Repository.Repositories;
using SGM.ServicosAoCidadao.Core.Usuario;

namespace SGM.ServicosAoCidadao.Api.Configurations
{
	public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<SolicitarIsencaoIptuCommand, ValidationResult>, SolicitarIsencaoIptuCommandHandler>();
            services.AddScoped<IRequestHandler<SolicitarConcertoIluminacaoCommand, ValidationResult>, SolicitarConcertoIluminacaoHandler>();

            services.AddScoped<IRequestHandler<IniciarAtendimentoSolicitacaoConcertoIluminacaoCommand, ValidationResult>, IniciarAtendimentoSolicitacaoConcertoIluminacaoHandler>();
            services.AddScoped<IRequestHandler<FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand, ValidationResult>, FinalizarAtendimentoSolicitacaoConcertoIluminacaoHandler>();
            services.AddScoped<IRequestHandler<DeleteSolicitacaoConcertoIluminacaoCommand, ValidationResult>, DeleteSolicitacaoConcertoIluminacaoHandler>();

            services.AddScoped<ISolicitacaoReparoRepository, SolicitacaoReparoRepository>();
            services.AddScoped<ISolicitacaoIsencaoRepository, SolicitacaoIsencaoRepository>();

            services.AddHostedService<SolicitacaoIsencaoIptuProcessadaIntegrationHandler>();
        }
    }
}

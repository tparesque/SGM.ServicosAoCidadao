using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SGM.ServicosAoCidadao.Core.MensagensIntegracao;
using SGM.ServicosAoCidadao.Core.MessageBus;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Core.Enumerators;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Api.Services
{
	public class SolicitacaoIsencaoIptuProcessadaIntegrationHandler : BackgroundService
	{
		private readonly IMessageBus _messageBus;
		private readonly IServiceProvider _serviceProvider;
		private ISolicitacaoIsencaoRepository _repository;

		public SolicitacaoIsencaoIptuProcessadaIntegrationHandler(IMessageBus messageBus, IServiceProvider serviceProvider)
		{
			_messageBus = messageBus;
			_serviceProvider = serviceProvider;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_messageBus.SubscribeAsync<IsencaoIptuProcessadoIntegrationEvent>(solicitacao => ProcessarSolicitacao(solicitacao));

			return Task.CompletedTask;
		}

		private async Task ProcessarSolicitacao(IsencaoIptuProcessadoIntegrationEvent integrationEvent)
		{
			Console.WriteLine("***** TESTE ***** SOLICITAÇÃO ISENÇÃO - " + integrationEvent.SituacaoSolicitacao);

			var scope = _serviceProvider.CreateScope();
			_repository = scope.ServiceProvider.GetRequiredService<ISolicitacaoIsencaoRepository>();

			var solicitacaoBanco = await _repository.FirstOrDefault(x => x.SolicitacaoId == integrationEvent.AggregateId);

			var historicoSolicitacao = new HistoricoSolicitacao()
			{
				HistoricoSolicitacaoId = Guid.NewGuid(),
				UsuarioAlteracaoId = solicitacaoBanco.UsuarioId,
				UsuarioAlteracaoNome = solicitacaoBanco.UsuarioNome,
				DataAlteracao = DateTime.Now,
				SituacaoId = solicitacaoBanco.SituacaoId
			};
			
			solicitacaoBanco.AdicionarHistorico(historicoSolicitacao);

			solicitacaoBanco.SituacaoId = integrationEvent.SituacaoSolicitacao == SituacaoSolicitacaoEnum.Deferido ? (int)ESituacao.DEFERIDO : (int)ESituacao.INDEFERIDO;
			solicitacaoBanco.JustificativaPrefeitura = integrationEvent.Justificativa;
			solicitacaoBanco.UsuarioNome = integrationEvent.UsuarioNome;
			solicitacaoBanco.UsuarioId = integrationEvent.UsuarioId;

			await _repository.Update(solicitacaoBanco);

			Console.WriteLine("***** TESTE ***** SOLICITAÇÃO ISENÇÃO FINALIZADA");
		}
	}
}

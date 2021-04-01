using FluentValidation.Results;
using MediatR;
using SGM.ServicosAoCidadao.Core.Mensagens;
using SGM.ServicosAoCidadao.Core.MensagensIntegracao;
using SGM.ServicosAoCidadao.Core.MessageBus;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Repository.Context;
using SGM.ServicosAoCidadao.Core.Enumerators;
using SGM.ServicosAoCidadao.Core.Usuario;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Application.Handlers
{
	public class SolicitarIsencaoIptuCommandHandler : CommandHandler, IRequestHandler<SolicitarIsencaoIptuCommand, ValidationResult>
	{
		private readonly IAspNetUser _user;
		private readonly IMessageBus _bus;
		private readonly ServicosAoCidadaoContext _context;

		public SolicitarIsencaoIptuCommandHandler(
			IAspNetUser user,
			IMessageBus bus,
			ServicosAoCidadaoContext context)
		{
			_user = user;
			_bus = bus;
			_context = context;
		}

		public async Task<ValidationResult> Handle(SolicitarIsencaoIptuCommand command, CancellationToken cancellationToken)
		{
			command.UsuarioId = _user.ObterUserId();
			command.UsuarioNome = _user.Name;

			if (!command.IndicaValido())
			{
				return command.ValidationResult;
			}

			if(_context.SolicitacaoIsencao.Any(x=> x.MatriculaImovel == command.Matricula))
			{
				//TODO: Colocar também na verificação acima: SITUAÇÃO 
				base.AdicionarErro("Já existe uma Solicitação de Isenção de IPTU para o imóvel informado.");
			}

			if(ExisteErro())
			{
				return base.ValidationResult;
			}

			var solicitacaoIsencao = new SolicitacaoIsencao()
			{
				SolicitacaoId = Guid.NewGuid(),
				DataCadastro = DateTime.Now,
				MatriculaImovel = command.Matricula,
				TipoSolicitacao = TipoSolicitacaoEnum.IsencaoIptu,
				SituacaoId = (int)ESituacao.SOLICITACAO_EFETUADA,
				UsuarioId = command.UsuarioId,
				UsuarioNome = command.UsuarioNome
			};

			try
			{
				_context.SolicitacaoIsencao.Add(solicitacaoIsencao);
				await _context.SaveChangesAsync();

				var solicitacaoEvent = new IsencaoIptuSolicitadoIntegrationEvent(solicitacaoIsencao.SolicitacaoId, solicitacaoIsencao.MatriculaImovel);
				await _bus.Publish(solicitacaoEvent);

			}
			catch (Exception e)
			{

				throw;
			}


			return base.ValidationResult;

		}
	}
}

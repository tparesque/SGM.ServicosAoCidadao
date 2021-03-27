using FluentValidation.Results;
using MediatR;
using SGM.ServicosAoCidadao.Core.Mensagens;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Domain.Entities;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using SGM.ServicosAoCidadao.Core.Enumerators;
using SGM.ServicosAoCidadao.Core.Usuario;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Application.Handlers
{
	public class SolicitarConcertoIluminacaoHandler : CommandHandler, IRequestHandler<SolicitarConcertoIluminacaoCommand, ValidationResult>
	{			
		private readonly ISolicitacaoReparoRepository _solicitacaoReparoRepository;
		private readonly IAspNetUser _user;

		public SolicitarConcertoIluminacaoHandler(ISolicitacaoReparoRepository solicitacaoReparoRepository, IAspNetUser user)
		{			
			_solicitacaoReparoRepository = solicitacaoReparoRepository;
			_user = user;
		}

		public async Task<ValidationResult> Handle(SolicitarConcertoIluminacaoCommand command, CancellationToken cancellationToken)
		{
			var usuarioId = _user.ObterUserId();
			var usuarioNome = _user.Name;

			if (!command.IndicaValido())
			{
				return command.ValidationResult;
			}	

			var solicitacaoReparo = new SolicitacaoReparo()
			{
				SolicitacaoId = Guid.NewGuid(),
				UsuarioId = usuarioId,
				UsuarioNome = usuarioNome,
				DataCadastro = DateTime.Now,				
				TipoSolicitacao = TipoSolicitacaoEnum.ReparoIluminacaoPublica,
				Logradouro = command.Logradouro,
				Numero = command.Numero,
				CEP = command.CEP,
				Bairro = command.Bairro,
				Complemento = command.Complemento,
				MunicipioId = command.MunicipioId,
				MunicipioNome = command.MunicipioNome,
				EstadoId = command.EstadoId,
				EstadoNome = command.EstadoNome,
				Observacao = command.Observacao,
				SituacaoId = (int)ESituacao.SOLICITACAO_EFETUADA
			};

			var historicoSolicitacao = new HistoricoSolicitacao()
			{
				HistoricoSolicitacaoId = Guid.NewGuid(),
				UsuarioAlteracaoId = usuarioId,
				UsuarioAlteracaoNome = usuarioNome,
				DataAlteracao = DateTime.Now,				
				SituacaoId = (int)ESituacao.SOLICITACAO_EFETUADA
			};

			solicitacaoReparo.AdicionarHistorico(historicoSolicitacao);

			await _solicitacaoReparoRepository.Create(solicitacaoReparo);						
			
			return base.ValidationResult;

		}
	}
}

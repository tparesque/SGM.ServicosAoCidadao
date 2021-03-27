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
	public class FinalizarAtendimentoSolicitacaoConcertoIluminacaoHandler : CommandHandler, IRequestHandler<FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand, ValidationResult>
	{			
		private readonly ISolicitacaoReparoRepository _solicitacaoReparoRepository;
		private readonly IAspNetUser _user;

		public FinalizarAtendimentoSolicitacaoConcertoIluminacaoHandler(ISolicitacaoReparoRepository solicitacaoReparoRepository, IAspNetUser user)
		{			
			_solicitacaoReparoRepository = solicitacaoReparoRepository;
			_user = user;
		}

		public async Task<ValidationResult> Handle(FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand command, CancellationToken cancellationToken)
		{
			if (!command.IndicaValido())
			{
				return command.ValidationResult;
			}				

			var solicitacao = await _solicitacaoReparoRepository.GetById(command.SolicitacaoId);
			solicitacao.AtualizarSituacaoAtual((int)ESituacao.CONCLUIDA);

			var usuarioId = _user.ObterUserId();
			var usuarioNome = _user.Name;

			var historicoSolicitacao = new HistoricoSolicitacao()
			{
				HistoricoSolicitacaoId = Guid.NewGuid(),
				UsuarioAlteracaoId = usuarioId,
				UsuarioAlteracaoNome = usuarioNome,
				DataAlteracao = DateTime.Now,
				SituacaoId = (int)ESituacao.CONCLUIDA
			};

			solicitacao.AdicionarHistorico(historicoSolicitacao);

			await _solicitacaoReparoRepository.Update(solicitacao);

			return base.ValidationResult;
		}
	}
}

using FluentValidation.Results;
using MediatR;
using SGM.ServicosAoCidadao.Core.Mensagens;
using SGM.ServicosAoCidadao.Application.Commands;
using SGM.ServicosAoCidadao.Domain.Interfaces.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Application.Handlers
{
	public class DeleteSolicitacaoConcertoIluminacaoHandler : CommandHandler, IRequestHandler<DeleteSolicitacaoConcertoIluminacaoCommand, ValidationResult>
	{			
		private readonly ISolicitacaoReparoRepository _solicitacaoReparoRepository;

		public DeleteSolicitacaoConcertoIluminacaoHandler(ISolicitacaoReparoRepository solicitacaoReparoRepository)
		{			
			_solicitacaoReparoRepository = solicitacaoReparoRepository;
		}

		public async Task<ValidationResult> Handle(DeleteSolicitacaoConcertoIluminacaoCommand command, CancellationToken cancellationToken)
		{
			if (!command.IndicaValido())
			{
				return command.ValidationResult;
			}				

			var solicitacao = await _solicitacaoReparoRepository.GetById(command.SolicitacaoId);
			await _solicitacaoReparoRepository.Remove(solicitacao);

			return base.ValidationResult;

		}
	}
}

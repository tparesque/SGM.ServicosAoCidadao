using FluentValidation;
using SGM.ServicosAoCidadao.Core.Mensagens;
using System;

namespace SGM.ServicosAoCidadao.Application.Commands
{
	public class FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand : Command
	{
		public Guid SolicitacaoId { get; set; }		

		public override bool IndicaValido()
		{
			base.ValidationResult = new FinalizarAtendimentoSolicitacaoConcertoIluminacaoValidation().Validate(this);

			return base.ValidationResult.IsValid;
		}

		public class FinalizarAtendimentoSolicitacaoConcertoIluminacaoValidation : AbstractValidator<FinalizarAtendimentoSolicitacaoConcertoIluminacaoCommand>
		{
			public FinalizarAtendimentoSolicitacaoConcertoIluminacaoValidation()
			{
				RuleFor(x => x.SolicitacaoId)
					.NotEmpty().WithMessage("Solicitação é obrigatório");
			}
		}
	}
}

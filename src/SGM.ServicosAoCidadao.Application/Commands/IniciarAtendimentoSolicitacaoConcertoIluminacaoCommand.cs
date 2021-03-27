using FluentValidation;
using SGM.ServicosAoCidadao.Core.Mensagens;
using System;

namespace SGM.ServicosAoCidadao.Application.Commands
{
	public class IniciarAtendimentoSolicitacaoConcertoIluminacaoCommand : Command
	{
		public Guid SolicitacaoId { get; set; }		

		public override bool IndicaValido()
		{
			base.ValidationResult = new IniciarAtendimentoSolicitacaoConcertoIluminacaoValidation().Validate(this);

			return base.ValidationResult.IsValid;
		}

		public class IniciarAtendimentoSolicitacaoConcertoIluminacaoValidation : AbstractValidator<IniciarAtendimentoSolicitacaoConcertoIluminacaoCommand>
		{
			public IniciarAtendimentoSolicitacaoConcertoIluminacaoValidation()
			{
				RuleFor(x => x.SolicitacaoId)
					.NotEmpty().WithMessage("Solicitação é obrigatório");
			}
		}
	}
}

using FluentValidation;
using SGM.ServicosAoCidadao.Core.Mensagens;
using System;

namespace SGM.ServicosAoCidadao.Application.Commands
{
	public class DeleteSolicitacaoConcertoIluminacaoCommand : Command
	{
		public Guid SolicitacaoId { get; set; }		

		public override bool IndicaValido()
		{
			base.ValidationResult = new DeleteSolicitacaoConcertoIluminacaoValidation().Validate(this);

			return base.ValidationResult.IsValid;
		}

		public class DeleteSolicitacaoConcertoIluminacaoValidation : AbstractValidator<DeleteSolicitacaoConcertoIluminacaoCommand>
		{
			public DeleteSolicitacaoConcertoIluminacaoValidation()
			{
				RuleFor(x => x.SolicitacaoId)
					.NotEmpty().WithMessage("Solicitação é obrigatório");
			}
		}
	}
}

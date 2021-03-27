using FluentValidation;
using SGM.ServicosAoCidadao.Core.Mensagens;
using System;

namespace SGM.ServicosAoCidadao.Application.Commands
{
	public class SolicitarIsencaoIptuCommand : Command
	{
		public string Matricula { get; set; }
		public Guid UsuarioId { get; set; }
		public string UsuarioNome { get; set; }
		public string Observacao { get; set; }

		public SolicitarIsencaoIptuCommand(string matricula, string observacao, string usuarioNome, Guid usuarioId)
		{
			Matricula = matricula;
			Observacao = observacao;
			UsuarioNome = usuarioNome;
			UsuarioId = usuarioId;
		}

		public override bool IndicaValido()
		{
			base.ValidationResult = new SolicitarIsencaoIptuValidation().Validate(this);

			return base.ValidationResult.IsValid;
		}

		public class SolicitarIsencaoIptuValidation : AbstractValidator<SolicitarIsencaoIptuCommand>
		{
			public SolicitarIsencaoIptuValidation()
			{
				RuleFor(x => x.Matricula)
					.NotEmpty().WithMessage("O campo Matrícula do Imóvel é de preenchimento obrigatório")
					.MaximumLength(30).WithMessage("O campo Matrícula do Imóvel não deve conter mais do que 30 caracteres");

				RuleFor(x => x.Observacao)
					.NotEmpty().WithMessage("O campo Observação é de preenchimento obrigatório");

				RuleFor(x => x.UsuarioNome)
					.NotEmpty().WithMessage("O Nome do Usuário que está solicitando a isenção é de preenchimento obrigatório");

				RuleFor(x => x.UsuarioId)
					.NotEmpty().WithMessage("O Identificador do Usuário que está solicitando a isenção é de preenchimento obrigatório");

			}
		}
	}
}

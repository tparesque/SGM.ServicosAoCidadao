using FluentValidation;
using SGM.ServicosAoCidadao.Core.Mensagens;

namespace SGM.ServicosAoCidadao.Application.Commands
{
	public class SolicitarConcertoIluminacaoCommand : Command
	{		
		public string Observacao { get; set; }
		public string Logradouro { get; set; }
		public int Numero { get; set; }
		public string CEP { get; set; }
		public string Bairro { get; set; }
		public string Complemento { get; set; }
		public int MunicipioId { get; set; }
		public string MunicipioNome { get; set; }
		public int EstadoId { get; set; }
		public string EstadoNome { get; set; }		

		public override bool IndicaValido()
		{
			base.ValidationResult = new SolicitarConcertoIluminacaoValidation().Validate(this);

			return base.ValidationResult.IsValid;
		}

		public class SolicitarConcertoIluminacaoValidation : AbstractValidator<SolicitarConcertoIluminacaoCommand>
		{
			public SolicitarConcertoIluminacaoValidation()
			{
				RuleFor(x => x.Logradouro)
					.NotEmpty().WithMessage("O campo Logradouro é de preenchimento obrigatório")
					.MaximumLength(30).WithMessage("O campo Logradouro não deve conter mais do que 150 caracteres");

				RuleFor(x => x.Numero)
					.NotEmpty().WithMessage("O campo Número é de preenchimento obrigatório");					

				RuleFor(x => x.CEP)
					.NotEmpty().WithMessage("O campo CEP é de preenchimento obrigatório")
					.MaximumLength(30).WithMessage("O campo CEP não deve conter mais do que 8 caracteres");

				RuleFor(x => x.Bairro)
					.NotEmpty().WithMessage("O campo Bairro é de preenchimento obrigatório")
					.MaximumLength(150).WithMessage("O campo Bairro não deve conter mais do que 150 caracteres");

				RuleFor(x => x.MunicipioId)
					.NotEmpty().WithMessage("O campo Município é de preenchimento obrigatório");

				RuleFor(x => x.MunicipioNome)
					.NotEmpty().WithMessage("O campo Município é de preenchimento obrigatório")
					.MaximumLength(150).WithMessage("O campo Município não deve conter mais do que 150 caracteres");

				RuleFor(x => x.EstadoId)
					.NotEmpty().WithMessage("O campo Estado é de preenchimento obrigatório");

				RuleFor(x => x.EstadoNome)
					.NotEmpty().WithMessage("O campo Estado é de preenchimento obrigatório")
					.MaximumLength(150).WithMessage("O campo Estado não deve conter mais do que 150 caracteres");

			}
		}
	}
}

using FluentValidation.Results;

namespace SGM.ServicosAoCidadao.Core.Mensagens
{
	public abstract class CommandHandler
	{
		protected ValidationResult ValidationResult;

		protected CommandHandler()
		{
			ValidationResult = new ValidationResult();
		}

		protected bool ExisteErro()
		{
			return ValidationResult.Errors.Count > 0;
		}

		protected void AdicionarErro(string mensagem)
		{
			ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
		}
	}
}

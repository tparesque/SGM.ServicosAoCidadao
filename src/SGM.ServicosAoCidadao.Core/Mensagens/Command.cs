﻿using FluentValidation.Results;
using MediatR;

namespace SGM.ServicosAoCidadao.Core.Mensagens
{
	public abstract class Command : IRequest<ValidationResult>
	{
		public ValidationResult ValidationResult { get; protected set; }

		public abstract bool IndicaValido();
	}
}

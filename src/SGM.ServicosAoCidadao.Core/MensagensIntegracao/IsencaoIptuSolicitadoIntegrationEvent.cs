using SGM.ServicosAoCidadao.Core.Mensagens;
using System;

namespace SGM.ServicosAoCidadao.Core.MensagensIntegracao
{
	public class IsencaoIptuSolicitadoIntegrationEvent : IntegrationEvent
	{
		public string MatriculaImovel { get; private set; }

		public IsencaoIptuSolicitadoIntegrationEvent(Guid solicitacaoId, string matriculaImovel)
		{
			base.AggregateId = solicitacaoId;
			MatriculaImovel = matriculaImovel;
		}

	}
}

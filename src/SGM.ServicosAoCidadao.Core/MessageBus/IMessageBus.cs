using SGM.ServicosAoCidadao.Core.Mensagens;
using System;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Core.MessageBus
{
	public interface IMessageBus : IDisposable
	{
		#region Padrão Publish/Subscribe

		Task Publish<T>(T message) where T : IntegrationEvent;

		void Subscribe<T>(Action<T> onMessage) where T : class;

		#endregion
	}
}

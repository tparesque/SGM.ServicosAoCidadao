using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGM.ServicosAoCidadao.Core.MessageBus;
using System;

namespace SGM.ServicosAoCidadao.Api.Configurations
{
	public static class MessageBusConfig
	{
		public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var connection = configuration?.GetSection("MessageQueueConnection")?["MessageBus"];
			if (string.IsNullOrEmpty(connection))
			{
				throw new ArgumentNullException();
			}

			services.AddSingleton<IMessageBus>(new MessageBus(connection));
		}
	}
}

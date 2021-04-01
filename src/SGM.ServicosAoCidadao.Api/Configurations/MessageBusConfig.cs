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
			services.Configure<RabbitMqConfigurations>(configuration.GetSection("MessageQueueConnection"));

			services.AddSingleton<IMessageBus, MessageBusRabbit>();
		}
	}
}

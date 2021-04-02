using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Core.MessageBus
{
	public class RabbitMqConfigurations
	{
		public string HostName { get; set; }
		public string QueueName { get; set; }
		public int Port { get; set; }
	}
}

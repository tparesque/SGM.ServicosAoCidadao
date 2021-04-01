﻿using EasyNetQ;
using Polly;
using RabbitMQ.Client.Exceptions;
using SGM.ServicosAoCidadao.Core.Mensagens;
using System;
using System.Threading.Tasks;

namespace SGM.ServicosAoCidadao.Core.MessageBus
{
	public class MessageBus : IMessageBus
	{
		private IBus _bus;
		private readonly string _connectionString;
		private IAdvancedBus _advancedBus;

		public bool IsConnected => _bus?.Advanced?.IsConnected ?? false;
		public IAdvancedBus AdvancedBus => _bus?.Advanced;

		public MessageBus(string connectionString)
		{
			_connectionString = connectionString;
			TryConnect();
		}

		#region Padrão Publish/Subscribe

		public async Task PublishAsync<T>(T message) where T : IntegrationEvent
		{
			TryConnect();
			await _bus.PubSub.PublishAsync(message);
		}

		public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
		{
			TryConnect();
			_bus.PubSub.SubscribeAsync(subscriptionId, onMessage);
		}


		#endregion

		#region Padrão Request/Response

		public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
			where TRequest : IntegrationEvent 
			where TResponse : ResponseMessage
		{
			TryConnect();
			return await _bus.Rpc.RequestAsync<TRequest, TResponse>(request);
		}

		public async Task<IDisposable> RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
			where TRequest : IntegrationEvent 
			where TResponse : ResponseMessage
		{
			TryConnect();
			return await _bus.Rpc.RespondAsync(responder);
		}


		#endregion

		#region Métodos Auxiliares

		private void TryConnect()
		{
			if (IsConnected) return;

			var politicaDeConexaoComRabbit = Policy.Handle<EasyNetQException>()
				.Or<BrokerUnreachableException>()
				.WaitAndRetry(3, tentativa => TimeSpan.FromSeconds(Math.Pow(2, tentativa)));

			politicaDeConexaoComRabbit.Execute(() =>
			{
				_bus = RabbitHutch.CreateBus(_connectionString);
				_advancedBus = _bus.Advanced;
				_advancedBus.Disconnected += OnDisconnect;
			});
		}

		private void OnDisconnect(object s, EventArgs e)
		{
			var policy = Policy.Handle<EasyNetQException>()
				.Or<BrokerUnreachableException>()
				.RetryForever();

			policy.Execute(TryConnect);
		}

		public void Dispose()
		{
			_bus.Dispose();
		}

		#endregion

	}
}

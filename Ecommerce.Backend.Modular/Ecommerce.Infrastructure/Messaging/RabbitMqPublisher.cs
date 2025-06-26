using Ecommerce.Application.DTOs.Events;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Ecommerce.Application.Interfaces.Messaging;

namespace Ecommerce.Infrastructure.Messaging
{
    public class RabbitMqPublisher : IEventPublisher
    {
        public readonly string _host;
        public readonly string _user;
        public readonly string _password;
        public RabbitMqPublisher(IConfiguration config)
        {
            _host = config["RabbitMq:Host"];
            _user = config["RabbitMq:Default_User"];
            _password = config["RabbitMq:Default_Pass"];


        }

        public async Task PublishAsync(OrderCreated orderCreatedDto)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _host,
                UserName = _user,
                Password = _password
            };

            using var connection =await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();


            await channel.QueueDeclareAsync(
                queue: "order-created-queue",
                durable: true,
                exclusive: false,
                autoDelete: false
                );

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(orderCreatedDto));

            var properties = new BasicProperties
            {
                ContentType = "application/json",
            };

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "order-created-queue",
                mandatory: false,
                body: body,
                basicProperties: properties
                );
        }

    }
}

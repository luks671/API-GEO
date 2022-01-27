using RabbitMQ.Client;
using System;
using System.Text;

namespace Rabbit
{
    public class Productor
    {
        public static void Enviar(string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conecction = factory.CreateConnection())
            {
                using (var channel = conecction.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "procesar", type: ExchangeType.Fanout);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "procesar", routingKey: "", basicProperties: null, body: body);

                    //Console.WriteLine($"[X] Sent {message}");

                }
            }
        }
    }
}

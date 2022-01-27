using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_GEO.Productor.Interface
{
    public class PendienteDeGeocodificar : IProductor
    {
        public void Enviar(string message)
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

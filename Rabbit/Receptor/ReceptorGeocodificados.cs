using Newtonsoft.Json;
using Rabbit.Interface;
using Rabbit.Persistencia;
using Rabbit.Persistencia.Entity;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbit
{
    public class ReceptorGeocodificados : IReceptor
    {
        private readonly ApplicationDbContext _context;

        public ReceptorGeocodificados(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Recibir()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var conecction = factory.CreateConnection())
            {
                using (var channel = conecction.CreateModel())
                {
                    //lee del exchange procesado los registros listos
                    channel.ExchangeDeclare(exchange: "procesado", type: ExchangeType.Fanout);

                    string queName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queName, exchange: "procesado", routingKey: "");
                    
                    Console.WriteLine("API-GEO Waiting for logs...");

                    var consumer = new EventingBasicConsumer(channel);
                    try
                    {
                        consumer.Received += (model, ea) =>
                        {
                            var body = ea.Body.ToArray();
                            string message = Encoding.UTF8.GetString(body);
                            Dictionary<string, string> geolocalizarJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);

                            #region actualiza entity
                            //Console.WriteLine($"[x] Received: {message}");
                            Geolocalizar geolocalizar = _context.Geolocalizar.Single(x => x.Id == int.Parse(geolocalizarJson["Id"]));
                            geolocalizar.Latitud = geolocalizarJson["Latitud"];
                            geolocalizar.Longitud = geolocalizarJson["Longitud"];
                            geolocalizar.Estado = "FINALIZADO";

                            _context.SaveChanges();

                            #endregion


                            //Confirma el ack para liberar el mensaje de la cola
                            //solo luego de geocodificar
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                        };
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }

                    //Se configura el autoack en manual para asegurarse de que el mensaje se procese
                    channel.BasicConsume(queue: queName, autoAck: false, consumer: consumer);


                    Console.WriteLine("Presione una tecla para salir...");

                    Console.ReadLine();
                }
            }

        }
    }
}

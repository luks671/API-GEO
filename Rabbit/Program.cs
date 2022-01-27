using Microsoft.Extensions.Configuration;
using Rabbit.Interface;
using Rabbit.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rabbit
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Config
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            string connection = configuration["ConnectionString"];
            #endregion

            ApplicationDbContext context = new ApplicationDbContext(connection);
            IReceptor receptor = new ReceptorGeocodificados(context);
            
            receptor.Recibir();
        }

        
    }
}

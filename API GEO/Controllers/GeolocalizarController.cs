using API_GEO.Models;
using API_GEO.Productor.Interface;
using Entidades.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistencia;
using System;
using System.Threading.Tasks;


namespace API_GEO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeolocalizarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IProductor productor;
        public GeolocalizarController(ApplicationDbContext context)
        {
            _context = context;
            productor = new PendienteDeGeocodificar();
        }

        // POST : /geolocalizar
        [HttpPost]
        public async Task<IActionResult> Post(GeolocalizarRequest request)
        {
            Geolocalizar geolocalizar = new Geolocalizar {
                Calle = request.Calle,
                Ciudad = request.Ciudad,
                Codigo_Postal = request.Codigo_Postal,
                Numero = request.Numero,
                Pais = request.Pais,
                Provincia = request.Provincia,
                Estado = "PROCESANDO"
            };

            _context.Geolocalizar.Add(geolocalizar);

            try
            {
                await _context.SaveChangesAsync();
                string json = JsonConvert.SerializeObject(geolocalizar);
                productor.Enviar(json);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
                        
            return Accepted(new GeolocalizarResponse { Id = geolocalizar.Id });
        }
    }
}

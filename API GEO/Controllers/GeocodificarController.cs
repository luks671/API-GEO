using API_GEO.Models;
using Entidades.Entity;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_GEO.Controllers
{
    [Route("")]
    [ApiController]
    public class GeocodificarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeocodificarController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /geocodificar?id
        [HttpGet("geocodificar")]
        public async Task<IActionResult> Get(int id)
        {
            Geolocalizar entity = await _context.Geolocalizar.FindAsync(id);
            GeocodificarResponse response;
            try
            {
                response = new GeocodificarResponse()
                {
                    Id = entity.Id,
                    Estado = entity.Estado,
                    Latitud = entity.Latitud,
                    Longitud = entity.Longitud
                };
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(response);
        }       

        
    }
}

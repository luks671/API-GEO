using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades.Entity
{
    public class Geolocalizar
    {
        public int Id { get; set; }        
        [Required]
        public string Calle { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Codigo_Postal { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}

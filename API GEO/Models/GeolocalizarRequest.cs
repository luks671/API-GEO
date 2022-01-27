using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_GEO.Models
{
    public class GeolocalizarRequest
    {
        [Required(ErrorMessage = "campo requerido")]
        public string Calle{ get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public int Numero{ get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Ciudad{ get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Codigo_Postal{ get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Provincia{ get; set; }

        [Required(ErrorMessage = "campo requerido")]
        public string Pais{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DespegarCore.Models
{
    public class Vuelos
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public int IDVuelo { get; set; }

        [Required]
        public string Origen { get; set; }

        [Required]
        public string Destino { get; set; }

        [Required]
        public DateTime? FechayHoraSalida { get; set; }              

        [Required]
        public string Clase { get; set; }

        [Required]
        public string Aerolinea { get; set; }

        [Required]
        public int Precio { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2023.Models
{
    public class Equipo
    {
     
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        [Display(Name ="Lista de jugadores")]
      
        public List<Jugador> Lista_jugadores { get; set; }
        //public int EstadoId { get; set; }

        //public Estado Estado { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha_creacion { get; set; }

    }
}

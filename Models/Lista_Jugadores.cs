using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fifa2023.Models
{
    public class Lista_Jugadores
    {

        public int Equipo_id { get; set; }
        public Equipo Equipo { get; set; }
        public string Nombre_Equipo { get; set; }

       
    }
}

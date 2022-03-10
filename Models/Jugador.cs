using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2023.Models
{
    public class Jugador
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Display(Name ="Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Nacimiento { get; set; }
        public string Pasaporte { get; set; }
        public string Direccion { get; set; }
        public char Sexo { get; set; }
        public int EquipoId { get; set; }
       
        public Equipo Equipo { get; set; }
        public int EstadoId { get; set; }

        public Estado Estado { get; set; }


    }
}

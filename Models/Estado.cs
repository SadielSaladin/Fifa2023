using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fifa2023.Models
{
    public class Estado
    {

        public int Id { get; set; }
        [Column("Nombre del estado")]
        public string Nombre_estado { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("Fecha de Creacion")]
        public DateTime Fecha_Creacion { get; set; }


    }
}

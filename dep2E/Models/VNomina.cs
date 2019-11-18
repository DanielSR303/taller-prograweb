using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dep2E.Models
{
    [MetadataType(typeof(VNomina))]
    public partial class Nomina
    {
        class VNomina
        {
            [DisplayName("Sueldo por día")]
            [Required]
            public double sueldo_por_dia { get; set; }
            [DisplayName("Días trabajados")]
            [Required]
            public int dias_trabajados { get; set; }
            [DisplayName("Sueldo quincenal")]
            [Required]
            public double sueldo_quincenal { get; set; }
            [DisplayName("Fecha")]
            [Required]
            public System.DateTime fecha { get; set; }
        }
    }

}
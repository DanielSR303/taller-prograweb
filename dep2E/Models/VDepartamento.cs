using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dep2E.Models
{
    [MetadataType(typeof(VDepartamento))]
    public partial class Departamento
    {
        class VDepartamento
        {
            [DisplayName("Departamento")]
            [Required]
            [StringLength(70)]
            public string nombre_Departamento { get; set; }
        }
    }

}
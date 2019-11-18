using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dep2E.Models
{
    [MetadataType(typeof(VEmpleado))]
    public partial class Empleado
    {
        class VEmpleado
        {
            [DisplayName("Departamento")]
            [Required]
            public int idDepartamento { get; set; }
            [DisplayName("Empleado")]
            [Required]
            [StringLength(100)]
            public string nombre_Empleado { get; set; }
        }

    }

}
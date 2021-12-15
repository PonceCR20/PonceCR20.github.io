using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatrimonioInventario.Models
{
    public class Ubicacion
    {
        [Key]
        public int UbicacionId { get; set; }

        public string NombreUbicacion { get; set; }

        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
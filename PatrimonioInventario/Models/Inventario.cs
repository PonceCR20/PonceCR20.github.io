using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PatrimonioInventario.Models
{
    public class Inventario
    {
        public Inventario()
        {
            Ubicacion = new Ubicacion();
        }

        [Key]
        public int Id { get; set; }

        public int UbicacionId { get; set; }
        [NotMapped]
        public Ubicacion Ubicacion { get; set; }

        public string NoControl { get; set; }

        public string Descripcion { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Serie { get; set; }

        public string Resguardante { get; set; }

        public string Color { get; set; }

        public string Placas { get; set; }

        public string Observaciones { get; set; }

        public string Imagen { get; set; }

        public DateTime Creado { get; set; }

        public bool Status { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
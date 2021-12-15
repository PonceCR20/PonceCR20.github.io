using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatrimonioInventario.Models
{
    public class Inmuebles
    {
        [Key]
        public int Id { get; set; }

        public string Colonia { get; set; }

        public string Ubicacion { get; set; }

        public string SuperficieTotal { get; set; }

        public string Destinado { get; set; }

        public string EstadoActualPredio { get; set; }

        public string Permuta { get; set; }

        public string Actas { get; set; }

        public string DonadaPermutaCons { get; set; }

        public string AreaDisponible { get; set; }

        public string Finca { get; set; }

        public string Escritura { get; set; }

        public string ValorCatastral { get; set; }

        public string Total { get; set; }

        public string TotalC_Donacion_Permuta { get; set; }

        public string ClaveCatastral { get; set; }

        public bool Status { get; set; }
    }
}
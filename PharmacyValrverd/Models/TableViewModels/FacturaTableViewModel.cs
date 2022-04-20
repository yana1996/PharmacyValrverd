using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.TableViewModels
{
    public class FacturaTableViewModel 
    {

        public int id { get; set; }
        public string numFactura { get; set; }
        public int idPaciente { get; set; }
        public int idMedico { get; set; }
        public string tipoFactura { get; set; } 
        public decimal totalFactura { get; set; }
        public decimal impuesto { get; set; }
        public decimal totaldeduccion { get; set; }
        public decimal porcentaje { get; set; }
        public string obsGeneral { get; set; }
        public string obsEspecifico { get; set; }
        public List<DetalleTableViewModel> detalle { get; set; } 

    }
}

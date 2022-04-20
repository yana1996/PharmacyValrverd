using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.TableViewModels
{
    public class DetalleTableViewModel
    {
        public int id { get; set; }
        public int idFactura { get; set; } 
        public int idPerfilExamen { get; set; } 
        public int cantidad { get; set; }
        public decimal precioUni { get; set; }
        public decimal total { get; set; }       
        public string entrega { get; set; }
         
    }
}

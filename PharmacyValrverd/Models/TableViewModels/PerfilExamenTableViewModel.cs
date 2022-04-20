using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.TableViewModels
{
    public class PerfilExamenTableViewModel 
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public Decimal precio { get; set; } 
    }
}

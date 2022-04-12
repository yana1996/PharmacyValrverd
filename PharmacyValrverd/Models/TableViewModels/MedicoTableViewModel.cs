using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.TableViewModels
{
    public class MedicoTableViewModel
    {

        public int id { get; set; }
        public string cedula { get; set; }
        public string numero { get; set; } 
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string sexo { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }
        public string oficina { get; set; }
    }
}

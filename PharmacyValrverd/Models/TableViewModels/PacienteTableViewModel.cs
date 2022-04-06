using System;

namespace PharmacyValrverd.Models.TableViewModels
{
    public class PacienteTableViewModel
    {
        public int id { get; set; }
        public string tipoId { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string correo { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }

        public int provincia { get; set; }
        public int canton { get; set; }
        public int distrito { get; set; }

        public string nomProvincia { get; set; }
        public string nomCanton { get; set; }
        public string nomDistrito { get; set; }

        public string direccion { get; set; }
        public string ocupacion { get; set; }
        public string lugarTrabajo { get; set; }
        public string oficina { get; set; }
        //public string observacionGeneral { get; set; }
        //public string observacionEspecifica { get; set; } 
    }
}

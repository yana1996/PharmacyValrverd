using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.ViewModels
{
    public class FacturaViewModel
    {
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdPerfilExamen { get; set; } 

        [Required()]
        [StringLength(1, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Tipo Ide:")]

        public string TipoIde { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacia.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula:")]

        public string Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre:")]

        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "1° Apellido:")]

        public string Apellido1 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "2° Apellido:")]

        public string Apellido2 { get; set; }

        [Required()]
        [StringLength(1, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Sexo:")]

        public string Sexo { get; set; }

        [Required()]
        [Display(Name = "F.Nacim:")]

        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La edad no puede estar vacia.")]
        [Display(Name = "Edad:")]

        public int Edad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre a facturar no puede estar vacio.")]
        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Facturar a:")]

        public string NomFactura { get; set; }

        [Required()]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "N° Factura:")]

        public string NumFactura { get; set; }

        [Required()]
        [Display(Name = "Médico:")]

        public string Medico { get; set; }

        [Required()]
        [Display(Name = "Tipo:")]

        public string TipoFactura { get; set; } 

        [Required()]
        [Display(Name = "Total:")]

        public decimal TotalFactura { get; set; }

        [Required()]
        [Display(Name = "Impuesto:")]

        public decimal Impuesto { get; set; }

        [Required()]
        [Display(Name = "Deducible:")]

        public decimal Deduccion { get; set; }

        [Display(Name = "Porcentaje:")]

        public decimal Porcentaje { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La observación general no puede estar vacia.")]
        [Display(Name = "Obs General:")]

        public string ObsGeneral { get; set; }

        [Display(Name = "Obs Específicas:")]

        public string ObsEspecifico { get; set; }

    }
}

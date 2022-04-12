using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.ViewModels
{
    public class MedicoViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacia.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula:")]
        public string Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "1° Apellido:")]
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "2° Apellido:")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacio.")]
        [EmailAddress]
        [Display(Name = "Correo:")]
        public string Correo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Celular:")]
        public string Celular { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Teléfono:")]
        public string Telefono { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Tel Oficina:")]
        public string Oficina { get; set; }

    }

    public class EditMedicoViewModel 
    {

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacia.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula:")]
        public string Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre:")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "1° Apellido:")]
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "2° Apellido:")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacio.")]
        [EmailAddress]
        [Display(Name = "Correo:")]
        public string Correo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Celular:")]
        public string Celular { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Teléfono:")]
        public string Telefono { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Tel Oficina:")]
        public string Oficina { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyValrverd.Models
{
    public class PacienteViewModel
    {
        [Required]
        [Display(Name = "Tipo Ide:")]
        public string TipoId { get; set; }

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
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "2° Apellido:")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Sexo:")]
        public string Sexo { get; set; }

        [Display(Name = "Fecha Naci:")]
        public DateTime FechaNacimiento { get; set; }

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


        [Required(AllowEmptyStrings = false, ErrorMessage = "Se debe seleccionar al menos una provincia.")]
        [Display(Name = "Provincia:")]
        public int Provincia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se debe seleccionar al menos un cantón.")]
        [Display(Name = "Cantón:")]
        public int Canton { get; set; } 

        [Required(AllowEmptyStrings = false, ErrorMessage = "Se debe seleccionar al menos un distrito.")]
        [Display(Name = "Distrito:")]
        public int Distrito { get; set; }

        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Dirección:")]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ocupacion no puede estar vacio.")]
        [StringLength(40, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Ocupación:")]
        public string Ocupacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El lugar de trabajo no puede estar vacio.")]
        [StringLength(40, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Dir Trabajo:")]

        public string LugarTrabajo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        [Display(Name = "Tel Oficina:")]
        public string Oficina { get; set; }

        //[StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        //[Display(Name = "Observación General:")]
        //public string ObservacionGeneral { get; set; }

        //[StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        //[Display(Name = "Observación Específica:")]
        //public string ObservacionEspecifica { get; set; } 

    }

    public class EditPacienteViewModel 
    {

        public int Id { get; set; }

        [Display(Name = "Tipo Ide")]
        public string TipoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacio.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "1° Apellido")]
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "2° Apellido")]
        public string SegundoApellido { get; set; }

        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Display(Name = "Fecha Naci")]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacio.")]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public string Celular { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public string Telefono { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La provincia no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El cantón no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cantón")]
        public string Canton { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El distrito no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La dirección no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ocupacion no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Ocupación")]
        public string Ocupacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El lugar de trabajo no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lugar Trabajo")]

        public string LugarTrabajo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public string Oficina { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "La observacion general no puede estar vacio.")]
        //[StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        //[Display(Name = "Observación General")]
        //public string ObservacionGeneral { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessage = "La observacion específica no puede estar vacio.")]
        //[StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        //[Display(Name = "Observación Específica")]
        //public string ObservacionEspecifica { get; set; }

    }
}

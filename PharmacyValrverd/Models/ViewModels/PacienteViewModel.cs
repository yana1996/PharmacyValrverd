using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyValrverd.Models
{
    public class PacienteViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "Tipo Ide")]
        public string TipoId { get; set; } 

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacio.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacio.")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Celular { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Telefono { get; set; } 

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Oficina { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ocupacion no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Ocupación")]
        public string Ocupacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El lugar de trabajo no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lugar Trabajo")]
        
        public string LugarTrabajo { get; set; }

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

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Observación General")]
        public string observacionGeneral { get; set; }

        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Observación Específica")]
        public string observacionEspecifica { get; set; } 

    }

    public class EditPacienteViewModel 
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo Ide")]
        public string TipoId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El primer apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El segundo apellido no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La cédula no puede estar vacio.")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El correo no puede estar vacio.")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Celular { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Telefono { get; set; }

        [RegularExpression(@"(\d{4})(\d{2})(\d{2})", ErrorMessage = "Se requiere un número válido")]
        public int Oficina { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La ocupacion no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Ocupación")]
        public string Ocupacion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El lugar de trabajo no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Lugar Trabajo")]

        public string LugarTrabajo { get; set; }

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

        [Required(AllowEmptyStrings = false, ErrorMessage = "La observacion general no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Observación General")]
        public string observacionGeneral { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La observacion específica no puede estar vacio.")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Observación Específica")]
        public string observacionEspecifica { get; set; }

    }
}

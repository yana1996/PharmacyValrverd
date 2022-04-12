using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyValrverd.Models.ViewModels
{
    public class PerfilExamenViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número no puede estar vacio.")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Required()]
        [Display(Name = "Tipo:")]
        public string Tipo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción no puede estar vacia.")]
        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }
    }

    public class EditPerfilExamenViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El número no puede estar vacio.")]
        [StringLength(10, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Required()]
        [Display(Name = "Tipo:")]
        public string Tipo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La descripción no puede estar vacia.")]
        [StringLength(150, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name = "Descripción:")]
        public string Descripcion { get; set; }
    }
}

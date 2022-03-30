using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PharmacyValrverd.Models
{
    public class ProvinciaViewModel
    {
        public int CodigoProvincia { get; set; }

        public string NumeroProvincia { get; set; }

        public string NombreProvincia { get; set; }

        public SelectList ProvinciaList { get; set; }

    }
}

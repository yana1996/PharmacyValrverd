using Microsoft.AspNetCore.Mvc.Rendering;

namespace PharmacyValrverd.Models.TableViewModels
{
	public class CantonViewModel
	{
		public int CodigoCanton { get; set; }
		public int CodigoProvincia { get; set; }

		public string NumeroCanton { get; set; }

		public string NombreCanton { get; set; }

		public SelectList CantonList { get; set; } 
	}
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace PharmacyValrverd.Models.TableViewModels
{
	public class DistritoViewModel
	{
		public int CodigoDistrito { get; set; }
		public int CodigoCanton { get; set; }		

		public string NumeroDistrito { get; set; }

		public string NombreDistrito { get; set; } 

		public SelectList DistritoList { get; set; }
	}
}

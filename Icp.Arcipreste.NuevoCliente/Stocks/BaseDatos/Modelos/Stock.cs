using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.Stocks.BaseDatos.Modelos
{
	public class Stock
	{
		[Key]
		public int ID_STOCK { get; set; }
		public int ID_ALMACEN { get; set; }
		public int ID_ARTICULO { get; set; }
		public int CANTIDAD { get; set; }

	}
}

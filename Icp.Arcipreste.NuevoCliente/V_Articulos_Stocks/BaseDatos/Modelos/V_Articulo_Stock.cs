using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos.Modelos
{
	public class V_Articulo_Stock
	{
		public int ID_ARTICULO { get; set; }
		public string ARTICULO { get; set; }
		public string DESCRIPCION { get; set; }
		public string FABRICANTE { get; set; }
		public decimal PESO { get; set; }
		public decimal LARGO { get; set; }
		public decimal ANCHO { get; set; }
		public decimal ALTO { get; set; }
		public decimal PRECIO { get; set; }
		public int ID_ESTADO_ARTICULO { get; set; }
		public int ID_STOCK { get; set; }
		public int ID_ALMACEN { get; set; }
		public int CANTIDAD { get; set; }
	}
}

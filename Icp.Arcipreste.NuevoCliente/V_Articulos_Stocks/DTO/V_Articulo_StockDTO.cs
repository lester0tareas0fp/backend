namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.DTO
{
	public class V_Articulo_StockDTO
	{
		public int id_articulo { get; set; }
		public string articulo { get; set; }
		public string descripcion { get; set; }
		public string fabricante { get; set; }
		public decimal peso { get; set; }
		public decimal largo { get; set; }
		public decimal ancho { get; set; }
		public decimal alto { get; set; }
		public decimal precio { get; set; }
		public int id_estado_articulo { get; set; }
		public int id_stock { get; set; }
		public int id_almacen { get; set; }
		public int cantidad { get; set; }
	}
}

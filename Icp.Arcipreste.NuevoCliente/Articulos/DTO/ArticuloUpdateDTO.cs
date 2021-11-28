namespace Icp.Arcipreste.NuevoCliente.Articulos.DTO
{
	public class ArticuloUpdateDTO
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
		public string nombre_imagen { get; set; }
		public string imagen { get; set; }
		public string formato { get; set; }
	}
}

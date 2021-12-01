using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos.Modelos
{
	public class Seccion_Pedido
	{
		[Key]
		public int ID_SECCION_PEDIDO { get; set; }
		public int ID_PEDIDO { get; set; }
		public int? ID_ARTICULO { get; set; }
		public int? ID_STOCK { get; set; }
		public int CANTIDAD { get; set; }
		public int ID_ESTADO_PEDIDO { get; set; }
	}
}

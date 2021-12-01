namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.DTO
{
	public class Seccion_PedidoDTO
	{
		public int id_seccion_pedido { get; set; }
		public int id_pedido { get; set; }
		public int id_articulo { get; set; }
		public int cantidad { get; set; }
		public int id_estado_pedido { get; set; }
	}
}

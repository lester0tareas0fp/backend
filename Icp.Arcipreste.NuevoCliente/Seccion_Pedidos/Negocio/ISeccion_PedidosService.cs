using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.Negocio
{
	public interface ISeccion_PedidosService
	{
		Task<List<Seccion_Pedido>> GetSeccionPedidos(int id_pedido);
	}
}

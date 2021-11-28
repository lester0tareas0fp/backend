using Icp.Arcipreste.NuevoCliente.Modelos;
using Icp.Arcipreste.NuevoCliente.Pedidos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Pedidos.DTO;

namespace Icp.Arcipreste.NuevoCliente.Pedidos.Negocio
{
	public interface IPedidosService
	{
		Task<RetcodeMensaje<Pedido>> AddPedido(PedidoDTO pedido);
		Task<RetcodeMensaje<PedidoSeccion>> AddSeccionPedido(PedidoSeccionDTO pedido);
	}
}

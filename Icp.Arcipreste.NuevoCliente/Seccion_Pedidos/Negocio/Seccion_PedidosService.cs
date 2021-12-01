using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos;
using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.DTO;
using Microsoft.EntityFrameworkCore;

namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.Negocio
{
	public class Seccion_PedidosService: ISeccion_PedidosService
	{
		private Seccion_PedidosDbContext seccion_pedidosCtx;

		public Seccion_PedidosService(Seccion_PedidosDbContext seccion_pedidosCtx)
		{
			this.seccion_pedidosCtx = seccion_pedidosCtx;
		}

		public async Task<List<Seccion_Pedido>> GetSeccionPedidos(int id_pedido)
		{
			return await seccion_pedidosCtx.Seccion_Pedido.Where(x => x.ID_PEDIDO == id_pedido).ToListAsync();
		}
	}
}

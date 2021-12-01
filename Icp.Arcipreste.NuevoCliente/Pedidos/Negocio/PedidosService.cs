using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Pedidos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Pedidos.DTO;
using Icp.Arcipreste.NuevoCliente.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Pedidos.Negocio
{
	public class PedidosService: IPedidosService
	{
		private PedidosDbContext pedidosCtx { get; set; }
		public PedidosService(PedidosDbContext pedidosCtx)
		{
			this.pedidosCtx = pedidosCtx;
		}

		public async Task<List<Pedido>> GetPedidos()
		{
			return await pedidosCtx.Pedido.ToListAsync();
		}

		public async Task<RetcodeMensaje<Pedido>> AddPedido(PedidoDTO pedido)
		{
			var ret = new RetcodeMensaje<Pedido>();
			ret.Dato = new Pedido();
			var invoker = 0;
			var retcode = 0;
			var id_pedido = 0;
			var usuario = "";
			var cultura = "es";
			var mensaje = "";

			pedidosCtx.PaCrearPedido(pedido.calle, pedido.numero, pedido.provincia, pedido.poblacion, pedido.codigo_postal, pedido.telefono, pedido.contacto, pedido.id_usuario, invoker, usuario, cultura, out id_pedido, out retcode, out mensaje);

			if (retcode != 10)
			{
				throw new Exception(mensaje);

			}

			ret.RetCode = retcode;	
			ret.Mensaje = mensaje;
			ret.Dato.ID_PEDIDO = id_pedido;

			return ret;
		}

		//
		public async Task<RetcodeMensaje<PedidoSeccion>> AddSeccionPedido(PedidoSeccionDTO pedido)
		{
			var ret = new RetcodeMensaje<PedidoSeccion>();
			ret.Dato = new PedidoSeccion();
			var invoker = 0;
			var retcode = 0;
			var id_seccion_pedido = 0;
			var usuario = "";
			var cultura = "es";
			var mensaje = "";

			pedidosCtx.PaSeccionPedido(pedido.id_pedido, pedido.id_articulo, pedido.cantidad, invoker, usuario, cultura, out id_seccion_pedido, out retcode, out mensaje);

			if (retcode != 10)
			{
				throw new Exception(mensaje);

			}

			ret.RetCode = retcode;
			ret.Mensaje = mensaje;
			ret.Dato.id_seccion_pedido = id_seccion_pedido;

			return ret;
		}

	}
}

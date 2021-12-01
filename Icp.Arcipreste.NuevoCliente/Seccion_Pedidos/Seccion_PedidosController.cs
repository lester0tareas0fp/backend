using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos
{
	[Route("[controller]")]
	public class Seccion_PedidosController: Controller
	{
		private readonly ISeccion_PedidosService _seccion_pedidoService;

		public Seccion_PedidosController(ISeccion_PedidosService seccion_pedidoService)
		{
			_seccion_pedidoService = seccion_pedidoService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Seccion_Pedido>>> GetSeccionPedidoId(int id_pedido)
		{
			try
			{
				var lista = await _seccion_pedidoService.GetSeccionPedidos(id_pedido);
				return Ok(lista);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

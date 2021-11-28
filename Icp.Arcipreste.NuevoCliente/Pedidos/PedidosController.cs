using Icp.Arcipreste.NuevoCliente.Pedidos.Negocio;
using Icp.Arcipreste.NuevoCliente.Pedidos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Icp.Arcipreste.NuevoCliente.Pedidos
{
	[Route("[controller]")]
	public class PedidosController: Controller
	{

		private readonly IPedidosService _pedidosService;

		public PedidosController(IPedidosService pedidosService)
		{
			_pedidosService = pedidosService;	
		}

		[HttpPost]
		[Route("crearPedido")]
		public async Task<ActionResult<string>> PostPedido([FromBody]PedidoDTO pedido)
		{
			try
			{
				var respuesta = await _pedidosService.AddPedido(pedido);

				return Ok(respuesta.Dato);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("crearSeccionPedido")]
		public async Task<ActionResult<string>> PostSeccionPedido([FromBody]PedidoSeccionDTO pedido)
		{
			try
			{
				var respuesta = await _pedidosService.AddSeccionPedido(pedido);

				return Ok(respuesta.Dato);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}

using Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.V_Articulos_Stocks.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stocks
{
	[Route("[controller]")]
	public class V_Articulos_StocksController: Controller
	{

		private readonly IV_Articulos_StocksService _v_articulos_stocksService;

		public V_Articulos_StocksController(IV_Articulos_StocksService v_articulos_stocksService)
		{
			_v_articulos_stocksService = v_articulos_stocksService;
		}

		[HttpGet]
		public async Task<ActionResult<List<V_Articulo_Stock>>> Get()
		{
			try
			{
				var lista = await _v_articulos_stocksService.GetArticulosStocks();
				return Ok(lista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("articulo")]
		public async Task<ActionResult<V_Articulo_Stock>> GetArtStock(int id_articulo)
		{

			try
			{
				var articulo = await _v_articulos_stocksService.GetArtDet(id_articulo);
				return Ok(articulo);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			//
			
		}

	}
}

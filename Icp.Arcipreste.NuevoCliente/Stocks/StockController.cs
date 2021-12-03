using Icp.Arcipreste.NuevoCliente.Stocks.DTO;
using Icp.Arcipreste.NuevoCliente.Stocks.Negocio;
using Icp.Arcipreste.NuevoCliente.Stocks.BaseDatos.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Icp.Arcipreste.NuevoCliente.Stocks
{
	[Route("[controller]")]
	public class StockController : Controller
	{
		private readonly IStockService _stockService;

		public StockController(IStockService stockService)
		{
			_stockService = stockService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Stock>>> StockArticulo(int id_articulo)
		{
			try
			{
				var lista = await _stockService.GetStockArticulo(id_articulo);
				return Ok(lista);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("almacen")]
		public async Task<ActionResult<string>> StockAlmacen(int id_stock)
		{
			try
			{
				var stock = await _stockService.GetAlmacen(id_stock);

				StockAlmacenDTO almacen = new StockAlmacenDTO(stock.ID_ALMACEN);
				
				return Ok(almacen);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet]
		[Route("parametros")]
        public async Task<ActionResult<string>> StockArticuloAlmacen(int id_articulo, int id_almacen)
        {
            try
            {
                var stock = await _stockService.GetStockArticuloAlmacen(id_articulo, id_almacen);
				StockCantidadDTO cantidad = new StockCantidadDTO(stock.CANTIDAD);
                return Ok(stock.CANTIDAD);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
		[Route("agregarStock")]
		public async Task<ActionResult<string>> ActualizarStock([FromBody]StockInsertDTO insertarStock)
		{
			try
			{
				await _stockService.AddStock(insertarStock);
				return Ok("Stock actualizado con éxito");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}

using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Modelos;
using Icp.Arcipreste.NuevoCliente.Stocks.DTO;
using Icp.Arcipreste.NuevoCliente.Stocks.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Stocks.Negocio
{
	public class StockService : IStockService
	{
		private StockDbContext stocksCtx;

		public StockService(StockDbContext stocksCtx)
		{
			this.stocksCtx = stocksCtx;
		}

		public async Task<List<Stock>> GetStockArticulo(int id_articulo)
		{
			try
			{
				var stocks = await stocksCtx.Stock.Where(x => x.ID_ARTICULO == id_articulo).ToListAsync();

				if (stocks == null)
				{
					throw new Exception("No existe creado en ningún almacén stock para ese artículo o el artículo no existe");
				}

				return stocks;

			}catch (Exception ex){
				throw new Exception(ex.Message);
			}
		}

		public async Task<Stock> GetStockArticuloAlmacen(int id_articulo, int id_almacen)
        {
			try
            {
				var stock = await stocksCtx.Stock.FirstOrDefaultAsync(x => (x.ID_ARTICULO == id_articulo) && (x.ID_ALMACEN == id_almacen));

				if (stock == null)
                {
					throw new Exception("No existe ningún stock para ese almacén y artículo");
                }

				return stock;

			}
			catch(Exception ex)
            {
				throw new Exception(ex.Message);
            }

        }

		public async Task<RetcodeMensaje<Stock>> AddStock(StockInsertDTO stockInsert)
		{
			var ret = new RetcodeMensaje<Stock>();
			var invoker = 0;
			var retcode = 0;
			var lang = "es";
			var usuario_r = "";
			var mensaje = "";

			//byte[] fichero = null;

			//fromba

			try
			{
				stocksCtx.PaInsertarStock(stockInsert.id_almacen, stockInsert.id_articulo, stockInsert.cantidad, invoker, usuario_r, lang, out retcode, out mensaje);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

			if(retcode != 10)
			{
				throw new Exception(mensaje);
			}

			ret.RetCode = retcode;
			ret.Mensaje = mensaje;

			return ret;

		}
	}
}

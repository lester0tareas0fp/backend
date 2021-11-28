using Icp.Arcipreste.NuevoCliente.Modelos;
using Icp.Arcipreste.NuevoCliente.Stocks.DTO;
using Icp.Arcipreste.NuevoCliente.Stocks.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Stocks.Negocio
{
	public interface IStockService
	{
		Task<List<Stock>> GetStockArticulo(int id_articulo);
		Task<Stock> GetStockArticuloAlmacen(int id_articulo, int id_almacen);

		Task<RetcodeMensaje<Stock>> AddStock(StockInsertDTO stockInsert);
	}
}

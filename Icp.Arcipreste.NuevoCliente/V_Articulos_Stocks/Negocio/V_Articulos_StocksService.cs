using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos;
using Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos.Modelos;
using Microsoft.Data.SqlClient;


namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stocks.Negocio
{
	public class V_Articulos_StocksService: IV_Articulos_StocksService
	{
		private V_Articulos_StocksDbContext v_articulos_stocksCtx { get; set; }
		public V_Articulos_StocksService(V_Articulos_StocksDbContext v_articulos_stocksCtx)
		{
			this.v_articulos_stocksCtx = v_articulos_stocksCtx;
		}

		public async Task<List<V_Articulo_Stock>> GetArticulosStocks()
		{
			return await v_articulos_stocksCtx.V_Articulo_Stock.ToListAsync();
		}

		public async Task<List<V_Articulo_Stock>> GetArtDet(int id_articulo)
		{
			return await v_articulos_stocksCtx.V_Articulo_Stock.Where(x => x.ID_ARTICULO == id_articulo).ToListAsync();
		}

	}
}

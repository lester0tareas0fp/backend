using Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stocks.Negocio
{
	public interface IV_Articulos_StocksService
	{
		Task<List<V_Articulo_Stock>> GetArticulosStocks();
		Task<List<V_Articulo_Stock>> GetArtDet(int id_articulo);
	}
}

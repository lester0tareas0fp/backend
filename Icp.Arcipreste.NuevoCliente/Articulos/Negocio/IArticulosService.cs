using Icp.Arcipreste.NuevoCliente.Articulos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Articulos.DTO;
using Icp.Arcipreste.NuevoCliente.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Articulos.Negocio
{
	public interface IArticulosService
	{
		Task<List<Articulo>> GetArticulos();
		Task<Articulo> GetArticulo(int id_articulo);

		Task<RetcodeMensaje<Articulo>> AddArticulo(ArticuloDTO articulo);
		Task<RetcodeMensaje<Articulo>> ArticuloUpdate(ArticuloUpdateDTO articulo);

		Task<RetcodeMensaje<Articulo>> ArticuloDelete(ArticuloMainDTO articulo);
	}
}

using Microsoft.AspNetCore.Mvc;
using Icp.Arcipreste.NuevoCliente.Articulos.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Articulos.DTO;
using Icp.Arcipreste.NuevoCliente.Articulos.Negocio;

namespace Icp.Arcipreste.NuevoCliente.Articulos
{
	[Route("[controller]")]
	public class ArticulosController : Controller
	{

		private readonly IArticulosService _articulosService;

		public ArticulosController(IArticulosService articulosService){
			_articulosService = articulosService;
		}

		[HttpGet]
		public async Task<ActionResult<List<Articulo>>> Get()
		{
			try
			{
				var lista = await _articulosService.GetArticulos();
				return Ok(lista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("articulo")]
		public async Task<ActionResult<Articulo>> GetArt(int id_articulo)
		{
			var articulo = await _articulosService.GetArticulo(id_articulo);
			return Ok(articulo);	
		}

		[HttpPost]
		[Route("crearArticulo")]
		public async Task<ActionResult<string>> Post([FromBody]ArticuloDTO dato)
		{
			try
			{
				var lista = await _articulosService.AddArticulo(dato);
				ArticuloNuevoCreadoDTO articuloNuevo = new ArticuloNuevoCreadoDTO(lista.Dato.ID_ARTICULO);

				return Ok(articuloNuevo);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("actualizarArticulo")]
		public async Task<ActionResult<string>> PostArticuloUpdate([FromBody] ArticuloUpdateDTO dato)
		{
			try
			{
				var respuesta = await _articulosService.ArticuloUpdate(dato);

				return Ok(respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}

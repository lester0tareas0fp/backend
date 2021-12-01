using Microsoft.AspNetCore.Mvc;
using Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Usuarios.DTO;
using Icp.Arcipreste.NuevoCliente.Usuarios.Negocio;

namespace Icp.Arcipreste.NuevoCliente.Usuarios
{
	[Route("[controller]")]
	public class UsuariosController : Controller
	{

		private readonly IUsuariosService _usuariosService;

		public UsuariosController(IUsuariosService usuariosService){
			_usuariosService = usuariosService;
		}

		[HttpGet]
		public async Task<ActionResult<List<UsuarioListaDTO>>> Get()
		{
			try
			{
				var lista = await _usuariosService.GetUsuarios();
				return Ok(lista);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("usuario")]
		public async Task<ActionResult<UsuarioListaDTO>> GetArt(int id_usuario)
		{
			var usuario = await _usuariosService.GetUsuario(id_usuario);
			return Ok(usuario);
		}

		[HttpPost]
		[Route("auth")]
		public async Task<ActionResult<string>> VerificarUsuarioAuth([FromBody]UsuarioEntradaAuthDTO dato)
		{
			try
			{
				var user = await _usuariosService.PostUsuarioVerificado(dato);

				UsuarioAuthDTO usuarioAuth = new UsuarioAuthDTO(user.USUARIO, user.ID_PERFIL, user.ID_USUARIO);
				
				return Ok(usuarioAuth);

			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("crearUsuario")]
		public async Task<ActionResult<string>> CrearUsuario([FromBody]UsuarioDTO dato)
		{
			try
			{
				await _usuariosService.AddUsuario(dato);
				return Ok("Usuario creado con éxito");
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("actualizarUsuario")]
		public async Task<ActionResult<string>> ActualizarUsuario([FromBody] UsuarioUpdateDTO dato)
		{
			try
			{
				await _usuariosService.UpdateUsuario(dato);
				return Ok("Usuario actualizado con éxito");
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		[Route("borrarUsuario")]
		public async Task<ActionResult<string>> PostArticuloDelete([FromBody] UsuarioMainDTO usuario)
		{
			try
			{
				var respuesta = await _usuariosService.UsuarioDelete(usuario);

				return Ok(respuesta);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}

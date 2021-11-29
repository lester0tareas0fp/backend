using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Usuarios.DTO;
using Icp.Arcipreste.NuevoCliente.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Usuarios.Negocio
{
	public class UsuariosService : IUsuariosService
	{
		private UsuariosDbContext usuariosCtx { get; set; }
		public UsuariosService(UsuariosDbContext usuariosCtx)
		{
			this.usuariosCtx = usuariosCtx;
		}

		public async Task<List<UsuarioListaDTO>> GetUsuarios()
		{
			return await usuariosCtx.Usuario.Select(x => new UsuarioListaDTO(x.USUARIO, x.ID_USUARIO, x.EMAIL, x.ID_PERFIL) ).ToListAsync();
		}

		public async Task<Usuario> PostUsuarioVerificado(UsuarioEntradaAuthDTO dato)
		{
			try{
				var user = await usuariosCtx.Usuario.FirstOrDefaultAsync(x => (x.USUARIO == dato.usuario && x.PASS == dato.pass));
				
				if( user == null ){

					throw new Exception("No existe el usuario");
				}

				return user;

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public async Task<RetcodeMensaje<Usuario>> AddUsuario(UsuarioDTO usuario)
		{
			var ret = new RetcodeMensaje<Usuario>();
			var retcode = 0;
			var invoker = 0;
			var lang = "es";
			var usuario_r = "";
			var mensaje = "";

			usuariosCtx.PaCrearUsuario(usuario.usuario, usuario.pass, usuario.email, usuario.id_perfil, invoker, usuario_r, lang, out retcode, out mensaje);

			if(retcode != 10){
				throw new Exception(mensaje);
			}
			ret.RetCode = retcode;
			ret.Mensaje = mensaje;
			return ret;
		}

		public async Task<RetcodeMensaje<Usuario>> UsuarioDelete(UsuarioMainDTO usuario)
		{
			var ret = new RetcodeMensaje<Usuario>();
			var invoker = 0;
			var retcode = 0;
			var user = "";
			var leng = "es";
			var mensaje = "";
			usuariosCtx.PaBorrarUsuario(usuario.id_usuario, invoker, user, leng, out retcode, out mensaje);

			if (retcode != 10)
			{
				throw new Exception(mensaje);
			}
			ret.RetCode = retcode;
			ret.Mensaje = mensaje;

			return ret;
		}
	}
}

using Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Usuarios.DTO;
using Icp.Arcipreste.NuevoCliente.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Usuarios.Negocio
{
	public interface IUsuariosService
	{
		Task<List<Usuario>> GetUsuarios();
		Task<Usuario> PostUsuarioVerificado(UsuarioEntradaAuthDTO dato);

		Task<RetcodeMensaje<Usuario>> AddUsuario(UsuarioDTO usuario);
	}
}

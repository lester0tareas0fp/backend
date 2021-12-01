using Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos;
using Icp.Arcipreste.NuevoCliente.Usuarios.DTO;
using Icp.Arcipreste.NuevoCliente.Modelos;

namespace Icp.Arcipreste.NuevoCliente.Usuarios.Negocio
{
	public interface IUsuariosService
	{
		Task<List<UsuarioListaDTO>> GetUsuarios();
		Task<UsuarioListaDTO> GetUsuario(int id_usuario);
		Task<Usuario> PostUsuarioVerificado(UsuarioEntradaAuthDTO dato);

		Task<RetcodeMensaje<Usuario>> AddUsuario(UsuarioDTO usuario);
		Task<RetcodeMensaje<Usuario>> UpdateUsuario(UsuarioUpdateDTO usuario);

		Task<RetcodeMensaje<Usuario>> UsuarioDelete(UsuarioMainDTO usuario);
	}
}

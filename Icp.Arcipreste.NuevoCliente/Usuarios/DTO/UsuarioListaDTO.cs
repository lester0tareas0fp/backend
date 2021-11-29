namespace Icp.Arcipreste.NuevoCliente.Usuarios.DTO
{
	public class UsuarioListaDTO
	{
		public string usuario { get; set; }
		public int id_usuario { get; set; }
		public string email { get; set; }
		public int id_perfil { get; set; }

		public UsuarioListaDTO(string usuario, int id_usuario, string email, int id_perfil)
		{
			this.usuario = usuario;
			this.id_usuario = id_usuario;
			this.email = email;
			this.id_perfil = id_perfil;
		}
	}
}

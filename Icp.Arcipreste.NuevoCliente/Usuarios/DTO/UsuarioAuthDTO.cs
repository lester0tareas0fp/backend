namespace Icp.Arcipreste.NuevoCliente.Usuarios.DTO
{
	public class UsuarioAuthDTO
	{
		public string? usuario { get; set; }
		public int? id_perfil { get; set; }
		public int? id_usuario { get; set; }

		public UsuarioAuthDTO(string usuario, int id_perfil, int id_usuario)
		{
			this.id_perfil = id_perfil;
			this.usuario = usuario;
			this.id_usuario = id_usuario;
		}

		public UsuarioAuthDTO()
		{
			this.id_perfil = null;
			this.usuario = null;
			this.id_perfil = null;
		}
	}
}

namespace Icp.Arcipreste.NuevoCliente.Usuarios.DTO
{
	public class UsuarioAuthDTO
	{
		public string? usuario { get; set; }
		public int? id_perfil { get; set; }

		public UsuarioAuthDTO(string usuario, int id_perfil)
		{
			this.id_perfil = id_perfil;
			this.usuario = usuario;
		}

		public UsuarioAuthDTO()
		{
			this.id_perfil = null;
			this.usuario = null;
		}
	}
}

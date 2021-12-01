namespace Icp.Arcipreste.NuevoCliente.Usuarios.DTO
{
	public class UsuarioUpdateDTO
	{
		public int id_usuario { get; set; }
		public string usuario { get; set; }
		public string pass { get; set; }
		public string email { get; set; }
		public int id_perfil { get; set; }
	}
}

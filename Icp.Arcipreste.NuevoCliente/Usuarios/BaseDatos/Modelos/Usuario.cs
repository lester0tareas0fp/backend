using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos
{
	public class Usuario
	{
		[Key]	
		public int ID_USUARIO { get; set; }
		public string USUARIO { get; set; }
		public string PASS { get; set; }
		public string EMAIL { get; set; }
		public int ID_PERFIL {  get; set;}
	}
}

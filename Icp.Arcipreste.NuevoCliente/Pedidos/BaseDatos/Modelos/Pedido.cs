using System.ComponentModel.DataAnnotations;

namespace Icp.Arcipreste.NuevoCliente.Pedidos.BaseDatos.Modelos
{
	public class Pedido
	{
		[Key]
		public int ID_PEDIDO { get; set; }
		public int? ID_DIRECCION { get; set; }	
		public int? ID_USUARIO { get; set; }
		public DateTime FECHA { get; set; }
		public string CONTACTO { get; set; }
	}
}

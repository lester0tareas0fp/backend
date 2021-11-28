namespace Icp.Arcipreste.NuevoCliente.Modelos
{
	public class RetcodeMensaje<T>
	{
		public int RetCode { get; set; }
		public string Mensaje { get; set; }
		public T Dato { get; set; }
	}
}

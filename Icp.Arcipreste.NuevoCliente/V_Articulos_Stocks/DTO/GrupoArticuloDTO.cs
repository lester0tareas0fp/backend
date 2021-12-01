namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stocks.DTO
{
	public class GrupoArticuloDTO
	{
		public int grupo_id { get; set; }
		public int grupo_total {  get; set; }

		public GrupoArticuloDTO(int grupo_id, int grupo_total)
		{
			this.grupo_id = grupo_id;
			this.grupo_total = grupo_total;
		}
	}
}

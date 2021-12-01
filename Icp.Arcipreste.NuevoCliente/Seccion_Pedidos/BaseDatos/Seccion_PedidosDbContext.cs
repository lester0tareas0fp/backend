using Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Icp.Arcipreste.NuevoCliente.Seccion_Pedidos.BaseDatos
{
	public class Seccion_PedidosDbContext: DbContext
	{
		public Seccion_PedidosDbContext(DbContextOptions<Seccion_PedidosDbContext> options) : base(options) { }

		public DbSet<Seccion_Pedido> Seccion_Pedido { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Seccion_Pedido>(entity =>
			{
				entity.Property(e => e.ID_SECCION_PEDIDO)
					.IsUnicode(false);
			});
		}
	}
}

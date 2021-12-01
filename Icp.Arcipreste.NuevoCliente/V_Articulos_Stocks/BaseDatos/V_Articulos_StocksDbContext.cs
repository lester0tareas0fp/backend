using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente.V_Articulos_Stock.BaseDatos
{
	public class V_Articulos_StocksDbContext: DbContext
	{
		public V_Articulos_StocksDbContext(DbContextOptions<V_Articulos_StocksDbContext> options) : base(options) { }

		public DbSet<V_Articulo_Stock> V_Articulo_Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<V_Articulo_Stock>(
                    e =>
                    {
                        e.HasNoKey();
                        e.ToView("V_Articulo_Stock");
                        e.Property(v => v.ID_ARTICULO).HasColumnName("ID_ARTICULO");
                    });
        }

    }
}

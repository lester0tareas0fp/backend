using Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos
{
    public class ImagenesDbContext: DbContext
    {
        public ImagenesDbContext(DbContextOptions<ImagenesDbContext> options): base(options) { }

        public DbSet<Imagen> Imagen { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Imagen>(entity =>
			{
				entity.Property(e => e.ID_IMAGEN)
					.IsUnicode(false);
			});
		}


	}
}

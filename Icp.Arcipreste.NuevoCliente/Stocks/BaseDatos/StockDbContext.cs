using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Stocks.BaseDatos.Modelos;

namespace Icp.Arcipreste.NuevoCliente
{
	public class StockDbContext : DbContext
	{
		public StockDbContext(DbContextOptions<StockDbContext> options) : base(options) { }

		public DbSet<Stock> Stock { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Stock>(entity => 
			{
				entity.Property(e => e.ID_STOCK)
					.IsUnicode(false);
			});
		}

		public void PaInsertarStock(int id_almacen, int id_articulo,int cantidad, int? invoker, string usuarioR, string cultura, out int retCode, out string mensaje)
		{

			//PARAMETROS OUTPUT
			var paramRETCODE = new SqlParameter
			{
				ParameterName = "RETCODE",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.Int,
			};
			var paramMENSAJE = new SqlParameter
			{
				ParameterName = "MENSAJE",
				Size = 1000,
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.VarChar,
			};

			//PARAMETROS INPUT
			var sqlParameters = new[]
			{
				new SqlParameter
				{
					ParameterName = "ID_ALMACEN",
					Value = id_almacen,
					SqlDbType = System.Data.SqlDbType.Int,
				},
				new SqlParameter
				{
					ParameterName = "ID_ARTICULO",
					Value = id_articulo,
					SqlDbType = System.Data.SqlDbType.Int,
				},
				new SqlParameter
				{
					ParameterName = "CANTIDAD",
					Value = cantidad,
					SqlDbType = System.Data.SqlDbType.Int,
				},
				new SqlParameter
					{
						ParameterName = "CULTURA",
						Value = cultura,
						Size = 5,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
				new SqlParameter
					{
						ParameterName = "INVOKER",
						Value = invoker ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.Int,
					},
					new SqlParameter
					{
						ParameterName = "USUARIO_R",
						Size = 20,
						Value = usuarioR ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
				paramRETCODE,
				paramMENSAJE
			};

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_INSERTAR_STOCK] @ID_ALMACEN, @ID_ARTICULO, @CANTIDAD, @INVOKER, @USUARIO_R, @CULTURA, @RETCODE OUTPUT, @MENSAJE OUTPUT", sqlParameters);

			retCode = (int)paramRETCODE.Value;
			mensaje = (string)paramMENSAJE.Value;
		}

	}
}

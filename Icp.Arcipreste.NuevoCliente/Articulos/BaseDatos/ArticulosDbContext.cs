using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Articulos.BaseDatos.Modelos;
//using Icp.Arcipreste.NuevoCliente.Entidades;

namespace Icp.Arcipreste.NuevoCliente
{
	public class ArticulosDbContext : DbContext
	{
		public ArticulosDbContext(DbContextOptions<ArticulosDbContext> options): base(options) {}

		public DbSet<Articulo> Articulo { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Articulo>(entity =>
			{
				entity.Property(e => e.ID_ARTICULO)
					.IsUnicode(false);
			});


		}

		public void PaCrearArticulo(string articulo, string descripcion, string fabricante, decimal peso, decimal largo, decimal ancho, decimal alto, decimal precio, string nombre_imagen, string imagen, string formato, int? invoker, string usuario, string cultura, out int id_articulo, out int retCode, out string mensaje)
		{

			// PARAMETROS OUTPUT
			var paramID_ARTICULO = new SqlParameter
			{
				ParameterName = "ID_ARTICULO",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.Int,
			};
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


			// PARAMETROS INPUT
			var sqlParameters = new[]
			{
					new SqlParameter
					{
						ParameterName = "ARTICULO",
						Value = articulo,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "DESCRIPCION",
						Value = descripcion,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "FABRICANTE",
						Value = fabricante,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "PESO",
						Value = peso,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
					new SqlParameter
					{
						ParameterName = "LARGO",
						Value = largo,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
					new SqlParameter
					{
						ParameterName = "ANCHO",
						Value = ancho,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "ALTO",
						Value = alto,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "PRECIO",
						Value = precio,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "NOMBRE_IMAGEN",
						Value = nombre_imagen,
						Size = 500,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
						new SqlParameter
					{
						ParameterName = "IMAGEN",
						Value = imagen,
						Size = imagen.Length,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
						new SqlParameter
					{
						ParameterName = "FORMATO",
						Value = formato,
						Size = 10,
						SqlDbType = System.Data.SqlDbType.VarChar,
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
						ParameterName = "USUARIO",
						Size = 12,
						Value = usuario ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},

					paramID_ARTICULO,
					paramRETCODE,
					paramMENSAJE
			   };

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_CREAR_ARTICULO] @ARTICULO , @DESCRIPCION,	@FABRICANTE,	@PESO,	@LARGO,	@ANCHO,	@ALTO,	@PRECIO, @NOMBRE_IMAGEN, @IMAGEN, @FORMATO,	@INVOKER,	@USUARIO,	@CULTURA,	@ID_ARTICULO OUTPUT,	@RETCODE OUTPUT,	@MENSAJE OUTPUT", sqlParameters);

			id_articulo = (int)paramID_ARTICULO.Value;
			retCode = (int)paramRETCODE.Value;
			mensaje = (string)paramMENSAJE.Value;
		}

		public void PaActualizarArticulo(int id_articulo, string articulo, string descripcion, string fabricante, decimal peso, decimal largo, decimal ancho, decimal alto, decimal precio, string nombre_imagen, string imagen, string formato, int? invoker, string usuario, string cultura, out int retCode, out string mensaje)
		{

			// PARAMETROS OUTPUT
			
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


			// PARAMETROS INPUT
			var sqlParameters = new[]
			{
					new SqlParameter
					{
						ParameterName = "ID_ARTICULO",
						Value = id_articulo,
						SqlDbType = System.Data.SqlDbType.Int,
					},
					new SqlParameter
					{
						ParameterName = "ARTICULO",
						Value = articulo,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "DESCRIPCION",
						Value = descripcion,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "FABRICANTE",
						Value = fabricante,
						Size = 100,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "PESO",
						Value = peso,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
					new SqlParameter
					{
						ParameterName = "LARGO",
						Value = largo,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
					new SqlParameter
					{
						ParameterName = "ANCHO",
						Value = ancho,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "ALTO",
						Value = alto,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "PRECIO",
						Value = precio,
						SqlDbType = System.Data.SqlDbType.Decimal,
					},
						new SqlParameter
					{
						ParameterName = "NOMBRE_IMAGEN",
						Value = nombre_imagen,
						Size = 500,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
						new SqlParameter
					{
						ParameterName = "IMAGEN",
						Value = imagen,
						Size = imagen.Length,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
						new SqlParameter
					{
						ParameterName = "FORMATO",
						Value = formato,
						Size = 10,
						SqlDbType = System.Data.SqlDbType.VarChar,
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
						ParameterName = "USUARIO",
						Size = 12,
						Value = usuario ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},

					paramRETCODE,
					paramMENSAJE
			   };

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_ACTUALIZAR_ARTICULO] @ID_ARTICULO, @ARTICULO , @DESCRIPCION, @FABRICANTE, @PESO, @LARGO, @ANCHO, @ALTO, @PRECIO, @NOMBRE_IMAGEN, @IMAGEN, @FORMATO,	@INVOKER,	@USUARIO,	@CULTURA,	@RETCODE OUTPUT,	@MENSAJE OUTPUT", sqlParameters);

			retCode = (int)paramRETCODE.Value;
			mensaje = (string)paramMENSAJE.Value;
		}

		//Borrar Artículo

		public void PaBorrarArticulo(int id_articulo, int? invoker, string usuario, string cultura, out int retCode, out string mensaje)
		{

			// PARAMETROS OUTPUT
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


			// PARAMETROS INPUT
			var sqlParameters = new[]
			{
					new SqlParameter
					{
						ParameterName = "ID_ARTICULO",
						Value = id_articulo,
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
						ParameterName = "USUARIO",
						Size = 12,
						Value = usuario ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					paramRETCODE,
					paramMENSAJE
			   };

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_BORRAR_ARTICULO] @ID_ARTICULO, @INVOKER, @USUARIO,	@CULTURA, @RETCODE OUTPUT, @MENSAJE OUTPUT", sqlParameters);

			retCode = (int)paramRETCODE.Value;
			mensaje = (string)paramMENSAJE.Value;
		}


	}
}

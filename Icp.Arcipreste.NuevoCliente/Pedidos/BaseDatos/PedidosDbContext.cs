using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Pedidos.BaseDatos.Modelos;
using Microsoft.Data.SqlClient;

namespace Icp.Arcipreste.NuevoCliente
{
	public class PedidosDbContext : DbContext
	{
		public PedidosDbContext(DbContextOptions<PedidosDbContext> options): base(options){}

		public DbSet<Pedido> Pedido { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Pedido>(entity =>
			{
				entity.Property(e => e.ID_PEDIDO)
					.IsUnicode(false);
			});
		}

		public void PaCrearPedido(string calle, string numero, string provincia, string poblacion, string codigo_postal, int telefono, string contacto, int id_usuario, int? invoker, string usuario, string cultura, out int id_pedido, out int retCode, out string mensaje)
		{
			//PARAMETROS OUTPUT
			var paramID_PEDIDO = new SqlParameter
			{
				ParameterName = "ID_PEDIDO",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.Int,
			};
			var paramRETCODE = new SqlParameter
			{ 
				ParameterName = "RETCODE",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType=System.Data.SqlDbType.Int,
			};
			var parameMENSAJE = new SqlParameter
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
					ParameterName = "CALLE",
					Value = calle,
					Size = 30,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				new SqlParameter
				{
					ParameterName = "NUMERO",
					Value = numero,
					Size = 30,
					SqlDbType = System.Data.SqlDbType.VarChar,

				},
				new SqlParameter
				{
					ParameterName = "PROVINCIA",
					Value = provincia,
					Size = 42,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				new SqlParameter
				{
					ParameterName = "POBLACION",
					Value = poblacion,
					Size = 50,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				new SqlParameter
				{
					ParameterName = "CODIGO_POSTAL",
					Value = codigo_postal,
					Size = 5,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				new SqlParameter
				{
					ParameterName = "TELEFONO",
					Value = telefono,
					SqlDbType = System.Data.SqlDbType.Int,
				},
				new SqlParameter
				{
					ParameterName = "CONTACTO",
					Value = contacto,
					Size = 60,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				new SqlParameter
				{
					ParameterName = "ID_USUARIO",
					Value = id_usuario,
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
				paramID_PEDIDO,
				paramRETCODE,
				parameMENSAJE
			};

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_CREAR_PEDIDO] @CALLE, @NUMERO, @PROVINCIA, @POBLACION, @CODIGO_POSTAL, @TELEFONO, @CONTACTO, @ID_USUARIO, @INVOKER, @USUARIO, @CULTURA, @ID_PEDIDO OUTPUT, @RETCODE OUTPUT, @MENSAJE OUTPUT", sqlParameters);

			id_pedido = (int)paramID_PEDIDO.Value;
			retCode = (int)paramRETCODE.Value;	
			mensaje = (string)parameMENSAJE.Value;

		}


		//
		public void PaSeccionPedido( int id_pedido, int id_articulo, int cantidad, int? invoker, string usuario, string cultura, out int id_seccion_pedido, out int retCode, out string mensaje)
		{
			//PARAMETROS OUTPUT
			var paramID_SECCION_PEDIDO = new SqlParameter
			{
				ParameterName = "ID_SECCION_PEDIDO",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.Int,
			};
			var paramRETCODE = new SqlParameter
			{
				ParameterName = "RETCODE",
				Direction = System.Data.ParameterDirection.Output,
				SqlDbType = System.Data.SqlDbType.Int,
			};
			var parameMENSAJE = new SqlParameter
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
					ParameterName = "ID_PEDIDO",
					Value = id_pedido,
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
					ParameterName = "USUARIO",
					Size = 12,
					Value = usuario ?? Convert.DBNull,
					SqlDbType = System.Data.SqlDbType.VarChar,
				},
				paramID_SECCION_PEDIDO,
				paramRETCODE,
				parameMENSAJE
			};

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_SECCION_PEDIDO] @ID_PEDIDO, @ID_ARTICULO, @CANTIDAD, @INVOKER, @USUARIO, @CULTURA, @ID_SECCION_PEDIDO OUTPUT, @RETCODE OUTPUT, @MENSAJE OUTPUT", sqlParameters);

			id_seccion_pedido = (int)paramID_SECCION_PEDIDO.Value;
			retCode = (int)paramRETCODE.Value;
			mensaje = (string)parameMENSAJE.Value;

		}

	}
}

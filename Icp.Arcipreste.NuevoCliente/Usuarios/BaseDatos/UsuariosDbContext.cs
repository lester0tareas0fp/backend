using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Icp.Arcipreste.NuevoCliente.Usuarios.BaseDatos.Modelos;
//using Icp.Arcipreste.NuevoCliente.Entidades;

namespace Icp.Arcipreste.NuevoCliente
{
	public class UsuariosDbContext : DbContext
	{
		public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options): base(options) {}

		public DbSet<Usuario> Usuario { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Usuario>(entity =>
			{
				entity.Property(e => e.ID_USUARIO)
					.IsUnicode(false);
			});


		}

		public void PaCrearUsuario(string usuario, string pass, string email, int id_perfil, int? invoker, string usuarioR, string cultura, out int retCode, out string mensaje)
		{

			// PARAMETROS OUTPUT
			var paramIDUSUARIO = new SqlParameter
			{
				ParameterName = "ID_USUARIO",
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
						ParameterName = "USUARIO",
						Value = usuario,
						Size = 50,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "PASS",
						Value = pass,
						Size = 50,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "EMAIL",
						Value = email,
						Size = 30,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},
					new SqlParameter
					{
						ParameterName = "ID_PERFIL",
						Value = id_perfil,
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
						Size = 12,
						Value = usuarioR ?? Convert.DBNull,
						SqlDbType = System.Data.SqlDbType.VarChar,
					},

					paramIDUSUARIO,
					paramRETCODE,
					paramMENSAJE
			   };

			this.Database.ExecuteSqlRaw("EXEC [dbo].[PA_CREAR_USUARIO] @USUARIO , @PASS, @EMAIL, @ID_PERFIL, @INVOKER, @USUARIO_R, @CULTURA, @ID_USUARIO OUTPUT, @RETCODE OUTPUT,	@MENSAJE OUTPUT", sqlParameters);

			retCode = (int)paramRETCODE.Value;
			mensaje = (string)paramMENSAJE.Value;
		}
	}
}

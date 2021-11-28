using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Icp.Arcipreste.NuevoCliente.Articulos.Negocio;
using Icp.Arcipreste.NuevoCliente.Usuarios.Negocio;
using Icp.Arcipreste.NuevoCliente.Stocks.Negocio;
using Icp.Arcipreste.NuevoCliente.Imagenes.BaseDatos;
using Icp.Arcipreste.NuevoCliente.Imagenes.Negocio;
using Icp.Arcipreste.NuevoCliente.Pedidos.Negocio;

namespace Icp.Arcipreste.NuevoCliente
{
	public class Startup
	{

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{

			services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
					builder =>
					{
						builder.AllowAnyOrigin();
						builder.AllowAnyMethod();
						builder.AllowAnyHeader();
					});

			});

			services.AddControllers().AddJsonOptions(x =>
			   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

			services.AddDbContext<ArticulosDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

			services.AddScoped<IArticulosService, ArticulosService>();

			services.AddDbContext<UsuariosDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

			services.AddScoped<IUsuariosService, UsuariosService>();

			services.AddDbContext<StockDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

			services.AddScoped<IStockService, StockService>();

			services.AddDbContext<ImagenesDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

			services.AddScoped<IImagenesService, ImagenesService>();

			services.AddDbContext<PedidosDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

			services.AddScoped<IPedidosService, PedidosService>();



			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new() { Title = "Arcipreste1", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Configure the HTTP request pipeline.
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/vq/swagger.json", "Arcipreste1 v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseCors(MyAllowSpecificOrigins);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

	}
}

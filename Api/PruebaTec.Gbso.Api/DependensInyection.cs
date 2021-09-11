using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTec.Gbso.Bll;
using PruebaTec.Gbso.Bll.Interfaces;
using PruebaTec.Gbso.Dal;

namespace PruebaTec.Gbso.Api
{
	public static class DependensInyection
	{

		public static void AddServiceLayer(this IServiceCollection services)
		{
			services.AddTransient<IUsuarioService, UsuarioService>();
			services.AddTransient<ITipoIdentificacionService, TipoIdentificacionService>();

		}
		public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RootDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RootConection")));
		}
	}
}
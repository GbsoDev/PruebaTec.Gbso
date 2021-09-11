using Microsoft.Extensions.DependencyInjection;
using PruebaTec.Gbso.Web.Services;
using PruebaTec.Gbso.Web.Services.Interfaces;

namespace PruebaTec.Gbso.Web
{
	public static class DependensInyection
	{
		public static void AddServiceLayer(this IServiceCollection services)
		{
			services.AddTransient<IUsuarioService, UsuarioService>();
		}
	}
}
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Api
{
	[ApiController]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class GlobalErrorsController : Controller
	{
		public GlobalErrorsController()
		{
		}

		[HttpGet("/errors")]
		public async Task<IActionResult> HandleErrors()
		{
			var contextException = HttpContext.Features.Get<ExceptionHandlerFeature>();
			var exceptionType = contextException?.Error.GetType();
			return Problem("Error interno - Consulte con el administrador ");
		}
	}
}

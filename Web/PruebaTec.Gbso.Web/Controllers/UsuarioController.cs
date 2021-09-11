using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTec.Gbso.Web.Models;
using PruebaTec.Gbso.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Web.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuarioService UsuarioService;

		public UsuarioController(IUsuarioService usuarioService)
		{
			this.UsuarioService = usuarioService;
		}

		public ActionResult Usuarios()
		{
			return View();
		}

		public async Task<ActionResult> Usuario(int id)
		{
			var usuario = await UsuarioService.ConsultarAsync(id);
			return View(usuario);
		}

		public async Task<ActionResult> Crear(UsuarioModel usuarioModel)
		{
			await UsuarioService.RegistrarAsync(usuarioModel);
			return View();
		}

		public async Task<ActionResult> Editar(int id)
		{
			return await Usuario(id);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public Task<ActionResult> Editar(int id, IFormCollection collection)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult> Eliminar(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public Task<ActionResult> Eliminar(int id, IFormCollection collection)
		{
			throw new NotImplementedException();
		}
	}
}

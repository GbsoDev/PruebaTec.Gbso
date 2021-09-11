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
	public class UsuariosController : Controller
	{
		private readonly IUsuarioService UsuarioService;

		public UsuariosController(IUsuarioService usuarioService)
		{
			this.UsuarioService = usuarioService;
		}

		public async Task<ActionResult> Index()
		{
			var usuarios = await UsuarioService.ConsultarAsync();
			return View(usuarios);
		}

		public async Task<PartialViewResult> Usuario(int id)
		{
			var usuario = await UsuarioService.ConsultarAsync(id);
			return PartialView(usuario);
		}

		public async Task<PartialViewResult> Crear(UsuarioModel usuarioModel)
		{
			await UsuarioService.RegistrarAsync(usuarioModel);
			return PartialView();
		}

		public async Task<PartialViewResult> Editar(int id)
		{
			return await Usuario(id);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public Task<PartialViewResult> Editar(int id, IFormCollection collection)
		{
			throw new NotImplementedException();
		}

		public Task<PartialViewResult> Eliminar(int id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public Task<PartialViewResult> Eliminar(int id, IFormCollection collection)
		{
			throw new NotImplementedException();
		}
	}
}

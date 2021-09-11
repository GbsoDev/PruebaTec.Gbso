using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTec.Gbso.Bll.Interfaces;
using PruebaTec.Gbso.Dtos;
using PruebaTec.Gbso.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Api
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private readonly IUsuarioService usuarioService;
		private readonly IMapper mapper;

		public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
		{
			this.usuarioService = usuarioService;
			this.mapper = mapper;
		}

		[HttpPost()]
		public async Task<int> PostAsync([FromBody] UsuarioDto usuarioDto)
		{
			var usuario = mapper.Map<UsuarioModel>(usuarioDto);
			return (await usuarioService.AddAsync(usuario)).Id;
		}

		[HttpGet]
		public async Task<IEnumerable<UsuarioDto>> GetAsync()
		{
			var usuarios = await usuarioService.GetAllAsync();
			return mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
		}

		[HttpGet("{id}")]
		public async Task<UsuarioDto> GetAsync(int id)
		{
			var usuario = await usuarioService.FindAsync(id);
			return mapper.Map<UsuarioDto>(usuario);
		}

		[HttpPut("{id}")]
		public async Task PutAsync(int id, [FromBody] UsuarioDto usuarioDto)
		{
			var usuario = mapper.Map<UsuarioModel>(usuarioDto);
			await usuarioService.UpdateAsync(usuario, id);
		}

		[HttpDelete("{id}")]
		public async Task DeleteAsync(int id)
		{
			await usuarioService.RemoveAsync(id);
		}
	}
}

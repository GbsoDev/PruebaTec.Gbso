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
	public class TiposIdentificacionController : ControllerBase
	{
		private readonly ITipoIdentificacionService tiposIdentificacionService;
		private readonly IMapper mapper;

		public TiposIdentificacionController(ITipoIdentificacionService tipoIdentificacionService, IMapper mapper)
		{
			this.tiposIdentificacionService = tipoIdentificacionService;
			this.mapper = mapper;
		}

		[HttpGet()]
		public async Task<IEnumerable<TipoIdentificacionDto>> GetAsync()
		{
			var tiposIdentificacion = await tiposIdentificacionService.GetAllAsync();
			return mapper.Map<IEnumerable<TipoIdentificacionDto>>(tiposIdentificacion);
		}

		[HttpGet("{id}")]
		public async Task<TipoIdentificacionDto> GetAsync(int id)
		{
			var tipoIdentificacion = await tiposIdentificacionService.FindAsync(id);
			return mapper.Map<TipoIdentificacionDto>(tipoIdentificacion);
		}
	}
}

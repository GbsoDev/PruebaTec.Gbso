using AutoMapper;
using PruebaTec.Gbso.Dtos;
using PruebaTec.Gbso.Models;
using System;
using System.Collections.Generic;

namespace PruebaTec.Gbso.Api.Mappers
{
	public class UsuarioProfile : Profile
	{
		public UsuarioProfile()
		{
			CreateMap<UsuarioModel, UsuarioDto>();
			CreateMap<UsuarioDto, UsuarioModel>();
			CreateMap<UsuarioModel, UsuarioModel>()
				.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
				.ForAllOtherMembers(ops => ops.Ignore());
		}
	}
}

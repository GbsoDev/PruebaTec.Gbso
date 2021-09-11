using AutoMapper;
using PruebaTec.Gbso.Dtos;
using PruebaTec.Gbso.Models;
using System.Collections.Generic;

namespace PruebaTec.Gbso.Api.Mappers
{
	public class TipoIdentificacionProfile : Profile
	{
		public TipoIdentificacionProfile()
		{
			CreateMap<TipoIdentificacionModel, TipoIdentificacionDto>();
			CreateMap<TipoIdentificacionDto, TipoIdentificacionModel>();
			CreateMap<TipoIdentificacionModel, TipoIdentificacionModel>()
				.ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
				.ForAllOtherMembers(ops => ops.Ignore());
		}
	}
}

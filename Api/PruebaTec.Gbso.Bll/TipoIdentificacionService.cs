using AutoMapper;
using PruebaTec.Gbso.Bll.Interfaces;
using PruebaTec.Gbso.Dal;
using PruebaTec.Gbso.Models;

namespace PruebaTec.Gbso.Bll
{
	public class TipoIdentificacionService : BaseService<TipoIdentificacionModel>, ITipoIdentificacionService
	{
		public TipoIdentificacionService(RootDbContext rootDbContext, IMapper mapper) : base(rootDbContext, mapper)
		{
		}
	}
}

using AutoMapper;
using PruebaTec.Gbso.Bll.Interfaces;
using PruebaTec.Gbso.Dal;
using PruebaTec.Gbso.Models;

namespace PruebaTec.Gbso.Bll
{
	public class UsuarioService: BaseService<UsuarioModel>, IUsuarioService
	{
		public UsuarioService(RootDbContext rootDbContext, IMapper mapper) : base (rootDbContext, mapper)
		{
		}
	}
}

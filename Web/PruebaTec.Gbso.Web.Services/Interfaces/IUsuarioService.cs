using PruebaTec.Gbso.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Web.Services.Interfaces
{
	public interface IUsuarioService
	{
		Task ActualizarAsync(UsuarioModel usuarioModel);
		Task<IEnumerable<UsuarioModel>> ConsultarAsync();
		Task<UsuarioModel> ConsultarAsync(int id);
		Task EliminarAsync(int id);
		Task<int> RegistrarAsync(UsuarioModel usuarioModel);
	}
}
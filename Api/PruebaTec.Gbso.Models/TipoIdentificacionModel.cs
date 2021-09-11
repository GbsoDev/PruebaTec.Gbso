using System.Collections.Generic;

namespace PruebaTec.Gbso.Models
{
	public class TipoIdentificacionModel
	{
		public TiposIdentificacionEnum Id { get; set; }
		public string Name { get; set; }
		public List<UsuarioModel> Usuarios { get; set; }
	}
}

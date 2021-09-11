using PruebaTec.Gbso.Models;

namespace PruebaTec.Gbso.Dtos
{
	public class UsuarioDto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public TiposIdentificacionEnum TipoIdentificacionId { get; set; }
		public string Contrasenia { get; set; }
		public string CorreoElectronico { get; set; }
	}
}

using System;
using System.Collections.Generic;

namespace PruebaTec.Gbso.Web.Models
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public TiposIdentificacionEnum TipoIdentificacionId { get; set; }
		public TipoIdentificacionModel TipoIdentificacion { get; set; }
		public string Contrasenia { get; set; }
		public string CorreoElectronico { get; set; }
	}
}

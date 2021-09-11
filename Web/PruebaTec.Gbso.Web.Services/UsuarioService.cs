using Flurl;
using Microsoft.Extensions.Configuration;
using PruebaTec.Gbso.Web.Services.Interfaces;
using PruebaTec.Gbso.Web.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Web.Services
{
	public class UsuarioService : BaseService, IUsuarioService
	{
		private readonly IConfiguration Configuration;

		public UsuarioService(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		protected override string UrlApi => Configuration.GetSection("UrlApi").Value;

		protected override string EndPoint => "Usuarios";

		public async Task<int> RegistrarAsync(UsuarioModel usuarioModel)
		{
			var url = BuildUrlApi();
			var client = new RestClient(url);
			var request = new RestRequest(Method.POST);
			request.AddJsonBody(JsonSerializer.Serialize(usuarioModel));
			IRestResponse response = await client.ExecuteAsync(request);
			return Read<int>(response);
		}

		public async Task<IEnumerable<UsuarioModel>> ConsultarAsync()
		{
			var url = BuildUrlApi();
			var client = new RestClient(url);
			var request = new RestRequest(Method.GET);
			IRestResponse response = await client.ExecuteAsync(request);
			return Read<IEnumerable<UsuarioModel>>(response);
		}

		public async Task<UsuarioModel> ConsultarAsync(int id)
		{
			var url = BuildUrlApi("{id}");
			var client = new RestClient(url);
			var request = new RestRequest(Method.GET);
			request.AddUrlSegment("id", id);
			IRestResponse response = await client.ExecuteAsync(request);
			return Read<UsuarioModel>(response);
		}
		public async Task ActualizarAsync(UsuarioModel usuarioModel)
		{
			var url = BuildUrlApi("{id}");
			var client = new RestClient(url);
			var request = new RestRequest(Method.PUT);
			request.AddUrlSegment("id", usuarioModel.Id);
			request.AddJsonBody(JsonSerializer.Serialize(usuarioModel));
			IRestResponse response = await client.ExecuteAsync(request);
			switch (response.StatusCode)
			{
				case HttpStatusCode.NotFound:
				default:
					throw new ApplicationException("Error al actualizar Informacion: " + response.StatusCode, new ApplicationException(response.Content));
			}
		}

		public async Task EliminarAsync(int id)
		{
			var url = BuildUrlApi("{id}");
			var client = new RestClient(url);
			var request = new RestRequest(Method.DELETE);
			request.AddUrlSegment("id", id);
			IRestResponse response = await client.ExecuteAsync(request);
			switch (response.StatusCode)
			{
				case HttpStatusCode.NotFound:
				default:
					throw new ApplicationException("Error al actualizar Informacion: " + response.StatusCode, new ApplicationException(response.Content));
			}
		}

		public async Task<IEnumerable<TipoIdentificacionModel>> ConsultarTiposIdentificacionAsync()
		{
			var url = BuildUrlApi(UrlApi, "TiposIdentificacion");
			var client = new RestClient(url);
			var request = new RestRequest(Method.GET);
			IRestResponse response = await client.ExecuteAsync(request);
			return Read<IEnumerable<TipoIdentificacionModel>>(response);
		}
	}
}
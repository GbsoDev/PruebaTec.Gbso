using Flurl;
using PruebaTec.Gbso.Web.Services.Interfaces;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaTec.Gbso.Web.Services
{
	public abstract class BaseService : IBaseService
	{
		#region Construccion de la Url
		protected abstract string UrlApi { get; }
		protected abstract string EndPoint { get; }
		protected string BuildUrlApi(params string[] endpoints)
		{
			endpoints = endpoints.Prepend(EndPoint).Prepend(UrlApi).ToArray();
			return Url.Combine(endpoints);
		}
		#endregion


		protected TType Read<TType>(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    {
                        //var jsonOptions = new JsonSerializerSettings
                        //{
                        //    PreserveReferencesHandling = PreserveReferencesHandling.All,
                        //    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                        //    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                        //};
                        //jsonOptions.Converters.Add(new StringEnumConverter());
                        //return JsonConvert.DeserializeObject<TType>(content, jsonOptions);
						var @Object = JsonSerializer.Deserialize<TType>(response.Content);
						return @Object;
                    }
                case HttpStatusCode.NotFound:
                case HttpStatusCode.NoContent:
                    return default(TType);
                default:
					throw new ApplicationException("Error al consultar Informacion: " + response.StatusCode, new ApplicationException(response.Content));
                    //throw new HttpException($"Error al consumir servicio {UrlApi}", new HttpException($"{response.StatusCode} - {content}"));
            }
        }
	}
}

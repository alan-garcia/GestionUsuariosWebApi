using System.Net;
using System.Net.Http;

namespace GestionUsuariosWebApi.Helpers
{
    /// <summary>
    /// Clase para operar con respuestas HTTP personalizadas
    /// </summary>
    public class CustomHttpResponse
    {
        /// <summary>
        ///     Configura un mensaje de error para el tipo HTTP 404 (Not Found)
        /// </summary>
        /// <param name="message">Mensaje para un error de tipo HTTP 404 (Not Found)</param>
        /// <returns>Mensaje de la respuesta HTTP</returns>
        public static HttpResponseMessage SetNotFoundMessage(string message)
        {
            return new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent(message)
            };
        }
    }
}
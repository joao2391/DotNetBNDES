using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.BNDES
{
    /// <summary>
    /// Interface do HttpClientWrapper
    /// </summary>
    public interface IHttpClientWrapper
    {
        /// <summary>
        /// Método responsável realizar o GET
        /// </summary>        
        /// <param name="requestMessage">Objeto da Requisição</param>
        /// <returns>Task de HttpResponseMessage</returns>
        Task<HttpResponseMessage> GetAsync(HttpRequestMessage requestMessage);

        /// <summary>
        /// Método responsável por realizar o POST
        /// </summary>        
        /// <param name="requestMessage">Objeto da Requisição</param>
        /// <returns>Task de HttpResponseMessage</returns>
        Task<HttpResponseMessage> PostAsync(HttpRequestMessage requestMessage);
    }
}

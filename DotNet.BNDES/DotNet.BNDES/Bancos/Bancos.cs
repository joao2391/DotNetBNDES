using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Bancos
    /// </summary>
    public class Bancos : IBancos
    {
        private readonly IHttpClientWrapper _httpClient;

        /// <summary>
        /// Construtor para instanciar a classe HttpClientWrapper via injeção de dependência.
        /// </summary>
        /// <param name="httpClientWrapper">Objeto HttpClientWrapper</param>
        public Bancos(IHttpClientWrapper httpClientWrapper)
        {
            _httpClient = httpClientWrapper;
        }

        /// <summary>
        /// Busca os bancos credenciados
        /// </summary>
        /// <returns>Bancos Credenciados</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="HtmlWebException">HtmlWebException</exception>
        public async Task<BancosCredenciados> GetBancosCredenciadosAsync()
        {
            try
            {
                var bancos = new BancosCredenciados
                {
                    Bancos = new List<Banco>()
                };

                var requestMsg = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(Constants.URL_GET_BANCOS)
                };

                var response = await _httpClient.GetAsync(requestMsg).ConfigureAwait(false);

                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var doc = new HtmlDocument();

                doc.LoadHtml(contentString);

                var tabela = doc.DocumentNode.SelectSingleNode(Constants.XPATH_TABELA);

                var itens = tabela.ChildNodes.Count;

                for (int i = 0; i < itens; i++)
                {

                    if (tabela?.ChildNodes[i]?.Name == Constants.H2)
                    {
                        var nomeBanco = tabela.ChildNodes[i]?.InnerText;
                        bancos.Bancos.Add(new Banco() { Nome = nomeBanco });
                    }

                }

                return bancos;
            }
            catch (HttpRequestException)
            {

                throw;
            }
            catch (HtmlWebException)
            {

                throw;
            }

        }
    }
}

using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Cartao
    /// </summary>
    public class Cartao : ICartao
    {

        private readonly IHttpClientWrapper _httpClient;

        /// <summary>
        /// Construtor para instanciar a classe HttpClientWrapper via injeção de dependência.
        /// </summary>
        /// <param name="httpClientWrapper">Objeto HttpClientWrapper</param>
        public Cartao(IHttpClientWrapper httpClientWrapper)
        {
            _httpClient = httpClientWrapper;
        }


        /// <summary>
        /// Busca os fornecedores cadastrados no BNDES pelo nome.
        /// </summary>
        /// <param name="nomeFornecedor">Nome do Fornecedor</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Fornecedores</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="JsonSerializationException">JsonSerializationException</exception>
        public async Task<CatalogoFornecedores> GetFornecedoresByNameAsync(string nomeFornecedor, int pagina = 1)
        {
            try
            {
                var requestMsg = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://www.cartaobndes.gov.br/cartaobndes/Servico/Fornecedores.asp?acao=busca&chr_tiposaida=JSON&fornecedor={nomeFornecedor}&pagina={pagina}")
                };

                requestMsg.Headers.Add("Accept", "*/*");

                var response = await _httpClient.GetAsync(requestMsg).ConfigureAwait(false);

                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var fornecedores = JsonConvert.DeserializeObject<CatalogoFornecedores>(contentString);

                return fornecedores ?? new CatalogoFornecedores();
            }
            catch (HttpRequestException)
            {

                throw;
            }
            catch (JsonSerializationException)
            {

                throw;
            }


        }

        /// <summary>
        /// Busca os fornecedores cadastrados no BNDES pelo nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Nome do Produto</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Fornecedores</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="JsonSerializationException">JsonSerializationException</exception>
        public async Task<CatalogoFornecedores> GetFornecedoresByNomeProdutoAsync(string nomeProduto, int pagina = 1)
        {
            try
            {
                var requestMsg = new HttpRequestMessage()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://www.cartaobndes.gov.br/cartaobndes/Servico/Fornecedores.asp?acao=busca&chr_tiposaida=JSON&produto={nomeProduto}&pagina={pagina}")
                };

                requestMsg.Headers.Add("Accept", "*/*");

                var response = await _httpClient.GetAsync(requestMsg).ConfigureAwait(false);

                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var fornecedores = JsonConvert.DeserializeObject<CatalogoFornecedores>(contentString);

                return fornecedores ?? new CatalogoFornecedores();
            }
            catch (HttpRequestException)
            {

                throw;
            }
            catch (JsonSerializationException)
            {

                throw;
            }


        }

        /// <summary>
        /// Busca os produtos cadastrados no BNDES pelo nome.
        /// </summary>
        /// <param name="nomeProduto">Nome do Produto</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Produtos</returns>
        /// <exception cref="HttpRequestException">HttpRequestException</exception>
        /// <exception cref="HtmlWebException">HtmlWebException</exception>
        public async Task<CatalogoProdutos> GetProdutosByNameAsync(string nomeProduto, int pagina = 1)
        {
            try
            {
                var totalProdutos = await GetQuantidadeProdutosByRegexAsync(nomeProduto).ConfigureAwait(false);

                var dict = new Dictionary<string, string>
                {
                    {"chr_PalavraPesquisadaHidden", nomeProduto},
                    {"int_PaginaAtual", pagina.ToString() }
                };

                var requestMsg = new HttpRequestMessage(HttpMethod.Post, Constants.URL_POST_PRODUTOS)
                {
                    Content = new FormUrlEncodedContent(dict),
                };

                var response = await _httpClient.PostAsync(requestMsg).ConfigureAwait(false);

                var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var doc = new HtmlDocument();

                doc.LoadHtml(contentString);

                var checkBloq = doc.DocumentNode.SelectSingleNode(Constants.XPATH_CHECK_BLOQ);

                if (checkBloq.Attributes[2].Value == Constants.S)
                {
                    throw new HtmlWebException("reCaptcha foi ativado! Favor tentar novamente!");
                }                

                var itens = doc.DocumentNode.SelectSingleNode(Constants.XPATH_ITENS);

                var quantidadeItens = itens is null ? 0 : itens.ChildNodes.Count;

                var catalogoProdutos = new CatalogoProdutos() { Produtos = new List<Produto>() };

                for (int i = 0; i < quantidadeItens; i++)
                {
                    if (itens.ChildNodes[i].Attributes.Count > 0 && itens.ChildNodes[i].Attributes[0].Value == Constants.TOP)
                    {
                        catalogoProdutos.Produtos.Add(new Produto()
                        {
                            NomeFabricante = itens.ChildNodes[i].ChildNodes[7].InnerText,
                            NomeProduto = itens.ChildNodes[i].ChildNodes[3].InnerText
                        });
                    }
                }

                catalogoProdutos.PaginaAtual = pagina;
                catalogoProdutos.QuantidadeProdutos = totalProdutos;
                catalogoProdutos.QuantidadePaginas = (totalProdutos / 10) + 1;

                return catalogoProdutos;
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

        private async Task<int> GetQuantidadeProdutosByRegexAsync(string nomeProduto)
        {
            var dict = new Dictionary<string, string>
                {
                    {"chr_PalavraPesquisadaHidden", nomeProduto},
                    {"chr_PalavraPesquisada", nomeProduto}
                };

            var requestMsg = new HttpRequestMessage(HttpMethod.Post, Constants.URL_POST_REGEX)
            {
                Content = new FormUrlEncodedContent(dict)
            };

            var response = await _httpClient.PostAsync(requestMsg).ConfigureAwait(false);

            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var doc = new HtmlDocument();

            doc.LoadHtml(contentString);

            var checkBloq = doc.DocumentNode.SelectSingleNode(Constants.XPATH_CHECK_BLOQ);

            if (checkBloq?.Attributes[2]?.Value == Constants.S)
            {
                throw new HtmlWebException("reCaptcha foi ativado! Favor tentar novamente!");
            }

            var texto = doc.DocumentNode.SelectSingleNode(Constants.XPATH_TEXTO_QTDE_ITENS);

            string result = Regex.Replace(texto.InnerText, @"[^\d]", "");

            return int.Parse(result);
        }
    }
}

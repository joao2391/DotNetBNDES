using Moq;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DotNet.BNDES.Test
{
    public class CartaoTests
    {

        private readonly string fakeContentJson = string.Empty;
        private readonly string fakeContentHtml = string.Empty;
        private Cartao _cartao;

        public CartaoTests()
        {
            fakeContentJson = File.ReadAllText(@".\FakeData.json");
            fakeContentHtml = File.ReadAllText(@".\FakeDataQtdeProdutos.html");
        }


        [Fact]
        public void Should_Return_Fornecedores_From_GetFornecedoresByNomeAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContentJson)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _cartao = new Cartao(mockHttp.Object);

            var result = _cartao.GetFornecedoresByNameAsync("Zezinho", 1).Result;

            Assert.NotNull(result);
            Assert.IsType<CatalogoFornecedores>(result);

        }

        [Fact]
        public void Should_Return_Fornecedores_From_GetFornecedoresByNomeProdutoAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContentJson)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _cartao = new Cartao(mockHttp.Object);

            var result = _cartao.GetFornecedoresByNomeProdutoAsync("cimento", 1).Result;

            Assert.NotNull(result);
            Assert.IsType<CatalogoFornecedores>(result);

        }

        [Fact]
        public void Should_Return_Produtos_From_GetProdutosByNameAsync_When_All_Params_is_Full()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var responseJson = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContentJson)
            };
            var responseHtml = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContentHtml)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(responseJson);
            mockHttp.Setup(x => x.PostAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(responseHtml);

            _cartao = new Cartao(mockHttp.Object);

            var result = _cartao.GetProdutosByNameAsync("cimento").Result;

            Assert.NotNull(result);
            Assert.IsType<CatalogoProdutos>(result);

        }
    }
}

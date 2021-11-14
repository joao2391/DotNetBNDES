using Moq;
using System.IO;
using System.Net;
using System.Net.Http;
using Xunit;

namespace DotNet.BNDES.Test
{
    public class BancoTests
    {
        private readonly string fakeContentHtml = string.Empty;
        private Bancos _bancos;

        public BancoTests()
        {
            fakeContentHtml = File.ReadAllText(@".\FakeDataBancosCredenciados.html");
        }

        [Fact]
        public void Should_Return_BancosCredenciados_From_GetBancosCredenciadosAsync()
        {
            var mockHttp = new Mock<IHttpClientWrapper>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(fakeContentHtml)
            };

            mockHttp.Setup(x => x.GetAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(response);

            _bancos = new Bancos(mockHttp.Object);

            var result = _bancos.GetBancosCredenciadosAsync().Result;

            Assert.NotNull(result);
            Assert.IsType<BancosCredenciados>(result);

        }
    }
}

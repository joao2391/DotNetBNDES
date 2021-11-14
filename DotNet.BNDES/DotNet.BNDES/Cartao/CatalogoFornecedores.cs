using Newtonsoft.Json;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Catalogo Fornecedores
    /// </summary>
    public class CatalogoFornecedores
    {
        /// <summary>
        /// Array de Fornecedores dentro do Catalogo
        /// </summary>
        [JsonProperty("Catalogo")]
        public Fornecedor[] Fornecedores { get; set; }
    }
}

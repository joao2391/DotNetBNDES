using Newtonsoft.Json;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Fornecedor
    /// </summary>
    public class Fornecedor
    {
        /// <summary>
        /// Total de Registros
        /// </summary>
        [JsonProperty("qtdtotalregistros")]
        public int TotalRegistros { get; set; }

        /// <summary>
        /// Última Página do Grupo
        /// </summary>
        [JsonProperty("ultimapaginagrupo")]
        public int UltimaPaginaGrupo { get; set; }

        /// <summary>
        /// Nome Pessoa
        /// </summary>
        [JsonProperty("nomepessoa")]
        public string NomePessoa { get; set; }

        /// <summary>
        /// Nome Fantasia
        /// </summary>
        [JsonProperty("nomefantasia")]
        public string NomeFantasia { get; set; }
    }
}

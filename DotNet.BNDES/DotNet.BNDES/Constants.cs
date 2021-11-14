namespace DotNet.BNDES
{
    /// <summary>
    /// Classe de Constantes
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// URL utilizada se obter a quantidade de itens via Regex
        /// </summary>
        public const string URL_POST_REGEX = "https://www.cartaobndes.gov.br/cartaobndes/PaginasCartao/Catalogo.asp?Acao=RBS&CTRL=";

        /// <summary>
        /// URL utilizada para realizar a chamada POST de produtos
        /// </summary>
        public const string URL_POST_PRODUTOS = "https://www.cartaobndes.gov.br/cartaobndes/PaginasCartao/Catalogo.asp?Acao=LP&CTRL=";

        /// <summary>
        /// URL utilizada para se obter os Bancos
        /// </summary>
        public const string URL_GET_BANCOS = "https://www.bndes.gov.br/wps/portal/site/home/instituicoes-financeiras-credenciadas/rede-credenciada-brasil";

        /// <summary>
        /// XPATH para obter o status de bloqueio da página.
        /// </summary>
        public const string XPATH_CHECK_BLOQ = "/html[1]/body[1]/div[1]/div[4]/div[2]/form[1]/input[6]";
        
        /// <summary>
        /// XPATH para obter os itens
        /// </summary>
        public const string XPATH_ITENS = "/html[1]/body[1]/div[1]/div[4]/div[2]/table[3]/tr[2]/td[1]/table[1]";

        /// <summary>
        /// Palavra top
        /// </summary>
        public const string TOP = "top";

        /// <summary>
        /// Letra s
        /// </summary>
        public const string S = "S";

        /// <summary>
        /// Tag H2 do HTML
        /// </summary>
        public const string H2 = "h2";

        /// <summary>
        /// XPATH do texto que contém a quantidade de itens.
        /// </summary>
        public const string XPATH_TEXTO_QTDE_ITENS = "/html[1]/body[1]/div[1]/div[4]/div[2]/table[3]/tr[11]";

        /// <summary>
        /// XPATH da tabela
        /// </summary>
        public const string XPATH_TABELA = "/html[1]/body[1]/div[4]/div[2]/div[1]/table[1]/tr[2]/td[1]/table[1]/tr[1]/td[1]/table[1]/tr[1]/td[1]/div[1]/section[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]";
    }
}

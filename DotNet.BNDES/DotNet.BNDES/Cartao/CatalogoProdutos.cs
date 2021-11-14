using System.Collections.Generic;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Catalogo de Produtos
    /// </summary>
    public class CatalogoProdutos
    {
        /// <summary>
        /// Lista de Produtos
        /// </summary>
        public List<Produto> Produtos { get; set; }

        /// <summary>
        /// Quantidade de Páginas
        /// </summary>
        public int QuantidadePaginas { get; set; }

        /// <summary>
        /// Quantidade de Produtos
        /// </summary>
        public int QuantidadeProdutos { get; set; }

        /// <summary>
        /// Página Atual
        /// </summary>
        public int PaginaAtual { get; set; }
    }
}

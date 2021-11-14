using System.Threading.Tasks;

namespace DotNet.BNDES
{
    /// <summary>
    /// Interface para a classe Cartao
    /// </summary>
    public interface ICartao
    {
        /// <summary>
        /// Busca os fornecedores cadastrados no BNDES pelo nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Nome do Produto</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Fornecedores</returns>
        Task<CatalogoFornecedores> GetFornecedoresByNomeProdutoAsync(string nomeProduto, int pagina = 1);

        /// <summary>
        /// Busca os fornecedores cadastrados no BNDES pelo nome.
        /// </summary>
        /// <param name="nomeFornecedor">Nome do Fornecedor</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Fornecedores</returns>
        Task<CatalogoFornecedores> GetFornecedoresByNameAsync(string nomeFornecedor, int pagina = 1);

        /// <summary>
        /// Busca os produtos cadastrados no BNDES pelo nome.
        /// </summary>
        /// <param name="nomeProduto">Nome do Produto</param>
        /// <param name="pagina">Paginação da consulta.</param>
        /// <returns>Catalogo de Produtos</returns>
        Task<CatalogoProdutos> GetProdutosByNameAsync(string nomeProduto, int pagina = 1);
    }
}

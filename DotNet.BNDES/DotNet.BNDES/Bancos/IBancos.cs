using System.Threading.Tasks;

namespace DotNet.BNDES
{
    /// <summary>
    /// Interface para a classe Bancos
    /// </summary>
    public interface IBancos
    {
        /// <summary>
        /// Busca os bancos credenciados
        /// </summary>
        /// <returns>Bancos Credenciados</returns>
        Task<BancosCredenciados> GetBancosCredenciadosAsync();
    }
}

using System.Collections.Generic;

namespace DotNet.BNDES
{
    /// <summary>
    /// Classe Bancos Credenciados
    /// </summary>
    public class BancosCredenciados
    {
        /// <summary>
        /// Lista de Bancos
        /// </summary>
        public List<Banco> Bancos { get; set; }

        /// <summary>
        /// Mensagem padrão
        /// </summary>
        public string Mensagem => "As instituições marcadas com '*' são bancos públicos.";
    }
}

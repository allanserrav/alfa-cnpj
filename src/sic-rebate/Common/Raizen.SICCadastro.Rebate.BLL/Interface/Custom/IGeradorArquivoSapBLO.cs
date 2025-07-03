using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.BLL
{
    public interface IGeradorArquivoSapBLO
    {
        /// <summary>
        /// Gerar Arquivo de Pagamento dos Rebates Aprovados
        /// </summary>
        void ProcessarServico(string localArquivo);
    }
}

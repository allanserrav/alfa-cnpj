using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// InformacaoRebateRelFiltro
    /// </summary>
    public class InformacaoRebateRelFiltro
    {
        /// <summary>
        /// Número IBM do Cliente
        /// </summary>
        public string CodigoIBM { get; set; }

        /// <summary>
        /// Status para Busca
        /// </summary>
        public string ListaStatus { get; set; }

        /// <summary>
        /// Tipos Rebate
        /// </summary>
        public string ListaTipoRebate { get; set; }
    }
}

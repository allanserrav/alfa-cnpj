using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Classe para apresentação de bonificação em uma grid
    /// </summary>
    [Serializable]
    public class FiltroLogIntegracaoSic
    {
        /// <summary>
        /// Periodo em que o cálculo foi executado
        /// </summary>
        public DateTime DataPeriodoIni { get; set; }

        /// <summary>
        /// Periodo em que o cálculo foi executado
        /// </summary>
        public DateTime DataPeriodoFim { get; set; }
    }
}


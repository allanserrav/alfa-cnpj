using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Esta entidade agrupa rebates e faixas 
    /// </summary>
    public class RebateFaixaAgrupador
    {
        /// <summary>
        /// Lista de Rebates
        /// </summary>
        public List<RebateSic> listRebateSic { get; set; }

        /// <summary>
        /// Lista de faixas dos rebates locais
        /// </summary>
        public List<FaixarebateSic> listFaixaRebateSic { get; set; }
    }
}

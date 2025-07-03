using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    public class BonificacaoProporcionalGrid
    {
        public string NrIbmClienteSic { get; set; }
        public string NrCodigoFornecedorRebateSic { get; set; }
        public decimal VlVolumeCalculadoSic { get; set; }
        public decimal VlValorBonificacaoProporcionalSic { get; set; }
    }
}
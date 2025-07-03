using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    public class DadosBonificacaoRebate
    {
        public CalculoRebateProporcionalSic CalculoRebateProporcionalSic { get; set; }
        public CalculoRebateSic CalculoRebateSic { get; set; }
        public IBMFornecedor IBMFornecedor { get; set; }
        public ClienteSic ClienteSic { get; set; }
        public bool PagamentoManual { get; set; }
    }
}
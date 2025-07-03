using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Compara Duas bonificações Grid por Rebate
    /// </summary>
    public class ComparaBonificacaoGridPorCodigoRebate : IEqualityComparer<BonificacaoGrid>
    {
        public bool Equals(BonificacaoGrid x, BonificacaoGrid y)
        {
            if (x.CodigoRebate == y.CodigoRebate)
                return true;
            else
                return false;
        }

        public int GetHashCode(BonificacaoGrid obj)
        {
            return obj.CodigoRebate.GetHashCode();
        }
    }        

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Compara Duas Faixas Rebate por categoria
    /// </summary>
    public class ComparaFaixaRebatePorCategoria : IEqualityComparer<FaixarebateSic>
    {
        public bool Equals(FaixarebateSic x, FaixarebateSic y)
        {
            if (x.NrSeqCategoriaSic == y.NrSeqCategoriaSic)
                return true;
            else
                return false;
        }

        public int GetHashCode(FaixarebateSic obj)
        {
            return obj.NrSeqCategoriaSic.GetHashCode();
        }
    }        
}

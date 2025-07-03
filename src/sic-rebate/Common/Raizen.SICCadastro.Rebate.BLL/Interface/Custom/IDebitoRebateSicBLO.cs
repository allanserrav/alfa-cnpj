using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IDebitoRebateSicBLO
    /// </summary>
    public partial interface IDebitoRebateSicBLO
    {
        #region Metodos de IDebitoRebateSicDAO

        #region Selecionar SelecionarDebitoRbc
        /// <summary>
        /// Seleciona em lote os dados do Debito do Cliente na base RBC (Oracle)
        /// </summary>        
        /// <param name="listIBM">Lista de IBMs</param>        
        /// <returns></returns>
        IList<DebitoRbc> SelecionarDebitoRbc(List<RebateSic> listRebateSic);
        #endregion

        #endregion
    }
}

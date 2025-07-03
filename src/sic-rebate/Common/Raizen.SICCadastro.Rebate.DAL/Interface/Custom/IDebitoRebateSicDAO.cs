using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.DBUtil;

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IDebitoRebateSicDAO
    /// </summary>
    public partial interface IDebitoRebateSicDAO
    {
        #region Metodos de IDebitoRebateSicDAO

        #region Selecionar SelecionarDebitoRbc
        /// <summary>
        /// Seleciona em lote os dados do Debito do Cliente na base RBC (Oracle)
        /// </summary>
        /// <param name="dataConsultaAte">Data para buscar débitos anteriores</param>
        /// <param name="listIBM">Lista de IBMs</param>
        /// <param name="listMotivoRegimeEspecial">Lista de motivos exclusiovs à busca</param>
        /// <returns></returns>
        IList<DebitoRbc> SelecionarDebitoRbc(DateTime dataConsultaAte, List<string> listIBM, List<string> listMotivoRegimeEspecial);
        #endregion

        #region Incluir
        /// <summary>
        /// Incluir DebitoRebateSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="DebitoRebateSic"/></param>
        void IncluirComTransacao(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager);
        #endregion

        #endregion
    }
}

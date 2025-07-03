#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ISaldoRebateSicDAO.cs
// Class Name	        : ISaldoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : 
//	Date of Modification    : 
//	Reason for modification : 
//	Modification Done       : 
//	Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
using COSAN.Framework.DBUtil;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a ISaldoRebateSicDAO
    /// </summary>
    public partial interface ISaldoRebateSicDAO
    {
        #region Incluir
        /// <summary>
        /// Incluir SaldoRebateSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="SaldoRebateSic"/></param>
        void IncluirComTransacao(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager);

        #endregion Incluir

        #region SelecionarPeriodo

        /// <summary>
        /// Consulta os lancamentos do Saldo Rebate por periodo
        /// </summary>
        /// <param name="saldoRebateSic">objeto SaldoRebateSic</param>
        /// <param name="dataInicio">Data de Início do Período</param>
        /// <param name="dataFim">Data de Fim do Período</param>
        /// <returns>Lista de lançamentos SaldoRebateSic</returns>
        IList<SaldoRebateSic> SelecionarPeriodo(SaldoRebateSic saldoRebateSic, DateTime dataInicio, DateTime dataFim);

        #endregion SelecionarPeriodo
    }
}

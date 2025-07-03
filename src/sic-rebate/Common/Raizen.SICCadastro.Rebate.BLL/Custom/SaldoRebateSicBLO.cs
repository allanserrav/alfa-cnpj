#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : SaldoRebateSicBLO.cs
// Class Name	        : SaldoRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/08/2012
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a  SaldoRebateSicBLO
    /// </summary>
    internal partial class SaldoRebateSicBLO : ISaldoRebateSicBLO
    {
        #region Metodos Publicos

        #region Selecionar
      
        /// <summary>
        /// Selecionar o último registro referente aos dados de SaldoRebateSic
        /// </summary>
        /// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
        /// <returns>Retorna uma instância de SaldoRebateSic</returns>
        public SaldoRebateSic SelecionarUltimo(SaldoRebateSic saldoRebateSic)
        {
            IList<SaldoRebateSic> lista = this.Selecionar(saldoRebateSic, 1, "TB_SALDO_REBATE_SIC.NR_SEQ_SALDO_REBATE_SIC DESC");
            if (lista.Count > 0)
                return lista[0];
            else
                return new SaldoRebateSic();
        }
        #endregion Selecionar

        #region SelecionarPeriodo
        
        /// <summary>
        /// Consulta os lancamentos do Saldo Rebate por periodo
        /// </summary>
        /// <param name="saldoRebateSic">objeto SaldoRebateSic</param>
        /// <param name="dataInicio">Data de Início do Período</param>
        /// <param name="dataFim">Data de Fim do Período</param>
        /// <returns>Lista de lançamentos SaldoRebateSic</returns>
        public IList<SaldoRebateSic> SelecionarPeriodo(SaldoRebateSic saldoRebateSic, DateTime dataInicio, DateTime dataFim)
        {
            return this.saldoRebateSicDAO.SelecionarPeriodo(saldoRebateSic, dataInicio, dataFim);
        }

        #endregion SelecionarPeriodo

        #endregion Public Methods
    }
}


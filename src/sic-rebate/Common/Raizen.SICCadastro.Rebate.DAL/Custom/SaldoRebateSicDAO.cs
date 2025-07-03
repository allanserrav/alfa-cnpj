#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : SaldoRebateSicDAO.cs
// Class Name	        : SaldoRebateSicDAO
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
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	#region classe concreta SaldoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a SaldoRebateSicDAO
	/// </summary>
	internal partial class SaldoRebateSicDAO : ISaldoRebateSicDAO
	{
        /// <summary>
        /// Incluir SaldoRebateSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="SaldoRebateSic"/></param>
        public void IncluirComTransacao(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager)
        {
            Incluir(saldoRebateSic, databaseManager);
        }

        /// <summary>
        /// Consulta os lancamentos do Saldo Rebate por periodo
        /// </summary>
        /// <param name="saldoRebateSic">objeto SaldoRebateSic</param>
        /// <param name="dataInicio">Data de Início do Período</param>
        /// <param name="dataFim">Data de Fim do Período</param>
        /// <returns>Lista de lançamentos SaldoRebateSic</returns>
        public IList<SaldoRebateSic> SelecionarPeriodo(SaldoRebateSic saldoRebateSic, DateTime dataInicio, DateTime dataFim)
        {
            IList<SaldoRebateSic> listSaldoRebateSic = new List<SaldoRebateSic>();

            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                int numeroLinhas = 0;
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, saldoRebateSic, out where);
                where += (where.Equals(string.Empty) ? " " : " AND ") +
                    " (DT_LANCAMENTO_SIC >= '" + dataInicio.ToString("yyyy-MM-dd HH:mm:ss") + "' " +
                    "AND DT_LANCAMENTO_SIC <= '" + dataFim.AddDays(1).AddMilliseconds(-1).ToString("yyyy-MM-dd HH:mm:ss") + "')";

                string newQuery = string.Format(querySelecionar,
                    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
                    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
                    "ORDER BY NR_SEQ_SALDO_REBATE_SIC");
                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listSaldoRebateSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }

            return listSaldoRebateSic;
        }

	}
	#endregion classe concreta 
}

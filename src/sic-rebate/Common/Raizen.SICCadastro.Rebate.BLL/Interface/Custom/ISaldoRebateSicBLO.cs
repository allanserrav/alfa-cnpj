#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ISaldoRebateSicBLO.cs
// Class Name	        : ISaldoRebateSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a ISaldoRebateSicBLO
	/// </summary>
	public partial interface ISaldoRebateSicBLO
	{
		#region Metodos de ISaldoRebateSicBLO 
		
		#region Selecionar		
		/// <summary>
		/// Selecionar o último registro referente aos dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de SaldoRebateSic</returns>
		SaldoRebateSic SelecionarUltimo(SaldoRebateSic saldoRebateSic);
		#endregion Selecionar	

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

        #endregion ISaldoRebateSicBLO
    }
}

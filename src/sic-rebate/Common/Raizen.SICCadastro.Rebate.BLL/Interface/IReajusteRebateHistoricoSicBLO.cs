#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IReajusteRebateHistoricoSicBLO.cs
// Class Name	        : IReajusteRebateHistoricoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	/// Representa funcionalidade relacionada a IReajusteRebateHistoricoSicBLO
	/// </summary>
	public partial interface IReajusteRebateHistoricoSicBLO
	{
		#region Metodos de IReajusteRebateHistoricoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		IList<ReajusteRebateHistoricoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteRebateHistoricoSic</returns>
		ReajusteRebateHistoricoSic SelecionarPrimeiro(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		void Incluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		void Atualizar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		void Excluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic);
		#endregion Excluir
		
		#endregion IReajusteRebateHistoricoSicBLO
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IFaixaRebateHistoricoSicBLO.cs
// Class Name	        : IFaixaRebateHistoricoSicBLO
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
	/// Representa funcionalidade relacionada a IFaixaRebateHistoricoSicBLO
	/// </summary>
	public partial interface IFaixaRebateHistoricoSicBLO
	{
		#region Metodos de IFaixaRebateHistoricoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic);
		
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		IList<FaixaRebateHistoricoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de FaixaRebateHistoricoSic</returns>
		FaixaRebateHistoricoSic SelecionarPrimeiro(FaixaRebateHistoricoSic faixaRebateHistoricoSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		void Incluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		void Atualizar(FaixaRebateHistoricoSic faixaRebateHistoricoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui faixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		void Excluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic);
		#endregion Excluir
		
		#endregion IFaixaRebateHistoricoSicBLO
	}
}

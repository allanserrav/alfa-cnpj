#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ITipoclienteSicBLO.cs
// Class Name	        : ITipoclienteSicBLO
// Author		        : Romildo Cruz
// Creation Date 	    : 26/09/2012
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
	/// Representa funcionalidade relacionada a ITipoclienteSicBLO
	/// </summary>
	public interface ITipoclienteSicBLO
	{
		#region Metodos de ITipoclienteSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic);
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		IList<TipoclienteSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TipoclienteSic</returns>
		TipoclienteSic SelecionarPrimeiro(TipoclienteSic tipoclienteSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		void Incluir(TipoclienteSic tipoclienteSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		void Atualizar(TipoclienteSic tipoclienteSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		void Excluir(TipoclienteSic tipoclienteSic);
		#endregion Excluir
		
		#endregion ITipoclienteSicBLO
	}
}

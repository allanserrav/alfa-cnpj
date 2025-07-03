#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IReajusteSicBLO.cs
// Class Name	        : IReajusteSicBLO
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
	/// Representa funcionalidade relacionada a IReajusteSicBLO
	/// </summary>
	public partial interface IReajusteSicBLO
	{
		#region Metodos de IReajusteSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteSic</returns>
		IList<ReajusteSic> Selecionar(ReajusteSic reajusteSic);
		
		/// <summary>
		/// Selecionar os dados de ReajusteSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteSic</returns>
		IList<ReajusteSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instância de <see cref="ReajusteSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteSic</returns>
		ReajusteSic SelecionarPrimeiro(ReajusteSic reajusteSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		void Incluir(ReajusteSic reajusteSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		void Atualizar(ReajusteSic reajusteSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteSic
		/// </summary>
		/// <param name="reajusteSic">Instance of <see cref="ReajusteSic"/></param>
		void Excluir(ReajusteSic reajusteSic);
		#endregion Excluir
		
		#endregion IReajusteSicBLO
	}
}

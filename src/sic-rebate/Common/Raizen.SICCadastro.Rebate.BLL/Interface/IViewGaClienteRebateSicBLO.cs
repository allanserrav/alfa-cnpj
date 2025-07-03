#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IViewGaClienteRebateSicBLO.cs
// Class Name	        : IViewGaClienteRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage / Romildo Cruz
// Creation Date 	    : 24/01/2013
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
	/// Representa funcionalidade relacionada a IViewGaClienteRebateSicBLO
	/// </summary>
	public partial interface IViewGaClienteRebateSicBLO
	{
		#region Metodos de IViewGaClienteRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic);
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		IList<ViewGaClienteRebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ViewGaClienteRebateSic</returns>
		ViewGaClienteRebateSic SelecionarPrimeiro(ViewGaClienteRebateSic viewGaClienteRebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		void Incluir(ViewGaClienteRebateSic viewGaClienteRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		void Atualizar(ViewGaClienteRebateSic viewGaClienteRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		void Excluir(ViewGaClienteRebateSic viewGaClienteRebateSic);
		#endregion Excluir
		
		#endregion IViewGaClienteRebateSicBLO
	}
}

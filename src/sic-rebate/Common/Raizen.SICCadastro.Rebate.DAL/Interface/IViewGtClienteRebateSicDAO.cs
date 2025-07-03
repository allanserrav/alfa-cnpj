#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IViewGtClienteRebateSicDAO.cs
// Class Name	        : IViewGtClienteRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/02/2013
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
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IViewGtClienteRebateSicDAO
	/// </summary>
	public partial interface IViewGtClienteRebateSicDAO
	{
		#region Metodos de IViewGtClienteRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instância de <see cref="ViewGtClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGtClienteRebateSic</returns>
		IList<ViewGtClienteRebateSic> Selecionar(ViewGtClienteRebateSic viewGtClienteRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		void Incluir(ViewGtClienteRebateSic viewGtClienteRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		void Atualizar(ViewGtClienteRebateSic viewGtClienteRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		void Excluir(ViewGtClienteRebateSic viewGtClienteRebateSic);
		#endregion Excluir
		
		#endregion IViewGtClienteRebateSicDAO
	}
}

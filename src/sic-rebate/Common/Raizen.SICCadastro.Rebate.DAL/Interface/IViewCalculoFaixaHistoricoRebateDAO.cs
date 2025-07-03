#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IViewCalculoFaixaHistoricoRebateDAO.cs
// Class Name	        : IViewCalculoFaixaHistoricoRebateDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 29/01/2013
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
	/// Representa funcionalidade relacionada a IViewCalculoFaixaHistoricoRebateDAO
	/// </summary>
	public partial interface IViewCalculoFaixaHistoricoRebateDAO
	{
		#region Metodos de IViewCalculoFaixaHistoricoRebateDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		IList<ViewCalculoFaixaHistoricoRebate> Selecionar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		void Incluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		void Atualizar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		void Excluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate);
		#endregion Excluir
		
		#endregion IViewCalculoFaixaHistoricoRebateDAO
	}
}

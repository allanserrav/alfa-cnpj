#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDebitoRebateSicDAO.cs
// Class Name	        : IDebitoRebateSicDAO
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
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IDebitoRebateSicDAO
	/// </summary>
	public partial interface IDebitoRebateSicDAO
	{
		#region Metodos de IDebitoRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Incluir(DebitoRebateSic debitoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Atualizar(DebitoRebateSic debitoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui debitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Excluir(DebitoRebateSic debitoRebateSic);
		#endregion Excluir
		
		#endregion IDebitoRebateSicDAO
	}
}

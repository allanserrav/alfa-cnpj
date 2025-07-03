#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IAgrupamentoredeRebateSicDAO.cs
// Class Name	        : IAgrupamentoredeRebateSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 13/08/2014
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
	/// Representa funcionalidade relacionada a IAgrupamentoredeRebateSicDAO
	/// </summary>
	public interface IAgrupamentoredeRebateSicDAO
	{
		#region Metodos de IAgrupamentoredeRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instância de <see cref="AgrupamentoredeRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgrupamentoredeRebateSic</returns>
		IList<AgrupamentoredeRebateSic> Selecionar(AgrupamentoredeRebateSic agrupamentoredeRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		void Incluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AgrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		void Atualizar(AgrupamentoredeRebateSic agrupamentoredeRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui agrupamentoredeRebateSic
		/// </summary>
		/// <param name="agrupamentoredeRebateSic">Instance of <see cref="AgrupamentoredeRebateSic"/></param>
		void Excluir(AgrupamentoredeRebateSic agrupamentoredeRebateSic);
		#endregion Excluir
		
		#endregion IAgrupamentoredeRebateSicDAO
	}
}

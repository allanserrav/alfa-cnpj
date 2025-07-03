#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IStatusCalculoRebateSicDAO.cs
// Class Name	        : IStatusCalculoRebateSicDAO
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
	/// Representa funcionalidade relacionada a IStatusCalculoRebateSicDAO
	/// </summary>
	public partial interface IStatusCalculoRebateSicDAO
	{
		#region Metodos de IStatusCalculoRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		IList<StatusCalculoRebateSic> Selecionar(StatusCalculoRebateSic statusCalculoRebateSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		void Incluir(StatusCalculoRebateSic statusCalculoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		void Atualizar(StatusCalculoRebateSic statusCalculoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		void Excluir(StatusCalculoRebateSic statusCalculoRebateSic);
		#endregion Excluir
		
		#endregion IStatusCalculoRebateSicDAO
	}
}

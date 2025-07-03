#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IStatusSicDAO.cs
// Class Name	        : IStatusSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/01/2013
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
	/// Representa funcionalidade relacionada a IStatusSicDAO
	/// </summary>
	public partial interface IStatusSicDAO
	{
		#region Metodos de IStatusSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusSic</returns>
		IList<StatusSic> Selecionar(StatusSic statusSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		void Incluir(StatusSic statusSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		void Atualizar(StatusSic statusSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		void Excluir(StatusSic statusSic);
		#endregion Excluir
		
		#endregion IStatusSicDAO
	}
}

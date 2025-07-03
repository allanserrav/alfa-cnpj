#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IClienteSicDAO.cs
// Class Name	        : IClienteSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/03/2013
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
	/// Representa funcionalidade relacionada a IClienteSicDAO
	/// </summary>
	public partial interface IClienteSicDAO
	{
		#region Metodos de IClienteSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClienteSic</returns>
		IList<ClienteSic> Selecionar(ClienteSic clienteSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		void Incluir(ClienteSic clienteSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		void Atualizar(ClienteSic clienteSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui clienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		void Excluir(ClienteSic clienteSic);
		#endregion Excluir
		
		#endregion IClienteSicDAO
	}
}

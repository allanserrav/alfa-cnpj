#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICategoriaSicDAO.cs
// Class Name	        : ICategoriaSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 25/10/2012
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
	/// Representa funcionalidade relacionada a ICategoriaSicDAO
	/// </summary>
	public interface ICategoriaSicDAO
	{
		#region Metodos de ICategoriaSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Incluir(CategoriaSic categoriaSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Atualizar(CategoriaSic categoriaSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui categoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Excluir(CategoriaSic categoriaSic);
		#endregion Excluir
		
		#endregion ICategoriaSicDAO
	}
}

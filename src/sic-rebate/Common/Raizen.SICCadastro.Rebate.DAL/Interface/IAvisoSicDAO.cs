#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IAvisoSicDAO.cs
// Class Name	        : IAvisoSicDAO
// Author		        : Hélio Jânio Ferreira
// Creation Date 	    : 17/01/2013
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
	/// Representa funcionalidade relacionada a IAvisoSicDAO
	/// </summary>
	public interface IAvisoSicDAO
	{
		#region Metodos de IAvisoSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AvisoSic</returns>
		IList<AvisoSic> Selecionar(AvisoSic avisoSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		void Incluir(AvisoSic avisoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		void Atualizar(AvisoSic avisoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui avisoSic
		/// </summary>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		void Excluir(AvisoSic avisoSic);
		#endregion Excluir
		
		#endregion IAvisoSicDAO
	}
}

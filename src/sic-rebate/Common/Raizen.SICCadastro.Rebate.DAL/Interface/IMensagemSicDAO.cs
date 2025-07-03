#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IMensagemSicDAO.cs
// Class Name	        : IMensagemSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 22/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 18/12/2012
//	Reason for modification : Change namespace SICCadastro to SICCadastro.Rebate
//	Modification Done       : 18/12/2012
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
	/// Representa funcionalidade relacionada a IMensagemSicDAO
	/// </summary>
	public interface IMensagemSicDAO
	{
		#region Metodos de IMensagemSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MensagemSic</returns>
		IList<MensagemSic> Selecionar(MensagemSic mensagemSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		void Incluir(MensagemSic mensagemSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		void Atualizar(MensagemSic mensagemSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui mensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		void Excluir(MensagemSic mensagemSic);
		#endregion Excluir
		
		#endregion IMensagemSicDAO
	}
}

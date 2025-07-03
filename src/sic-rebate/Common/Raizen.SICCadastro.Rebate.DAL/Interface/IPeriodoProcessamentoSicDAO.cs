#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IPeriodoProcessamentoSicDAO.cs
// Class Name	        : IPeriodoProcessamentoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 18/01/2013
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
	/// Representa funcionalidade relacionada a IPeriodoProcessamentoSicDAO
	/// </summary>
	public partial interface IPeriodoProcessamentoSicDAO
	{
		#region Metodos de IPeriodoProcessamentoSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		void Incluir(PeriodoProcessamentoSic periodoProcessamentoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		void Atualizar(PeriodoProcessamentoSic periodoProcessamentoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui periodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		void Excluir(PeriodoProcessamentoSic periodoProcessamentoSic);
		#endregion Excluir
		
		#endregion IPeriodoProcessamentoSicDAO
	}
}

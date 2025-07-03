#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IIgpmPeriodoSicDAO.cs
// Class Name	        : IIgpmPeriodoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	/// Representa funcionalidade relacionada a IIgpmPeriodoSicDAO
	/// </summary>
	public partial interface IIgpmPeriodoSicDAO
	{
		#region Metodos de IIgpmPeriodoSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Incluir(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Atualizar(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui igpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Excluir(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Excluir
		
		#endregion IIgpmPeriodoSicDAO
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IRebateSicBLO.cs
// Class Name	        : IRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 25/07/2014
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IRebateSicBLO
	/// </summary>
	public partial interface IRebateSicBLO
	{
		#region Metodos de IRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de RebateSic</returns>
		IList<RebateSic> Selecionar(RebateSic rebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de RebateSic</returns>
		IList<RebateSic> Selecionar(RebateSic rebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de RebateSic</returns>
		IList<RebateSic> Selecionar(RebateSic rebateSic);
		
		/// <summary>
		/// Selecionar os dados de RebateSic
		/// </summary>
		/// <returns>Retorna lista de RebateSic</returns>
		IList<RebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de RebateSic
		/// </summary>
		/// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de RebateSic</returns>
		RebateSic SelecionarPrimeiro(RebateSic rebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		void Incluir(RebateSic rebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza RebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		void Atualizar(RebateSic rebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui rebateSic
		/// </summary>
		/// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
		void Excluir(RebateSic rebateSic);
		#endregion Excluir
		
		#endregion IRebateSicBLO
	}
}

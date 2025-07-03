#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IReajusteRebatexfranquiaSicBLO.cs
// Class Name	        : IReajusteRebatexfranquiaSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IReajusteRebatexfranquiaSicBLO
	/// </summary>
	public partial interface IReajusteRebatexfranquiaSicBLO
	{
		#region Metodos de IReajusteRebatexfranquiaSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic);
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		IList<ReajusteRebatexfranquiaSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteRebatexfranquiaSic</returns>
		ReajusteRebatexfranquiaSic SelecionarPrimeiro(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		void Incluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		void Atualizar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		void Excluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic);
		#endregion Excluir
		
		#endregion IReajusteRebatexfranquiaSicBLO
	}
}

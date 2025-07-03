#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IPeriodoProcessamentoSicBLO.cs
// Class Name	        : IPeriodoProcessamentoSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IPeriodoProcessamentoSicBLO
	/// </summary>
	public partial interface IPeriodoProcessamentoSicBLO
	{
		#region Metodos de IPeriodoProcessamentoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		IList<PeriodoProcessamentoSic> Selecionar(PeriodoProcessamentoSic periodoProcessamentoSic);
		
		/// <summary>
		/// Selecionar os dados de PeriodoProcessamentoSic
		/// </summary>
		/// <returns>Retorna lista de PeriodoProcessamentoSic</returns>
		IList<PeriodoProcessamentoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instância de <see cref="PeriodoProcessamentoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de PeriodoProcessamentoSic</returns>
		PeriodoProcessamentoSic SelecionarPrimeiro(PeriodoProcessamentoSic periodoProcessamentoSic);
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
		
		#endregion IPeriodoProcessamentoSicBLO
	}
}

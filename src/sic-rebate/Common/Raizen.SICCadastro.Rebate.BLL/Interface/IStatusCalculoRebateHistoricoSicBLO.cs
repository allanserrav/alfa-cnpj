#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IStatusCalculoRebateHistoricoSicBLO.cs
// Class Name	        : IStatusCalculoRebateHistoricoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	/// Representa funcionalidade relacionada a IStatusCalculoRebateHistoricoSicBLO
	/// </summary>
	public partial interface IStatusCalculoRebateHistoricoSicBLO
	{
		#region Metodos de IStatusCalculoRebateHistoricoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic);
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		IList<StatusCalculoRebateHistoricoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de StatusCalculoRebateHistoricoSic</returns>
		StatusCalculoRebateHistoricoSic SelecionarPrimeiro(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		void Incluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		void Atualizar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui statusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		void Excluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic);
		#endregion Excluir
		
		#endregion IStatusCalculoRebateHistoricoSicBLO
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IAgendamentoMensagemSicBLO.cs
// Class Name	        : IAgendamentoMensagemSicBLO
// Author		        : Romildo Cruz
// Creation Date 	    : 23/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 12/18/2012
//	Reason for modification : Copy class from SICCadastros to SICCadastros.Rebate
//	Modification Done       : 12/18/2012
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
	/// Representa funcionalidade relacionada a IAgendamentoMensagemSicBLO
	/// </summary>
	public interface IAgendamentoMensagemSicBLO
	{
		#region Metodos de IAgendamentoMensagemSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic);
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		IList<AgendamentoMensagemSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de AgendamentoMensagemSic</returns>
		AgendamentoMensagemSic SelecionarPrimeiro(AgendamentoMensagemSic agendamentoMensagemSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		void Incluir(AgendamentoMensagemSic agendamentoMensagemSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		void Atualizar(AgendamentoMensagemSic agendamentoMensagemSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui agendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		void Excluir(AgendamentoMensagemSic agendamentoMensagemSic);
		#endregion Excluir
		
		#endregion IAgendamentoMensagemSicBLO
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgendamentoMensagemSicBLO.cs
// Class Name	        : AgendamentoMensagemSicBLO
// Author		        : Romildo Cruz
// Creation Date 	    : 10/23/2012
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  AgendamentoMensagemSicBLO
	/// </summary>
	internal class AgendamentoMensagemSicBLO : IAgendamentoMensagemSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de AgendamentoMensagemSicDAO 
		/// </summary>
		private readonly IAgendamentoMensagemSicDAO agendamentoMensagemSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public AgendamentoMensagemSicBLO()
		{
			this.agendamentoMensagemSicDAO = Factory.CreateFactoryInstance().CreateInstance<IAgendamentoMensagemSicDAO>("AgendamentoMensagemSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		public IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic, int numeroLinhas, string ordem)
		{
			return this.agendamentoMensagemSicDAO.Selecionar(agendamentoMensagemSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		public IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic, string ordem)
		{
			return this.Selecionar(agendamentoMensagemSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		public IList<AgendamentoMensagemSic> Selecionar(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			return this.Selecionar(agendamentoMensagemSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de AgendamentoMensagemSic
		/// </summary>
		/// <returns>Retorna lista de AgendamentoMensagemSic</returns>
		public IList<AgendamentoMensagemSic> Selecionar()
		{
			return this.Selecionar(new AgendamentoMensagemSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instância de <see cref="AgendamentoMensagemSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de AgendamentoMensagemSic</returns>
		public AgendamentoMensagemSic SelecionarPrimeiro(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			IList<AgendamentoMensagemSic> lista = this.Selecionar(agendamentoMensagemSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new AgendamentoMensagemSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Incluir(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			if (null == agendamentoMensagemSic) throw (new ArgumentNullException());
			this.agendamentoMensagemSicDAO.Incluir(agendamentoMensagemSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar AgendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Atualizar(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			if (null == agendamentoMensagemSic) throw (new ArgumentNullException());
			this.agendamentoMensagemSicDAO.Atualizar(agendamentoMensagemSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir agendamentoMensagemSic
		/// </summary>
		/// <param name="agendamentoMensagemSic">Instance of <see cref="AgendamentoMensagemSic"/></param>
		public void Excluir(AgendamentoMensagemSic agendamentoMensagemSic)
		{
			if (null == agendamentoMensagemSic) throw (new ArgumentNullException());
			this.agendamentoMensagemSicDAO.Excluir(agendamentoMensagemSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


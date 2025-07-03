#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateHistoricoSicBLO.cs
// Class Name	        : StatusCalculoRebateHistoricoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/08/2012
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
	/// Representa funcionalidade relacionada a  StatusCalculoRebateHistoricoSicBLO
	/// </summary>
	internal partial class StatusCalculoRebateHistoricoSicBLO : IStatusCalculoRebateHistoricoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de StatusCalculoRebateHistoricoSicDAO 
		/// </summary>
		private readonly IStatusCalculoRebateHistoricoSicDAO statusCalculoRebateHistoricoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public StatusCalculoRebateHistoricoSicBLO()
		{
			this.statusCalculoRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicDAO>("StatusCalculoRebateHistoricoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		public IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			return this.statusCalculoRebateHistoricoSicDAO.Selecionar(statusCalculoRebateHistoricoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		public IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, string ordem)
		{
			return this.Selecionar(statusCalculoRebateHistoricoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		public IList<StatusCalculoRebateHistoricoSic> Selecionar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			return this.Selecionar(statusCalculoRebateHistoricoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de StatusCalculoRebateHistoricoSic</returns>
		public IList<StatusCalculoRebateHistoricoSic> Selecionar()
		{
			return this.Selecionar(new StatusCalculoRebateHistoricoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instância de <see cref="StatusCalculoRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de StatusCalculoRebateHistoricoSic</returns>
		public StatusCalculoRebateHistoricoSic SelecionarPrimeiro(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			IList<StatusCalculoRebateHistoricoSic> lista = this.Selecionar(statusCalculoRebateHistoricoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new StatusCalculoRebateHistoricoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Incluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			if (null == statusCalculoRebateHistoricoSic) throw (new ArgumentNullException());
			this.statusCalculoRebateHistoricoSicDAO.Incluir(statusCalculoRebateHistoricoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar StatusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Atualizar(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			if (null == statusCalculoRebateHistoricoSic) throw (new ArgumentNullException());
			this.statusCalculoRebateHistoricoSicDAO.Atualizar(statusCalculoRebateHistoricoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir statusCalculoRebateHistoricoSic
		/// </summary>
		/// <param name="statusCalculoRebateHistoricoSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
		public void Excluir(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic)
		{
			if (null == statusCalculoRebateHistoricoSic) throw (new ArgumentNullException());
			this.statusCalculoRebateHistoricoSicDAO.Excluir(statusCalculoRebateHistoricoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


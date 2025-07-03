#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusSicBLO.cs
// Class Name	        : StatusSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/21/2013
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
	/// Representa funcionalidade relacionada a  StatusSicBLO
	/// </summary>
	internal partial class StatusSicBLO : IStatusSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de StatusSicDAO 
		/// </summary>
		private readonly IStatusSicDAO statusSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public StatusSicBLO()
		{
			this.statusSicDAO = Factory.CreateFactoryInstance().CreateInstance<IStatusSicDAO>("StatusSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusSic</returns>
		public IList<StatusSic> Selecionar(StatusSic statusSic, int numeroLinhas, string ordem)
		{
			return this.statusSicDAO.Selecionar(statusSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusSic</returns>
		public IList<StatusSic> Selecionar(StatusSic statusSic, string ordem)
		{
			return this.Selecionar(statusSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de StatusSic</returns>
		public IList<StatusSic> Selecionar(StatusSic statusSic)
		{
			return this.Selecionar(statusSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusSic
		/// </summary>
		/// <returns>Retorna lista de StatusSic</returns>
		public IList<StatusSic> Selecionar()
		{
			return this.Selecionar(new StatusSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de StatusSic
		/// </summary>
		/// <param name="statusSic">Instância de <see cref="StatusSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de StatusSic</returns>
		public StatusSic SelecionarPrimeiro(StatusSic statusSic)
		{
			IList<StatusSic> lista = this.Selecionar(statusSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new StatusSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Incluir(StatusSic statusSic)
		{
			if (null == statusSic) throw (new ArgumentNullException());
			this.statusSicDAO.Incluir(statusSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar StatusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Atualizar(StatusSic statusSic)
		{
			if (null == statusSic) throw (new ArgumentNullException());
			this.statusSicDAO.Atualizar(statusSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir statusSic
		/// </summary>
		/// <param name="statusSic">Instance of <see cref="StatusSic"/></param>
		public void Excluir(StatusSic statusSic)
		{
			if (null == statusSic) throw (new ArgumentNullException());
			this.statusSicDAO.Excluir(statusSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


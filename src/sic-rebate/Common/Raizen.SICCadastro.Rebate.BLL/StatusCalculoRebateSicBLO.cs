#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateSicBLO.cs
// Class Name	        : StatusCalculoRebateSicBLO
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
	/// Representa funcionalidade relacionada a  StatusCalculoRebateSicBLO
	/// </summary>
	internal partial class StatusCalculoRebateSicBLO : IStatusCalculoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de StatusCalculoRebateSicDAO 
		/// </summary>
		private readonly IStatusCalculoRebateSicDAO statusCalculoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public StatusCalculoRebateSicBLO()
		{
			this.statusCalculoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateSicDAO>("StatusCalculoRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		public IList<StatusCalculoRebateSic> Selecionar(StatusCalculoRebateSic statusCalculoRebateSic, int numeroLinhas, string ordem)
		{
			return this.statusCalculoRebateSicDAO.Selecionar(statusCalculoRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		public IList<StatusCalculoRebateSic> Selecionar(StatusCalculoRebateSic statusCalculoRebateSic, string ordem)
		{
			return this.Selecionar(statusCalculoRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		public IList<StatusCalculoRebateSic> Selecionar(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			return this.Selecionar(statusCalculoRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de StatusCalculoRebateSic
		/// </summary>
		/// <returns>Retorna lista de StatusCalculoRebateSic</returns>
		public IList<StatusCalculoRebateSic> Selecionar()
		{
			return this.Selecionar(new StatusCalculoRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instância de <see cref="StatusCalculoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de StatusCalculoRebateSic</returns>
		public StatusCalculoRebateSic SelecionarPrimeiro(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			IList<StatusCalculoRebateSic> lista = this.Selecionar(statusCalculoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new StatusCalculoRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Incluir(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			if (null == statusCalculoRebateSic) throw (new ArgumentNullException());
			this.statusCalculoRebateSicDAO.Incluir(statusCalculoRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar StatusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Atualizar(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			if (null == statusCalculoRebateSic) throw (new ArgumentNullException());
			this.statusCalculoRebateSicDAO.Atualizar(statusCalculoRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir statusCalculoRebateSic
		/// </summary>
		/// <param name="statusCalculoRebateSic">Instance of <see cref="StatusCalculoRebateSic"/></param>
		public void Excluir(StatusCalculoRebateSic statusCalculoRebateSic)
		{
			if (null == statusCalculoRebateSic) throw (new ArgumentNullException());
			this.statusCalculoRebateSicDAO.Excluir(statusCalculoRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


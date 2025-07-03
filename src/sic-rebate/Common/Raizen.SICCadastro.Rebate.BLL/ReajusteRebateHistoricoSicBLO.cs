#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebateHistoricoSicBLO.cs
// Class Name	        : ReajusteRebateHistoricoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/08/2013
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
	/// Representa funcionalidade relacionada a  ReajusteRebateHistoricoSicBLO
	/// </summary>
	internal partial class ReajusteRebateHistoricoSicBLO : IReajusteRebateHistoricoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ReajusteRebateHistoricoSicDAO 
		/// </summary>
		private readonly IReajusteRebateHistoricoSicDAO reajusteRebateHistoricoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ReajusteRebateHistoricoSicBLO()
		{
			this.reajusteRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IReajusteRebateHistoricoSicDAO>("ReajusteRebateHistoricoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		public IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			return this.reajusteRebateHistoricoSicDAO.Selecionar(reajusteRebateHistoricoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		public IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, string ordem)
		{
			return this.Selecionar(reajusteRebateHistoricoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		public IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			return this.Selecionar(reajusteRebateHistoricoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		public IList<ReajusteRebateHistoricoSic> Selecionar()
		{
			return this.Selecionar(new ReajusteRebateHistoricoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteRebateHistoricoSic</returns>
		public ReajusteRebateHistoricoSic SelecionarPrimeiro(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			IList<ReajusteRebateHistoricoSic> lista = this.Selecionar(reajusteRebateHistoricoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ReajusteRebateHistoricoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Incluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			if (null == reajusteRebateHistoricoSic) throw (new ArgumentNullException());
			this.reajusteRebateHistoricoSicDAO.Incluir(reajusteRebateHistoricoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Atualizar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			if (null == reajusteRebateHistoricoSic) throw (new ArgumentNullException());
			this.reajusteRebateHistoricoSicDAO.Atualizar(reajusteRebateHistoricoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir reajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Excluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			if (null == reajusteRebateHistoricoSic) throw (new ArgumentNullException());
			this.reajusteRebateHistoricoSicDAO.Excluir(reajusteRebateHistoricoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


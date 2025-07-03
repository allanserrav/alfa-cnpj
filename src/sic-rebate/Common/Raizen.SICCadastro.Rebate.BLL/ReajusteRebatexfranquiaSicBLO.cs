#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebatexfranquiaSicBLO.cs
// Class Name	        : ReajusteRebatexfranquiaSicBLO
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
	/// Representa funcionalidade relacionada a  ReajusteRebatexfranquiaSicBLO
	/// </summary>
	internal partial class ReajusteRebatexfranquiaSicBLO : IReajusteRebatexfranquiaSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ReajusteRebatexfranquiaSicDAO 
		/// </summary>
		private readonly IReajusteRebatexfranquiaSicDAO reajusteRebatexfranquiaSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ReajusteRebatexfranquiaSicBLO()
		{
			this.reajusteRebatexfranquiaSicDAO = Factory.CreateFactoryInstance().CreateInstance<IReajusteRebatexfranquiaSicDAO>("ReajusteRebatexfranquiaSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		public IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, int numeroLinhas, string ordem)
		{
			return this.reajusteRebatexfranquiaSicDAO.Selecionar(reajusteRebatexfranquiaSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		public IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, string ordem)
		{
			return this.Selecionar(reajusteRebatexfranquiaSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		public IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			return this.Selecionar(reajusteRebatexfranquiaSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		public IList<ReajusteRebatexfranquiaSic> Selecionar()
		{
			return this.Selecionar(new ReajusteRebatexfranquiaSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ReajusteRebatexfranquiaSic</returns>
		public ReajusteRebatexfranquiaSic SelecionarPrimeiro(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			IList<ReajusteRebatexfranquiaSic> lista = this.Selecionar(reajusteRebatexfranquiaSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ReajusteRebatexfranquiaSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Incluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			if (null == reajusteRebatexfranquiaSic) throw (new ArgumentNullException());
			this.reajusteRebatexfranquiaSicDAO.Incluir(reajusteRebatexfranquiaSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Atualizar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			if (null == reajusteRebatexfranquiaSic) throw (new ArgumentNullException());
			this.reajusteRebatexfranquiaSicDAO.Atualizar(reajusteRebatexfranquiaSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir reajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Excluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			if (null == reajusteRebatexfranquiaSic) throw (new ArgumentNullException());
			this.reajusteRebatexfranquiaSicDAO.Excluir(reajusteRebatexfranquiaSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


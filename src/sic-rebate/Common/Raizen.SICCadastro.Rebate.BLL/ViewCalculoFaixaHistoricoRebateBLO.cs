#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewCalculoFaixaHistoricoRebateBLO.cs
// Class Name	        : ViewCalculoFaixaHistoricoRebateBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 01/29/2013
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
	/// Representa funcionalidade relacionada a  ViewCalculoFaixaHistoricoRebateBLO
	/// </summary>
	internal partial class ViewCalculoFaixaHistoricoRebateBLO : IViewCalculoFaixaHistoricoRebateBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ViewCalculoFaixaHistoricoRebateDAO 
		/// </summary>
		private readonly IViewCalculoFaixaHistoricoRebateDAO viewCalculoFaixaHistoricoRebateDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ViewCalculoFaixaHistoricoRebateBLO()
		{
			this.viewCalculoFaixaHistoricoRebateDAO = Factory.CreateFactoryInstance().CreateInstance<IViewCalculoFaixaHistoricoRebateDAO>("ViewCalculoFaixaHistoricoRebateDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		public IList<ViewCalculoFaixaHistoricoRebate> Selecionar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, int numeroLinhas, string ordem)
		{
			return this.viewCalculoFaixaHistoricoRebateDAO.Selecionar(viewCalculoFaixaHistoricoRebate, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		public IList<ViewCalculoFaixaHistoricoRebate> Selecionar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, string ordem)
		{
			return this.Selecionar(viewCalculoFaixaHistoricoRebate, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		public IList<ViewCalculoFaixaHistoricoRebate> Selecionar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			return this.Selecionar(viewCalculoFaixaHistoricoRebate, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <returns>Retorna lista de ViewCalculoFaixaHistoricoRebate</returns>
		public IList<ViewCalculoFaixaHistoricoRebate> Selecionar()
		{
			return this.Selecionar(new ViewCalculoFaixaHistoricoRebate(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instância de <see cref="ViewCalculoFaixaHistoricoRebate"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ViewCalculoFaixaHistoricoRebate</returns>
		public ViewCalculoFaixaHistoricoRebate SelecionarPrimeiro(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			IList<ViewCalculoFaixaHistoricoRebate> lista = this.Selecionar(viewCalculoFaixaHistoricoRebate, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ViewCalculoFaixaHistoricoRebate();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Incluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			if (null == viewCalculoFaixaHistoricoRebate) throw (new ArgumentNullException());
			this.viewCalculoFaixaHistoricoRebateDAO.Incluir(viewCalculoFaixaHistoricoRebate);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Atualizar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			if (null == viewCalculoFaixaHistoricoRebate) throw (new ArgumentNullException());
			this.viewCalculoFaixaHistoricoRebateDAO.Atualizar(viewCalculoFaixaHistoricoRebate);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir viewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Excluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			if (null == viewCalculoFaixaHistoricoRebate) throw (new ArgumentNullException());
			this.viewCalculoFaixaHistoricoRebateDAO.Excluir(viewCalculoFaixaHistoricoRebate);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewGtClienteRebateSicBLO.cs
// Class Name	        : ViewGtClienteRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 02/08/2013
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
	/// Representa funcionalidade relacionada a  ViewGtClienteRebateSicBLO
	/// </summary>
	internal partial class ViewGtClienteRebateSicBLO : IViewGtClienteRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ViewGtClienteRebateSicDAO 
		/// </summary>
		private readonly IViewGtClienteRebateSicDAO viewGtClienteRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ViewGtClienteRebateSicBLO()
		{
			this.viewGtClienteRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IViewGtClienteRebateSicDAO>("ViewGtClienteRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instância de <see cref="ViewGtClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGtClienteRebateSic</returns>
		public IList<ViewGtClienteRebateSic> Selecionar(ViewGtClienteRebateSic viewGtClienteRebateSic, int numeroLinhas, string ordem)
		{
			return this.viewGtClienteRebateSicDAO.Selecionar(viewGtClienteRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instância de <see cref="ViewGtClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGtClienteRebateSic</returns>
		public IList<ViewGtClienteRebateSic> Selecionar(ViewGtClienteRebateSic viewGtClienteRebateSic, string ordem)
		{
			return this.Selecionar(viewGtClienteRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instância de <see cref="ViewGtClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ViewGtClienteRebateSic</returns>
		public IList<ViewGtClienteRebateSic> Selecionar(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			return this.Selecionar(viewGtClienteRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGtClienteRebateSic
		/// </summary>
		/// <returns>Retorna lista de ViewGtClienteRebateSic</returns>
		public IList<ViewGtClienteRebateSic> Selecionar()
		{
			return this.Selecionar(new ViewGtClienteRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instância de <see cref="ViewGtClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ViewGtClienteRebateSic</returns>
		public ViewGtClienteRebateSic SelecionarPrimeiro(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			IList<ViewGtClienteRebateSic> lista = this.Selecionar(viewGtClienteRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ViewGtClienteRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Incluir(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			if (null == viewGtClienteRebateSic) throw (new ArgumentNullException());
			this.viewGtClienteRebateSicDAO.Incluir(viewGtClienteRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Atualizar(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			if (null == viewGtClienteRebateSic) throw (new ArgumentNullException());
			this.viewGtClienteRebateSicDAO.Atualizar(viewGtClienteRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir viewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Excluir(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			if (null == viewGtClienteRebateSic) throw (new ArgumentNullException());
			this.viewGtClienteRebateSicDAO.Excluir(viewGtClienteRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


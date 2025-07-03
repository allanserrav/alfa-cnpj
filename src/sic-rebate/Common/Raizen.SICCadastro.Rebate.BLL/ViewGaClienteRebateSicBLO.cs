#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ViewGaClienteRebateSicBLO.cs
// Class Name	        : ViewGaClienteRebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage / Romildo Cruz
// Creation Date 	    : 01/24/2013
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
	/// Representa funcionalidade relacionada a  ViewGaClienteRebateSicBLO
	/// </summary>
	internal partial class ViewGaClienteRebateSicBLO : IViewGaClienteRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ViewGaClienteRebateSicDAO 
		/// </summary>
		private readonly IViewGaClienteRebateSicDAO viewGaClienteRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ViewGaClienteRebateSicBLO()
		{
			this.viewGaClienteRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IViewGaClienteRebateSicDAO>("ViewGaClienteRebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		public IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic, int numeroLinhas, string ordem)
		{
			return this.viewGaClienteRebateSicDAO.Selecionar(viewGaClienteRebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		public IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic, string ordem)
		{
			return this.Selecionar(viewGaClienteRebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		public IList<ViewGaClienteRebateSic> Selecionar(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			return this.Selecionar(viewGaClienteRebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ViewGaClienteRebateSic
		/// </summary>
		/// <returns>Retorna lista de ViewGaClienteRebateSic</returns>
		public IList<ViewGaClienteRebateSic> Selecionar()
		{
			return this.Selecionar(new ViewGaClienteRebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instância de <see cref="ViewGaClienteRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ViewGaClienteRebateSic</returns>
		public ViewGaClienteRebateSic SelecionarPrimeiro(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			IList<ViewGaClienteRebateSic> lista = this.Selecionar(viewGaClienteRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ViewGaClienteRebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Incluir(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			if (null == viewGaClienteRebateSic) throw (new ArgumentNullException());
			this.viewGaClienteRebateSicDAO.Incluir(viewGaClienteRebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Atualizar(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			if (null == viewGaClienteRebateSic) throw (new ArgumentNullException());
			this.viewGaClienteRebateSicDAO.Atualizar(viewGaClienteRebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir viewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Excluir(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			if (null == viewGaClienteRebateSic) throw (new ArgumentNullException());
			this.viewGaClienteRebateSicDAO.Excluir(viewGaClienteRebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


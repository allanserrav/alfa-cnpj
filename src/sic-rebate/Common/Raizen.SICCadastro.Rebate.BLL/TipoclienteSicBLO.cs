#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TipoclienteSicBLO.cs
// Class Name	        : TipoclienteSicBLO
// Author		        : Romildo Cruz
// Creation Date 	    : 09/26/2012
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
	/// Representa funcionalidade relacionada a  TipoclienteSicBLO
	/// </summary>
	internal class TipoclienteSicBLO : ITipoclienteSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de TipoclienteSicDAO 
		/// </summary>
		private readonly ITipoclienteSicDAO tipoclienteSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public TipoclienteSicBLO()
		{
			this.tipoclienteSicDAO = Factory.CreateFactoryInstance().CreateInstance<ITipoclienteSicDAO>("TipoclienteSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		public IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic, int numeroLinhas, string ordem)
		{
			return this.tipoclienteSicDAO.Selecionar(tipoclienteSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		public IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic, string ordem)
		{
			return this.Selecionar(tipoclienteSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		public IList<TipoclienteSic> Selecionar(TipoclienteSic tipoclienteSic)
		{
			return this.Selecionar(tipoclienteSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de TipoclienteSic
		/// </summary>
		/// <returns>Retorna lista de TipoclienteSic</returns>
		public IList<TipoclienteSic> Selecionar()
		{
			return this.Selecionar(new TipoclienteSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instância de <see cref="TipoclienteSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TipoclienteSic</returns>
		public TipoclienteSic SelecionarPrimeiro(TipoclienteSic tipoclienteSic)
		{
			IList<TipoclienteSic> lista = this.Selecionar(tipoclienteSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new TipoclienteSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Incluir(TipoclienteSic tipoclienteSic)
		{
			if (null == tipoclienteSic) throw (new ArgumentNullException());
			this.tipoclienteSicDAO.Incluir(tipoclienteSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar TipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Atualizar(TipoclienteSic tipoclienteSic)
		{
			if (null == tipoclienteSic) throw (new ArgumentNullException());
			this.tipoclienteSicDAO.Atualizar(tipoclienteSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir tipoclienteSic
		/// </summary>
		/// <param name="tipoclienteSic">Instance of <see cref="TipoclienteSic"/></param>
		public void Excluir(TipoclienteSic tipoclienteSic)
		{
			if (null == tipoclienteSic) throw (new ArgumentNullException());
			this.tipoclienteSicDAO.Excluir(tipoclienteSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


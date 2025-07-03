#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ProdutoSicBLO.cs
// Class Name	        : ProdutoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 10/31/2012
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
	/// Representa funcionalidade relacionada a  ProdutoSicBLO
	/// </summary>
	internal partial class ProdutoSicBLO : IProdutoSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de ProdutoSicDAO 
		/// </summary>
		private readonly IProdutoSicDAO produtoSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public ProdutoSicBLO()
		{
			this.produtoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IProdutoSicDAO>("ProdutoSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		public IList<ProdutoSic> Selecionar(ProdutoSic produtoSic, int numeroLinhas, string ordem)
		{
			return this.produtoSicDAO.Selecionar(produtoSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		public IList<ProdutoSic> Selecionar(ProdutoSic produtoSic, string ordem)
		{
			return this.Selecionar(produtoSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		public IList<ProdutoSic> Selecionar(ProdutoSic produtoSic)
		{
			return this.Selecionar(produtoSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <returns>Retorna lista de ProdutoSic</returns>
		public IList<ProdutoSic> Selecionar()
		{
			return this.Selecionar(new ProdutoSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ProdutoSic</returns>
		public ProdutoSic SelecionarPrimeiro(ProdutoSic produtoSic)
		{
			IList<ProdutoSic> lista = this.Selecionar(produtoSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new ProdutoSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Incluir(ProdutoSic produtoSic)
		{
			if (null == produtoSic) throw (new ArgumentNullException());
			this.produtoSicDAO.Incluir(produtoSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Atualizar(ProdutoSic produtoSic)
		{
			if (null == produtoSic) throw (new ArgumentNullException());
			this.produtoSicDAO.Atualizar(produtoSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir produtoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		public void Excluir(ProdutoSic produtoSic)
		{
			if (null == produtoSic) throw (new ArgumentNullException());
			this.produtoSicDAO.Excluir(produtoSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


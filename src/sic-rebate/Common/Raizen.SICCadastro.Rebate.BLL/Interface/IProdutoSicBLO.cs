#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IProdutoSicBLO.cs
// Class Name	        : IProdutoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 25/10/2012
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
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IProdutoSicBLO
	/// </summary>
	public interface IProdutoSicBLO
	{
		#region Metodos de IProdutoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		IList<ProdutoSic> Selecionar(ProdutoSic produtoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		IList<ProdutoSic> Selecionar(ProdutoSic produtoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de ProdutoSic</returns>
		IList<ProdutoSic> Selecionar(ProdutoSic produtoSic);
		
		/// <summary>
		/// Selecionar os dados de ProdutoSic
		/// </summary>
		/// <returns>Retorna lista de ProdutoSic</returns>
		IList<ProdutoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instância de <see cref="ProdutoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de ProdutoSic</returns>
		ProdutoSic SelecionarPrimeiro(ProdutoSic produtoSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		void Incluir(ProdutoSic produtoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ProdutoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		void Atualizar(ProdutoSic produtoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui produtoSic
		/// </summary>
		/// <param name="produtoSic">Instance of <see cref="ProdutoSic"/></param>
		void Excluir(ProdutoSic produtoSic);
		#endregion Excluir
		
		#endregion IProdutoSicBLO
	}
}

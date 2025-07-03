#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICategoriaSicBLO.cs
// Class Name	        : ICategoriaSicBLO
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
	/// Representa funcionalidade relacionada a ICategoriaSicBLO
	/// </summary>
	public interface ICategoriaSicBLO
	{
		#region Metodos de ICategoriaSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic);
		
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <returns>Retorna lista de CategoriaSic</returns>
		IList<CategoriaSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CategoriaSic</returns>
		CategoriaSic SelecionarPrimeiro(CategoriaSic categoriaSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Incluir(CategoriaSic categoriaSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Atualizar(CategoriaSic categoriaSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui categoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		void Excluir(CategoriaSic categoriaSic);
		#endregion Excluir
		
		#endregion ICategoriaSicBLO
	}
}

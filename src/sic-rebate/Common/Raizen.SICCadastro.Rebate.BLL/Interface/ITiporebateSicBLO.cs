#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ITiporebateSicBLO.cs
// Class Name	        : ITiporebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 05/11/2012
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
	/// Representa funcionalidade relacionada a ITiporebateSicBLO
	/// </summary>
	public partial interface ITiporebateSicBLO
	{
		#region Metodos de ITiporebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic);
		
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <returns>Retorna lista de TiporebateSic</returns>
		IList<TiporebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de TiporebateSic</returns>
		TiporebateSic SelecionarPrimeiro(TiporebateSic tiporebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		void Incluir(TiporebateSic tiporebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		void Atualizar(TiporebateSic tiporebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		void Excluir(TiporebateSic tiporebateSic);
		#endregion Excluir
		
		#endregion ITiporebateSicBLO
	}
}

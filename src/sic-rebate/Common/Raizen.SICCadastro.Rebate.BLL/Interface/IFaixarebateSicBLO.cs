#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IFaixarebateSicBLO.cs
// Class Name	        : IFaixarebateSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	/// Representa funcionalidade relacionada a IFaixarebateSicBLO
	/// </summary>
	public partial interface IFaixarebateSicBLO
	{
		#region Metodos de IFaixarebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic);
		
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		IList<FaixarebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de FaixarebateSic</returns>
		FaixarebateSic SelecionarPrimeiro(FaixarebateSic faixarebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		void Incluir(FaixarebateSic faixarebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		void Atualizar(FaixarebateSic faixarebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui faixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		void Excluir(FaixarebateSic faixarebateSic);
		#endregion Excluir
		
		#endregion IFaixarebateSicBLO
	}
}

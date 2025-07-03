#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateProporcionalSicBLO.cs
// Class Name	        : ICalculoRebateProporcionalSicBLO
// Author		        : Murilo Beltrame
// Creation Date 	    : 22/08/2014
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
	/// Representa funcionalidade relacionada a ICalculoRebateProporcionalSicBLO
	/// </summary>
	public partial interface ICalculoRebateProporcionalSicBLO
	{
		#region Metodos de ICalculoRebateProporcionalSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		IList<CalculoRebateProporcionalSic> Selecionar(CalculoRebateProporcionalSic calculoRebateProporcionalSic);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <returns>Retorna lista de CalculoRebateProporcionalSic</returns>
		IList<CalculoRebateProporcionalSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instância de <see cref="CalculoRebateProporcionalSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CalculoRebateProporcionalSic</returns>
		CalculoRebateProporcionalSic SelecionarPrimeiro(CalculoRebateProporcionalSic calculoRebateProporcionalSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		void Incluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		void Atualizar(CalculoRebateProporcionalSic calculoRebateProporcionalSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		void Excluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic);
		#endregion Excluir
		
		#endregion ICalculoRebateProporcionalSicBLO
	}
}

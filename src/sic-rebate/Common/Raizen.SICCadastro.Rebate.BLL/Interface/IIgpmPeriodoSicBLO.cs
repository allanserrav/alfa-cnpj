#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IIgpmPeriodoSicBLO.cs
// Class Name	        : IIgpmPeriodoSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	/// Representa funcionalidade relacionada a IIgpmPeriodoSicBLO
	/// </summary>
	public partial interface IIgpmPeriodoSicBLO
	{
		#region Metodos de IIgpmPeriodoSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		IList<IgpmPeriodoSic> Selecionar(IgpmPeriodoSic igpmPeriodoSic);
		
		/// <summary>
		/// Selecionar os dados de IgpmPeriodoSic
		/// </summary>
		/// <returns>Retorna lista de IgpmPeriodoSic</returns>
		IList<IgpmPeriodoSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instância de <see cref="IgpmPeriodoSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de IgpmPeriodoSic</returns>
		IgpmPeriodoSic SelecionarPrimeiro(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Incluir(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza IgpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Atualizar(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui igpmPeriodoSic
		/// </summary>
		/// <param name="igpmPeriodoSic">Instance of <see cref="IgpmPeriodoSic"/></param>
		void Excluir(IgpmPeriodoSic igpmPeriodoSic);
		#endregion Excluir
		
		#endregion IIgpmPeriodoSicBLO
	}
}

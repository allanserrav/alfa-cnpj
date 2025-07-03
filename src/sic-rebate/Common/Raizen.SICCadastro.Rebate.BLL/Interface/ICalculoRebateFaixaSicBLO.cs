#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateFaixaSicBLO.cs
// Class Name	        : ICalculoRebateFaixaSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 04/01/2013
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
	/// Representa funcionalidade relacionada a ICalculoRebateFaixaSicBLO
	/// </summary>
	public partial interface ICalculoRebateFaixaSicBLO
	{
		#region Metodos de ICalculoRebateFaixaSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		IList<CalculoRebateFaixaSic> Selecionar(CalculoRebateFaixaSic calculoRebateFaixaSic);
		
		/// <summary>
		/// Selecionar os dados de CalculoRebateFaixaSic
		/// </summary>
		/// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
		IList<CalculoRebateFaixaSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de CalculoRebateFaixaSic</returns>
		CalculoRebateFaixaSic SelecionarPrimeiro(CalculoRebateFaixaSic calculoRebateFaixaSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		void Incluir(CalculoRebateFaixaSic calculoRebateFaixaSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		void Atualizar(CalculoRebateFaixaSic calculoRebateFaixaSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateFaixaSic
		/// </summary>
		/// <param name="calculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
		void Excluir(CalculoRebateFaixaSic calculoRebateFaixaSic);
		#endregion Excluir
		
		#endregion ICalculoRebateFaixaSicBLO
	}
}

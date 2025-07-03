#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDebitoRebateSicBLO.cs
// Class Name	        : IDebitoRebateSicBLO
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
	/// Representa funcionalidade relacionada a IDebitoRebateSicBLO
	/// </summary>
	public partial interface IDebitoRebateSicBLO
	{
		#region Metodos de IDebitoRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		IList<DebitoRebateSic> Selecionar(DebitoRebateSic debitoRebateSic);
		
		/// <summary>
		/// Selecionar os dados de DebitoRebateSic
		/// </summary>
		/// <returns>Retorna lista de DebitoRebateSic</returns>
		IList<DebitoRebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instância de <see cref="DebitoRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de DebitoRebateSic</returns>
		DebitoRebateSic SelecionarPrimeiro(DebitoRebateSic debitoRebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Incluir(DebitoRebateSic debitoRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza DebitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Atualizar(DebitoRebateSic debitoRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui debitoRebateSic
		/// </summary>
		/// <param name="debitoRebateSic">Instance of <see cref="DebitoRebateSic"/></param>
		void Excluir(DebitoRebateSic debitoRebateSic);
		#endregion Excluir
		
		#endregion IDebitoRebateSicBLO
	}
}

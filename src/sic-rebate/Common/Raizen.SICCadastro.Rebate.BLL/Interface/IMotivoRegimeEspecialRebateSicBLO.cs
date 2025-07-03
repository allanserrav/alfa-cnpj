#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IMotivoRegimeEspecialRebateSicBLO.cs
// Class Name	        : IMotivoRegimeEspecialRebateSicBLO
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
	/// Representa funcionalidade relacionada a IMotivoRegimeEspecialRebateSicBLO
	/// </summary>
	public partial interface IMotivoRegimeEspecialRebateSicBLO
	{
		#region Metodos de IMotivoRegimeEspecialRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, int numeroLinhas, string ordem);
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic, string ordem);
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		IList<MotivoRegimeEspecialRebateSic> Selecionar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic);
		
		/// <summary>
		/// Selecionar os dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <returns>Retorna lista de MotivoRegimeEspecialRebateSic</returns>
		IList<MotivoRegimeEspecialRebateSic> Selecionar();
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instância de <see cref="MotivoRegimeEspecialRebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de MotivoRegimeEspecialRebateSic</returns>
		MotivoRegimeEspecialRebateSic SelecionarPrimeiro(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic);
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		void Incluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic);
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza MotivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		void Atualizar(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic);
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui motivoRegimeEspecialRebateSic
		/// </summary>
		/// <param name="motivoRegimeEspecialRebateSic">Instance of <see cref="MotivoRegimeEspecialRebateSic"/></param>
		void Excluir(MotivoRegimeEspecialRebateSic motivoRegimeEspecialRebateSic);
		#endregion Excluir
		
		#endregion IMotivoRegimeEspecialRebateSicBLO
	}
}

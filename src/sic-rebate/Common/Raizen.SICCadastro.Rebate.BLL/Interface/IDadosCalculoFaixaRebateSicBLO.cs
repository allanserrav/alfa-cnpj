#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDadosCalculoFaixaRebateSicBLO.cs
// Class Name	        : IDadosCalculoFaixaRebateSicBLO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 27/01/2020
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
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IDadosCalculoFaixaRebateSicBLO
	/// </summary>
	public partial interface IDadosCalculoFaixaRebateSicBLO
	{
		#region Metodos de IDadosCalculoFaixaRebateSicBLO 

		#region Selecionar
		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <param name="numeroLinhas"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, int numeroLinhas, string ordem);

		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, string ordem);

		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <returns></returns>
		IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic);
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<DadosCalculoRebateFaixaSic> Selecionar();

		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de FaixarebateSic</returns>
		DadosCalculoRebateFaixaSic SelecionarPrimeiro(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic);
		#endregion Selecionar

		#endregion IDadosCalculoFaixaRebateSicBLO
	}
}
#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDadosCalculoRebateSicBLO.cs
// Class Name	        : IDadosCalculoRebateSicBLO
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
	/// Representa funcionalidade relacionada a ICalculoRebateSicBLO
	/// </summary>
	public partial interface IDadosCalculoRebateSicBLO
	{
		#region Metodos de IDadosCalculoRebateSicBLO 

		#region Selecionar
		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic"></param>
		/// <param name="numeroLinhas"></param>
		/// <param name="ordem"></param>
		/// <returns>Retorna Lista de DadosCalculoRebateSic</returns>
		IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, int numeroLinhas, string ordem);

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, string ordem);
		
		
		IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic);

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <returns></returns>
		IList<DadosCalculoRebateSic> Selecionar();

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <returns></returns>
		DadosCalculoRebateSic SelecionarPrimeiro(DadosCalculoRebateSic dadosCalculoRebateSic);
		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <returns></returns>
		DadosCalculoRebateSic SelecionarUltimo(DadosCalculoRebateSic dadosCalculoRebateSic);
		#endregion Selecionar

		#region Incluir
		/// <summary>
		/// Incluir DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		void Incluir(DadosCalculoRebateSic dadosCalculoRebateSic);
		#endregion Incluir

		#endregion IDadosCalculoRebateSicBLO
	}
}
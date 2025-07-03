#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDadosCalculoFaixaRebateSicDAO.cs
// Class Name	        : IDadosCalculoFaixaRebateSicDAO
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

namespace Raizen.SICCadastro.Rebate.DAL
{
	/// <summary>
	/// Representa funcionalidade relacionada a IFaixarebateSicDAO
	/// </summary>
	public partial interface IDadosCalculoFaixaRebateSicDAO
	{
		#region Metodos de IFaixarebateSicDAO 

		#region Selecionar
		/// <summary>
		/// Selecionar DadosCalculoRebateFaixaSic
		/// </summary>
		/// <param name="dadosCalculoRebateFaixaSic"></param>
		/// <param name="numeroLinhas"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, int numeroLinhas, string ordem);
		#endregion Selecionar
		
		#endregion IFaixarebateSicDAO
	}
}

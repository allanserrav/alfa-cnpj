#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IDadosCalculoRebateDAO.cs
// Class Name	        : IDadosCalculoRebateDAO
// Author		        : CDI
// Creation Date 	    : 22/01/2020
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
	/// Representa funcionalidade relacionada a IDadosCalculoRebateDAO
	/// </summary>
	public interface IDadosCalculoRebateSicDAO
	{
		void Incluir(DadosCalculoRebateSic dados);

		IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, int numeroLinhas, string ordem);
	}
}
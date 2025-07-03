#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IAcertoCalculoRebateSicDAO.cs
// Class Name	        : IAcertoCalculoRebateSicDAO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 23/01/2020
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
	/// Representa funcionalidade relacionada a ICalculoRebateSicDAO
	/// </summary>
	public partial interface IAcertoCalculoRebateSicDAO
	{
		#region Metodos de IAcertoCalculoRebateSicDAO 
		
		#region Selecionar
		/// <summary>
		/// Filtro
		/// </summary>
		/// <param name="filtro"></param>
		/// <returns></returns>
		IList<AcertoCalculoRebateSic> Selecionar(string ibm);
		#endregion Selecionar
		
		#endregion IAcertoCalculoRebateSicDAO
	}
}
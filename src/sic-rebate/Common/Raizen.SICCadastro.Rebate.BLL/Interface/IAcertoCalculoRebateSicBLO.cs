#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IAcertoCalculoRebateSicBLO.cs
// Class Name	        : IAcertoCalculoRebateSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a ICalculoRebateSicBLO
	/// </summary>
	public partial interface IAcertoCalculoRebateSicBLO
	{
		#region Metodos de ICalculoRebateSicBLO 
		
		#region Selecionar
		/// <summary>
		/// Selecionar
		/// </summary>
		/// <param name="ibm"></param>
		/// <returns></returns>
		IList<AcertoCalculoRebateSic> Selecionar(string ibm);
		#endregion

		#region PesquisarPorIBM
		/// <summary>
		/// PesquisarPorIBM
		/// </summary>
		/// <param name="ibm"></param>
		/// <returns></returns>
		List<AcertoCalculoRebateSic> PesquisarPorIBM(ClienteSic cli);
		#endregion

		#region LancarAjustes
		/// <summary>
		/// LancarAjustes
		/// </summary>
		/// <param name="list"></param>
		void LancarAjustes(List<AcertoCalculoRebateSic> list);

		/// <summary>
		/// InjecaoDao utilizado para classe de testes
		/// </summary>
		/// <param name="dao"></param>
		void InjecaoDao(IAcertoCalculoRebateSicDAO dao);
		#endregion

		#endregion ICalculoRebateSicBLO
	}
}
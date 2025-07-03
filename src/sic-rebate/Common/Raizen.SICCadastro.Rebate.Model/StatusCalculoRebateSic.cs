#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateSic.cs
// Class Name	        : StatusCalculoRebateSic
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
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.Model
{
	/// <summary>
	/// Entitade Representada por StatusCalculoRebateSic
	/// </summary>
	[Serializable]
	public class StatusCalculoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqStatusCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NmStatusCalculoRebateSic
		/// </summary>
		public string NmStatusCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DsStatusCalculoRebateSic
		/// </summary>
		public string DsStatusCalculoRebateSic { get; set; }
		#endregion
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusSic.cs
// Class Name	        : StatusSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/01/2013
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
	/// Entitade Representada por StatusSic
	/// </summary>
	[Serializable]
	public class StatusSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqStatusSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusSic { get; set; }
		/// <summary>
		/// Propriedade NmStatusSic
		/// </summary>
		public string NmStatusSic { get; set; }
		/// <summary>
		/// Propriedade DsStatusSic
		/// </summary>
		public string DsStatusSic { get; set; }
		#endregion
	}
}

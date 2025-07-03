#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TipoclienteSic.cs
// Class Name	        : TipoclienteSic
// Author		        : Romildo Cruz
// Creation Date 	    : 26/09/2012
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
	/// Entitade Representada por TipoclienteSic
	/// </summary>
	[Serializable]
	public class TipoclienteSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqTipoclienteSic
		/// </summary>
		public Nullable<Int32> NrSeqTipoclienteSic { get; set; }
		/// <summary>
		/// Propriedade NmTipoclienteSic
		/// </summary>
		public string NmTipoclienteSic { get; set; }
		/// <summary>
		/// Propriedade DsTipoclienteSic
		/// </summary>
		public string DsTipoclienteSic { get; set; }
		#endregion
	}
}

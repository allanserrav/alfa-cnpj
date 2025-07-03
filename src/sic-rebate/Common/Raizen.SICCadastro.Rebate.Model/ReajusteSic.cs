#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteSic.cs
// Class Name	        : ReajusteSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	/// Entitade Representada por ReajusteSic
	/// </summary>
	[Serializable]
	public class ReajusteSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqReajusteSic
		/// </summary>
		public Nullable<Int32> NrSeqReajusteSic { get; set; }
		/// <summary>
		/// Propriedade NmReajusteSic
		/// </summary>
		public string NmReajusteSic { get; set; }
		/// <summary>
		/// Propriedade VlPercentReajusteSic
		/// </summary>
		public Nullable<decimal> VlPercentReajusteSic { get; set; }
		/// <summary>
		/// Propriedade DsReajusteSic
		/// </summary>
		public string DsReajusteSic { get; set; }
		#endregion
	}
}

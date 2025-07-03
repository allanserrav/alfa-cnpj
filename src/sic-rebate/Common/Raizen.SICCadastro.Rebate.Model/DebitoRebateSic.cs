#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DebitoRebateSic.cs
// Class Name	        : DebitoRebateSic
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
	/// Entitade Representada por DebitoRebateSic
	/// </summary>
	[Serializable]
	public class DebitoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqDebitoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqDebitoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtConsultaSic
		/// </summary>
		public Nullable<DateTime> DtConsultaSic { get; set; }
		/// <summary>
		/// Propriedade VlDebitoSic
		/// </summary>
		public Nullable<decimal> VlDebitoSic { get; set; }
		#endregion
	}
}

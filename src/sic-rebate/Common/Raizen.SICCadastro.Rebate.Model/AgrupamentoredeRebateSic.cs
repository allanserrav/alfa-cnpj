#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgrupamentoredeRebateSic.cs
// Class Name	        : AgrupamentoredeRebateSic
// Author		        : Murilo Beltrame
// Creation Date 	    : 13/08/2014
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
	/// Entitade Representada por AgrupamentoredeRebateSic
	/// </summary>
	[Serializable]
	public class AgrupamentoredeRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqAgrupamentoredeRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqAgrupamentoredeRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmRebateSic
		/// </summary>
		public string NrIbmRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrGruporedeRebateSic
		/// </summary>
		public Nullable<Int32> NrGruporedeRebateSic { get; set; }
		#endregion
	}
}

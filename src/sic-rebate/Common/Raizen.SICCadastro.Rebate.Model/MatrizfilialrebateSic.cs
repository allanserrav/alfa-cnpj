#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MatrizfilialrebateSic.cs
// Class Name	        : MatrizfilialrebateSic
// Author		        : Murilo Beltrame
// Creation Date 	    : 29/07/2014
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
	/// Entitade Representada por MatrizfilialrebateSic
	/// </summary>
	[Serializable]
	public class MatrizfilialrebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqMatrizfilialrebateSic
		/// </summary>
		public Nullable<Int32> NrSeqMatrizfilialrebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebatematrizSic
		/// </summary>
		public Nullable<Int32> NrSeqRebatematrizSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmFilialSic
		/// </summary>
		public string NrIbmFilialSic { get; set; }
		/// <summary>
		/// Propriedade NrCdfornecedorFilialSic
		/// </summary>
		public string NrCdfornecedorFilialSic { get; set; }
		#endregion
	}
}

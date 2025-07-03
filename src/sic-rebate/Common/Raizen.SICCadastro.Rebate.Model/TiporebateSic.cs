#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TiporebateSic.cs
// Class Name	        : TiporebateSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 05/11/2012
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
	/// Entitade Representada por TiporebateSic
	/// </summary>
	[Serializable]
	public class TiporebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqTiporebateSic
		/// </summary>
		public Nullable<Int32> NrSeqTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade NmTiporebateSic
		/// </summary>
		public string NmTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade DsTiporebateSic
		/// </summary>
		public string DsTiporebateSic { get; set; }
		#endregion
	}
}

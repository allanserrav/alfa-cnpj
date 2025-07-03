#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AvisoSic.cs
// Class Name	        : AvisoSic
// Author		        : Hélio Jânio Ferreira
// Creation Date 	    : 17/01/2013
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
	/// Entitade Representada por AvisoSic
	/// </summary>
	[Serializable]
	public class AvisoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqAvisoSic
		/// </summary>
		public Nullable<Int32> NrSeqAvisoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTipoclienteSic
		/// </summary>
		public Nullable<Int32> NrSeqTipoclienteSic { get; set; }
		/// <summary>
		/// Propriedade DsAvisoSic
		/// </summary>
		public string DsAvisoSic { get; set; }
		/// <summary>
		/// Propriedade StAvisoSic
		/// </summary>
		public Nullable<Boolean> StAvisoSic { get; set; }
		/// <summary>
		/// Propriedade NmUsuarioexSic
		/// </summary>
		public string NmUsuarioexSic { get; set; }
		/// <summary>
		/// Propriedade DtExclusaoavisoSic
		/// </summary>
		public Nullable<DateTime> DtExclusaoavisoSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmAvisoSic
		/// </summary>
		public string NrIbmAvisoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTipoAvisoSic
		/// </summary>
		public Nullable<Int32> NrSeqTipoAvisoSic { get; set; }
		/// <summary>
		/// Propriedade DtInclusaoavisoSic
		/// </summary>
		public Nullable<DateTime> DtInclusaoavisoSic { get; set; }
		#endregion
	}
}

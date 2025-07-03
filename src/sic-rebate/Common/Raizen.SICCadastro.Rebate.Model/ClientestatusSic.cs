#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClientestatusSic.cs
// Class Name	        : ClientestatusSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 13/02/2013
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
	/// Entitade Representada por ClientestatusSic
	/// </summary>
	[Serializable]
	public class ClientestatusSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqClientestausSic
		/// </summary>
		public Nullable<Int32> NrSeqClientestausSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqStatusSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqClienteSic
		/// </summary>
		public Nullable<Int32> NrSeqClienteSic { get; set; }
		/// <summary>
		/// Propriedade DtAlteracaoSic
		/// </summary>
		public Nullable<DateTime> DtAlteracaoSic { get; set; }
		/// <summary>
		/// Propriedade NmLoginSic
		/// </summary>
		public string NmLoginSic { get; set; }
		/// <summary>
		/// Propriedade DsObservacaoSic
		/// </summary>
		public string DsObservacaoSic { get; set; }
		#endregion
	}
}

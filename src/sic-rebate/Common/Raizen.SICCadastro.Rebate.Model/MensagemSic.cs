#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MensagemSic.cs
// Class Name	        : MensagemSic
// Author		        : Romildo Cruz
// Creation Date 	    : 22/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 18/12/2012
//	Reason for modification : Change namespace SICCadastro to SICCadastro.Rebate
//	Modification Done       : 18/12/2012
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
	/// Entitade Representada por MensagemSic
	/// </summary>
	[Serializable]
	public class MensagemSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqMensagemSic
		/// </summary>
		public Nullable<Int32> NrSeqMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NmMensagemSic
		/// </summary>
		public string NmMensagemSic { get; set; }
		/// <summary>
		/// Propriedade DsMensagemSic
		/// </summary>
		public string DsMensagemSic { get; set; }
		/// <summary>
		/// Propriedade DsEmailMensagemSic
		/// </summary>
		public string DsEmailMensagemSic { get; set; }
		#endregion
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateHistoricoSic.cs
// Class Name	        : StatusCalculoRebateHistoricoSic
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
	/// Entitade Representada por StatusCalculoRebateHistoricoSic
	/// </summary>
	[Serializable]
	public class StatusCalculoRebateHistoricoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqStatusCalculoRebateHistoricoSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusCalculoRebateHistoricoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqStatusCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusCalculoRebateSic { get; set; }
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

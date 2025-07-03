#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : SaldoRebateSic.cs
// Class Name	        : SaldoRebateSic
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
	/// Entitade Representada por SaldoRebateSic
	/// </summary>
	[Serializable]
	public class SaldoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqSaldoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqSaldoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlSaldoAtualSic
		/// </summary>
		public Nullable<decimal> VlSaldoAtualSic { get; set; }
		/// <summary>
		/// Propriedade VlLancamentoSic
		/// </summary>
		public Nullable<decimal> VlLancamentoSic { get; set; }
		/// <summary>
		/// Propriedade DtLancamentoSic
		/// </summary>
		public Nullable<DateTime> DtLancamentoSic { get; set; }
		/// <summary>
		/// Propriedade DsObsComplementoSic
		/// </summary>
		public string DsObsComplementoSic { get; set; }
		#endregion
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebateHistoricoSic.cs
// Class Name	        : ReajusteRebateHistoricoSic
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
	/// Entitade Representada por ReajusteRebateHistoricoSic
	/// </summary>
	[Serializable]
	public class ReajusteRebateHistoricoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqReajusteRebateHistoricoSic
		/// </summary>
		public Nullable<Int32> NrSeqReajusteRebateHistoricoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixarebateSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixarebateSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoRebateSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqReajusteSic
		/// </summary>
		public Nullable<Int32> NrSeqReajusteSic { get; set; }
		/// <summary>
		/// Propriedade VlIgpmReajusteRebateSic
		/// </summary>
		public Nullable<decimal> VlIgpmReajusteRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlManualReajusteRebateSic
		/// </summary>
		public Nullable<decimal> VlManualReajusteRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrPeriodoReajusteRebateSic
		/// </summary>
		public Nullable<Int32> NrPeriodoReajusteRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtAlteracaoSic
		/// </summary>
		public Nullable<DateTime> DtAlteracaoSic { get; set; }
		#endregion
	}
}

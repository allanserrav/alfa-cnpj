#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateSic.cs
// Class Name	        : CalculoRebateSic
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 08/08/2014
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
	/// Entitade Representada por CalculoRebateSic
	/// </summary>
	[Serializable]
	public class CalculoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade DtPagamentoSic
		/// </summary>
		public Nullable<DateTime> DtPagamentoSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoTotalSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoTotalSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeTotal
		/// </summary>
		public Nullable<decimal> VlVolumeTotal { get; set; }
		/// <summary>
		/// Propriedade DsObsCalculoSic
		/// </summary>
		public string DsObsCalculoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqStatusCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqStatusCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade StAprovadoAnalistaSic
		/// </summary>
		public Nullable<Boolean> StAprovadoAnalistaSic { get; set; }
		/// <summary>
		/// Propriedade DtAprovadoAnalistaSic
		/// </summary>
		public Nullable<DateTime> DtAprovadoAnalistaSic { get; set; }
		/// <summary>
		/// Propriedade StEnviadoAprovacaoGerenteSic
		/// </summary>
		public Nullable<Boolean> StEnviadoAprovacaoGerenteSic { get; set; }
		/// <summary>
		/// Propriedade DtEnviadoAprovacaoGerenteSic
		/// </summary>
		public Nullable<DateTime> DtEnviadoAprovacaoGerenteSic { get; set; }
		/// <summary>
		/// Propriedade StAprovadoGerenteSic
		/// </summary>
		public Nullable<Boolean> StAprovadoGerenteSic { get; set; }
		/// <summary>
		/// Propriedade DtAprovadoGerenteSic
		/// </summary>
		public Nullable<DateTime> DtAprovadoGerenteSic { get; set; }
		/// <summary>
		/// Propriedade StAditivoSic
		/// </summary>
		public Nullable<Boolean> StAditivoSic { get; set; }
		/// <summary>
		/// Propriedade StPagtoManualSic
		/// </summary>
		public Nullable<Boolean> StPagtoManualSic { get; set; }
		/// <summary>
		/// Propriedade DsObsPagtoSic
		/// </summary>
		public string DsObsPagtoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeConsumidoSic
		/// </summary>
		public Nullable<decimal> VlVolumeConsumidoSic { get; set; }
		/// <summary>
		/// Propriedade StAcertoSic
		/// </summary>
		public Nullable<Boolean> StAcertoSic { get; set; }
		#endregion
	}
}

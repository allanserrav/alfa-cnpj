#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : RebateSic.cs
// Class Name	        : RebateSic
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 25/07/2014
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
	/// Entitade Representada por RebateSic
	/// </summary>
	[Serializable]
	public partial class RebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTiporebateSic
		/// </summary>
		public Nullable<Int32> NrSeqTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqClienteSic
		/// </summary>
		public Nullable<Int32> NrSeqClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmRebateSic
		/// </summary>
		public string NrIbmRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtAssinaturacontratoRebateSic
		/// </summary>
		public Nullable<DateTime> DtAssinaturacontratoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtIniciovigenciaRebateSic
		/// </summary>
		public Nullable<DateTime> DtIniciovigenciaRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtFimvigenciaRebateSic
		/// </summary>
		public Nullable<DateTime> DtFimvigenciaRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrCodigofornecedorRebateSic
		/// </summary>
		public string NrCodigofornecedorRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrCodigopagadorRebateSic
		/// </summary>
		public string NrCodigopagadorRebateSic { get; set; }
		/// <summary>
		/// Propriedade StCalculoRebateSic
		/// </summary>
		public Nullable<Boolean> StCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade StMatrizRebateSic
		/// </summary>
		public Nullable<Boolean> StMatrizRebateSic { get; set; }
		/// <summary>
		/// Propriedade DsObsRebate
		/// </summary>
		public string DsObsRebate { get; set; }
		/// <summary>
		/// Propriedade StCalculoRetroativoSic
		/// </summary>
		public Nullable<Boolean> StCalculoRetroativoSic { get; set; }
		/// <summary>
		/// Propriedade StPossuiCalculoRebateSic
		/// </summary>
		public Nullable<Boolean> StPossuiCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade StNaoenviarsapRebateSic
		/// </summary>
		public Nullable<Boolean> StNaoenviarsapRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumecontratadoRebateSic
		/// </summary>
		public Nullable<decimal> VlVolumecontratadoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumelimiteRebateSic
		/// </summary>
		public Nullable<decimal> VlVolumelimiteRebateSic { get; set; }
		/// <summary>
		/// Propriedade StControlevolume
		/// </summary>
		public Nullable<Boolean> StControlevolume { get; set; }
		/// <summary>
		/// Propriedade StPagamentoProporcional
		/// </summary>
		public Nullable<Boolean> StPagamentoProporcional { get; set; }
		#endregion
	}
}

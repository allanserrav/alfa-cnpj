#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeMensalFaixaRebateSic.cs
// Class Name	        : VolumeMensalFaixaRebateSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 28/01/2013
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
	/// Entitade Representada por VolumeMensalFaixaRebateSic
	/// </summary>
	[Serializable]
	public partial class VolumeMensalFaixaRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqVolumeMensalFaixaRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqVolumeMensalFaixaRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixarebateSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixarebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixaRebateHistoricoSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixaRebateHistoricoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeCompradoSic
		/// </summary>
		public Nullable<decimal> VlVolumeCompradoSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade StVolumeEncontrado
		/// </summary>
		public Nullable<Boolean> StVolumeEncontrado { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade DtGravacaoSic
		/// </summary>
		public Nullable<DateTime> DtGravacaoSic { get; set; }
		#endregion
	}
}

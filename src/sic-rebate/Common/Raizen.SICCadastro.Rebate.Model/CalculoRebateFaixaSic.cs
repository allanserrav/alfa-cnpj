#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateFaixaSic.cs
// Class Name	        : CalculoRebateFaixaSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 04/01/2013
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
	/// Entitade Representada por CalculoRebateFaixaSic
	/// </summary>
	[Serializable]
	public class CalculoRebateFaixaSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqCalculoRebateFaixaSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateFaixaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeMaximoSic
		/// </summary>
		public Nullable<decimal> VlVolumeMaximoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeMinimoSic
		/// </summary>
		public Nullable<decimal> VlVolumeMinimoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeCalculadoSic
		/// </summary>
		public Nullable<decimal> VlVolumeCalculadoSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoCalculadoSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoCalculadoSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeContratadoSic
		/// </summary>
		public Nullable<decimal> VlVolumeContratadoSic { get; set; }
		#endregion
	}
}

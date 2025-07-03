#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateProporcionalSic.cs
// Class Name	        : CalculoRebateProporcionalSic
// Author		        : Murilo Beltrame
// Creation Date 	    : 22/08/2014
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
	/// Entitade Representada por CalculoRebateProporcionalSic
	/// </summary>
	[Serializable]
	public class CalculoRebateProporcionalSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqCalculoProporcionalRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoProporcionalRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqClienteSic
		/// </summary>
		public Nullable<Int32> NrSeqClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmClienteSic
		/// </summary>
		public string NrIbmClienteSic { get; set; }
		/// <summary>
		/// Propriedade VlProporcaoSic
		/// </summary>
		public Nullable<decimal> VlProporcaoSic { get; set; }
		/// <summary>
		/// Propriedade VlValorBonificacaoProporcionalSic
		/// </summary>
		public Nullable<decimal> VlValorBonificacaoProporcionalSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumeCalculadoSic
		/// </summary>
		public Nullable<decimal> VlVolumeCalculadoSic { get; set; }
		#endregion
	}
}

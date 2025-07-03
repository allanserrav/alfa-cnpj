#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoRebateFaixaSic.cs
// Class Name	        : DadosCalculoRebateFaixaSic
// Author		        : CDI
// Creation Date 	    : 22/01/2020
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
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.Model
{
	/// <summary>
	/// Entitade Representada por DadosCalculoRebateFaixaSic
	/// </summary>
	public class DadosCalculoRebateFaixaSic
	{
		#region Propriedades

		/// <summary>
		/// NrSeqDadosCalculoRebateFaixaSic
		/// </summary>
		public Nullable<Int32> NrSeqDadosCalculoRebateFaixaSic { get; set; }

		/// <summary>
		/// NrSeqDadosCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqDadosCalculoRebateSic { get; set; }

		/// <summary>
		/// NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }

		/// <summary>
		/// VlVolumeMensalRebateSic
		/// </summary>
		public Nullable<Decimal> VlVolumeMensalRebateSic { get; set; }

		/// <summary>
		/// VlPercMinimoRebateSic
		/// </summary>
		public Nullable<Decimal> VlPercMinimoRebateSic { get; set; }

		/// <summary>
		/// VlPercMaximoRebateSic
		/// </summary>
		public Nullable<Decimal> VlPercMaximoRebateSic { get; set; }

		/// <summary>
		/// VlBonificacaoRebateSic
		/// </summary>
		public Nullable<Decimal> VlBonificacaoRebateSic { get; set; }

		#endregion
	}
}
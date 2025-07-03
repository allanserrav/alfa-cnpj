#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : FaixaRebateHistoricoSic.cs
// Class Name	        : FaixaRebateHistoricoSic
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
	/// Entitade Representada por FaixaRebateHistoricoSic
	/// </summary>
	[Serializable]
	public class FaixaRebateHistoricoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqFaixaRebateHistoricoSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixaRebateHistoricoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixarebateSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixarebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade DtIniciocalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtIniciocalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtFimcalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtFimcalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlVolumemensalRebateSic
		/// </summary>
		public Nullable<decimal> VlVolumemensalRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlPercminimoRebateSic
		/// </summary>
		public Nullable<decimal> VlPercminimoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlPercmaximoRebateSic
		/// </summary>
		public Nullable<decimal> VlPercmaximoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoRebateSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlRecebebonusRebateSic
		/// </summary>
		public Nullable<decimal> VlRecebebonusRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqGrupoSic
		/// </summary>
		public Nullable<Int32> NrSeqGrupoSic { get; set; }
		#endregion
	}
}

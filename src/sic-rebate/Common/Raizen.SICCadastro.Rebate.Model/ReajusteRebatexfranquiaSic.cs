#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebatexfranquiaSic.cs
// Class Name	        : ReajusteRebatexfranquiaSic
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
	/// Entitade Representada por ReajusteRebatexfranquiaSic
	/// </summary>
	[Serializable]
	public class ReajusteRebatexfranquiaSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqReajusteRebatexfranquiaSic
		/// </summary>
		public Nullable<Int32> NrSeqReajusteRebatexfranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFranquiaSic
		/// </summary>
		public Nullable<Int32> NrSeqFranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqFaixaSic
		/// </summary>
		public Nullable<Int32> NrSeqFaixaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqReajusteSic
		/// </summary>
		public Nullable<Int32> NrSeqReajusteSic { get; set; }
		/// <summary>
		/// Propriedade VlManualReajusterebatexfranquiaSic
		/// </summary>
		public Nullable<decimal> VlManualReajusterebatexfranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrPeriodoReajusterebatexfranquiaSic
		/// </summary>
		public Nullable<Int32> NrPeriodoReajusterebatexfranquiaSic { get; set; }
		/// <summary>
		/// Propriedade StFeeminimoFaixaSic
		/// </summary>
		public Nullable<Boolean> StFeeminimoFaixaSic { get; set; }
		/// <summary>
		/// Propriedade StFeemaximoFaixaSic
		/// </summary>
		public Nullable<Boolean> StFeemaximoFaixaSic { get; set; }
		/// <summary>
		/// Propriedade StValoresFaixaSic
		/// </summary>
		public Nullable<Boolean> StValoresFaixaSic { get; set; }
		#endregion
	}
}

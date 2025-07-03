#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IgpmPeriodoSic.cs
// Class Name	        : IgpmPeriodoSic
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
	/// Entitade Representada por IgpmPeriodoSic
	/// </summary>
	[Serializable]
	public class IgpmPeriodoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqIgpmPeriodoSic
		/// </summary>
		public Nullable<Int32> NrSeqIgpmPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoFormatadoSic
		/// </summary>
		public string DtPeriodoFormatadoSic { get; set; }
		/// <summary>
		/// Propriedade VlFatorSic
		/// </summary>
		public Nullable<decimal> VlFatorSic { get; set; }
		/// <summary>
		/// Propriedade VlPercentualSic
		/// </summary>
		public Nullable<decimal> VlPercentualSic { get; set; }
		/// <summary>
		/// Propriedade DtAlteracaoSic
		/// </summary>
		public Nullable<DateTime> DtAlteracaoSic { get; set; }
		#endregion
	}
}

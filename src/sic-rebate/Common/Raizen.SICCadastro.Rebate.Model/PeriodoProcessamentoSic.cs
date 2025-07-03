#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : PeriodoProcessamentoSic.cs
// Class Name	        : PeriodoProcessamentoSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 18/01/2013
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
	/// Entitade Representada por PeriodoProcessamentoSic
	/// </summary>
	[Serializable]
	public class PeriodoProcessamentoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqPeriodoProcessamentoSic
		/// </summary>
		public Nullable<Int32> NrSeqPeriodoProcessamentoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTipofranquiaSic
		/// </summary>
		public Nullable<Int32> NrSeqTipofranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqTiporebateSic
		/// </summary>
		public Nullable<Int32> NrSeqTiporebateSic { get; set; }
		/// <summary>
		/// Propriedade NrDiaInicioPeriodoProcessamentoSic
		/// </summary>
		public Nullable<Int32> NrDiaInicioPeriodoProcessamentoSic { get; set; }
		/// <summary>
		/// Propriedade NrDiaFimPeriodoProcessamentoSic
		/// </summary>
		public Nullable<Int32> NrDiaFimPeriodoProcessamentoSic { get; set; }
		/// <summary>
		/// Propriedade NrDiaInicioCalculoSic
		/// </summary>
		public Nullable<Int32> NrDiaInicioCalculoSic { get; set; }
		/// <summary>
		/// Propriedade NrDiaEmissaoCobranca
		/// </summary>
		public Nullable<Int32> NrDiaEmissaoCobranca { get; set; }
		#endregion
	}
}

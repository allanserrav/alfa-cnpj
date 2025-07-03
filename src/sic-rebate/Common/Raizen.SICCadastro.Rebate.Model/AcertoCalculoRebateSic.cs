#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AcertoCalculoRebateSic.cs
// Class Name	        : AcertoCalculoRebateSic
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 23/01/2019
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
	/// Entitade Representada por AcertoCalculoRebateSic
	/// </summary>
	[Serializable]
	public class AcertoCalculoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }
		/// <summary>
		/// Propriedade DtIniciocalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtIniciocalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade DtFimcalculoRebateSic
		/// </summary>
		public Nullable<DateTime> DtFimcalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoTotalSic
		/// </summary>
		public Nullable<decimal> VlBonificacaoTotalSic { get; set; }
		/// <summary>
		/// Propriedade StCalculoRebateSic
		/// </summary>
		public Nullable<Boolean> StCalculoRebateSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoTotalSic
		/// </summary>
		public Nullable<decimal> VlAcertoBonificacaoTotalSic { get; set; }
		/// <summary>
		/// Propriedade VlBonificacaoTotalSic
		/// </summary>
		public Nullable<decimal> VlSaldoAcertoBonificacaoSic { get; set; }
		/// <summary>
		/// Propriedade DsPeriodo
		/// </summary>
		public string DsPeriodo
		{
			get
			{
				if (this.StCalculoRebateSic == true)
					return "Trimestral";
				else
					return "Mensal";
			}
		}

		#endregion
	}
}
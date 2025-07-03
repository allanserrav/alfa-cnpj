#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoRebateSic.cs
// Class Name	        : DadosCalculoRebateSic
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
using System.Collections.Generic;
using System.Text;
using System.Data;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.Model
{
	/// <summary>
	/// Entitade Representada por DadosCalculoRebateSic
	/// </summary>
	public class DadosCalculoRebateSic
	{
		#region Propriedades

		/// <summary>
		/// NrSeqDadosCalculoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqDadosCalculoRebateSic { get; set; }

		/// <summary>
		/// NrSeqClienteSic
		/// </summary>
		public Nullable<Int32> NrSeqClienteSic { get; set; }

		/// <summary>
		/// NrIbmClienteSic
		/// </summary>
		public String NrIbmClienteSic { get; set; }

		/// <summary>
		/// DtPeriodoSic
		/// </summary>
		public Nullable<DateTime> DtPeriodoSic { get; set; }

		/// <summary>
		/// NrSeqTipoRebate
		/// </summary>
		public Nullable<Int32> NrSeqTipoRebate { get; set; }

		/// <summary>
		/// StCalculoRebateSic
		/// True para trimestral  / false para Mensal
		/// </summary>
		public Nullable<Boolean> StCalculoRebateSic { get; set; }

		/// <summary>
		/// List<DadosCalculoRebateFaixaSic> 
		/// </summary>
		public List<DadosCalculoRebateFaixaSic> Faixas {get;set;}

		#endregion
	}
}

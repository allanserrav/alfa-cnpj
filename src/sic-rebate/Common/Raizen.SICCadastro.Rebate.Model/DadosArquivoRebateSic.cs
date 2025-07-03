#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosArquivoRebateSic.cs
// Class Name	        : DadosArquivoRebateSic
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 17/01/2013
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
	/// Entitade Representada por DadosArquivoRebateSic
	/// </summary>
	[Serializable]
	public class DadosArquivoRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqDadosArquivoRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqDadosArquivoRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrReferenciaSeqSic
		/// </summary>
		public Nullable<Int32> NrReferenciaSeqSic { get; set; }
		/// <summary>
		/// Propriedade NrArquivoSbopSeqSic
		/// </summary>
		public Nullable<Int32> NrArquivoSbopSeqSic { get; set; }
		/// <summary>
		/// Propriedade NrArquivoSaabSeqSic
		/// </summary>
		public Nullable<Int32> NrArquivoSaabSeqSic { get; set; }
		/// <summary>
		/// Propriedade NrArquivoMimeSeqSic
		/// </summary>
		public Nullable<Int32> NrArquivoMimeSeqSic { get; set; }
		#endregion
	}
}

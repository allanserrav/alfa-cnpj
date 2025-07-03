#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AgendamentoMensagemSic.cs
// Class Name	        : AgendamentoMensagemSic
// Author		        : Romildo Cruz
// Creation Date 	    : 23/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 12/18/2012
//	Reason for modification : Copy class from SICCadastros to SICCadastros.Rebate
//	Modification Done       : 12/18/2012
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
	/// Entitade Representada por AgendamentoMensagemSic
	/// </summary>
	[Serializable]
	public class AgendamentoMensagemSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqAgendamentoMensagemSic
		/// </summary>
		public Nullable<Int32> NrSeqAgendamentoMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqMensagemSic
		/// </summary>
		public Nullable<Int32> NrSeqMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NmUserSolicitacaoSic
		/// </summary>
		public string NmUserSolicitacaoSic { get; set; }
		/// <summary>
		/// Propriedade DtAgendamentoMensagemSic
		/// </summary>
		public Nullable<DateTime> DtAgendamentoMensagemSic { get; set; }
		/// <summary>
		/// Propriedade StAgengamentoMensagemSic
		/// </summary>
		public Nullable<Boolean> StAgengamentoMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NmGrupodeAgengamentoMensagemSic
		/// </summary>
		public string NmGrupodeAgengamentoMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NmGrupoparaAgendamentoMensagemSic
		/// </summary>
		public string NmGrupoparaAgendamentoMensagemSic { get; set; }
		/// <summary>
		/// Propriedade NmLinkAgendamentoMensagemSic
		/// </summary>
		public string NmLinkAgendamentoMensagemSic { get; set; }
		#endregion
	}
}

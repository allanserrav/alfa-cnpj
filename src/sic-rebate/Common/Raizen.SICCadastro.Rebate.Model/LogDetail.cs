#region Cabeçalho do Arquivo
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
	/// Entitade Representada por LogDetail
	/// </summary>
	[Serializable]
	public partial class LogDetail
	{
		#region Propriedades
		public int? NrSeqLogRebateRetroativo { get; set; }
		public DateTime? Timestamp { get; set; }
		public string Step { get; set; }
		public string User { get; set; }

		#endregion
	}
}

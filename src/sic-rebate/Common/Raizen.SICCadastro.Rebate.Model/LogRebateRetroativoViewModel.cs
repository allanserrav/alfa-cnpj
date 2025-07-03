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
	/// Entitade Representada por LogRebateRetroativoViewModel
	/// </summary>
	[Serializable]
	public partial class LogRebateRetroativoViewModel
	{
		#region Propriedades
		public DateTime? Timestamp { get; set; }
		public string User { get; set; }
		public string Step { get; set; }
		public int? NrSeqRebateSic { get; set; }
		public string NrIbmRebateSic { get; set; }
		public long? NrContrato { get; set; }

		#endregion
	}
}

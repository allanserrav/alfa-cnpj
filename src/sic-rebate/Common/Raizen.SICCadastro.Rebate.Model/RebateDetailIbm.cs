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
	/// Entitade Representada por RebateDetailIbm
	/// </summary>
	[Serializable]
	public partial class RebateDetailIbm
	{
		#region Propriedades
		public int? NrSeqRebateSic { get; set; }
		public string NrIbmRebateSic { get; set; }
		public DateTime? DtInicioVigencia { get; set; }
		public DateTime? DtFimVigencia { get; set; }
		public decimal? VolumeContratado { get; set; }

		#endregion
	}
}

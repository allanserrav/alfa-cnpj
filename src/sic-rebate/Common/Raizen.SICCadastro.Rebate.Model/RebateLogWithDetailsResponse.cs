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
	/// Entitade Representada por RebateLogWithDetailsResponse
	/// </summary>
	[Serializable]
	public partial class RebateLogWithDetailsResponse
	{
		#region Propriedades
		public LogDetail Log { get; set; }
		public RebateDetailIbm Rebate { get; set; }

		#endregion
	}
}

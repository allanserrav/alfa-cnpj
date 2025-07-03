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
	/// Entitade Representada por Restricao
	/// </summary>
	[Serializable]
	public partial class RestricaoExport
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqRestricao
		/// </summary>
		public Nullable<Int32> NrSeqRestricao { get; set; }
		/// <summary>
		/// Propriedade DsRestricao
		/// </summary>
		public string DsMotivo { get; set; }

		public string DsIbm { get; set; }

		public string DsTipoRestricao { get; set; }

		#endregion
	}
}

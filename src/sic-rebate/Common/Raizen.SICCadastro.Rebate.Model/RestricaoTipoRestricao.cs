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
	public partial class RestricaoTipoRestricao
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqRestricao
		/// </summary>
		public Nullable<Int32> NrSeqIbmTipoRestricao { get; set; }
		/// <summary>
		/// Propriedade DsRestricao
		/// </summary>
		public Nullable<Int32> NrSeqTipoRestricao { get; set; }

		public Nullable<Int32> NrSeqRestricao { get; set; }

		#endregion
	}
}

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
	/// Entitade Representada por TipoRestricao
	/// </summary>
	[Serializable]
	public partial class TipoRestricao
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqTipoRestricao
		/// </summary>
		public Nullable<Int32> NrSeqTipoRestricao { get; set; }
		/// <summary>
		/// Propriedade DsTipoRestricao
		/// </summary>
		public string DsTipoRestricao { get; set; }	
		#endregion
	}
}

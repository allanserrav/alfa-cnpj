#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MotivoRegimeEspecialRebateSic.cs
// Class Name	        : MotivoRegimeEspecialRebateSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	/// Entitade Representada por MotivoRegimeEspecialRebateSic
	/// </summary>
	[Serializable]
	public class MotivoRegimeEspecialRebateSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqMotivoRegimeEspecialRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqMotivoRegimeEspecialRebateSic { get; set; }
		/// <summary>
		/// Propriedade CdMotivoSic
		/// </summary>
		public string CdMotivoSic { get; set; }
		/// <summary>
		/// Propriedade DsMotivoSic
		/// </summary>
		public string DsMotivoSic { get; set; }
		#endregion
	}
}

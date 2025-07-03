#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeCalculoRebateFaixaSic.cs
// Class Name	        : VolumeCalculoRebateFaixaSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 19/11/2012
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
	/// Entitade Representada por VolumeCalculoRebateFaixaSic
	/// </summary>
	[Serializable]
	public class VolumeCalculoRebateFaixaSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqVolumeMensalFaixaRebateSic
		/// </summary>
		public Nullable<Int32> NrSeqVolumeMensalFaixaRebateSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCalculoRebateFaixaSic
		/// </summary>
		public Nullable<Int32> NrSeqCalculoRebateFaixaSic { get; set; }
        public Nullable<Int32> NrSeqCalculoRebateSic { get; set; }
        #endregion
    }
}

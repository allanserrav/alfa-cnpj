#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClienteSic.cs
// Class Name	        : ClienteSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/03/2013
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
	/// Entitade Representada por ClienteSic
	/// </summary>
	[Serializable]
	public class ClienteSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqClienteSic
		/// </summary>
		public Nullable<Int32> NrSeqClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrIbmClienteSic
		/// </summary>
		public string NrIbmClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrCnpjClienteSic
		/// </summary>
		public string NrCnpjClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqEmpresaSic
		/// </summary>
		public Nullable<Int32> NrSeqEmpresaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqSistemaSic
		/// </summary>
		public Nullable<Int32> NrSeqSistemaSic { get; set; }
		/// <summary>
		/// Propriedade NrInscestadlojaFranquiaSic
		/// </summary>
		public string NrInscestadlojaFranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqAreaSic
		/// </summary>
		public Nullable<Int32> NrSeqAreaSic { get; set; }
		/// <summary>
		/// Propriedade NmRazsociallojaFranquiaSic
		/// </summary>
		public string NmRazsociallojaFranquiaSic { get; set; }
		/// <summary>
		/// Propriedade NmGtlojaClienteSic
		/// </summary>
		public string NmGtlojaClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmGalojaClienteSic
		/// </summary>
		public string NmGalojaClienteSic { get; set; }
		/// <summary>
		/// Propriedade NrCegrpostoClienteSic
		/// </summary>
		public string NrCegrpostoClienteSic { get; set; }
		/// <summary>
		/// Propriedade StDescontoimpostoClienteSic
		/// </summary>
		public Nullable<Boolean> StDescontoimpostoClienteSic { get; set; }
		/// <summary>
		/// Propriedade StRebrandingClienteSic
		/// </summary>
		public Nullable<Boolean> StRebrandingClienteSic { get; set; }
		/// <summary>
		/// Propriedade StEnviocalendarioClienteSic
		/// </summary>
		public Nullable<Boolean> StEnviocalendarioClienteSic { get; set; }
		/// <summary>
		/// Propriedade StProcessojudicialClienteSic
		/// </summary>
		public Nullable<Boolean> StProcessojudicialClienteSic { get; set; }
		/// <summary>
		/// Propriedade StFoodservfullClienteSic
		/// </summary>
		public Nullable<Boolean> StFoodservfullClienteSic { get; set; }
		/// <summary>
		/// Propriedade StPrgcafeClienteSic
		/// </summary>
		public Nullable<Boolean> StPrgcafeClienteSic { get; set; }
		/// <summary>
		/// Propriedade StSanduicheQuenteClienteSic
		/// </summary>
		public Nullable<Boolean> StSanduicheQuenteClienteSic { get; set; }
		/// <summary>
		/// Propriedade StVendecartaoClienteSic
		/// </summary>
		public Nullable<Boolean> StVendecartaoClienteSic { get; set; }
		/// <summary>
		/// Propriedade StAtmClienteSic
		/// </summary>
		public Nullable<Boolean> StAtmClienteSic { get; set; }
		/// <summary>
		/// Propriedade StOiClienteSic
		/// </summary>
		public Nullable<Boolean> StOiClienteSic { get; set; }
		/// <summary>
		/// Propriedade StAbriClienteSic
		/// </summary>
		public Nullable<Boolean> StAbriClienteSic { get; set; }
		/// <summary>
		/// Propriedade StA0ClienteSic
		/// </summary>
		public Nullable<Boolean> StA0ClienteSic { get; set; }
		/// <summary>
		/// Propriedade StA4ClienteSic
		/// </summary>
		public Nullable<Boolean> StA4ClienteSic { get; set; }
		/// <summary>
		/// Propriedade StGalhardestesClienteSic
		/// </summary>
		public Nullable<Boolean> StGalhardestesClienteSic { get; set; }
		/// <summary>
		/// Propriedade StCartazcolunaClienteSic
		/// </summary>
		public Nullable<Boolean> StCartazcolunaClienteSic { get; set; }
		/// <summary>
		/// Propriedade StStationposterClienteSic
		/// </summary>
		public Nullable<Boolean> StStationposterClienteSic { get; set; }
		/// <summary>
		/// Propriedade DsObsClienteSic
		/// </summary>
		public string DsObsClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmCanalClienteSic
		/// </summary>
		public string NmCanalClienteSic { get; set; }
		/// <summary>
		/// Propriedade NmSegmercadoClienteSic
		/// </summary>
		public string NmSegmercadoClienteSic { get; set; }
		/// <summary>
		/// Propriedade StSanduicheFrioClienteSic
		/// </summary>
		public Nullable<Boolean> StSanduicheFrioClienteSic { get; set; }
		/// <summary>
		/// Propriedade StFoodservselfClienteSic
		/// </summary>
		public Nullable<Boolean> StFoodservselfClienteSic { get; set; }
		#endregion
	}
}

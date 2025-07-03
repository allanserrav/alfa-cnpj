#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CategoriaSic.cs
// Class Name	        : CategoriaSic
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 31/10/2012
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
	/// Entitade Representada por CategoriaSic
	/// </summary>
	[Serializable]
	public class CategoriaSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade NmCategoriaSic
		/// </summary>
		public string NmCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade DsCategoriaSic
		/// </summary>
		public string DsCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade StCategoriaPistaSic
		/// </summary>
		public Nullable<Boolean> StCategoriaPistaSic { get; set; }
		/// <summary>
		/// Propriedade StCategoriaLojaSic
		/// </summary>
		public Nullable<Boolean> StCategoriaLojaSic { get; set; }
		/// <summary>
		/// Propriedade StCategoriaFranquiaSic
		/// </summary>
		public Nullable<Boolean> StCategoriaFranquiaSic { get; set; }
		/// <summary>
		/// Propriedade StCategoriaRebateSic
		/// </summary>
		public Nullable<Boolean> StCategoriaRebateSic { get; set; }
		#endregion
	}
}

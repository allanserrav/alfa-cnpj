#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ProdutoSic.cs
// Class Name	        : ProdutoSic
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
	/// Entitade Representada por ProdutoSic
	/// </summary>
	[Serializable]
	public class ProdutoSic
	{
		#region Propriedades
		/// <summary>
		/// Propriedade NrSeqProdutoSic
		/// </summary>
		public Nullable<Int32> NrSeqProdutoSic { get; set; }
		/// <summary>
		/// Propriedade NrSeqCategoriaSic
		/// </summary>
		public Nullable<Int32> NrSeqCategoriaSic { get; set; }
		/// <summary>
		/// Propriedade NmProdutoSic
		/// </summary>
		public string NmProdutoSic { get; set; }
		/// <summary>
		/// Propriedade DsProdutoSic
		/// </summary>
		public string DsProdutoSic { get; set; }
		/// <summary>
		/// Propriedade CdSapProdutoSic
		/// </summary>
		public string CdSapProdutoSic { get; set; }
		/// <summary>
		/// Propriedade CdBarraProdutoSic
		/// </summary>
		public string CdBarraProdutoSic { get; set; }
		#endregion
	}
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : LogIntegracaoSic.cs
// Class Name	        : LogIntegracaoSic
// Author		        : Leandro Oliveira
// Creation Date 	    : 02/12/2024
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
    /// Entitade Representada por LogIntegracaoSic
    /// </summary>
    [Serializable]
    public class LogIntegracaoSic
    {
        #region Propriedades
        /// <summary>
        /// Propriedade NrSeqLogIntegracaoSic
        /// </summary>
        public Nullable<Int32> NrSeqLogIntegracaoSic { get; set; }
        /// <summary>
        /// Propriedade NmMetodoSic
        /// </summary>
        public string NmMetodoSic { get; set; }
        /// <summary>
        /// Propriedade DsAcaoSic
        /// </summary>
        public string DsAcaoSic { get; set; }
        /// <summary>
        /// Propriedade NmPaginaSic
        /// </summary>
        public string NmPaginaSic { get; set; }
        /// <summary>
        /// Propriedade DtAcaoSic
        /// </summary>
        public Nullable<DateTime> DtAcaoSic { get; set; }
        /// <summary>
        /// Propriedade NmUsuarioSic
        /// </summary>
        public string NmUsuarioSic { get; set; }
        
        #endregion
    }
}

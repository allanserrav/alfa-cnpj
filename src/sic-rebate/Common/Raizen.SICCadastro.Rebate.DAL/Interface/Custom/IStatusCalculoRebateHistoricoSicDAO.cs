#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IStatusCalculoRebateHistoricoSicDAO.cs
// Class Name	        : IStatusCalculoRebateHistoricoSicDAO
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
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
using COSAN.Framework.DBUtil;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IStatusCalculoRebateHistoricoSicDAO
    /// </summary>
    public partial interface IStatusCalculoRebateHistoricoSicDAO
    {
        #region Metodos de IStatusCalculoRebateHistoricoSicDAO

        #region Incluir
        /// <summary>
        /// Incluir StatusCalculoRebateHistoricoSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
        void IncluirComTransacao(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager);
        #endregion

        #endregion IStatusCalculoRebateHistoricoSicDAO
    }
}

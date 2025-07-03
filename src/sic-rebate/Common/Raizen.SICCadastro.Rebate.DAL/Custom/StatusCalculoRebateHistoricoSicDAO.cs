#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : StatusCalculoRebateHistoricoSicDAO.cs
// Class Name	        : StatusCalculoRebateHistoricoSicDAO
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
using System.Data;
using System.Data.Common;
using System.Security;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	#region classe concreta StatusCalculoRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a StatusCalculoRebateHistoricoSicDAO
	/// </summary>
	internal partial class StatusCalculoRebateHistoricoSicDAO : IStatusCalculoRebateHistoricoSicDAO
	{
        #region Incluir
        /// <summary>
        /// Incluir StatusCalculoRebateHistoricoSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="StatusCalculoRebateHistoricoSic"/></param>
        public void IncluirComTransacao(StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic, DatabaseManager databaseManager)
        {
            Incluir(statusCalculoRebateHistoricoSic, databaseManager);
        }
        #endregion
	}
	#endregion classe concreta 
}

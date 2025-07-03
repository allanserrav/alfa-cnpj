#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : VolumeCalculoRebateFaixaSicDAO.cs
// Class Name	        : VolumeCalculoRebateFaixaSicDAO
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
using System.Data;
using System.Data.Common;
using System.Security;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    #region classe concreta VolumeCalculoRebateFaixaSicDAO
    /// <summary>
    /// Representa funcionalidade relacionada a VolumeCalculoRebateFaixaSicDAO
    /// </summary>
    internal partial class VolumeCalculoRebateFaixaSicDAO : IVolumeCalculoRebateFaixaSicDAO
    {
        /// <summary>
        /// Incluir VolumeCalculoRebateFaixaSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
        public void IncluirComTransacao(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager)
        {
            Incluir(volumeCalculoRebateFaixaSic, databaseManager);
        }
    }
    #endregion classe concreta
}

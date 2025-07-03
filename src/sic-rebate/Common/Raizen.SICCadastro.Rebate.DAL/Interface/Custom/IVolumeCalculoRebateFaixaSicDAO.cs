#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : IVolumeCalculoRebateFaixaSicDAO.cs
// Class Name	        : IVolumeCalculoRebateFaixaSicDAO
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
using Raizen.SICCadastro.Rebate.Model;
using System.Collections.Generic;
using COSAN.Framework.DBUtil;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Representa funcionalidade relacionada a IVolumeCalculoRebateFaixaSicDAO
    /// </summary>
    public partial interface IVolumeCalculoRebateFaixaSicDAO
    {
        #region Metodos de IVolumeCalculoRebateFaixaSicDAO

        #region Incluir
        /// <summary>
        /// Incluir VolumeCalculoRebateFaixaSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
        void IncluirComTransacao(VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic, DatabaseManager databaseManager);
        #endregion Incluir

        #endregion IVolumeCalculoRebateFaixaSicDAO
    }
}

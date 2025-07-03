#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateProporcionalSicDAO.cs
// Class Name	        : CalculoRebateProporcionalSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 29/07/2014
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
	#region classe concreta CalculoRebateProporcionalSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateProporcionalSicDAO
	/// </summary>
	internal partial class CalculoRebateProporcionalSicDAO : ICalculoRebateProporcionalSicDAO
	{
        public void IncluirComTransacao(CalculoRebateProporcionalSic calculoRebateFaixaSic, DatabaseManager databaseManager)
        {
            Incluir(calculoRebateFaixaSic, databaseManager);
        }
    }
	#endregion classe concreta 
}
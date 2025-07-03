#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosArquivoRebateSicDAO.cs
// Class Name	        : DadosArquivoRebateSicDAO
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 22/01/2013
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
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.DBUtil;

#endregion

namespace Raizen.SICCadastro.Rebate.DAL
{
    internal partial class DadosArquivoRebateSicDAO : IDadosArquivoRebateSicDAO
    {
        public void AtualizarComTransacao(DadosArquivoRebateSic dadosArquivoRebateSic, DatabaseManager databaseManager)
        {
            Atualizar(dadosArquivoRebateSic, databaseManager);
        }
    }
}

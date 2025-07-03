#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateFaixaSicBLO.cs
// Class Name	        : ICalculoRebateFaixaSicBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a ICalculoRebateFaixaSicBLO
    /// </summary>
    public partial interface ICalculoRebateFaixaSicBLO
    {
        #region Metodos de ICalculoRebateFaixaSicBLO

        #region Selecionar Bonificacao Detalhe

        /// <summary>
        /// Seleciona o Detalhe de Bonificação de um Cálculo Rebate
        /// </summary>
        /// <param name="calculoRebateFaixaSic"></param>
        /// <returns>Lista de BonificacaoGridDetalhe</returns>
        IList<BonificacaoGridDetalhe> SelecionarBonificacaoDetalhe(int NrSeqCalculoRebateSic, DateTime dtPeriodo);

        #endregion Selecionar Bonificacao Detalhe


        #endregion ICalculoRebateFaixaSicBLO
    }
}

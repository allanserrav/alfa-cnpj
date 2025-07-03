#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ICalculoRebateFaixaSicDAO.cs
// Class Name	        : ICalculoRebateFaixaSicDAO
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
	/// Representa funcionalidade relacionada a ICalculoRebateFaixaSicDAO
	/// </summary>
	public partial interface ICalculoRebateFaixaSicDAO
	{
      #region Metodos de ICalculoRebateFaixaSicDAO 
		
        #region Incluir
        /// <summary>
        /// Incluir CalculoRebateFaixaSicDAO
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="VolumeCalculoRebateFaixaSic"/></param>
        void IncluirComTransacao(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager);
        #endregion Incluir

        #region Selecionar Bonificacao Detalhe
        /// <summary>
        /// Seleciona Detalhe da Bonificação Calculada
        /// </summary>
        /// <param name="calculoRebateFaixaSic"></param>
        /// <returns></returns>
        IList<BonificacaoGridDetalhe> SelecionarBonificacaoDetalhe(int NrSeqCalculoRebateSic, DateTime dtPeriodo);
        #endregion

        #endregion ICalculoRebateFaixaSicDAO
    }
}

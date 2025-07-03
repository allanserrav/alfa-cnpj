#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateFaixaSicBLO.cs
// Class Name	        : CalculoRebateFaixaSicBLO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 11/08/2012
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a  CalculoRebateFaixaSicBLO
    /// </summary>
    internal partial class CalculoRebateFaixaSicBLO : ICalculoRebateFaixaSicBLO
    {
        #region Metodos Publicos

        #region Selecionar Bonificação Detalhe
        /// <summary>
        /// Selecionar os dados de CalculoRebateFaixaSic
        /// </summary>
        /// <param name="calculoRebateFaixaSic">Instância de <see cref="CalculoRebateFaixaSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de CalculoRebateFaixaSic</returns>
        public IList<BonificacaoGridDetalhe> SelecionarBonificacaoDetalhe(int NrSeqCalculoRebateSic, DateTime dtPeriodo)
        {
            return this.calculoRebateFaixaSicDAO.SelecionarBonificacaoDetalhe(NrSeqCalculoRebateSic, dtPeriodo);
        }

        #endregion Selecionar Bonificação Detalhe

        #endregion Public Methods
    }
}


#region Cabeçalho do Arquivo
// <Summary>
// File Name            : LogRebateRetroativo.cs
// Class Name           : LogRebateRetroativo
// Author               : Raphael Simões Andrade
// Creation Date        : 17/12/2024
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//  Modified By             : 
//  Date of Modification    : 
//  Reason for modification : 
//  Modification Done       : 
//  Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Entidade representada por LogRebateRetroativo
    /// </summary>
    [Serializable]
    public class LogRebateRetroativo
    {
        #region Propriedades
        /// <summary>
        /// Propriedade NrSeqLogRebateRetroativo
        /// Identificador da tabela.
        /// </summary>
        public int? NrSeqLogRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade NrSeqAplicacaoRebateRetroativo
        /// Identificador da aplicação relacionada.
        /// </summary>
        public int NrSeqAplicacaoRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade NrSeqModuloRebateRetroativo
        /// Identificador do módulo relacionado.
        /// </summary>
        public int NrSeqModuloRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade NrSeqEntidadeRebateRetroativo
        /// Identificador da entidade relacionada.
        /// </summary>
        public int NrSeqEntidadeRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade DtLogDatetimeRebateRetroativo
        /// Data e hora da ação registrada.
        /// </summary>
        public DateTime? DtLogDatetimeRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade CdLogUsuarioRebateRetroativo
        /// Usuário responsável pelo log.
        /// </summary>
        public string CdLogUsuarioRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade XmlLogDetalheRebateRetroativo
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public string XmlLogDetalheRebateRetroativo { get; set; }

        /// <summary>
        /// Propriedade DsIbm
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public string DsIbm { get; set; }

        /// <summary>
        /// Propriedade NumContrato
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public int? NrContrato { get; set; }

        /// <summary>
        /// Propriedade NrSeqClienteSic
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public int NrSeqClienteSic { get; set; }
        #endregion
    }
}

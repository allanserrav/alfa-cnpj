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
    /// Entidade representada por LogRebateRetroativoFiltro
    /// </summary>
    [Serializable]
    public class LogRebateRetroativoFiltro
    {
        #region Propriedades
        

        /// <summary>
        /// Propriedade DtInicio
        /// Data e hora da ação registrada.
        /// </summary>
        public DateTime? DtInicio { get; set; }

        /// <summary>
        /// Propriedade DtFim
        /// Data e hora da ação registrada.
        /// </summary>
        public DateTime? DtFim { get; set; }       

        /// <summary>
        /// Propriedade DsIbm
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public string DsIbm { get; set; }

        /// <summary>
        /// Propriedade NumContrato
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public string NumContrato { get; set; }

        /// <summary>
        /// Propriedade NumContrato
        /// Detalhes adicionais em formato XML.
        /// </summary>
        public string NumRebate { get; set; }
        #endregion
    }
}

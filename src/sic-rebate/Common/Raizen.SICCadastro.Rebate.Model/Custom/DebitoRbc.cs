using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Util;


namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Entitade que representa os dados selecionados no Oracle
    /// </summary>
    [Serializable]
    public class DebitoRbc
    {
        #region Propriedades
        /// <summary>
        /// <summary>
        /// Propriedade NrClientePagador
        /// </summary>
        public string NrClientePagador { get; set; }

        /// <summary>
        /// <summary>
        /// Propriedade DtVencimentoOriginal
        /// </summary>
        public DateTime DtVencimentoOriginal { get; set; }

        /// <summary>
        /// Propriedade DiasVencidos
        /// </summary>
        public int DiasVencidos
        {
            get
            {
                return RebateUtil.GetDiferencaDias(DtVencimentoOriginal.Date, RebateUtil.GetDataAtual().Date);
            }
        }

        /// <summary>
        /// Propriedade VlMontante
        /// </summary>
        public Nullable<Decimal> VlMontante { get; set; }

        #endregion
    }
}

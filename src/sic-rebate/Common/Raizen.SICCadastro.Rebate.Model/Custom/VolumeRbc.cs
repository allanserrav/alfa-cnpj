using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Entitade que representa os dados selecionados no Oracle
    /// </summary>
    [Serializable]
    public class VolumeRbc
    {
        #region Propriedades
        /// <summary>
        /// <summary>
        /// Propriedade NrIbmRebateRbc
        /// </summary>
        public string NrIbmRebateRbc { get; set; }

        /// <summary>
        /// <summary>
        /// Propriedade CdProdutoRbc
        /// </summary>
        public string CdProdutoRbc { get; set; }

        /// <summary>
        /// Propriedade NmProdutoRbc
        /// </summary>
        public string NmProdutoRbc { get; set; }

        /// <summary>
        /// Propriedade DtPeriodoRbcTexto
        /// </summary>
        public DateTime DtPeriodoRbcTexto { get; set; }

        /// <summary>
        /// Propriedade DtPeriodoRbc
        /// </summary>
        public DateTime DtPeriodoRbc
        {
            get
            {
                return DtPeriodoRbcTexto;
            }
        }

        /// <summary>
        /// Propriedade VlVolumeCompradoRbc
        /// </summary>
        public Nullable<Decimal> VlVolumeCompradoRbc { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Entitade Representada por InformacaoRebateRel
    /// </summary>
    [Serializable]
    public class InformacaoRebateRel
    {
        #region Propriedades
        /// <summary>
        /// Propriedade NrSeqRebateSic
        /// </summary>
        public Nullable<Int32> NrSeqRebateSic { get; set; }
        /// <summary>
        /// Propriedade NrSeqClienteSic
        /// </summary>
        public Nullable<Int32> NrSeqClienteSic { get; set; }
        /// <summary>
        /// Propriedade NrIbmClienteSic
        /// </summary>
        public string NrIbmClienteSic { get; set; }
        /// <summary>
        /// Propriedade NrCnpjClienteSic
        /// </summary>
        public string NrCnpjClienteSic { get; set; }
        /// <summary>
        /// Propriedade NmRazsociallojaFranquiaSic
        /// </summary>
        public string NmRazsociallojaFranquiaSic { get; set; }
        /// <summary>
        /// Propriedade NrSeqTiporebateSic
        /// </summary>
        public Nullable<Int32> NrSeqTiporebateSic { get; set; }
        /// <summary>
        /// Propriedade NmTiporebateSic
        /// </summary>
        public string NmTiporebateSic { get; set; }
        /// <summary>
        /// Propriedade NrSeqEmpresaSic
        /// </summary>
        public Nullable<Int32> NrSeqEmpresaSic { get; set; }
        /// <summary>
        /// Propriedade NmEmpresaSic
        /// </summary>
        public string NmEmpresaSic { get; set; }
        /// <summary>
        /// Propriedade NrCegrpostoClienteSic
        /// </summary>
        public string NrCegrpostoClienteSic { get; set; }
        /// <summary>
        /// Propriedade NrCodigopagadorRebateSic
        /// </summary>
        public string NrCodigopagadorRebateSic { get; set; }
        /// <summary>
        /// Propriedade NrCodigofornecedorRebateSic
        /// </summary>
        public string NrCodigofornecedorRebateSic { get; set; }
        /// <summary>
        /// Propriedade NmGalojaClienteSic
        /// </summary>
        public string NmGalojaClienteSic { get; set; }
        /// <summary>
        /// Propriedade NmGtlojaClienteSic
        /// </summary>
        public string NmGtlojaClienteSic { get; set; }
        /// <summary>
        /// Propriedade DtAssinaturacontratoRebateSic
        /// </summary>
        public Nullable<DateTime> DtAssinaturacontratoRebateSic { get; set; }
        /// <summary>
        /// Propriedade DtIniciovigenciaRebateSic
        /// </summary>
        public Nullable<DateTime> DtIniciovigenciaRebateSic { get; set; }
        /// <summary>
        /// Propriedade DtFimvigenciaRebateSic
        /// </summary>
        public Nullable<DateTime> DtFimvigenciaRebateSic { get; set; }
        /// <summary>
        /// Propriedade StCalculoRebateSic
        /// </summary>
        public Nullable<Boolean> StCalculoRebateSic { get; set; }
        /// <summary>
        /// Propriedade NrSeqStatusSic
        /// </summary>
        public Nullable<Int32> NrSeqStatusSic { get; set; }
        /// <summary>
        /// Propriedade NmStatusSic
        /// </summary>
        public string NmStatusSic { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Filtro para o Grid de bonificação
    /// </summary>
    public class FiltroBonificacaoGrid
    {
        /// <summary>
        /// Data Periodo
        /// </summary>
        public DateTime? DataPeriodo { get; set; }

        /// <summary>
        /// Número IBM do Cliente
        /// </summary>
        public string CodigoIBM { get; set; }

        /// <summary>
        /// Status para Busca
        /// </summary>
        public string ListaStatus { get; set; }

        /// <summary>
        /// AprovadoAnalista
        /// </summary>
        public bool? AprovadoAnalista { get; set; }

        /// <summary>
        /// EnviadoGestor
        /// </summary>
        public bool? EnviadoGestor { get; set; }

        /// <summary>
        /// CalculoRetroativo
        /// </summary>
        public bool? CalculoRetroativo { get; set; }

        /// <summary>
        /// Verifica se ao menos um filtro foi informado
        /// </summary>
        public bool FiltroInformado
        {
            get
            {
                return DataPeriodo.HasValue ||
                    !string.IsNullOrEmpty(CodigoIBM) ||
                    !string.IsNullOrEmpty(ListaStatus) ||
                    (AprovadoAnalista.HasValue && AprovadoAnalista.Value) ||
                    (EnviadoGestor.HasValue && EnviadoGestor.Value) ||
                    (CalculoRetroativo.HasValue && CalculoRetroativo.Value);
            }
        }

        /// <summary>
        /// Tipos Rebate
        /// </summary>
        public string ListaTipoRebate { get; set; }

        /// <summary>
        /// AprovacaoMassiva
        /// </summary>
        public bool?  AprovacaoMassiva { get; set; }
    }
}

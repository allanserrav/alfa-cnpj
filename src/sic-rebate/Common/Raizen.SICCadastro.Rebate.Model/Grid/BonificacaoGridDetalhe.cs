using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Classe para apresentação do detalhe da bonificação
    /// </summary>
    public class BonificacaoGridDetalhe
    {
        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string NomeCategoria { get; set; }

        /// <summary>
        /// Valor da bonificação por m³
        /// </summary>
        public decimal? BonificacaoUnitaria { get; set; }

        /// <summary>
        /// Volume contratado para o período
        /// </summary>
        public decimal? VolumeContratado { get; set; }

        /// <summary>
        /// Percentual Mínimo Sobre o Volume Contratado Para Recebimento de Bonificação
        /// </summary>
        public decimal? PercentualMinimo { get; set; }

        /// <summary>
        /// Percentual Máximo Sobre o Volume Contratado Para Recebimento de Bonificação
        /// </summary>
        public decimal? PercentualMáximo { get; set; }

        /// <summary>
        /// Valor do Volume Mínimo Para Calculo De Bonificação
        /// </summary>
        public decimal? VolumeMinimo { get; set; }

        /// <summary>
        /// Valor do Volume Máximo Para Calculo de Bonificação
        /// </summary>
        public decimal? VolumeMaximo { get; set; }

        /// <summary>
        /// Volume Comprado No Período Calculado
        /// </summary>
        public decimal? VolumeCompradoPeriodo { get; set; }

        /// <summary>
        /// Valor Calculado de Bonificação Para a Categoria no Período
        /// </summary>
        public decimal? ValorBonificacaoCategoria { get; set; }

        /// <summary>
        /// Grupo            
        /// </summary>
        public int? SeqGrupo { get; set; }

        /// <summary>
        /// Grupo            
        /// </summary>
        public int? NrSeqCalculoRebateFaixaSic { get; set; }
    }
}

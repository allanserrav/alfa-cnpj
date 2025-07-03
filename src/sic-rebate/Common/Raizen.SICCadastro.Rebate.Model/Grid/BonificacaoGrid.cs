using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Model
{
    /// <summary>
    /// Classe para apresentação de bonificação em uma grid
    /// </summary>
    [Serializable]
    public class BonificacaoGrid
    {
        /// <summary>
        /// Indica se o calculo foi aprovado
        /// </summary>
        public bool Selecionado { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int? CodigoCalculoRebate { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public int? CodigoRebate { get; set; }

        /// <summary>
        /// Número IBM do Cliente
        /// </summary>
        public string CodigoIBM { get; set; }

        /// <summary>
        /// Número IBM do Fornecedor
        /// </summary>
        public string CodigoIBMFornecedor { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string NomeCliente { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string TipoBonificacao
        {
            get
            {
                if (Aditivo.HasValue && Aditivo.Value)
                    return "Aditivo";
                else if (Acerto.HasValue && Acerto.Value)
                    return "Acerto";
                else
                    return "Bonif.";
            }
        }

        /// <summary>
        /// Valor da Bonificação
        /// </summary>
        public decimal? ValorBonificacao { get; set; }

        /// <summary>
        /// Valor do Bonificação Período Anterir
        /// </summary>
        public decimal? ValorBonificacaoAnterior { get; set; }

        /// <summary>
        /// Diferença % das bonificações
        /// </summary>
        public decimal? PercentualDiferencaBonificacao
        {
            get
            {
                if (Aditivo.HasValue && Aditivo.Value)
                    return 0;

                if (!ValorBonificacaoAnterior.HasValue || ValorBonificacaoAnterior == 0)
                    return 1;

                return ((ValorBonificacao ?? 0) - (ValorBonificacaoAnterior ?? 0)) / ValorBonificacaoAnterior;
            }
        }

        /// <summary>
        /// Valor do débito Atual do Cliente
        /// </summary>
        public decimal? ValorDebito { get; set; }

        /// <summary>
        /// Descrição do Status Atual
        /// </summary>
        public DateTime? DataPagamento { get; set; }

        /// <summary>
        /// Codigo do Status
        /// </summary>
        public int? CodigoStatus { get; set; }

        /// <summary>
        /// Descrição do Status Atual
        /// </summary>
        public string DescricaoStatusBanco { get; set; }

        /// <summary>
        /// Descrição do Status Atual
        /// </summary>
        public string DescricaoStatus
        {
            get
            {
                string statusAux = string.Empty;

                //Aprovado pelo Analista
                if (AprovadoAnalista.HasValue && AprovadoAnalista.Value && CodigoStatus.Value != Convert.ToInt16(StatusCalculoRebate.Pago) && CodigoStatus.Value != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento))
                    statusAux = " (A)";

                //Enviado para o Gerente
                if (EnviadoGerente.HasValue && EnviadoGerente.Value && CodigoStatus.Value != Convert.ToInt16(StatusCalculoRebate.Pago) && CodigoStatus.Value != Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento))
                    statusAux = " (E)";

                return string.Concat(DescricaoStatusBanco, statusAux);
            }
        }

        /// <summary>
        /// Indica se é trimestral ou mensal
        /// </summary>
        public bool Mensal { get; set; }

        /// <summary>
        /// Indica se é trimestral ou mensal
        /// </summary>
        public string PeriodicidadePagamento
        {
            get
            {
                if (Mensal) return "Mensal";
                return "Trimestral";
            }
        }

        /// <summary>
        /// Periodo em que o cálculo foi executado
        /// </summary>
        public DateTime DataPeriodoCalculo { get; set; }

        /// <summary>
        /// Periodo em que o cálculo foi executado
        /// </summary>
        public string PeriodoCalculo
        {
            get
            {
                return this.DataPeriodoCalculo.ToString("MM/yyyy");
            }
        }

        /// <summary>
        /// Descrição do Tipo do Rebate
        /// </summary>
        public string DescricaoTipoRebate { get; set; }

        /// <summary>
        /// Aprovado Analista
        /// </summary>
        public bool? AprovadoAnalista { get; set; }

        /// <summary>
        /// Enviado Gerente
        /// </summary>
        public bool? EnviadoGerente { get; set; }

        /// <summary>
        /// Aprovado Gerente
        /// </summary>
        public bool? AprovadoGerente { get; set; }

        /// <summary>
        /// Indica se é um aditivo
        /// </summary>
        public bool? Aditivo { get; set; }

        /// <summary>
        /// Canal de venda
        /// </summary>
        public string NomeCanal { get; set; }

        /// <summary>
        /// O volume consumido
        /// </summary>
        public decimal? VolumeConsumido { get; set; }

        /// <summary>
        /// O volume limite do contrato
        /// </summary>
        public decimal? VolumeLimite { get; set; }

        public bool? Acerto { get; set; }
    }
}

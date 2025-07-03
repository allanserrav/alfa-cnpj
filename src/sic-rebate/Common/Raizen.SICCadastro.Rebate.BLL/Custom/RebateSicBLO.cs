using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Model;

using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Complemento de RebateSicBLO
    /// </summary>
    internal partial class RebateSicBLO
    {
        #region Metodos Publicos

        /// <summary>
        /// Seleciona Lista de Rebates Vigentes
        /// </summary>
        public IList<RebateSic> SelecionarVigentes()
        {
            return this.rebateSicDAO.SelecionarVigentes();
        }

        /// <summary>
        /// Seleciona Lista de Rebates Vigentes
        /// </summary>
        public IList<RebateSic> SelecionarVigentesReajuste()
        {
            return this.rebateSicDAO.SelecionarVigentesReajuste();
        }

        /// <summary>
        /// Seleciona Lista de Rebate Relatorio
        /// </summary>
        public IList<InformacaoRebateRel> SelecionarRelatorioInformacoesRebate(InformacaoRebateRelFiltro filtro)
        {
            return this.rebateSicDAO.SelecionarRelatorioInformacoesRebate(filtro);
        }
                
        public decimal SelecionarVolumeComprado(RebateSic rebate, DateTime dataAlvo)
        {
            #region OLD
            //return this.rebateSicDAO.SelecionarVolumeComprado(IBM, de, ate); 
            #endregion
            //DEFININDO A DATA FINAL DO ÚLTIMO PERÍODO DE BONIFICAÇÃO ANTES DA DATA INFORMADA
            //var periodicidade = definirPeriodicidade(rebate);
            //var dataInicialPesquisa = definirDataInicial(rebate);
            //var dataFinalPesquisa = definirDataFinal(periodicidade, dataInicialPesquisa, dataAlvo);
            var dataFinalPesquisa = dataAlvo;//new DateTime(dataAlvo.Year, dataAlvo.Month, 1).AddDays(-1D);
            var volumeComprado = this.rebateSicDAO.SelecionarVolumeComprado(
                rebate.NrIbmRebateSic, 
                null,  // DEVE BUSCAR NA VULNERABILIDADE TODO O VOLUME COMPRADO
                dataFinalPesquisa);
            var idRede = new AgrupamentoredeRebateSicBLO().SelecionarPrimeiro(new AgrupamentoredeRebateSic
            {
                NrIbmRebateSic = rebate.NrIbmRebateSic
            });
            if (idRede != null && idRede.NrSeqAgrupamentoredeRebateSic.HasValue)
            {
                var rede = new AgrupamentoredeRebateSicBLO().Selecionar(new AgrupamentoredeRebateSic { NrSeqAgrupamentoredeRebateSic = idRede.NrSeqAgrupamentoredeRebateSic });
                if (rede != null && rede.Count > 0)
                {
                    rede = rede.Where(r => r.NrIbmRebateSic != rebate.NrIbmRebateSic).ToList();
                    foreach (var membro in rede)
                    {
                        volumeComprado += this.rebateSicDAO.SelecionarVolumeComprado(
                            membro.NrIbmRebateSic,
                            null,  // DEVE BUSCAR NA VULNERABILIDADE TODO O VOLUME COMPRADO
                            dataFinalPesquisa);
                    }
                }
            }
            return volumeComprado;
        }

        public RebateSic Selecionar(string ibm)
        {
            var rebate = SelecionarPrimeiro(new RebateSic {
                NrIbmRebateSic = ibm
            });

            if (rebate.NrSeqRebateSic == null)
            {
                return null;
            }

            var tipoRebateSic = Factory
                .CreateFactoryInstance()
                .CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO")
                .SelecionarPrimeiro(new TiporebateSic
                {
                    NrSeqTiporebateSic = rebate.NrSeqTiporebateSic
                });

            rebate.DsTipoRebateSic = tipoRebateSic.NmTiporebateSic;

            var lstCalculoRebateSic = Factory
                .CreateFactoryInstance()
                .CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO")
                .Selecionar(new CalculoRebateSic
                {
                    NrSeqRebateSic = rebate.NrSeqRebateSic
                })
                .Where(x => x.NrSeqStatusCalculoRebateSic == 3)
                .ToList();

            if (lstCalculoRebateSic.Count > 0)
            {
                CalculoRebateSic oCalculoRebateSic = lstCalculoRebateSic.FirstOrDefault(x => x.DtPagamentoSic == lstCalculoRebateSic.Max(y => y.DtPagamentoSic.Value));

                rebate.UltimoPagto = oCalculoRebateSic.DtPagamentoSic;
                rebate.ValorUltimoPagto = oCalculoRebateSic.VlBonificacaoTotalSic;
            }

            return rebate; 
        }

        #endregion

        #region Métodos Privados

        private DateTime definirDataFinal(int periodicidade, DateTime dataInicial, DateTime dataAlvo)
        {
            var data = dataInicial;
            while (data.AddMonths(periodicidade) < dataAlvo) data = data.AddMonths(periodicidade);
            return new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));
        }

        private DateTime definirDataInicial(RebateSic rebate) { return rebate.DtIniciovigenciaRebateSic.Value; }

        private int definirPeriodicidade(RebateSic rebate)
        {
            var tipoRebate = new TiporebateSicBLO()
                .SelecionarPrimeiro(new TiporebateSic { NrSeqTiporebateSic = rebate.NrSeqTiporebateSic });
            bool cosan = tipoRebate.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
            bool mensal = cosan || rebate.StCalculoRebateSic.HasValue && rebate.StCalculoRebateSic.Value ? false : true;
            return mensal || (cosan && !rebate.StCalculoRebateSic.Value) ? 1 : 3;
        } 

        #endregion
    }
}

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
    /// Lógica de Processamento para reajuste do Rebate
    /// </summary>
    public class ReajusteBonificacaoBLO : IReajusteBonificacaoBLO
    {
        #region Variaveis Privadas
        /// <summary>
        ///Armazena lista de tipos de rebate
        /// </summary>        
        private IList<TiporebateSic> ListTipoRebateSic { get; set; }

        /// <summary>
        ///Armazena lista de tipos de reajuste
        /// </summary>        
        private IList<ReajusteSic> ListReajusteSic { get; set; }

        /// <summary>
        ///Armazena lista de rebates
        /// </summary>
        private IList<RebateSic> ListRebateSic { get; set; }

        /// <summary>
        ///Armazena os produtos x categorias
        /// </summary>
        private IList<FaixarebateSic> ListFaixaRebateSic { get; set; }

        /// <summary>
        /// Retorna Instancia de RebateSicBLO
        /// </summary>
        private IRebateSicBLO RebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de FaixaRebateSicBLO
        /// </summary>
        private IFaixarebateSicBLO FaixaRebateSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de IReajusteRebateHistoricoSicBLO
        /// </summary>
        private IReajusteRebateHistoricoSicBLO ReajusteRebateHistoricoSicBLOServico { get; set; }

        /// <summary>
        /// Retorna Instancia de IReajusteRebateHistoricoSicBLO
        /// </summary>
        private IReajusteSicBLO ReajusteSicBLOServico { get; set; }

        /// <summary>
        /// Retorna Instancia de IReajusteRebateHistoricoSicBLO
        /// </summary>
        private IReajusteRebatexfranquiaSicBLO ReajusteRebatexfranquiaSicBLOServico { get; set; }

        /// <summary>
        /// Retorna Instancia de IIgpmPeriodoSicBLO
        /// </summary>
        private IIgpmPeriodoSicBLO IgpmPeriodoSicBLOService { get; set; }

        /// <summary>
        /// Retorna Instancia de TipoRebateSicBLO
        /// </summary>
        private ITiporebateSicBLO TiporebateSicBLOService { get; set; }

        #endregion

        #region Construtor
        /// <summary>
        /// Construtor Default
        /// </summary>
        public ReajusteBonificacaoBLO()
        {
            this.RebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
            this.FaixaRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IFaixarebateSicBLO>("FaixarebateSicBLO");
            this.TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");
            this.ReajusteRebateHistoricoSicBLOServico = Factory.CreateFactoryInstance().CreateInstance<IReajusteRebateHistoricoSicBLO>("ReajusteRebateHistoricoSicBLO");
            this.ReajusteSicBLOServico = Factory.CreateFactoryInstance().CreateInstance<IReajusteSicBLO>("ReajusteSicBLO");
            this.ReajusteRebatexfranquiaSicBLOServico = Factory.CreateFactoryInstance().CreateInstance<IReajusteRebatexfranquiaSicBLO>("ReajusteRebatexfranquiaSicBLO");
            this.IgpmPeriodoSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IIgpmPeriodoSicBLO>("IgpmPeriodoSicBLO");

            this.ListTipoRebateSic = this.TiporebateSicBLOService.Selecionar();
            this.ListReajusteSic = this.ReajusteSicBLOServico.Selecionar();
        }
        #endregion

        #region Metodos Publicos

        #region Métodos Processamento Serviço
        /// <summary>
        /// Executar o cálculo/inserção para os rebates do periodo atual
        /// </summary>
        public void ProcessarServico()
        {
            //Buscar todos os rebates com indicação de reajuste 
            IList<RebateSic> listRebateSic = RebateSicBLOService.SelecionarVigentesReajuste();
            DateTime dtAtual = RebateUtil.GetDataAtual();

            //Buscar reajustes            
            foreach (RebateSic rebateSic in listRebateSic)
            {
                //Buscar faixas ativas do rebate e não vencidas
                IList<FaixarebateSic> listFaixaRebateSic = FaixaRebateSicBLOService.Selecionar(new FaixarebateSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic, StAtivoFaixaSic = true });

                //Datas                
                DateTime dtInicioMensal = RebateUtil.GetInicioPeriodoMensal(dtAtual);                
                DateTime dtInicioTrimestral = RebateUtil.GetInicioPeriodoTrimestral(dtAtual);                

                //Mensal ou Trimestral?
                TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);
                bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
                bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;

                //Formata datas do rebate
                DateTime dtInicio = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? dtInicioMensal : dtInicioTrimestral;
     
                listFaixaRebateSic = listFaixaRebateSic.Where(fr => fr.DtFimcalculoRebateSic.Value >= dtInicio).ToList();
                if (listFaixaRebateSic == null || listFaixaRebateSic.Count == 0) continue;

                //Buscar informações dos reajuste do rebate
                IList<ReajusteRebatexfranquiaSic> listReajusteRebateSic = ReajusteRebatexfranquiaSicBLOServico.Selecionar(new ReajusteRebatexfranquiaSic { NrSeqRebateSic = rebateSic.NrSeqRebateSic });
                if (listReajusteRebateSic == null || listReajusteRebateSic.Count == 0) continue;

                //Percorre reajustes
                foreach (ReajusteRebatexfranquiaSic reajusteRebate in listReajusteRebateSic)
                {
                    //Verificar se o rebate deve ser reajustado
                    ReajusteSic reajuste = ListReajusteSic.First(r => r.NrSeqReajusteSic == reajusteRebate.NrSeqReajusteSic);
                    if (reajusteRebate == null) continue;

                    //verifica se é IGPM
                    bool IGPM = reajuste.NmReajusteSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REAJUSTE_IGPM);

                    //Encontra a frequencia de reajuste
                    int? frequenciaReajuste = IGPM ? 12 : reajusteRebate.NrPeriodoReajusterebatexfranquiaSic;
                    if (frequenciaReajuste == null || frequenciaReajuste.Value == 0) continue;

                    //Buscar a data de último reajuste para esta faixa de reajuste                    
                    DateTime? dtProxReajuste = null;
                    ReajusteRebateHistoricoSic reajusteHist = ReajusteRebateHistoricoSicBLOServico.Selecionar(
                        new ReajusteRebateHistoricoSic
                        {
                            NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                            NrSeqReajusteSic = reajusteRebate.NrSeqReajusteSic
                        }, 1, " TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC DESC ").SingleOrDefault();

                    //Rebate nunca foi atualizado
                    if (reajusteHist == null || !reajusteHist.NrSeqReajusteRebateHistoricoSic.HasValue)
                        dtProxReajuste = rebateSic.DtAssinaturacontratoRebateSic.Value.AddMonths(frequenciaReajuste.Value);
                    else //Rebate ja foi atualizado
                        dtProxReajuste = reajusteHist.DtAlteracaoSic.Value.AddMonths(frequenciaReajuste.Value);

                    //Verificar se deve atualizar
                    if (dtProxReajuste.Value > RebateUtil.GetDataAtual()) continue; //Não deve reajustar                   

                    //Se for IGPM, busca o índice
                    IgpmPeriodoSic IGPMCalculo = IGPM ? IgpmPeriodoSicBLOService.Selecionar(
                            new IgpmPeriodoSic(), 1, " TB_IGPM_PERIODO_SIC.NR_SEQ_IGPM_PERIODO_SIC DESC ").First() : null;

                    //Reajustar..................................................................
                    foreach (FaixarebateSic faixa in listFaixaRebateSic)
                    {
                        //Inserir historico da faixa a ser reajustada
                        ReajusteRebateHistoricoSic historico = new ReajusteRebateHistoricoSic();
                        historico.NrSeqFaixarebateSic = faixa.NrSeqFaixarebateSic;
                        historico.NrSeqReajusteSic = reajusteRebate.NrSeqReajusteSic;
                        historico.NrSeqRebateSic = faixa.NrSeqRebateSic;
                        historico.NrPeriodoReajusteRebateSic = reajusteRebate.NrPeriodoReajusterebatexfranquiaSic;
                        historico.VlBonificacaoRebateSic = faixa.VlBonificacaoRebateSic;
                        historico.VlIgpmReajusteRebateSic = IGPM ? IGPMCalculo.VlPercentualSic : null;
                        historico.VlManualReajusteRebateSic = reajusteRebate.VlManualReajusterebatexfranquiaSic;
                        historico.DtAlteracaoSic = RebateUtil.GetDataAtual();
                        ReajusteRebateHistoricoSicBLOServico.Incluir(historico);

                        //Atualizar faixas de acordo com o indice escolhido
                        if (IGPM)
                        {
                            decimal percentualAjusteIGMP = reajusteRebate.VlManualReajusterebatexfranquiaSic ?? 100;
                            decimal percentualIGPM = IGPMCalculo.VlPercentualSic ?? 0;
                            faixa.VlBonificacaoRebateSic = faixa.VlBonificacaoRebateSic.Value * ((((percentualAjusteIGMP / 100) * percentualIGPM) / 100) + 1);
                        }
                        else
                        {
                            decimal? fatorReajuste = reajusteRebate.VlManualReajusterebatexfranquiaSic;
                            if (!fatorReajuste.HasValue) continue; //Senão achar o fator, não atualiza...
                            faixa.VlBonificacaoRebateSic = faixa.VlBonificacaoRebateSic.Value * ((fatorReajuste / 100) + 1);
                        }

                        FaixaRebateSicBLOService.Atualizar(faixa);
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}


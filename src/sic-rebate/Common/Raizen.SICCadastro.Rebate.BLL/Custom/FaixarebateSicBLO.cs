using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.Util;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Model.Enum;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Complemento de FaixarebateSicBLO
    /// </summary>
    internal partial class FaixarebateSicBLO
    {
        #region Metodos Publicos

        #region Selecionar Faixa Rebate Vigente
        /// <summary>
        /// Selecionar os dados de FaixarebateSic
        /// </summary>
        /// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de FaixarebateSic</returns>
        public IList<FaixarebateSic> SelecionarFaixasVigentesRebate(FaixarebateSic faixarebateSic)
        {
            return this.faixarebateSicDAO.SelecionarFaixasVigentesRebate(faixarebateSic);
        }
        #endregion Selecionar Faixa Rebate Vigente

        #region Selecionar Faixas Vigente Lista Rebate
        /// <summary>
        /// Seleciona uma lista de faixa para cálculo do aditivo
        /// </summary>
        public IList<FaixarebateSic> SelecionarFaixasAditivo(RebateSic rebateSic, DateTime dataInicioAditivo)
        {
            //Lista de faixas
            List<FaixarebateSic> listFaixaRebateSic = this.faixarebateSicDAO.SelecionarFaixasAditivo(rebateSic, dataInicioAditivo).ToList();

            //Tipos Rebate
            IList<TiporebateSic> ListTipoRebateSic = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO").Selecionar();
            TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);

            //Mensal ou Trimestral?
            bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
            bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;

            //Data de termino do periodo  
            //DateTime dataFimPeriodo = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? RebateUtil.GetFimPeriodoMensal(dtRef) : RebateUtil.GetFimPeriodoTrimestral(dtRef);
            DateTime dtRef = RebateUtil.GetDataAtual().AddMonths(-1);

            //Formata Faixas
            FormatarFaixasRebate(rebateSic, tipoRebateSic, dataInicioAditivo, dtRef, listFaixaRebateSic);

            return listFaixaRebateSic;
        }
        #endregion

        #region Selecionar Faixas Vigente Lista Rebate
        /// <summary>
        /// Seleciona uma lista de faixa rebate através de uma lista de rebates
        /// </summary>
        /// <param name="listRebateSic">lista de rebate</param>
        /// <returns>lista de faixas rebate</returns>
        public IList<FaixarebateSic> SelecionarFaixasVigentesListaRebate(IList<RebateSic> listRebateSic)
        {
            //Lista de faixas
            List<FaixarebateSic> listFaixaRebateSic = new List<FaixarebateSic>();

            //Datas
            DateTime dtAtual = RebateUtil.GetDataAtual();
            DateTime dtInicioMensal = RebateUtil.GetInicioPeriodoMensal(dtAtual);
            DateTime dtFimMensal = RebateUtil.GetFimPeriodoMensal(dtInicioMensal);
            DateTime dtInicioTrimestral = RebateUtil.GetInicioPeriodoTrimestral(dtAtual);
            DateTime dtFimTrimestral = RebateUtil.GetFimPeriodoTrimestral(dtInicioTrimestral);

            IList<TiporebateSic> ListTipoRebateSic = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO").Selecionar();

            //Busca faixas por rebate
            foreach (RebateSic rebateSic in listRebateSic)
            {
                #region busca faixas vigentes
                TiporebateSic tipoRebateSic = ListTipoRebateSic.Single(t => t.NrSeqTiporebateSic == rebateSic.NrSeqTiporebateSic);

                //Mensal ou Trimestral?
                bool cosan = tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME);
                bool mensal = cosan || rebateSic.StCalculoRebateSic.HasValue && rebateSic.StCalculoRebateSic.Value ? false : true;

                //Formata datas do rebate
                DateTime dtInicio = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? dtInicioMensal : dtInicioTrimestral;
                DateTime dtFim = mensal || (cosan && !rebateSic.StCalculoRebateSic.Value) ? dtFimMensal : dtFimTrimestral;

                //Busca faixas na base
                IList<FaixarebateSic> listFaixasBD = null;
                //Para tipo cosan, considerar o inicio como recebeimento da primeira bonificação
                if (cosan && rebateSic.DtIniciovigenciaRebateSic.Value.Year == dtAtual.Year &&
                    rebateSic.DtIniciovigenciaRebateSic.Value.Month == dtAtual.Month)
                {
                    listFaixasBD = this.SelecionarFaixasVigentesRebate(new FaixarebateSic
                    {
                        NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                        DtIniciocalculoRebateSic = dtInicio.AddMonths(1),
                        DtFimcalculoRebateSic = RebateUtil.GetFimPeriodoMensal(dtInicio.AddMonths(1))
                    });
                }
                else
                {
                    listFaixasBD = this.SelecionarFaixasVigentesRebate(new FaixarebateSic
                    {
                        NrSeqRebateSic = rebateSic.NrSeqRebateSic,
                        DtIniciocalculoRebateSic = dtInicio,
                        DtFimcalculoRebateSic = dtFim
                    });
                }

                #endregion

                #region log
                //Loga erro
                if (listFaixasBD == null || listFaixasBD.Count == 0)
                {
                    LogError.Debug(string.Format("Nenhuma faixa encontrada para o IBM {0} (Seq {1}).",
                        rebateSic.NrIbmRebateSic, rebateSic.NrSeqClienteSic));
                    continue;
                }
                #endregion

                //Formata Faixas
                FormatarFaixasRebate(rebateSic, tipoRebateSic, dtInicio, dtFim, listFaixasBD);

                //Adiciona a lista de retorno
                listFaixaRebateSic.AddRange(listFaixasBD);
            }

            return listFaixaRebateSic;
        }

        public IList<FaixarebateSic> Selecionar(int nrSeqRebateSic)
        {
            var rebate = Factory
                .CreateFactoryInstance()
                .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                .SelecionarPrimeiro(new RebateSic
                {
                    NrSeqRebateSic = nrSeqRebateSic
                });

            var faixas = Selecionar(new FaixarebateSic
            {
                NrSeqRebateSic = rebate.NrSeqRebateSic,
                StAtivoFaixaSic = true
            }).ToList();

            var categorias = Factory.CreateFactoryInstance()
                   .CreateInstance<ICategoriaSicBLO>("CategoriaSicBLO")
                   .Selecionar();

            faixas.ForEach(c => {
                c.DsCategoriaSic = categorias.FirstOrDefault(w => w.NrSeqCategoriaSic == c.NrSeqCategoriaSic)
                .NmCategoriaSic;

                if (c.NrSeqGrupoSic.HasValue) {
                    faixas
                    .Where(f => f.NrSeqCategoriaSic != c.NrSeqCategoriaSic)
                    .ToList()
                    .ForEach(i => {
                        if ((i.NrSeqGrupoSic == c.NrSeqGrupoSic && !rebate.NrSeqTiporebateSic.Equals((int)TipoRebate.Escalonado))
                        || (i.NrSeqGrupoSic == c.NrSeqGrupoSic && i.VlVolumemensalRebateSic == c.VlVolumemensalRebateSic && rebate.NrSeqTiporebateSic.Equals((int)TipoRebate.Escalonado)))
                        {
                            c.DsCategoriaSic += string.Concat(" / ", categorias.FirstOrDefault(w => w.NrSeqCategoriaSic == i.NrSeqCategoriaSic).NmCategoriaSic);
                        }
                    });
                }
            });

            if (rebate.NrSeqTiporebateSic.Equals((int)TipoRebate.Escalonado))
            {
                return Order(AgruparCalculosEscalonados(faixas));
            }
            else if (rebate.NrSeqTiporebateSic.Equals((int)TipoRebate.GlobalSomaVolume) ||
                    rebate.NrSeqTiporebateSic.Equals((int)TipoRebate.GlobalMediaVolume))
            {
                return Order(AgruparCalculosGlobal(faixas));
            }
            else
            {
                return Order(faixas);
            }
        }

        public List<FaixarebateSic> Order(List<FaixarebateSic> list)
        {
            return list.OrderByDescending(x => x.DsCategoriaSic)
                .ThenBy(x => x.VlPercminimoRebateSic).ToList();
        }

        #region Selecionar Faixas Historico
        /// <summary>
        /// Selecionar faixas rebate historico
        /// </summary>
        public IList<FaixarebateSic> SelecionarFaixasHistorico(int NrSeqCalculoRebateSic)
        {
            return this.faixarebateSicDAO.SelecionarFaixasHistorico(NrSeqCalculoRebateSic);
        }
        #endregion

        #endregion

        #region Métodos Privados
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="tipoRebateSic"></param>
        /// <param name="dtInicio"></param>
        /// <param name="dtFim"></param>
        /// <param name="listFaixasBD"></param>
        private IList<FaixarebateSic> FormatarFaixasRebate(RebateSic rebateSic, TiporebateSic tipoRebateSic, DateTime dtInicio, DateTime dtFim, IList<FaixarebateSic> listFaixasBD)
        {
            if (rebateSic.DtFimvigenciaRebateSic == null)
                rebateSic.DtFimvigenciaRebateSic = DateTime.MaxValue;

            //Formata data da fim das faixas           
            if (rebateSic.DtFimvigenciaRebateSic.Value < dtFim)
                foreach (FaixarebateSic faixa in listFaixasBD)
                    if (faixa.DtFimcalculoRebateSic > rebateSic.DtFimvigenciaRebateSic.Value)
                        faixa.DtFimcalculoRebateSic = rebateSic.DtFimvigenciaRebateSic.Value;

            //Tratar faixas encontradas na base, para não temos mais de uma faixa no mês
            DateTime dataInicioVar = dtInicio;
            int meses = RebateUtil.GetDiferencaMeses(dtInicio, dtFim);

            //Percorre todos os meses do periodo atual
            for (int i = 0; i <= meses; i++)
            {
                //TODO: Tratar Tipo Rebate Global Cosan
                if (tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME) ||
                    tipoRebateSic.NmTiporebateSic.Trim().ToUpper().Contains(ConstantesRebate.TIPO_REBATE_ESCALONADO))
                    break;

                //Recupera todas as faixas do mês corrente
                //List<FaixarebateSic> faixasMes = listFaixasBD.Where(f => f.DtIniciocalculoRebateSic.Value <= RebateUtil.GetFimPeriodoMensal(dataInicioVar))
                //    .Distinct().ToList().OrderBy(f => f.DtIniciocalculoRebateSic.Value).ToList();

                List<FaixarebateSic> faixasMes = listFaixasBD.Where(f =>
                    f.DtIniciocalculoRebateSic.Value <= RebateUtil.GetFimPeriodoMensal(dataInicioVar)
                    && f.DtFimcalculoRebateSic.Value >= new DateTime(dataInicioVar.Year, dataInicioVar.Month, 1))
                    .Distinct().ToList().OrderBy(f => f.DtIniciocalculoRebateSic.Value).ToList();

                //Recupera as categorias das faixas do mês corrente
                List<int> categorias = faixasMes.Select(f => f.NrSeqCategoriaSic.Value).Distinct().ToList();

                //Percorre as categorias
                foreach (int cat in categorias)
                {
                    //Recupera as faixas do mês por categoria
                    List<FaixarebateSic> faixasMesCategoria = faixasMes.Where(f => f.NrSeqCategoriaSic.Value == cat).ToList();

                    //Formata faixas que começam dentro do mesmo mês
                    if (faixasMesCategoria != null && faixasMesCategoria.Count > 1)
                    {
                        //Considera última faixa
                        FaixarebateSic faixaValida = faixasMesCategoria.Last();
                        faixasMesCategoria.Remove(faixaValida);

                        //Formata data da faixa valida na lista de retorno
                        foreach (FaixarebateSic faixa in listFaixasBD)
                        {
                            if (faixa.NrSeqFaixarebateSic.Value == faixaValida.NrSeqFaixarebateSic)
                            {
                                faixa.DtIniciocalculoRebateSic = new DateTime(faixaValida.DtIniciocalculoRebateSic.Value.Year, faixaValida.DtIniciocalculoRebateSic.Value.Month, 1);
                                break;
                            }
                        }

                        //Primeiro mês, deve-se remover faixas duplicados (com mesmo mês), considerando como válida a última faixa apenas
                        if (i == 0)
                        {
                            //Remove as faixas que não serão utilizadas
                            List<FaixarebateSic> listFaixasBDRemover = listFaixasBD.Where(f => faixasMesCategoria.Select(fx => fx.NrSeqFaixarebateSic.Value).Contains(f.NrSeqFaixarebateSic.Value)).ToList();
                            listFaixasBDRemover.ForEach(f => listFaixasBD.Remove(f));
                        }
                        else
                        {
                            //Formata data da faixa para evitar sobreposição de meses
                            FaixarebateSic faixaInvalida = faixasMesCategoria.First();
                            faixasMesCategoria.Remove(faixaInvalida);

                            //Formata data da faixa valida na lista de retorno
                            foreach (FaixarebateSic faixa in listFaixasBD)
                            {
                                if (faixa.NrSeqFaixarebateSic.Value == faixaInvalida.NrSeqFaixarebateSic)
                                {
                                    faixa.DtFimcalculoRebateSic = new DateTime(faixaInvalida.DtFimcalculoRebateSic.Value.AddMonths(-1).Year, faixaInvalida.DtFimcalculoRebateSic.Value.AddMonths(-1).Month,
                                        DateTime.DaysInMonth(faixaInvalida.DtFimcalculoRebateSic.Value.AddMonths(-1).Year, faixaInvalida.DtFimcalculoRebateSic.Value.AddMonths(-1).Month));
                                    break;
                                }
                            }

                            //Remove as faixas que não serão utilizadas
                            if (faixasMesCategoria.Count > 0)
                            {
                                List<FaixarebateSic> listFaixasBDRemover = listFaixasBD.Where(f => faixasMesCategoria.Select(fx => fx.NrSeqFaixarebateSic.Value).Contains(f.NrSeqFaixarebateSic.Value)).ToList();
                                listFaixasBDRemover.ForEach(f => listFaixasBD.Remove(f));
                            }
                        }
                    }
                }

                //Incrementa os meses
                dataInicioVar = new DateTime(dataInicioVar.AddMonths(1).Year, dataInicioVar.AddMonths(1).Month, 1);
            }

            //Formata o inicio das faixas para o inicio do mês
            foreach (FaixarebateSic faixa in listFaixasBD)
                faixa.DtIniciocalculoRebateSic = new DateTime(faixa.DtIniciocalculoRebateSic.Value.Year, faixa.DtIniciocalculoRebateSic.Value.Month, 1);

            return listFaixasBD;
        }
        #endregion

        private List<FaixarebateSic> AgruparCalculosEscalonados(List<FaixarebateSic> lstFaixaRebate)
        {
            List<FaixarebateSic> lstAgrupa = new List<FaixarebateSic>();
            List<FaixarebateSic> lista = new List<FaixarebateSic>();
            int? id_grupo = 0;
            decimal? volume = 0M;
            lista = lstFaixaRebate.OrderBy(c => c.NrSeqGrupoSic).ToList();
            foreach (FaixarebateSic item in lista)
            {
                if (item.NrSeqGrupoSic != id_grupo || (item.NrSeqGrupoSic == id_grupo && item.VlVolumemensalRebateSic != volume))
                {
                    if (lstAgrupa.Count != 0)
                    {
                        if (lstAgrupa.Find(x => x.NrSeqGrupoSic == item.NrSeqGrupoSic && x.VlVolumemensalRebateSic == item.VlVolumemensalRebateSic) == null)
                            lstAgrupa.Add(item);
                    }
                    else
                        lstAgrupa.Add(item);
                    id_grupo = item.NrSeqGrupoSic;
                    volume = item.VlVolumemensalRebateSic;
                }
            }

            lstAgrupa.ForEach(r =>
            {
                if (r.VlPercmaximoRebateSic.HasValue &&
                    r.VlPercmaximoRebateSic.Value == 0) r.VlPercmaximoRebateSic = null;
            });

            lstAgrupa = lstAgrupa
                .OrderBy(r => r.DtIniciocalculoRebateSic)
                .ThenBy(r => r.VlVolumemensalRebateSic)
                .ToList();

            return lstAgrupa;
        }

        private List<FaixarebateSic> AgruparCalculosGlobal(List<FaixarebateSic> lstCalculoRebate)
        {
            List<FaixarebateSic> lstAgrupa = new List<FaixarebateSic>();
            List<FaixarebateSic> lista = new List<FaixarebateSic>();
            int? id_grupo = 0;
            lista = lstCalculoRebate.OrderBy(c => c.NrSeqGrupoSic).ToList();
            foreach (FaixarebateSic item in lista)
            {
                if (item.NrSeqGrupoSic != id_grupo)
                {
                    if (lstAgrupa.Count != 0)
                    {
                        if (lstAgrupa.Find(x => x.NrSeqGrupoSic == item.NrSeqGrupoSic) == null)
                            lstAgrupa.Add(item);
                    }
                    else
                        lstAgrupa.Add(item);
                    id_grupo = item.NrSeqGrupoSic;
                }
            }
            return lstAgrupa;
        }

        #endregion
    }
}

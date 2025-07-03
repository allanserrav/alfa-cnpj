//using System;
//using System.Collections.Generic;
//using System.Linq;
//using COSAN.Framework.Factory;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Raizen.SICCadastro.Rebate.BLL.Test.Msg;
//using Raizen.SICCadastro.Rebate.Model;
//using Raizen.SICCadastro.Rebate.Util;

//namespace Raizen.SICCadastro.Rebate.BLL.Test
//{
//    [TestClass]
//    public class CalculoRebateTest
//    {
//        private IList<TiporebateSic> ListaTipoRebateSic;

//        public enum ddlSituacao
//        {
//            BonificacaoPendentedePagamento = 1,
//            AprovadopeloAnalista = 2,
//            EnviadoAprovacaodoGestor = 3,
//            EnviadoparaPagamento = 4,
//            Pago = 5,
//            BonificacaoCancelada = 6,
//            CalculoRetroativo = 7,
//            RebatecomDebito = 8
//        }

//        private Boolean? FiltroBuscaCalculoRetroativo; 

//        private IList<BonificacaoGrid> ListaBonificacaoGrid;

//        private ICalculoRebateSicBLO _CalculoRebateSicBLOService;
//        private ICalculoRebateSicBLO CalculoRebateSicBLOService
//        {
//            get
//            {
//                if (_CalculoRebateSicBLOService == null)
//                    _CalculoRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateSicBLO>("CalculoRebateSicBLO");

//                return _CalculoRebateSicBLOService;
//            }
//        }

//        private ITiporebateSicBLO _TiporebateSicBLOService { get; set; }
//        private ITiporebateSicBLO TiporebateSicBLOService
//        {
//            get
//            {
//                if (_TiporebateSicBLOService == null)
//                    _TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");

//                return _TiporebateSicBLOService;
//            }
//        }

//        [TestMethod]
//        //public void BuscarBonificacao()
//        {
//            Boolean chkAprovacaoMassiva = true;
//            String txtPeriodo = "12/2019";
//            String txtIBM = String.Empty;
//            Boolean chkFaixaVolume = true;
//            Boolean chkMediaVolume = true;
//            Boolean chkSomaVolume = true;
//            Boolean chkEscalonado = true;

//            try
//            {
//                // Valida se checado a aprovação massiva então a informação do período é obrigatório.
//                if (chkAprovacaoMassiva && txtPeriodo.Length <= 0)
//                {
//                    //Assert.Fail(Mensagens.AlertaInformePeriodoAprovacaoMassiva);
//                }
//                //try
//                //{
//                //    // Valida se checado a aprovação massiva então a informação do período é obrigatório.
//                //    if (chkAprovacaoMassiva && txtPeriodo.Length <= 0)
//                //    {
//                //        Assert.Fail(Mensagens.AlertaInformePeriodoAprovacaoMassiva);
//                //    }

//                // Valida se checado a aprovação massiva então a informação do período é obrigatório.
//                if (chkAprovacaoMassiva && txtPeriodo.Length <= 0)
//                {
//                    Assert.Fail(Mensagens.AlertaPeriodoValido);
//                }

//                //Valida que a Data digitada é válida
//                DateTime tempDate;
//                if (txtPeriodo.Length > 0 && !DateTime.TryParse(txtPeriodo, out tempDate))
//                {
//                    Assert.Fail(Mensagens.AlertaPeriodoValido);
//                }

//                FiltroBonificacaoGrid filtro = new FiltroBonificacaoGrid();

//                //Periodo
//                if (!string.IsNullOrEmpty(txtPeriodo))
//                {
//                    string[] data = txtPeriodo.Split('/');
//                    filtro.DataPeriodo = new DateTime(Convert.ToInt16(data[1]), Convert.ToInt16(data[0]), 1);
//                }

//                //IBM
//                filtro.CodigoIBM = txtIBM;

//                //Tipo Rebate
//                this.ListaTipoRebateSic = TiporebateSicBLOService.Selecionar();
//                List<string> lstTiposRebate = new List<string>();
//                if (chkFaixaVolume)
//                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_FAIXA_VOLUME)).NrSeqTiporebateSic.ToString());
//                if (chkMediaVolume)
//                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME)).NrSeqTiporebateSic.ToString());
//                if (chkSomaVolume)
//                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME)).NrSeqTiporebateSic.ToString());
//                if (chkEscalonado)
//                    lstTiposRebate.Add(this.ListaTipoRebateSic.FirstOrDefault(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_ESCALONADO)).NrSeqTiporebateSic.ToString());

//                //Situação
//                string situacao = ddlSituacao.AprovadopeloAnalista.ToString();
//                if (situacao != ConstantesRebate.DDL_SELECIONE)
//                {
//                    switch (situacao)
//                    {
//                        case ConstantesRebate.DDL_PENDENTE_PAGAMENTO:
//                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.AptoPagamento), ",",
//                                Convert.ToInt16(StatusCalculoRebate.InformacoesInconsistentes), ",",
//                                Convert.ToInt16(StatusCalculoRebate.NaoAtingiuVolumeMinimo));
//                            break;
//                        case ConstantesRebate.DDL_APROVADO_ANALISTA:
//                            filtro.AprovadoAnalista = true;
//                            break;
//                        case ConstantesRebate.DDL_ENVIADO_APROVACAO_GERENCIAL:
//                            filtro.EnviadoGestor = true;
//                            break;
//                        case ConstantesRebate.DDL_ENVIADO_PAGAMENTO:
//                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento));
//                            break;
//                        case ConstantesRebate.DDL_PAGO:
//                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.Pago));
//                            break;
//                        case ConstantesRebate.DDL_CANCELADO:
//                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.Cancelado));
//                            break;
//                        case ConstantesRebate.DDL_CALCULO_RETROATIVO_PENDENTE:
//                            filtro.CalculoRetroativo = true;
//                            break;
//                        case ConstantesRebate.DDL_PENDENTE_DEBITO:
//                            filtro.ListaStatus = string.Concat(Convert.ToInt16(StatusCalculoRebate.PendenteDebito));
//                            break;
//                    }
//                }

//                //Verifica se o tipo foi informado                
//                if (lstTiposRebate.Count == 0)
//                {
//                    Assert.Fail(Mensagens.AlertaPesquisaTipoRebate);
//                }
//                else
//                    filtro.ListaTipoRebate = string.Join(",", lstTiposRebate.Select(r => r).ToArray());

//                //Aprovação Massiva
//                filtro.AprovacaoMassiva = chkAprovacaoMassiva;

//                //Verifica se os filtros foram informados
//                if (!filtro.FiltroInformado)
//                {
//                    Assert.Fail(Mensagens.AlertaPesquisaSemFiltros);
//                }

//                //Verifica qual busca deve executar
//                if (filtro.CalculoRetroativo.HasValue && filtro.CalculoRetroativo.Value)
//                {
//                    this.FiltroBuscaCalculoRetroativo = true;
//                    this.ListaBonificacaoGrid = CalculoRebateSicBLOService.SelecionarRebatesSemCalculo(filtro);
//                }
//                else
//                {
//                    this.FiltroBuscaCalculoRetroativo = false;
//                    this.ListaBonificacaoGrid = CalculoRebateSicBLOService.SelecionarBonificacao(filtro);
//                }

//                //Ordena
//                this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.OrderBy(b => b.CodigoIBM).ToList();

//                ////Filtra o Canal
//                //if (ddlCanal.SelectedValue != "0")
//                //    this.ListaBonificacaoGrid = this.ListaBonificacaoGrid.Where(b => b.NomeCanal.ToUpper().Trim().Equals(ddlCanal.SelectedValue.ToUpper().Trim())).ToList();

//                //Marca os Cálculos Apto Pagamento
//                foreach (BonificacaoGrid item in ListaBonificacaoGrid)
//                {
//                    if (item.CodigoStatus == Convert.ToInt16(StatusCalculoRebate.AptoPagamento) && (item.AprovadoAnalista.HasValue && !item.AprovadoAnalista.Value))
//                        item.Selecionado = true;
//                }

//                //Marca todos os itens
//                if ((filtro.AprovadoAnalista.HasValue && filtro.AprovadoAnalista.Value) ||
//                    (filtro.EnviadoGestor.HasValue && filtro.EnviadoGestor.Value) ||
//                    (filtro.CalculoRetroativo.HasValue && filtro.CalculoRetroativo.Value))
//                    this.ListaBonificacaoGrid.ToList().ForEach(b => b.Selecionado = true);

//                Assert.IsTrue(this.ListaBonificacaoGrid.ToList().Count > 0);
//            }
//            catch (Exception ex)
//            {
//                Assert.Fail(ex.Message);
//            }
//        }
//    }
//}
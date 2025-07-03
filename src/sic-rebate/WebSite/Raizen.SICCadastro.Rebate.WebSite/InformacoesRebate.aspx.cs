using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Raizen.SICCadastro.Rebate.Util.Relatorio;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using Raizen.SICCadastro.Rebate.BLL;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class InformacoesRebate : System.Web.UI.Page
    {
        #region Propriedades
        /// <summary>
        /// IRebateSicBLO
        /// </summary>
        private IRebateSicBLO _IRebateSicBLOService;
        private IRebateSicBLO RebateSicBLOService
        {
            get
            {
                if (_IRebateSicBLOService == null)
                    _IRebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");

                return _IRebateSicBLOService;
            }
        }

        /// <summary>
        /// ITiporebateSicBLO
        /// </summary>
        private ITiporebateSicBLO _TiporebateSicBLOService { get; set; }
        private ITiporebateSicBLO TiporebateSicBLOService
        {
            get
            {
                if (_TiporebateSicBLOService == null)
                    _TiporebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<ITiporebateSicBLO>("TiporebateSicBLO");

                return _TiporebateSicBLOService;
            }
        }

        /// <summary>
        /// Lista de Extrato
        /// </summary>
        private IList<InformacaoRebateRel> ListaRelatorio
        {
            get
            {
                if (ViewState["ListaRelatorio"] == null)
                    ViewState["ListaRelatorio"] = new List<InformacaoRebateRel>();

                return ViewState["ListaRelatorio"] as IList<InformacaoRebateRel>;
            }
            set
            {
                ViewState["ListaRelatorio"] = value;
            }
        }

        /// <summary>
        ///Armazena lista de tipos de rebate
        /// </summary>        
        private IList<TiporebateSic> ListaTipoRebateSic
        {
            get
            {
                if (ViewState["ListaTipoRebateSic"] == null)
                    ViewState["ListaTipoRebateSic"] = TiporebateSicBLOService.Selecionar();

                return ViewState["ListaTipoRebateSic"] as IList<TiporebateSic>;
            }
            set
            {
                ViewState["ListaTipoRebateSic"] = value;
            }
        }

        /// <summary>
        ///Armazena lista de status do cliente
        /// </summary>        
        private IList<StatusSic> ListaStatusSic
        {
            get
            {
                if (ViewState["ListaStatusSic"] == null)
                    ViewState["ListaStatusSic"] = Factory.CreateFactoryInstance().CreateInstance<IStatusSicBLO>("StatusSicBLO").Selecionar();

                return ViewState["ListaStatusSic"] as IList<StatusSic>;
            }
            set
            {
                ViewState["ListaStatusSic"] = value;
            }
        }
        #endregion

        #region Eventos [Page]
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        #endregion

        #region Eventos [Controles]

        /// <summary>
        /// btnOK_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e) { }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                //Tipo Rebate
                List<string> lstTiposRebate = new List<string>();
                if (chkFaixaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_FAIXA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkMediaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_MEDIA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkSomaVolume.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_GLOBAL_SOMA_VOLUME)).NrSeqTiporebateSic.ToString());
                if (chkEscalonado.Checked)
                    lstTiposRebate.Add(this.ListaTipoRebateSic.First(r => r.NmTiporebateSic.Trim().ToUpper().Equals(ConstantesRebate.TIPO_REBATE_ESCALONADO)).NrSeqTiporebateSic.ToString());

                //Status Cliente
                List<string> lstStatusCliente = new List<string>();
                if (chkAceito.Checked)
                    lstStatusCliente.Add(this.ListaStatusSic.First(s => s.NmStatusSic.Trim().ToUpper().Equals(ConstantesRebate.STATUS_CLIENTE_ACEITO)).NrSeqStatusSic.ToString());
                if (chkAnalise.Checked)
                    lstStatusCliente.Add(this.ListaStatusSic.First(s => s.NmStatusSic.Trim().ToUpper().Equals(ConstantesRebate.STATUS_CLIENTE_ANALISE)).NrSeqStatusSic.ToString());
                if (chkCorrecao.Checked)
                    lstStatusCliente.Add(this.ListaStatusSic.First(s => s.NmStatusSic.Trim().ToUpper().Equals(ConstantesRebate.STATUS_CLIENTE_CORRECAO)).NrSeqStatusSic.ToString());

                //Valida
                if (lstTiposRebate.Count == 0 || lstStatusCliente.Count == 0)
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaInfoCliente);
                    return;
                }

                //Preencha filtro
                InformacaoRebateRelFiltro filtro = new InformacaoRebateRelFiltro();
                if (!string.IsNullOrEmpty(txtIBM.Text))
                    filtro.CodigoIBM = txtIBM.Text.Trim();

                filtro.ListaTipoRebate = string.Join(",", lstTiposRebate.Select(r => r).ToArray());
                filtro.ListaStatus = string.Join(",", lstStatusCliente.Select(r => r).ToArray());
                this.ListaRelatorio = RebateSicBLOService.SelecionarRelatorioInformacoesRebate(filtro);

                //Bind
                CarregarGrid();
                if (this.ListaRelatorio.Count > 20)
                    ShowAlertMessage(Mensagens.AlertaExibicaoPrimeiros);
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        /// <summary>
        /// btnBuscar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida que a data inicial seja menor ou igual a data final
                if (this.ListaRelatorio.Count == 0)
                {
                    ShowAlertMessage(Mensagens.ErroGerarExcel);
                    return;
                }

                //Conteúdo do Response
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                Response.Charset = string.Empty;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "InformacoesRebate" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                //Exporta
                Response.Write(CriarTabela());
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            Response.End();
        }

        #endregion

        #region Métodos Privados
        /// <summary>
        /// Exibe erros
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        /// <summary>
        /// Carrega Grid
        /// </summary>
        /// <param name="saldos"></param>
        private void CarregarGrid()
        {
            grvResultado.DataSource = this.ListaRelatorio.Take(20);
            grvResultado.DataBind();
        }

        /// <summary>
        /// Gera tabela HTML
        /// </summary>
        /// <returns></returns>
        private string CriarTabela()
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "IBM"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "150px"), "CNPJ"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "400px"), "Razão Social"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "150px"), "Tipo Rebate"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Empresa"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "CEGR"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Pagador"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Fornecedor"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "200px"), "GA"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "300px"), "GT"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "120px"), "Dt. Ass. Contrato"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "120px"), "Dt. Início Vigência"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "120px"), "Dt. Fim Vigência"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Pagamento"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "100px"), "Status"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (InformacaoRebateRel item in this.ListaRelatorio)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "100px"), string.Empty, item.NrIbmClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "150px"), string.Empty, item.NrCnpjClienteSic + ""));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "400px"), string.Empty, item.NmRazsociallojaFranquiaSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "150px"), string.Empty, item.NmTiporebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmEmpresaSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "100px"), string.Empty, item.NrCegrpostoClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "100px"), string.Empty, item.NrCodigopagadorRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoTexto, "100px"), string.Empty, item.NrCodigofornecedorRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "200px"), string.Empty, item.NmGalojaClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "300px"), string.Empty, item.NmGtlojaClienteSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoData, "120px"), string.Empty, item.DtAssinaturacontratoRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoData, "120px"), string.Empty, item.DtIniciovigenciaRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD + TabelaHTML.FormatoData, "120px"), string.Empty, item.DtFimvigenciaRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.StCalculoRebateSic.Value ? "Trimestral" : "Mensal"));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "100px"), string.Empty, item.NmStatusSic));
                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }
        #endregion
    }
}


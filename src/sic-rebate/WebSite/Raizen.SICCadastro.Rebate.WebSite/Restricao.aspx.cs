using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Util;
using System.Data;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using COSAN.Framework.Util;
using System.Text;
using Raizen.SICCadastro.Rebate.WebSite.Controls;
using ClosedXML.Excel;
using System.IO;
using Raizen.SICCadastro.Rebate.Util.Relatorio;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Restricao : System.Web.UI.Page
    {
        #region Constantes

        #endregion


        #region Propriedades

        private IList<Raizen.SICCadastro.Rebate.Model.Restricao> ListaRestricao
        {
            get
            {
                if (ViewState["ListaRestricao"] == null)
                    ViewState["ListaRestricao"] = new List<Restricao>();

                return ViewState["ListaRestricao"] as IList<Raizen.SICCadastro.Rebate.Model.Restricao>;
            }
            set
            {
                ViewState["ListaRestricao"] = value;
            }
        }

        private Int32? NrSeqRestricao
        {
            get
            {
                return ViewState["NrSeqRestricao"] as Int32?;
            }
            set
            {
                ViewState["NrSeqRestricao"] = value;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e) { }

        #endregion

        #region Eventos da pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarListaRestricao();
            }
        }

        #endregion Eventos da pagina

        #region Metodos

        
        private void CarregarListaRestricao()
        {
            try
            {
                this.ListaRestricao = Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IRestricaoBLO>("RestricaoBLO")
                    .Selecionar();

                //***
                CarregarGrid();
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                ShowAlertMessage(Mensagens.MsgErroRestricao);
            }
        }


        private void CarregarGrid()
        {
            grvResultado.DataSource = this.ListaRestricao.OrderBy(p => p.DsIbm).ToList();
            grvResultado.DataBind();
        }

        private void Limpar()
        {
            grvResultado.PageIndex = 0;
            this.txtIbm.Text = string.Empty;
            this.txtIbm.Visible = true;
            this.txtMotivo.Text = string.Empty;
            this.txtMotivo.Visible = true;

            this.txtIbm.Focus();
            CarregarGrid();
        }

        #endregion

        #region Eventos de componetes

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            this.NrSeqRestricao = int.Parse(((ImageButton)sender).CommandArgument);
            ClientScript.RegisterStartupScript(Page.GetType(), "confirmacao", "Deletar();", true);
        }

        protected void btnSimExcluir_OnClick(object sender, EventArgs e)
        {
            try
            {
                Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").Excluir(new Raizen.SICCadastro.Rebate.Model.Restricao() 
                {
                    NrSeqRestricao = this.NrSeqRestricao
                });

                string ibm = string.Empty;
                var restricao = this.ListaRestricao.Where(j => j.NrSeqRestricao == this.NrSeqRestricao).FirstOrDefault();
                if (restricao != null)
                    ibm = restricao.DsIbm;

                string descricao = "Deletou a restrição para o IBM: " + ibm + ", ID: " + NrSeqRestricao;
                Factory.CreateFactoryInstance()
                    .CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO")
                    .IncluirLogDescricao("Restricao", "btnSimExcluir_OnClick", descricao, Util.Util.LoginUsuario());

                ShowAlertMessage(Mensagens.MsgRestricaoExcluirSucesso);

                //*** 
                this.NrSeqRestricao = null;
                CarregarListaRestricao();
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                ShowAlertMessage(Mensagens.MsgErroRestricao);
            }
        }

       

        #endregion Eventos de componetes

        #region Controle Paginação


        private void Paginacao(string command)
        {
            int iCurrentIndex = grvResultado.PageIndex;
            switch (command.ToLower())
            {
                case "primeiro":
                    grvResultado.PageIndex = 0;
                    break;
                case "anterior":
                    if (grvResultado.PageIndex != 0)
                        grvResultado.PageIndex = iCurrentIndex - 1;
                    break;
                case "proximo":
                    grvResultado.PageIndex = iCurrentIndex + 1;
                    break;
                case "ultimo":
                    grvResultado.PageIndex = grvResultado.PageCount;
                    break;
                case "ddcurrentpage":
                    GridViewRow row = grvResultado.BottomPagerRow;
                    DropDownList ddCurrentPage = (DropDownList)row.Cells[0].FindControl("ddCurrentPage");
                    grvResultado.PageIndex = ddCurrentPage.SelectedIndex;
                    break;
            }

            //*** Carrega novamente os dados no grid com a nova pagina
            CarregarGrid();
        }

        protected void ddCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Paginacao("ddcurrentpage");
        }

        protected void imgPageFirst_Command(object sender, CommandEventArgs e)
        {
            Paginacao("primeiro");
        }

        protected void imgPagePrevious_Command(object sender, CommandEventArgs e)
        {
            Paginacao("anterior");
        }

        protected void imgPageNext_Command(object sender, CommandEventArgs e)
        {
            Paginacao("proximo");
        }

        protected void imgPageLast_Command(object sender, CommandEventArgs e)
        {
            Paginacao("ultimo");
        }

        #endregion Controle Paginação

        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        private Model.Restricao MontarFiltroBusca()
        {
            var filtro = new Model.Restricao();

            if (!string.IsNullOrEmpty(this.txtIbm.Text))
            {
                filtro.DsIbm = txtIbm.Text;
            }

            if (!string.IsNullOrEmpty(this.txtMotivo.Text))
            {
                filtro.DsMotivo = txtMotivo.Text;
            }

            return filtro;
        }

        private void Buscar()
        {
            try
            {
                var filtro = MontarFiltroBusca();
                var lista = Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").Selecionar(filtro);

                //var listaCliente = from p in lista
                //                   join e in this.ListaRestricao on p.DsIbm equals e.DsIbm
                //                   orderby p.DsIbm
                //                   select new
                //                   {
                //                       p.NrSeqRestricao,
                //                       p.DsIbm,
                //                       p.DsMotivo,
                //                   };

                //grvResultado.DataSource = listaCliente.OrderBy(o => o.DsIbm).ToList();
                grvResultado.DataSource = lista.OrderBy(o => o.DsIbm).ToList();
                grvResultado.DataBind();

                //pnlInformacao.Visible = true;
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                ShowAlertMessage(Mensagens.AlertaExibicaoPrimeiros);
            }
        }

        protected void grvResultado_DataBound(object sender, EventArgs e)
        {
            GridViewRow gridRodape = grvResultado.BottomPagerRow;
            if (gridRodape == null) return;

            var paginacao = (ucPaginacaoRodape)gridRodape.Cells[0].FindControl("ucPaginacaoRodape");
            paginacao.Carregar(grvResultado.PageCount, grvResultado.PageIndex);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        protected void ucPaginacaoRodape_Comando(TipoComandoPaginacao tipoComandoPaginacao, int paginaAtual)
        {
            grvResultado.PageIndex = paginaAtual;
            Buscar();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroRestricao.aspx");
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                //Valida se as datas não estão em branco
                if (string.IsNullOrEmpty(txtIbm.Text))
                {
                    ShowAlertMessage(Mensagens.AlertaPesquisaExtrato);
                    return;
                }
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }
        }

        private string CriarTabela(IList<Model.RestricaoExport> lstListaRestricao)
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 3px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            //CABEÇALHO
            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "120px"), "IBM"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "400px"), "Motivo"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "220px"), "Tipo da Restrição"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (RestricaoExport item in lstListaRestricao)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.DsIbm));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.DsMotivo));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.DsTipoRestricao));

                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }

            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }

        private string ExportarResultado(IList<Model.RestricaoExport> lstListaRestricao)
        {
            return CriarTabela(lstListaRestricao);
        }

        protected void btnGerarExcel_Click(object sender, EventArgs e)
        {
            try
            {               

                IList<RestricaoExport> lstRestricoes = Factory.CreateFactoryInstance()
                .CreateInstance<IRestricaoBLO>("RestricaoBLO")
                .SelecionarExport().OrderBy(x=>x.DsIbm).ToList();

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                Response.Charset = string.Empty;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xls", "ResultadoListagemRestricoes.xlsx" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                Response.Write(ExportarResultado(lstRestricoes));
            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            Response.End();
        }

    }
}
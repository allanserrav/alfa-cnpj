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

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class TipoRestricao : System.Web.UI.Page
    {
        #region Constantes

        #endregion


        #region Propriedades

        private IEnumerable<Raizen.SICCadastro.Rebate.Model.TipoRestricao> ListaTipoRestricao
        {
            get
            {
                if (ViewState["ListaTipoRestricao"] == null)
                    ViewState["ListaTipoRestricao"] = new List<TipoRestricao>();

                return ViewState["ListaTipoRestricao"] as IEnumerable<Raizen.SICCadastro.Rebate.Model.TipoRestricao>;
            }
            set
            {
                ViewState["ListaTipoRestricao"] = value;
            }
        }

        private Int32? NrSeqTipoRestricao
        {
            get
            {
                return ViewState["NrSeqTipoRestricao"] as Int32?;
            }
            set
            {
                ViewState["NrSeqTipoRestricao"] = value;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e) { }

        #endregion

        #region Eventos da pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarListaTipoRestricao();
            }
        }

        #endregion Eventos da pagina

        #region Metodos

        
        private void CarregarListaTipoRestricao()
        {
            try
            {
                this.ListaTipoRestricao = Factory
                    .CreateFactoryInstance()
                    .CreateInstance<ITipoRestricaoBLO>("TipoRestricaoBLO")
                    .Selecionar();

                //***
                CarregarGrid();
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                ShowAlertMessage(Mensagens.MsgErroTipoRestricao);
            }
        }

        private string ValidarCadastro()
        {
            string mensagem = string.Empty;

            if (txtDsTipoRestricao.Text == null || txtDsTipoRestricao.Text == "")
            {
                mensagem = Mensagens.MsgTipoRestricaoVazio;
                
            }

            return mensagem;
        }

        private void CarregarGrid()
        {
            grvTipoRestricao.DataSource = this.ListaTipoRestricao.OrderBy(p => p.DsTipoRestricao).ToList();
            grvTipoRestricao.DataBind();
        }

        private void Limpar()
        {
            this.txtDsTipoRestricao.Text = string.Empty;
            this.lblTipoRestricao.Visible = true;

            this.txtDsTipoRestricao.Focus();
        }

        #endregion

        #region Eventos de componetes

        protected void grvTipoRestricao_DataBound(object sender, EventArgs e)
        {
            GridViewRow row = grvTipoRestricao.BottomPagerRow;
            if (row == null) return;

            DropDownList ddCurrentPage = (DropDownList)row.Cells[0].FindControl("ddCurrentPage");
            Label lblTotalPage = (Label)row.Cells[0].FindControl("lblTotalPage");

            if (ddCurrentPage != null)
            {
                for (int i = 0; i < grvTipoRestricao.PageCount; i++)
                {
                    int iPageNumber = i + 1;
                    ListItem myListItem = new ListItem(iPageNumber.ToString());

                    if (i == grvTipoRestricao.PageIndex)
                        myListItem.Selected = true;

                    ddCurrentPage.Items.Add(myListItem);
                }
            }

            if (lblTotalPage != null)
                lblTotalPage.Text = grvTipoRestricao.PageCount.ToString();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string mensagem = string.Empty;

            try
            {
                mensagem = ValidarCadastro();
                if (string.IsNullOrEmpty(mensagem))
                {
                    //*** Monta o objeto para poder atualizar ou inserir
                    var tipoRestricao = new Raizen.SICCadastro.Rebate.Model.TipoRestricao
                    {
                        DsTipoRestricao = txtDsTipoRestricao.Text,
                    };

                    Factory.CreateFactoryInstance().CreateInstance<ITipoRestricaoBLO>("TipoRestricaoBLO").Incluir(tipoRestricao);

                    ShowAlertMessage(Mensagens.MsgTipoRestricaoSucesso);

                    Limpar(); 
                    CarregarListaTipoRestricao();
                }
                else
                {
                    ShowAlertMessage(Mensagens.MsgTipoRestricaoVazio);
                }
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                ShowAlertMessage(Mensagens.MsgErroTipoRestricao);
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            this.NrSeqTipoRestricao = int.Parse(((ImageButton)sender).CommandArgument);
            ClientScript.RegisterStartupScript(Page.GetType(), "confirmacao", "Deletar();", true);
        }

        protected void btnSimExcluir_OnClick(object sender, EventArgs e)
        {
            try
            {
                Factory.CreateFactoryInstance().CreateInstance<ITipoRestricaoBLO>("TipoRestricaoBLO").Excluir(new Raizen.SICCadastro.Rebate.Model.TipoRestricao() 
                {
                    NrSeqTipoRestricao = this.NrSeqTipoRestricao
                });

                ShowAlertMessage(Mensagens.MsgTipoRestricaoExcluirSucesso);

                //*** 
                this.NrSeqTipoRestricao = null;
                CarregarListaTipoRestricao();
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                if (ex.ToString().Contains("FK_IBM_TIPO_RESTRICAO_SIC_TIPO_RESTRICAO_SIC"))
                    ShowAlertMessage(Mensagens.MsgErroTipoRestricaoEmUso);
                else
                    ShowAlertMessage(Mensagens.MsgErroTipoRestricao);
            }
        }

       

        #endregion Eventos de componetes

        #region Controle Paginação

        /// <summary>
        /// Paginação
        /// </summary>
        private void Paginacao(string command)
        {
            int iCurrentIndex = grvTipoRestricao.PageIndex;
            switch (command.ToLower())
            {
                case "primeiro":
                    grvTipoRestricao.PageIndex = 0;
                    break;
                case "anterior":
                    if (grvTipoRestricao.PageIndex != 0)
                        grvTipoRestricao.PageIndex = iCurrentIndex - 1;
                    break;
                case "proximo":
                    grvTipoRestricao.PageIndex = iCurrentIndex + 1;
                    break;
                case "ultimo":
                    grvTipoRestricao.PageIndex = grvTipoRestricao.PageCount;
                    break;
                case "ddcurrentpage":
                    GridViewRow row = grvTipoRestricao.BottomPagerRow;
                    DropDownList ddCurrentPage = (DropDownList)row.Cells[0].FindControl("ddCurrentPage");
                    grvTipoRestricao.PageIndex = ddCurrentPage.SelectedIndex;
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
    }
}
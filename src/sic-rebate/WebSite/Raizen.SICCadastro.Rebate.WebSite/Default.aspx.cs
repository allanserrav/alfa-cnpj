using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuscarAvisos(int.Parse(ddlFiltrar.SelectedItem.Value));
            }
        }

        protected void btnExcluirSelecionados_Click(object sender, EventArgs e)
        {
            BuscarIdsAvisosSelecionados().ForEach(
                x => this.ExcluirAviso(x));
        }

        protected List<int> BuscarIdsAvisosSelecionados()
        {
            List<int> ids = null;
            CheckBox chkTemp = null;
            try
            {
                ids = new List<int>();
                foreach (RepeaterItem item in rptAvisos.Items)
                {
                    if (item.ItemType != ListItemType.Footer || item.ItemType != ListItemType.Header)
                    {
                        chkTemp = (CheckBox)item.FindControl("chkExcluir");
                        if (chkTemp != null && chkTemp.Checked)
                        {
                            ids.Add(int.Parse(((Label)item.FindControl("lblNrSeqAvisoSic")).Text));
                        }
                    }
                }
                return ids;
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Error("Erro ao buscar IdsAvisosSelecionados", ex);
                throw;
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            BuscarAvisos(int.Parse(ddlFiltrar.SelectedItem.Value));
        }

        protected void imgExcluir_Click(object sender, EventArgs e)
        {
            this.ExcluirAviso(int.Parse(((ImageButton)sender).CommandArgument.ToString()));
        }

        protected void BuscarAvisos(int? tipoAviso = null)
        {
            int NrSeqTipoCliente = 0;
            ViewState["Avisos"] = null;
            NrSeqTipoCliente = Factory.CreateFactoryInstance().CreateInstance<ITipoclienteSicBLO>("TipoclienteSicBLO").Selecionar().ToList().Find(x => x.NmTipoclienteSic.ToUpper().Replace(" ", "").Contains("REBATE")).NrSeqTipoclienteSic.Value;
            ViewState["Avisos"] = rptAvisos.DataSource = (List<Model.AvisoSic>)Factory.CreateFactoryInstance().CreateInstance<IAvisoSicBLO>("AvisoSicBLO").Selecionar(new Model.AvisoSic
            {
                NrSeqTipoclienteSic = NrSeqTipoCliente,
                StAvisoSic = true,
                NrSeqTipoAvisoSic = tipoAviso
            }, 20, null);
            rptAvisos.DataBind();
            if (rptAvisos.Items.Count <= 0)
            {
                rptAvisos.Visible = btnExcluirSelecionados.Visible = false;
                lblRetorno.Text = "Não existem avisos desse tipo na base";
            }
            else
            {
                rptAvisos.Visible = btnExcluirSelecionados.Visible = true;
                lblRetorno.Text = "";
            }
        }

        protected void ExcluirAviso(int NrSeqAvisoSic)
        {
            Model.AvisoSic aviso = ((List<Model.AvisoSic>)ViewState["Avisos"]).Find(x => x.NrSeqAvisoSic == NrSeqAvisoSic);
            if (aviso != null)

                Factory.CreateFactoryInstance().CreateInstance<IAvisoSicBLO>("AvisoSicBLO").Atualizar(new Model.AvisoSic
                {
                    NrSeqAvisoSic = NrSeqAvisoSic,
                    NmUsuarioexSic = Request.Cookies["CookieLogon"].Value.ToString() == string.Empty ? "SICCadastro" : Request.Cookies["CookieLogon"].Value.ToString(),
                    StAvisoSic = false,
                    DtExclusaoavisoSic = DateTime.Now,
                    NrSeqTipoclienteSic = Factory.CreateFactoryInstance().CreateInstance<ITipoclienteSicBLO>("TipoclienteSicBLO").Selecionar().ToList().Find(x => x.NmTipoclienteSic.ToUpper().Replace(" ", "").Contains("REBATE")).NrSeqTipoclienteSic.Value,
                    DsAvisoSic = aviso.DsAvisoSic,
                    NrIbmAvisoSic = aviso.NrIbmAvisoSic,
                    NrSeqTipoAvisoSic = aviso.NrSeqTipoAvisoSic,
                    DtInclusaoavisoSic = aviso.DtInclusaoavisoSic
                });
            BuscarAvisos(int.Parse(ddlFiltrar.SelectedItem.Value));
        }
    }
}
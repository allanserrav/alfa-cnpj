using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    /// <summary>
    /// Página para lançamento de acerto de bonificações
    /// </summary>
    public partial class CalculoAcerto : System.Web.UI.Page
    {
        /// <summary>
        /// Instancia da BLO
        /// </summary>
        private readonly IAcertoCalculoRebateSicBLO acertoCalculoRebateSicBLO = null;

        /// <summary>
        /// Construtord
        /// </summary>
        public CalculoAcerto()
        {
            acertoCalculoRebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IAcertoCalculoRebateSicBLO>("AcertoCalculoRebateSicBLO");
        }

        /// <summary>
        /// Page_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// btnPesquisar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteSic cli = new ClienteSic();
                cli.NrIbmClienteSic = txtIBM.Text;
                var list = acertoCalculoRebateSicBLO.PesquisarPorIBM(cli);
               
                pnlResultado.Visible = true;
                lblNome.Text = cli.NmRazsociallojaFranquiaSic;
                lblNome.Visible = true;

                //RSIC-260 - Critério4 
                list = list.Where(t => t.VlSaldoAcertoBonificacaoSic != 0).ToList();
                if (list.Count == 0)
                    throw new Exception("Após o cálculo nenhum acerto com saldo diferente de zero foi encontrado.");

                rptBonifica.DataSource = list;
                rptBonifica.DataBind();
            }
            catch(Exception ex) 
            {
                string msg = ex.Message.Replace('\n', ' ');
                pnlResultado.Visible = false;
                lblNome.Visible = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "btnPesquisaReturnMsg", String.Format("ShowMessageData('{0}');", msg), true);
            }
        }

        /// <summary>
        /// btnLancarAcertos_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLancarAcertos_Click(object sender, EventArgs e)
        {
            List<AcertoCalculoRebateSic> list = new List<AcertoCalculoRebateSic>();
            foreach (var item in rptBonifica.Items)
            {
                var hdnNrSeqRebateSic = (HiddenField)((RepeaterItem)item).FindControl("hdnNrSeqRebateSic");
                var hdnDtPeriodoSic = (HiddenField)((RepeaterItem)item).FindControl("hdnDtPeriodoSic");
                var hdnDtIniciocalculoRebateSic = (HiddenField)((RepeaterItem)item).FindControl("hdnDtIniciocalculoRebateSic");
                var hdnDtFimcalculoRebateSic = (HiddenField)((RepeaterItem)item).FindControl("hdnDtFimcalculoRebateSic");
                var hdnVlBonificacaoTotalSic = (HiddenField)((RepeaterItem)item).FindControl("hdnVlBonificacaoTotalSic");
                var hdnVlAcertoBonificacaoTotalSic = (HiddenField)((RepeaterItem)item).FindControl("hdnVlAcertoBonificacaoTotalSic");
                var hdnVlSaldoAcertoBonificacaoSic = (HiddenField)((RepeaterItem)item).FindControl("hdnVlSaldoAcertoBonificacaoSic");

                var ckb = (CheckBox)((RepeaterItem)item).FindControl("ckb");
                if (ckb.Checked)
                {
                    AcertoCalculoRebateSic obj = new AcertoCalculoRebateSic();
                    obj.NrSeqRebateSic = Int32.Parse(hdnNrSeqRebateSic.Value);
                    obj.DtPeriodoSic = DateTime.Parse(hdnDtPeriodoSic.Value);
                    obj.DtIniciocalculoRebateSic = DateTime.Parse(hdnDtIniciocalculoRebateSic.Value);
                    obj.DtFimcalculoRebateSic = DateTime.Parse(hdnDtFimcalculoRebateSic.Value);
                    obj.VlBonificacaoTotalSic = Decimal.Parse(hdnVlBonificacaoTotalSic.Value);
                    obj.VlAcertoBonificacaoTotalSic = Decimal.Parse(hdnVlAcertoBonificacaoTotalSic.Value);
                    obj.VlSaldoAcertoBonificacaoSic = Decimal.Parse(hdnVlSaldoAcertoBonificacaoSic.Value);
                    list.Add(obj);
                }                
            }

            string msg = "Nenhum registro selecionado.";            
            try
            {
                if (list.Count > 0)
                {
                    acertoCalculoRebateSicBLO.LancarAjustes(list);                    
                    pnlResultado.Visible = false;
                    lblNome.Visible = false;
                    txtIBM.Text = "";
                    msg = "Acertos enviados para o fluxo de aprovação.";
                }
            } 
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "btnPesquisaReturnMsg", String.Format("ShowMessageData('{0}');", msg), true);            
        }
    }
}
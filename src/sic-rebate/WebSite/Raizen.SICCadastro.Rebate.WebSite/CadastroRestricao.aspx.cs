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

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class CadastroRestricao : System.Web.UI.Page
    {

        #region Propriedades        

        private List<Model.TipoRestricao> ListaTipoRestricao
        {
            get
            {
                if (ViewState["ListaTipoRestricao"] == null)
                    ViewState["ListaTipoRestricao"] = new List<Model.TipoRestricao>();

                return ViewState["ListaTipoRestricao"] as List<Model.TipoRestricao>;
            }
            set
            {
                ViewState["ListaTipoRestricao"] = value;
            }
        }

        private Model.Restricao Restricao
        {
            get
            {
                if (ViewState["Restricao"] == null)
                {
                    ViewState["Restricao"] = new Model.Restricao()
                    {
                        //Restricao = new List<Model.Restricao>()
                    };
                }

                return ViewState["Restricao"] as Model.Restricao;
            }
            set
            {
                ViewState["Restricao"] = value;
            }
        }

        #endregion Propriedades

        #region Eventos da pagina

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idRestricao;
                int.TryParse(Request.QueryString["restricao_id"], out idRestricao);
                CarregarDados(idRestricao);
                CarregarTiposRestricoes();
                if (idRestricao > 0)
                    PopulaCanaisDistribuicaoPorEmpresaSelecionada(idRestricao);
            }
        }

        #endregion Eventos da pagina

        #region Metodos Privados

        private string ValidarCadastro()
        {
            string mensagem = string.Empty;

            if (txtIbm.Text == null || txtIbm.Text == "" || !chkTipoRestricao.Items.Cast<ListItem>().Any(item => item.Selected))
            {
                mensagem = Mensagens.MsgRestricaoVazio;
            }

            return mensagem;
        }

        private void CarregarDados(int idRestricao)
        {
            if (idRestricao <= 0)
            {
                return;
            }

            var restricaoBlo = Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO");

            var filtroRestricao = new Model.Restricao()
            {
                NrSeqRestricao = idRestricao
            };

            var restricao = restricaoBlo.SelecionarPrimeiro(filtroRestricao);
            Restricao = restricao;

           //ddlTipoGrupo.SelectedValue = restricao.NrSeqRestricao.ToString();
            txtIbm.Text = restricao.DsIbm;
            txtMotivo.Text = restricao.DsMotivo;
        }

        private void CarregarTiposRestricoes()
        {
            try
            {
                var tipoRestricaoBlo = Factory.CreateFactoryInstance().CreateInstance<ITipoRestricaoBLO>("TipoRestricaoBLO");
                this.ListaTipoRestricao = tipoRestricaoBlo.Selecionar().ToList();

                foreach (var c in ListaTipoRestricao)
                {
                    var listItem = new ListItem();
                    listItem.Text = string.Format("{0}", c.DsTipoRestricao);
                    listItem.Value = c.NrSeqTipoRestricao.ToString();
                    chkTipoRestricao.Items.Add(listItem);
                }

            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
            }
        }

        private IList<RestricaoTipoRestricao> GetTiposRestricoesPorRestricao(int restricaoId)
        {
            return Factory.CreateFactoryInstance()
                .CreateInstance<IRestricaoBLO>("RestricaoBLO")
                .SelecionarPorRestricaoId(restricaoId);
        }

        private void PopulaCanaisDistribuicaoPorEmpresaSelecionada(int idRestricao)
        {
            IList<RestricaoTipoRestricao> listaTiposRestricoes = Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").SelecionarPorRestricaoId(idRestricao).ToList();

            foreach (var item in listaTiposRestricoes)
            {
                this.chkTipoRestricao.Items.Cast<ListItem>()
                    .Where(x => x.Value == item.NrSeqTipoRestricao.ToString())
                    .ToList()
                    .ForEach(x => x.Selected = true);
            }
        }

        private void CadastrarTiposRestricoes(int nrSeqRestricao, string ibm)
        {            
            Mensagem msg = null;

            IList<RestricaoTipoRestricao> restricoesAtuais = Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").SelecionarPorRestricaoId(nrSeqRestricao).ToList();
            var todasRestricoes = Factory.CreateFactoryInstance().CreateInstance<ITipoRestricaoBLO>("TipoRestricaoBLO").Selecionar().ToList();

            IList<ListItem> itens = chkTipoRestricao.Items.Cast<ListItem>()
            .Where(tipos => tipos.Selected).ToList();

            try
            {

                Factory.CreateFactoryInstance()
                    .CreateInstance<IRestricaoBLO>("RestricaoBLO")
                    .ExcluirTiposRestricoes(Restricao);

                foreach (ListItem novoId in itens)
                {
                    
                        Factory.CreateFactoryInstance()
                            .CreateInstance<IRestricaoBLO>("RestricaoBLO")
                            .IncluirTiposRestricoes(
                                new Model.RestricaoTipoRestricao
                                {
                                    NrSeqTipoRestricao = null,
                                    NrSeqRestricao = nrSeqRestricao,
                                    NrSeqIbmTipoRestricao = Int32.Parse(novoId.Value)
                                }                            
                             );

                    IList<RestricaoTipoRestricao> existe = restricoesAtuais.Where(e => e.NrSeqTipoRestricao == Int32.Parse(novoId.Value)).ToList();
                    if (existe.Count == 0)
                    {
                        string descricao = "Inseriu a restrição(" + novoId.Text + ") para o IBM: " + ibm;
                        Factory.CreateFactoryInstance()
                        .CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO")
                        .IncluirLogDescricao("CadastroRestricao", "CadastrarTiposRestricoes", descricao, Util.Util.LoginUsuario());
                    }
                }

                foreach(RestricaoTipoRestricao res in restricoesAtuais)
                {
                    IList<ListItem> existeItem = itens.Where(e => Int32.Parse(e.Value) == res.NrSeqTipoRestricao).ToList();
                    if(existeItem.Count == 0)
                    {
                        var tipoRestr = todasRestricoes.Where(e => e.NrSeqTipoRestricao == res.NrSeqTipoRestricao).FirstOrDefault();
                        string descricao = "Excluiu a restrição(" + tipoRestr.DsTipoRestricao + ") para o IBM: " + ibm;
                        Factory.CreateFactoryInstance()
                        .CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO")
                        .IncluirLogDescricao("CadastroRestricao", "CadastrarTiposRestricoes", descricao, Util.Util.LoginUsuario());
                    }
                }

                msg = new Mensagem { Texto = "Dados cadastrados com sucesso", Tipo = TipoMensagem.Sucesso };

                LimparCampos();
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                msg = new Mensagem { Texto = "Erro ao associar canais de distribuição", Tipo = TipoMensagem.Erro };
            }
            finally
            {
                MessageBox.Show("Aviso", msg.Texto, TipoBotao.OK, "salvar"); 
            }
        }

        private void LimparCampos()
        {
            chkTipoRestricao.ClearSelection();
            txtIbm.Text = String.Empty;
            txtMotivo.Text = String.Empty;
        }

        #endregion

        #region Eventos de componetes

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string mensagem = string.Empty;

            try
            {
                mensagem = ValidarCadastro();
                if (string.IsNullOrEmpty(mensagem))
                {
                    Restricao.DsIbm = txtIbm.Text;
                    Restricao.DsMotivo = txtMotivo.Text;

                    if (Restricao.NrSeqRestricao > 0)
                    {
                        Model.Restricao filtroRestricao = new Model.Restricao();
                        filtroRestricao.DsIbm = Restricao.DsIbm;
                        var verificaSeExiste = Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").SelecionarPrimeiro(filtroRestricao);

                        if (verificaSeExiste != null && verificaSeExiste.DsIbm != null && verificaSeExiste.NrSeqRestricao != Restricao.NrSeqRestricao)
                            MessageBox.Show("Aviso", Mensagens.MsgErroRestricaoIBMExistente, TipoBotao.Erro, "voltar");
                        else
                        {
                            Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").Atualizar(Restricao);
                            string descricao = "Atualizou a restrição para o IBM: " + Restricao.DsIbm + ", Motivo: " + Restricao.DsMotivo + ", ID: " + Restricao.NrSeqRestricao;

                            Factory.CreateFactoryInstance()
                                .CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO")
                                .IncluirLogDescricao("CadastroRestricao", "CadastrarTiposRestricoes", descricao, Util.Util.LoginUsuario());

                            CadastrarTiposRestricoes(Restricao.NrSeqRestricao.Value, Restricao.DsIbm);

                            MessageBox.Show("Aviso", Mensagens.MsgRestricaoSucesso, TipoBotao.OK, "salvar");
                        }
                    }
                    else {

                        Model.Restricao filtroRestricao = new Model.Restricao();
                        filtroRestricao.DsIbm = Restricao.DsIbm;
                        var verificaSeExiste =  Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").SelecionarPrimeiro(filtroRestricao);
                        
                        if (verificaSeExiste != null && verificaSeExiste.DsIbm != null)
                            MessageBox.Show("Aviso", Mensagens.MsgErroRestricaoIBMExistente, TipoBotao.Erro, "voltar");
                        else
                        {
                            Factory.CreateFactoryInstance().CreateInstance<IRestricaoBLO>("RestricaoBLO").Incluir(Restricao);
                            string descricao = "Adicionou o tipo de restrição para o IBM: " + Restricao.DsIbm + ", Motivo: " + Restricao.DsMotivo + ", ID: " + Restricao.NrSeqRestricao;

                            Factory.CreateFactoryInstance()
                                .CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO")
                                .IncluirLogDescricao("CadastroRestricao", "CadastrarTiposRestricoes", descricao, Util.Util.LoginUsuario());
                            
                            CadastrarTiposRestricoes(Restricao.NrSeqRestricao.Value, Restricao.DsIbm);

                            MessageBox.Show("Aviso", Mensagens.MsgRestricaoSucesso, TipoBotao.OK, "salvar");
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Aviso", Mensagens.MsgRestricaoVazio, TipoBotao.Erro, "voltar");
                    //ShowAlertMessage(Mensagens.MsgTipoRestricaoVazio);
                }
            }
            catch (Exception ex)
            {
                COSAN.Framework.Util.LogError.Debug(ex.ToString());
                MessageBox.Show("Aviso", Mensagens.MsgErroRestricao, TipoBotao.Erro, "voltar");
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aviso", Mensagens.MsgBotaoVoltar, TipoBotao.SimNao, "voltar");
        }

        protected void MessageBox_Resultado(object sender, ResultadoMessageBoxEvent e)
        {
            if ((e.Ancora == "voltar" && e.TipoResultado == TipoResultado.Sim) ||
                (e.Ancora == "salvar" && e.TipoResultado == TipoResultado.Ok))
            {
                Response.Redirect("restricao.aspx");
            }
        }

        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        #endregion Eventos de componetes
    }
}
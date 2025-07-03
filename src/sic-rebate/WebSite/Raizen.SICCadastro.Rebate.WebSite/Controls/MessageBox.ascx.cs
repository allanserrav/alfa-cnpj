using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Model;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.WebSite.Controls
{
    public partial class MessageBox : System.Web.UI.UserControl
    {
        private string _script;
        #region Eventos

        /// <summary>
        /// Evento que retorna a ação do usuario com a tela de mensagem.
        /// </summary>
        public event ResultadoMessageBoxHandler Resultado;

        /// <summary>
        /// Metodo que fecha a messagem depois de alguma ação do usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageBox_OnResultado(object sender, ResultadoMessageBoxEvent e)
        {
            this.Visible = false;
        }

        /// <summary>
        /// Configura o controle para ser exibido
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!string.IsNullOrEmpty(_script))
            {

                //*** Configura o botoes
                switch (this.TipoBotao)
                {
                    case TipoBotao.OK:
                        this.btnOk.Visible = true;
                        this.btnNao.Visible = false;
                        this.btnSim.Visible = false;
                        this.btnCancelar.Visible = false;
                        //this.btnErro.Visible = false;
                        this.btnOk.Focus();
                        break;
                    case TipoBotao.OKCancelar:
                        this.btnOk.Visible = true;
                        this.btnNao.Visible = false;
                        this.btnSim.Visible = false;
                        this.btnCancelar.Visible = true;
                        //this.btnErro.Visible = false;
                        this.btnOk.Focus();
                        break;
                    case TipoBotao.SimNao:
                        this.btnOk.Visible = false;
                        this.btnNao.Visible = true;
                        this.btnSim.Visible = true;
                        this.btnCancelar.Visible = false;
                        //this.btnErro.Visible = false;
                        this.btnNao.Focus();
                        break;
                    case TipoBotao.Erro:
                        this.btnOk.Visible = true;
                        this.btnNao.Visible = false;
                        this.btnSim.Visible = false;
                        this.btnCancelar.Visible = false;
                        //this.btnErro.Visible = true;
                        this.btnOk.Focus();
                        break;
                    default:
                        this.btnOk.Visible = false;
                        this.btnNao.Visible = false;
                        this.btnSim.Visible = false;
                        this.btnCancelar.Visible = false;
                        break;
                }

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "MessageBox_Show", _script, true);
            
            }

            base.OnPreRender(e);
        }

        #endregion

        #region Construtor

        /// <summary>
        /// Caixa para apresentar messangens ao usuario.
        /// </summary>
        public MessageBox()
        {
            this.Width = 400;
            this.Height = 150;
            this.Visible = false;
            this.Resultado += new ResultadoMessageBoxHandler(MessageBox_OnResultado);
        }

        #endregion

        #region Propriedade

        /// <summary>
        /// Tipo dos botoes que serão exibidos na caixa de mensagem
        /// </summary>
        public TipoBotao TipoBotao { get; set; }

        /// <summary>
        /// Largura da caixa de mensagem
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Altura da caixa de mensagem
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Titulo da caixa de mensagem
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Texto que será exibido na caixa de mensagem
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Variavel para ser usada como uma ancora na utilização do controle
        /// o valor dessa variavel é retornada no evento Retorno para o programador poder saber de onde foi disparada a mensagem.
        /// </summary>
        public string Ancora
        {
            get
            {
                return ViewState[this.Request.Url.AbsolutePath + "MessageBox_Ancora"] as string;
            }
            set
            {
                ViewState[this.Request.Url.AbsolutePath + "MessageBox_Ancora"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object Referencia
        {
            get
            {
                return ViewState[this.Request.Url.AbsolutePath + "MessageBox_Referencia"];
            }
            set
            {
                ViewState[this.Request.Url.AbsolutePath + "MessageBox_Referencia"] = value;
            }
        }

        #endregion

        #region Eventos de controles

        /// <summary>
        /// Evento Click do botão OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOk_Click(object sender, EventArgs e)
        {
            this.OnResultado(new ResultadoMessageBoxEvent(TipoResultado.Ok, this.Ancora, this.Referencia));
        }

        /// <summary>
        /// Evento Click do botão Sim
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSim_Click(object sender, EventArgs e)
        {
            this.OnResultado(new ResultadoMessageBoxEvent(TipoResultado.Sim, this.Ancora, this.Referencia));
        }

        /// <summary>
        /// Evento Click do botão Não
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNao_Click(object sender, EventArgs e)
        {
            this.OnResultado(new ResultadoMessageBoxEvent(TipoResultado.Nao, this.Ancora, this.Referencia));
        }

        /// <summary>
        /// Evento Click do botão Cancelar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.OnResultado(new ResultadoMessageBoxEvent(TipoResultado.Cancelar, this.Ancora, this.Referencia));
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        public void ShowValidacao(IEnumerable<MensagemControleValidacao> listaValidacao)
        {
            ShowValidacao(listaValidacao, this.Width, this.Height);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        public void ShowValidacao(IEnumerable<MensagemControleValidacao> listaValidacao, int width, int height)
        {
            ShowValidacao(listaValidacao, width, height, null);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="listaValidacao">Lista de mensagens de validação</param>
        /// <param name="ancora">Variavel de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        public void ShowValidacao(IEnumerable<MensagemControleValidacao> listaValidacao, string ancora)
        {
            ShowValidacao(listaValidacao, this.Width, this.Height, ancora);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="listaValidacao">Lista de mensagens de validação</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        /// <param name="ancora">Variavel de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        public void ShowValidacao(IEnumerable<MensagemControleValidacao> listaValidacao, int width, int height, string ancora)
        {
            ShowValidacao(listaValidacao, width, height, ancora, true);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="listaValidacao">Lista de mensagens de validação</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        /// <param name="ancora">Variavel de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        /// <param name="exibirBotaoFechar">Defini de deve exibir o botão de fechar na modal</param>
        public void ShowValidacao(IEnumerable<MensagemControleValidacao> listaValidacao, int width, int height, string ancora, bool exibirBotaoFechar)
        {
            this.Titulo = "Validação";
            this.Texto = "Verificar os campos abaixo:";
            this.TipoBotao = TipoBotao.OK;
            this.Visible = true;
            this.Width = width;
            this.Height = height;
            this.Ancora = ancora;
            var listaJson = new JavaScriptSerializer().Serialize(listaValidacao);

            //*** monta o script para ser executado
            _script = string.Format("MessageBox_ShowLista('{0}','{1}',{2},{3},{4},{5});", 
                this.Titulo, 
                this.Texto, 
                this.Width, 
                this.Height, 
                exibirBotaoFechar.ToString().ToLower(), 
                listaJson);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="ex">Exeption do erro gerado</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        //public void Show(Exception ex, string texto)
        //{
        //    this.Show(ex, texto);
        //}

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="ex">Exeption do erro gerado</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="ancora">Varial de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        //public void Show(Exception ex, string texto, string ancora)
        //{
        //    Util.Util.UltimoErro = ex;
        //    this.Show("Erro", texto, TipoBotao.Erro, this.Width, this.Height, ancora);
        //}

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        public void Show(string titulo, string texto)
        {
            this.Show(titulo, texto, TipoBotao.OK, this.Width, this.Height, null);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao)
        {
            this.Show(titulo, texto, tipoBotao, this.Width, this.Height, null);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="ancora">Varial de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao, string ancora)
        {
            this.Show(titulo, texto, tipoBotao, this.Width, this.Height, ancora);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="ancora">Varial de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        /// <param name="referencia">Referencia de um objeto que queira guardar</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao, string ancora, object referencia)
        {
            this.Show(titulo, texto, tipoBotao, this.Width, this.Height, ancora, referencia, false);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao, int width, int height)
        {
            this.Show(titulo, texto, tipoBotao, width, height, null);
        }
        
        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        /// <param name="ancora">Variavel de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao, int width, int height, string ancora)
        {
            this.Show(titulo, texto, tipoBotao, width, height, ancora, null, false);
        }

        /// <summary>
        /// Metodo que exibe a caixa de mensagem.
        /// </summary>
        /// <param name="titulo">Titulo da caixa de mensagem</param>
        /// <param name="texto">Texto que será exibido na caixa de mensagem</param>
        /// <param name="tipoBotao">Tipo dos botões que serão exibidos na caixa de mensagem</param>
        /// <param name="width">Largura da caixa de mensagem</param>
        /// <param name="height">Altura da caixa de mensagem</param>
        /// <param name="ancora">Variavel de controle que é retornado no evento Retorno do controle, é usado para saber a origem da mensagem</param>
        /// <param name="referencia">Referencia de um objeto que queira guardar</param>
        public void Show(string titulo, string texto, TipoBotao tipoBotao, int width, int height, string ancora, object referencia, bool exibirBotaoFechar)
        {
            this.Titulo = titulo;
            this.Texto = texto.Replace("'", "").Replace(Environment.NewLine, "").Replace("\\", "\\\\");
            this.TipoBotao = tipoBotao;
            this.Width = width;
            this.Height = height;
            this.Ancora = ancora;
            this.Referencia = referencia;
            this.Visible = true;

            //*** monta o script para ser executado
            _script = string.Format("MessageBox_Show('{0}','{1}',{2},{3},{4});", 
                this.Titulo, 
                this.Texto, 
                this.Width, 
                this.Height, 
                exibirBotaoFechar.ToString().ToLower());
        }

        private void OnResultado(ResultadoMessageBoxEvent e)
        {
            if (this.Resultado != null)
            {
                this.Resultado(this, e);
            }
        }

        #endregion
    }
}
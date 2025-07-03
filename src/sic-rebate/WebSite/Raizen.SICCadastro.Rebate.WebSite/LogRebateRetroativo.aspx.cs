using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.BLL;
using COSAN.Framework.Factory;
using ClosedXML.Excel;
using System.IO;
using Raizen.SICCadastro.Rebate.WebSite.Msg;
using COSAN.Framework.Util;
using System.Web.UI;
using Raizen.SICCadastro.Rebate.WebSite.Controls;
using Raizen.SICCadastro.Rebate.Util;
using System.Text;
using Raizen.SICCadastro.Rebate.Util.Relatorio;

namespace Raizen.SICCadastro.Rebate.WebSite
{
    public partial class LogRebateRetroativo : System.Web.UI.Page
    {
        private ILogRebateRetroativoBLO logRebateBLL => Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoBLO>("LogRebateRetroativoBLO");
        private IRebateSicBLO rebateSicBLL => Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimparConsulta();
            }
        }

        private void LimparConsulta()
        {
            grvResultado.PageIndex = 0;
            txtIBM.Text = string.Empty;
            txtContrato.Text = string.Empty;
            txtDataInicio.Text = string.Empty;
            txtDataFim.Text = string.Empty;

            grvResultado.DataSource = new List<RebateLogWithDetailsResponse>();
            grvResultado.DataBind();
        }

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
            Buscar();
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

        private void Buscar()
        {
            try
            {
                var ibm = txtIBM.Text.Trim();
                var contrato = txtContrato.Text.Trim();
                DateTime? dataInicio = string.IsNullOrEmpty(txtDataInicio.Text) ? null : (DateTime?)DateTime.Parse(txtDataInicio.Text);
                DateTime? dataFim = string.IsNullOrEmpty(txtDataFim.Text) ? null : (DateTime?)DateTime.Parse(txtDataFim.Text);

                if (dataInicio.HasValue && dataFim.HasValue && dataFim.Value.Subtract(dataInicio.Value).Days < 0)
                {
                    ShowAlertMessage("Data Fim não pode ser menor que Data Início!");
                    return;
                }

                if (dataInicio.HasValue && dataFim.HasValue && dataFim.Value.Subtract(dataInicio.Value).Days > 365)
                {
                    // Exibe mensagem de erro sobre o período exceder 12 meses
                    ShowAlertMessage("Periodo dos logs não pode exceder 12 meses!");
                    return;
                }

                if (dataFim.HasValue)
                    dataFim = new DateTime(dataFim.Value.Year, dataFim.Value.Month, dataFim.Value.Day, 23, 59, 59);


                if (dataInicio == null && dataFim == null)
                {
                    dataInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 00).AddYears(-1);
                    dataFim = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                }
                else
                if (dataFim == null)
                {
                    dataFim =  new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
                }
                else
                if (dataInicio == null)
                {
                    dataInicio = new DateTime(dataFim.Value.Year, dataFim.Value.Month, dataFim.Value.Day, 0, 0, 0).AddYears(-1);
                }

                LogRebateRetroativoFiltro filtroLog = new LogRebateRetroativoFiltro();
                filtroLog.DtInicio = dataInicio;
                filtroLog.DtFim = dataFim;
                filtroLog.DsIbm = ibm;
                filtroLog.NumContrato = contrato;

                var logsAux = logRebateBLL.SelecionarLog(filtroLog, 0, null);
                var ids = logsAux.Select(e => e.NrSeqClienteSic).Distinct().ToList();

                IList<Model.LogRebateRetroativo> rebates = new List<Model.LogRebateRetroativo>();
                if (ids.Count > 0)
                {
                    string join = string.Join(",", ids);
                    rebates = logRebateBLL.SelecionarContratosRebates(filtroLog, join, 0, null);
                    
                    IList<Model.LogRebateRetroativo> rebatesGuardaChuva = logRebateBLL.SelecionarContratosRebatesGuardaChuva(filtroLog, join, 0, null);
                    if(rebatesGuardaChuva.Count > 0)
                        rebates = rebates.Union(rebatesGuardaChuva).ToList();
                
                    foreach(Model.LogRebateRetroativo ret in logsAux)
                    {
                        if (rebates.Where(e => e.NrSeqLogRebateRetroativo == ret.NrSeqLogRebateRetroativo).Count() == 0)
                        {
                            var numeroContratoGC = logRebateBLL.SelecionarNumeroContratoGuardaChuva(ret.NrSeqClienteSic, 0, null);
                            if (numeroContratoGC != null)
                                ret.NrContrato = numeroContratoGC;

                            rebates.Add(ret);
                        }
                    }
                }

                var result = rebates.Select(log =>
                {
                    return new LogRebateRetroativoViewModel
                    {
                        Timestamp = log.DtLogDatetimeRebateRetroativo.HasValue
                            ? (DateTime?)log.DtLogDatetimeRebateRetroativo.Value
                            : null,
                        User = log.CdLogUsuarioRebateRetroativo,
                        Step = log.XmlLogDetalheRebateRetroativo,
                        NrSeqRebateSic = log.NrSeqEntidadeRebateRetroativo,
                        NrIbmRebateSic = log.DsIbm,
                        NrContrato = log.NrContrato
                    };
                }).ToList();

                // Tratar resuldado do XmlLogDetalheRebateRetroativo
                var resultLogHtml = new List<LogRebateRetroativoViewModel>();
                foreach (var log in result)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(log.Step))
                        {
                            continue;
                        }
                        var step = log.Step
                            .Replace("<LogIniciado>","")
                            .Replace("</LogIniciado>", "\n")
                            .Replace("<Etapa>", "")
                            .Replace("</Etapa>", "\n")
                            .Replace("<Descricao>", "")
                            .Replace("</Descricao>", "")
                            .Replace("<Inicio>", "")
                            .Replace("</Inicio>", "")
                            .Replace("<Fim>", "")
                            .Replace("</Fim>", "")
                            .Replace("<Erro>", "")
                            .Replace("<TotalExecucao>", "")
                            .Replace("</TotalExecucao>", "\n")
                            .Replace("</Erro>", "\n")
                            .Replace("</br>", "\n\r");
                        //var step = log.Step;
                        if (step.Length > 1)
                        {
                            var logHtml = new LogRebateRetroativoViewModel
                            {
                                Timestamp = log.Timestamp,
                                User = log.User,
                                Step = step,
                                NrSeqRebateSic = log.NrSeqRebateSic,
                                NrIbmRebateSic = log.NrIbmRebateSic,
                                NrContrato = log.NrContrato
                            };
                            resultLogHtml.Add(logHtml);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ShowAlertMessage(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                        // Loga erro
                        LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                    }
                }

                resultLogHtml = resultLogHtml.OrderByDescending(e => e.Timestamp).ToList();
                grvResultado.DataSource = resultLogHtml;
                grvResultado.DataBind();
            }
            catch (Exception ex)
            {
                ShowAlertMessage(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                // Loga erro
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
            }
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparConsulta();
        }


        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            Buscar();
        }


        private string CriarTabela(IList<LogRebateRetroativoViewModel> lstLogs)
        {
            string styleTable = "min-width: 100%; border: 0px; ";
            string styleTR = "height: 25px; ";
            string styleTH = "width: {0}; border-bottom: 1px solid #961A8D; background-color: #F8F2F7; height: 35px; color: #922980; ";
            string styleTD = "padding: 10px; width: {0}; ";

            StringBuilder linhas = new StringBuilder();

            //CABEÇALHO
            StringBuilder cabecalho = new StringBuilder();
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "120px"), "Data e Hora"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "70px"), "Usuário"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "800px"), "Etapa"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "70px"), "Número Rebate"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "70px"), "IBM"));
            cabecalho.AppendLine(string.Format(TabelaHTML.TH, string.Format(styleTH, "70px"), "Contrato"));
            linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, cabecalho.ToString()));

            foreach (LogRebateRetroativoViewModel item in lstLogs)
            {
                StringBuilder colunas = new StringBuilder();
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.Timestamp));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.User));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.Step));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.NrSeqRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.NrIbmRebateSic));
                colunas.AppendLine(string.Format(TabelaHTML.TD, string.Format(styleTD, "180px"), string.Empty, item.NrContrato));

                linhas.AppendLine(string.Format(TabelaHTML.TR, styleTR, colunas.ToString()));
            }


            string tabela = string.Format(TabelaHTML.Table, styleTable, linhas.ToString());
            return tabela;
        }

        private string ExportarResultado(IList<LogRebateRetroativoViewModel> lstLogs)
        {
            return CriarTabela(lstLogs);
        }

        protected void btnGerarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
               
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                Response.Charset = string.Empty;
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}.xlsx", "LogRebateRetroativo" + DateTime.Now.ToString("ddMMyyyy-HHmmss")));

                if (grvResultado.DataSource == null)
                {
                    Buscar();                    
                }

                var listaLogs = grvResultado.DataSource as List<LogRebateRetroativoViewModel>;

                Response.Write(ExportarResultado(listaLogs));

            }
            catch (Exception ex)
            {
                LogError.Debug(string.Format("Erro {0}: {1}", ex.Message, ex.StackTrace));
                ShowAlertMessage(Mensagens.ErroGenerico);
            }

            //Encerra
            Response.End();
        }

        /// <summary>
        /// Exibe erros
        /// </summary>
        /// <param name="error"></param>
        private void ShowAlertMessage(string error)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), string.Concat("err_msg", DateTime.Now.Ticks), string.Format("javascript:ShowMessage('{0}');", error), true);
        }

        protected void grvResultado_DataBound(object sender, EventArgs e)
        {
            GridViewRow gridRodape = grvResultado.BottomPagerRow;
            if (gridRodape == null) return;

            var paginacao = (ucPaginacaoRodape)gridRodape.Cells[0].FindControl("ucPaginacaoRodape");
            paginacao.Carregar(grvResultado.PageCount, grvResultado.PageIndex);
        }

        protected void ucPaginacaoRodape_Comando(TipoComandoPaginacao tipoComandoPaginacao, int paginaAtual)
        {
            grvResultado.PageIndex = paginaAtual;
            Buscar();
        }

    }




}

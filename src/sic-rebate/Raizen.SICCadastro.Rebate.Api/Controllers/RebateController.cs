using COSAN.Framework.Factory;
using COSAN.Framework.Util;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Raizen.SICCadastro.Rebate.Api.Models.Response;
using Raizen.SICCadastro.Rebate.BLL;
using Raizen.SICCadastro.Rebate.Model;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Raizen.SICCadastro.Rebate.Api.Controllers
{
    public class RebateController : ApiController
    {
        /// <summary>
        /// Obtém os dados de rebate por IBM.
        /// </summary>
        /// <param name="ibm">Número do ibm do cliente.</param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Server Error</response>
        [HttpGet]
        [Route("api/v1/rebates/{ibm}")]
        [SwaggerOperation("Get")]
        [SwaggerResponse(statusCode: 200, type: typeof(RebateResponse), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Server Error")]
        public virtual IHttpActionResult Get([FromUri][Required]string ibm)
        {
            try
            {
                var rebate = Factory
                    .CreateFactoryInstance()
                    .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                    .Selecionar(ibm);

                if (rebate != null)
                {
                    var faixas = Factory
                        .CreateFactoryInstance()
                        .CreateInstance<IFaixarebateSicBLO>("FaixarebateSicBLO")
                        .Selecionar(rebate.NrSeqRebateSic.Value);

                    var model = new RebateResponse(rebate, faixas);
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro {ex.Message}: {ex.StackTrace}");
                return InternalServerError();
            }
        }

        /// <summary>
        /// Verifica existência de rebate de um específico IBM.
        /// </summary>
        /// <param name="ibm">Número do ibm do cliente.</param>
        /// <response code="200">Success - Existe Rebate</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found - Não existe Rebate</response>
        /// <response code="500">Server Error</response>
        [HttpHead]
        [Route("api/v1/rebates/{ibm}")]
        [SwaggerOperation("Head")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found - Não existe Rebate")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Server Error")]
        public virtual IHttpActionResult Head([FromUri][Required]string ibm)
        {
            try
            {
                var rebate = Factory.CreateFactoryInstance()
                    .CreateInstance<IRebateSicBLO>("RebateSicBLO")
                    .SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibm });

                if (rebate.NrSeqRebateSic > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro {ex.Message}: {ex.StackTrace}");
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("api/v1/rebates/CalcularRetroativo/{id}")]
        [SwaggerOperation("CalcularRetroativo")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found - Não existe Rebate")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Server Error")]
        public virtual IHttpActionResult CalcularRetroativo([FromUri][Required]int id)
        {
            var facto = Factory.CreateFactoryInstance();
            try
            {
                facto.CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO")
                    .CalcularRetroativo(new RebateSic() { NrSeqRebateSic = id }, string.Empty, "Sistema");

                if (id > 0)
                {
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro {ex.Message}: {ex.StackTrace}");
                facto.CreateInstance<ILogIntegracaoSicBLO>("LogIntegracaoSicBLO").IncluirLogDescricao("CalcularRetroativo API", "Erro: ", ex.Message, "Sistema");
                return Ok(false);
            }
        }

        [HttpGet]
        [Route("api/v1/rebates/logs")]
        [SwaggerOperation("GetRebateLogs")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<RebateLogResponse>), description: "Logs retrieved successfully.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Logs not found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error.")]
        public virtual IHttpActionResult GetRebateLogs(
                [FromUri][Required] string ibm = null,
                [FromUri][Required] string contrato = null,
                [FromUri][Required] DateTime? dataInicio = null,
                [FromUri][Required] DateTime? dataFim = null)
        {
            try
            {
                // Validação dos parâmetros
                if (!dataInicio.HasValue || !dataFim.HasValue || dataFim.Value.Subtract(dataInicio.Value).Days > 365)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new ErrorResponse
                    {
                        Message = "O período de busca não pode exceder 12 meses.",
                        Details = "Verifique as datas fornecidas."
                    });
                }

                var logRebateBLL = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoBLO>("LogRebateRetroativoBLO");

                var rebatesSic = new List<RebateSic>();
                try
                {
                    
                    // Verifica se o IBM é válido
                    if (ibm != null)
                    {
                        // Recuperar Rebate
                        var rebateBLL = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
                        var rebs = rebateBLL.Selecionar(new RebateSic() { NrIbmRebateSic = ibm });
                        if (rebs != null & rebs.Any())
                        {
                            rebatesSic = rebs.ToList();
                        }
                    }
                    if (rebatesSic == null || !rebatesSic.Any())
                    {

                        if (contrato != null)
                        {
                            // Recuperar Rebate
                            var rebateBLL = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
                            var rebs = rebateBLL.Selecionar(new RebateSic() { NrSeqRebateSic = int.Parse(contrato) });
                            if (rebs != null & rebs.Any())
                            {
                                rebatesSic = rebs.ToList();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError.Debug($"Erro ao buscar logs: {ex.Message}: {ex.StackTrace}");
                    return NotFound();
                }

                if(rebatesSic == null || !rebatesSic.Any())
                {
                    return NotFound();
                }

                // Lista de NrSeqEntidadeRebateRetroativo
                var nrSeqEntidadeRebateRetroativo = rebatesSic.Select(x => x.NrSeqRebateSic?? 0).ToList();

                // Configura o filtro
                var filtro = new LogRebateRetroativo
                {
                    CdLogUsuarioRebateRetroativo = ibm,
                    NrSeqEntidadeRebateRetroativo = string.IsNullOrEmpty(contrato) ? (int)0 : int.Parse(contrato),
                    DtLogDatetimeRebateRetroativo = dataInicio
                };

                // Busca os logs com base no filtro
                var logs = logRebateBLL.Selecionar()
                                       .Where(log => nrSeqEntidadeRebateRetroativo.Contains(log.NrSeqEntidadeRebateRetroativo))
                                       .Where(log => log.DtLogDatetimeRebateRetroativo >= dataInicio && log.DtLogDatetimeRebateRetroativo <= dataFim)
                                       .OrderByDescending(log => log.DtLogDatetimeRebateRetroativo)
                                       .ToList();

                if (logs == null || logs.Count == 0)
                {
                    return NotFound();
                }

                // Monta a resposta
                var response = logs.Select(log => new RebateLogResponse
                {
                    Timestamp = log.DtLogDatetimeRebateRetroativo,
                    User = log.CdLogUsuarioRebateRetroativo,
                    Details = log.XmlLogDetalheRebateRetroativo
                });


                return Ok(response);
            }
            catch (Exception ex)
            {
                // Loga o erro
                LogError.Debug($"Erro ao buscar logs: {ex.Message}: {ex.StackTrace}");

                // Retorna o erro como uma resposta com o código 500
                return Content(System.Net.HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = "Ocorreu um erro inesperado.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("api/v1/rebates/logs/export")]
        [SwaggerOperation("ExportRebateLogs")]
        [SwaggerResponse(statusCode: 200, description: "File generated successfully.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error.")]
        public virtual IHttpActionResult ExportRebateLogs(
            [FromUri][Required] string ibm = null,
            [FromUri][Required] string contrato = null,
            [FromUri][Required] DateTime? dataInicio = null,
            [FromUri][Required] DateTime? dataFim = null)
        {
            try
            {
                // Reutiliza o método de busca
                var logsResponse = GetRebateLogs(ibm, contrato, dataInicio, dataFim) as 
                    OkNegotiatedContentResult<IEnumerable<RebateLogResponse>>;
                if (logsResponse == null || logsResponse.Content == null || !logsResponse.Content.Any())
                {
                    return NotFound();
                }

                var logs = logsResponse.Content;

                // Gera o Excel
                var excelBytes = GenerateExcel(logs);

                // Retorna o arquivo Excel
                var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(excelBytes)
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "RebateLogs.xlsx"
                };
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                return ResponseMessage(result);
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro ao exportar logs: {ex.Message}: {ex.StackTrace}");
                return Content(System.Net.HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = "Ocorreu um erro ao gerar o arquivo.",
                    Details = ex.Message
                });
            }
        }

        private byte[] GenerateExcel(IEnumerable<RebateLogResponse> logs)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Rebate Logs");

                // Cabeçalho
                worksheet.Cell(1, 1).Value = "Data e Hora";
                worksheet.Cell(1, 2).Value = "Usuário";
                worksheet.Cell(1, 3).Value = "Detalhes";

                var row = 2;
                foreach (var log in logs)
                {
                    worksheet.Cell(row, 1).Value = log.Timestamp;
                    worksheet.Cell(row, 2).Value = log.User;
                    worksheet.Cell(row, 3).Value = log.Details;
                    row++;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }

        [HttpGet]
        [Route("api/v1/rebates/logs/rebate/{nrSeqLogRebateRetroativo}")]
        [SwaggerOperation("GetRebateLogWithDetails")]
        [SwaggerResponse(statusCode: 200, type: typeof(RebateLogWithDetailsResponse), description: "Log and rebate details retrieved successfully.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Log or rebate not found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error.")]
        public virtual IHttpActionResult GetRebateLogWithDetails([FromUri][Required] int nrSeqLogRebateRetroativo)
        {
            try
            {
                // Busca o log pelo identificador
                var logRebateBLL = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoBLO>("LogRebateRetroativoBLO");
                var log = logRebateBLL.SelecionarPrimeiro(new LogRebateRetroativo { NrSeqLogRebateRetroativo = nrSeqLogRebateRetroativo });

                if (log == null)
                {
                    return NotFound();
                }

                // Busca os detalhes do rebate associados ao log
                var rebateBLL = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
                var rebate = rebateBLL.SelecionarPrimeiro(new RebateSic { NrSeqRebateSic = log.NrSeqEntidadeRebateRetroativo });

                if (rebate == null)
                {
                    return NotFound();
                }

                // Monta a resposta com os detalhes do log e do rebate
                var response = new RebateLogWithDetailsResponse
                {
                    Log = new LogDetail
                    {
                        NrSeqLogRebateRetroativo = log.NrSeqLogRebateRetroativo,
                        Timestamp = log.DtLogDatetimeRebateRetroativo,
                        Step = log.XmlLogDetalheRebateRetroativo,
                        User = log.CdLogUsuarioRebateRetroativo
                    },
                    Rebate = new RebateDetailIbm
                    {
                        NrSeqRebateSic = rebate.NrSeqRebateSic,
                        NrIbmRebateSic = rebate.NrIbmRebateSic,
                        DtInicioVigencia = rebate.DtIniciovigenciaRebateSic,
                        DtFimVigencia = rebate.DtFimvigenciaRebateSic,
                        VolumeContratado = rebate.VlVolumecontratadoRebateSic
                    }
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro ao buscar log e rebate: {ex.Message}: {ex.StackTrace}");

                return Content(System.Net.HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = "Ocorreu um erro inesperado ao buscar os dados.",
                    Details = ex.Message
                });
            }
        }




        [HttpGet]
        [Route("api/v1/rebates/logs/details")]
        [SwaggerOperation("GetRebateLogsWithDetails")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<RebateLogWithDetailsResponse>), description: "Logs and rebate details retrieved successfully.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request.")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Logs or rebates not found.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error.")]
        public virtual IHttpActionResult GetRebateLogsWithDetails(
                    [FromUri][Required] string ibm = null,
                    [FromUri][Required] string contrato = null,
                    [FromUri][Required] DateTime? dataInicio = null,
                    [FromUri][Required] DateTime? dataFim = null)
        {
            try
            {
                // Valida os parâmetros
                if (!dataInicio.HasValue || !dataFim.HasValue || dataFim.Value.Subtract(dataInicio.Value).Days > 365)
                {
                    return Content(System.Net.HttpStatusCode.BadRequest, new ErrorResponse
                    {
                        Message = "O período de busca não pode exceder 12 meses.",
                        Details = "Verifique as datas fornecidas."
                    });
                }

                // Recupera os rebates associados aos critérios fornecidos
                var rebateBLL = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
                var rebates = new List<RebateSic>();

                if (!string.IsNullOrEmpty(ibm))
                {
                    rebates = rebateBLL.Selecionar(new RebateSic { NrIbmRebateSic = ibm }).ToList();
                }
                else if (!string.IsNullOrEmpty(contrato))
                {
                    rebates = rebateBLL.Selecionar(new RebateSic { NrSeqRebateSic = int.Parse(contrato) }).ToList();
                }

                if (rebates == null || !rebates.Any())
                {
                    return NotFound();
                }

                var rebateIds = rebates.Select(r => r.NrSeqRebateSic.Value).ToList();

                // Recupera os logs associados aos rebates
                var logRebateBLL = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoBLO>("LogRebateRetroativoBLO");
                var logs = logRebateBLL.Selecionar()
                                       .Where(log => rebateIds.Contains(log.NrSeqEntidadeRebateRetroativo))
                                       .Where(log => log.DtLogDatetimeRebateRetroativo >= dataInicio && log.DtLogDatetimeRebateRetroativo <= dataFim)
                                       .ToList();

                if (logs == null || logs.Count == 0)
                {
                    return NotFound();
                }

                // Monta a resposta combinando logs e rebates
                var response = logs.Select(log =>
                {
                    var rebate = rebates.FirstOrDefault(r => r.NrSeqRebateSic == log.NrSeqEntidadeRebateRetroativo);
                    return new RebateLogWithDetailsResponse
                    {
                        Log = new LogDetail
                        {
                            NrSeqLogRebateRetroativo = log.NrSeqLogRebateRetroativo,
                            Timestamp = log.DtLogDatetimeRebateRetroativo,
                            Step = log.XmlLogDetalheRebateRetroativo,
                            User = log.CdLogUsuarioRebateRetroativo
                        },
                        Rebate = new RebateDetailIbm
                        {
                            NrSeqRebateSic = rebate?.NrSeqRebateSic,
                            NrIbmRebateSic = rebate?.NrIbmRebateSic,
                            DtInicioVigencia = rebate?.DtIniciovigenciaRebateSic,
                            DtFimVigencia = rebate?.DtFimvigenciaRebateSic,
                            VolumeContratado = rebate?.VlVolumecontratadoRebateSic
                        }
                    };
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Loga o erro
                LogError.Debug($"Erro ao buscar logs e detalhes do rebate: {ex.Message}: {ex.StackTrace}");

                return Content(System.Net.HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = "Ocorreu um erro inesperado.",
                    Details = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("api/v1/rebates/logs/details/export")]
        [SwaggerOperation("ExportRebateLogsWithDetails")]
        [SwaggerResponse(statusCode: 200, description: "File generated successfully.")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request.")]
        [SwaggerResponse(statusCode: 500, type: typeof(ErrorResponse), description: "Internal Server Error.")]
        public virtual IHttpActionResult ExportRebateLogsWithDetails(
            [FromUri][Required] string ibm = null,
            [FromUri][Required] string contrato = null,
            [FromUri][Required] DateTime? dataInicio = null,
            [FromUri][Required] DateTime? dataFim = null)
        {
            try
            {
                // Reutiliza o método de busca
                var logsResponse = GetRebateLogsWithDetails(ibm, contrato, dataInicio, dataFim) as OkNegotiatedContentResult<IEnumerable<RebateLogWithDetailsResponse>>;
                if (logsResponse == null || logsResponse.Content == null || !logsResponse.Content.Any())
                {
                    return NotFound();
                }

                var logs = logsResponse.Content;

                // Gera o Excel
                var excelBytes = GenerateExcelWithDetails(logs);

                // Retorna o arquivo Excel
                var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(excelBytes)
                };
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "RebateLogsWithDetails.xlsx"
                };
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                return ResponseMessage(result);
            }
            catch (Exception ex)
            {
                LogError.Debug($"Erro ao exportar logs com detalhes: {ex.Message}: {ex.StackTrace}");
                return Content(System.Net.HttpStatusCode.InternalServerError, new ErrorResponse
                {
                    Message = "Ocorreu um erro ao gerar o arquivo.",
                    Details = ex.Message
                });
            }
        }

        private byte[] GenerateExcelWithDetails(IEnumerable<RebateLogWithDetailsResponse> logs)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Rebate Logs with Details");

                // Cabeçalho
                worksheet.Cell(1, 1).Value = "Data e Hora";
                worksheet.Cell(1, 2).Value = "Usuário";
                worksheet.Cell(1, 3).Value = "Detalhes do Log";
                worksheet.Cell(1, 4).Value = "Número do Rebate";
                worksheet.Cell(1, 5).Value = "IBM";
                worksheet.Cell(1, 6).Value = "Início da Vigência";
                worksheet.Cell(1, 7).Value = "Fim da Vigência";
                worksheet.Cell(1, 8).Value = "Volume Contratado";

                var row = 2;
                foreach (var log in logs)
                {
                    worksheet.Cell(row, 1).Value = log.Log.Timestamp;
                    worksheet.Cell(row, 2).Value = log.Log.User;
                    worksheet.Cell(row, 3).Value = log.Log.Step;
                    worksheet.Cell(row, 4).Value = log.Rebate.NrSeqRebateSic;
                    worksheet.Cell(row, 5).Value = log.Rebate.NrIbmRebateSic;
                    worksheet.Cell(row, 6).Value = log.Rebate.DtInicioVigencia;
                    worksheet.Cell(row, 7).Value = log.Rebate.DtFimVigencia;
                    worksheet.Cell(row, 8).Value = log.Rebate.VolumeContratado;
                    row++;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }



    }

    public class RebateLogWithDetailsResponse
    {
        public LogDetail Log { get; set; }
        public RebateDetailIbm Rebate { get; set; }
    }

    public class LogDetailIbm
    {
        public int? NrSeqLogRebateRetroativo { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Step { get; set; }
        public string User { get; set; }
    }

    public class RebateDetailIbm
    {
        public int? NrSeqRebateSic { get; set; }
        public string NrIbmRebateSic { get; set; }
        public DateTime? DtInicioVigencia { get; set; }
        public DateTime? DtFimVigencia { get; set; }
        public decimal? VolumeContratado { get; set; }
    }


    public class RebateLogResponse
    {
        public DateTime? Timestamp { get; set; }
        public string User { get; set; }
        public string Details { get; set; }
    }


    public class LogResponse
    {
        public int NrSeqRebateSic { get; set; }
        public List<LogDetail> Logs { get; set; }
    }

    public class LogDetail
    {
        public int? NrSeqLogRebateRetroativo { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Step { get; set; }
        public string User { get; set; }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }


}

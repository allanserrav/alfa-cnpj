#region Cabeçalho do Arquivo
// <Summary>
// File Name            : LogRebateRetroativoDAO.cs
// Class Name           : LogRebateRetroativoDAO
// Author               : Raphael Simões Andrade
// Creation Date        : 17/12/2024
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//  Modified By             : 
//  Date of Modification    : 
//  Reason for modification : 
//  Modification Done       : 
//  Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Implementação da interface ILogRebateRetroativoDAO.
    /// </summary>
    internal class LogRebateRetroativoDAO : ILogRebateRetroativoDAO
    {
        #region Constantes
        private const string C_NrSeqLog = "NR_SEQ_LOG_REBATE_RETROATIVO";
        private const string C_NrSeqAplicacao = "NR_SEQ_APLICACAO_REBATE_RETROATIVO";
        private const string C_NrSeqModulo = "NR_SEQ_MODULO_REBATE_RETROATIVO";
        private const string C_NrSeqEntidade = "NR_SEQ_ENTIDADE_REBATE_RETROATIVO";
        private const string C_DtLogDatetime = "DT_LOG_DATETIME_REBATE_RETROATIVO";
        private const string C_CdLogUsuario = "CD_LOG_USUARIO_REBATE_RETROATIVO";
        private const string C_XmlLogDetalhe = "XML_LOG_DETALHE_REBATE_RETROATIVO";
        private const string C_DsIBM = "NR_IBM_REBATE_SIC";
        private const string C_NrContrato = "NR_SEQ_EC_CONTRATO_SIC";
        private const string C_NrSeqClienteSic = "NR_SEQ_CLIENTE_SIC";

        private const string orderByDefault = "DT_LOG_DATETIME_REBATE_RETROATIVO DESC";
        #endregion

        #region Queries
        private readonly string queryIncluir = "INSERT INTO TB_EC_LOG_SIC_REBATE_RETROATIVO (NR_SEQ_APLICACAO_REBATE_RETROATIVO, NR_SEQ_MODULO_REBATE_RETROATIVO, NR_SEQ_ENTIDADE_REBATE_RETROATIVO, DT_LOG_DATETIME_REBATE_RETROATIVO, CD_LOG_USUARIO_REBATE_RETROATIVO, XML_LOG_DETALHE_REBATE_RETROATIVO) VALUES (@Aplicacao, @Modulo, @Entidade, @DataLog, @Usuario, @XmlDetalhe); SELECT SCOPE_IDENTITY();";
        private readonly string queryAtualizar = "UPDATE TB_EC_LOG_SIC_REBATE_RETROATIVO SET NR_SEQ_APLICACAO_REBATE_RETROATIVO=@Aplicacao, NR_SEQ_MODULO_REBATE_RETROATIVO=@Modulo, NR_SEQ_ENTIDADE_REBATE_RETROATIVO=@Entidade, DT_LOG_DATETIME_REBATE_RETROATIVO=@DataLog, CD_LOG_USUARIO_REBATE_RETROATIVO=@Usuario, XML_LOG_DETALHE_REBATE_RETROATIVO=@XmlDetalhe WHERE NR_SEQ_LOG_REBATE_RETROATIVO=@LogId;";
        private readonly string queryExcluir = "DELETE FROM TB_EC_LOG_SIC_REBATE_RETROATIVO WHERE NR_SEQ_LOG_REBATE_RETROATIVO=@LogId;";
        
        private string querySelecionarLog = new StringBuilder().Append("SELECT DISTINCT {0} ")
            .Append(" RS.NR_IBM_REBATE_SIC, ")
            .Append(" LS.CD_LOG_USUARIO_REBATE_RETROATIVO, ")
            .Append(" LS.DT_LOG_DATETIME_REBATE_RETROATIVO, ")
            .Append(" LS.NR_SEQ_APLICACAO_REBATE_RETROATIVO, ")
            .Append(" LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO, ")
            .Append(" LS.NR_SEQ_LOG_REBATE_RETROATIVO, ")
            .Append(" LS.NR_SEQ_MODULO_REBATE_RETROATIVO, ")
            .Append(" LS.XML_LOG_DETALHE_REBATE_RETROATIVO, ")
            .Append(" CLI.NR_SEQ_CLIENTE_SIC ")
            .Append(" FROM TB_CLIENTE_SIC CLI ")
            .Append(" INNER JOIN TB_REBATE_SIC RS on RS.NR_SEQ_CLIENTE_SIC = cli.NR_SEQ_CLIENTE_SIC ")
            .Append(" INNER JOIN TB_EC_CLIENTE_X_CLIENTE_SIC CS on CS.NR_SEQ_CLIENTE_SIC = CLI.NR_SEQ_CLIENTE_SIC ")
            .Append(" INNER JOIN TB_EC_LOG_SIC_REBATE_RETROATIVO LS ON LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO = RS.NR_SEQ_REBATE_SIC ")
            .Append(" {1}")
            .Append(" ORDER BY {2}")
            .Append("").ToString();


        private string querySelecionarContratoGuardaChuva = new StringBuilder().Append("SELECT NR_SEQ_EC_CONTRATO_SIC ")
        .Append(" FROM TB_EC_CLIENTE_X_CLIENTE_SIC CC ")
        .Append(" INNER JOIN VIEW_EC_GUARDA_CHUVA_VALIDO_SIC GC ON GC.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC = CC.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC ")
        .Append(" {1}")
        .Append("").ToString();

        private string queryObterContratoRebate = new StringBuilder()
        .Append(" SELECT DISTINCT RS.NR_IBM_REBATE_SIC,  CO.NR_SEQ_EC_CONTRATO_SIC,  LS.CD_LOG_USUARIO_REBATE_RETROATIVO,")
        .Append(" LS.DT_LOG_DATETIME_REBATE_RETROATIVO,  LS.NR_SEQ_APLICACAO_REBATE_RETROATIVO,  LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO,")
        .Append(" LS.NR_SEQ_LOG_REBATE_RETROATIVO,  LS.NR_SEQ_MODULO_REBATE_RETROATIVO,  LS.XML_LOG_DETALHE_REBATE_RETROATIVO,")
        .Append(" CLI.NR_SEQ_CLIENTE_SIC")
        .Append(" FROM TB_CLIENTE_SIC CLI INNER JOIN TB_REBATE_SIC RS on RS.NR_SEQ_CLIENTE_SIC = cli.NR_SEQ_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_CLIENTE_X_CLIENTE_SIC CS on CS.NR_SEQ_CLIENTE_SIC = CLI.NR_SEQ_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_CONTRATO_SIC CO on CO.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC = CS.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_LOG_SIC_REBATE_RETROATIVO LS ON LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO = RS.NR_SEQ_REBATE_SIC")
        .Append(" INNER JOIN TB_EC_CONTRATO_TERMO_SIC CT on CO.NR_SEQ_EC_CONTRATO_SIC = CT.NR_SEQ_EC_CONTRATO_SIC")
        .Append(" INNER JOIN TB_EC_TERMO_SIC T on T.NR_SEQ_EC_TERMO_SIC = CT.NR_SEQ_EC_TERMO_SIC")
        .Append(" INNER JOIN TB_EC_TIPO_TERMO_SIC TT on TT.NR_SEQ_EC_TIPO_TERMO_SIC = T.NR_SEQ_EC_TIPO_TERMO_SIC")
        .Append(" INNER JOIN TB_EC_ATRIBUTO_REBATE_SIC AR on CT.NR_SEQ_EC_CONTRATO_TERMO_SIC = AR.NR_SEQ_EC_CONTRATO_TERMO_SIC")
        .Append(" {1}")
        .Append("").ToString();


        private string queryObterContratoRebateGuardaChuva = new StringBuilder()
        .Append(" SELECT DISTINCT RS.NR_IBM_REBATE_SIC,  CO.NR_SEQ_EC_CONTRATO_SIC,  LS.CD_LOG_USUARIO_REBATE_RETROATIVO,")
        .Append(" LS.DT_LOG_DATETIME_REBATE_RETROATIVO,  LS.NR_SEQ_APLICACAO_REBATE_RETROATIVO,  LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO,")  
        .Append(" LS.NR_SEQ_LOG_REBATE_RETROATIVO,  LS.NR_SEQ_MODULO_REBATE_RETROATIVO,  LS.XML_LOG_DETALHE_REBATE_RETROATIVO,")  
        .Append(" CLI.NR_SEQ_CLIENTE_SIC")
        .Append(" FROM TB_CLIENTE_SIC CLI  INNER JOIN TB_REBATE_SIC RS on RS.NR_SEQ_CLIENTE_SIC = cli.NR_SEQ_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_CLIENTE_X_CLIENTE_SIC CS on CS.NR_SEQ_CLIENTE_SIC = CLI.NR_SEQ_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_CONTRATO_SIC CO on CO.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC = CS.NR_SEQ_EC_CLIENTE_X_CLIENTE_SIC")
        .Append(" INNER JOIN TB_EC_LOG_SIC_REBATE_RETROATIVO LS ON LS.NR_SEQ_ENTIDADE_REBATE_RETROATIVO = RS.NR_SEQ_REBATE_SIC")
        .Append(" INNER JOIN TB_EC_CONTRATO_TERMO_SIC CT on CO.NR_SEQ_EC_CONTRATO_SIC = CT.NR_SEQ_EC_CONTRATO_SIC")
        .Append(" INNER JOIN TB_EC_ATRIBUTO_REBATE_GUARDA_CHUVA_SIC AR on CT.NR_SEQ_EC_CONTRATO_TERMO_SIC = AR.NR_SEQ_EC_CONTRATO_TERMO_SIC")
        .Append(" {1}")
        .Append("").ToString();



        #endregion

        #region Métodos Públicos


        public IList<LogRebateRetroativo> SelecionarContratosRebates(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem)
        {
            IList<LogRebateRetroativo> lista = new List<LogRebateRetroativo>();
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = new List<DbParameter>();

                if (!string.IsNullOrEmpty(ids))
                {
                    where += " (CLI.NR_SEQ_CLIENTE_SIC IN(" + ids + ") AND AR.NR_PERIODICIDADE_SIC in (1, 3) AND TT.ST_TIPO_ANEXO_EC_TIPO_TERMO_SIC = 1 AND 1 = 1) OR";
                    where += " (CLI.NR_SEQ_CLIENTE_SIC IN(" + ids + ") AND AR.NR_PERIODICIDADE_SIC in (1, 3) AND 0 = 1)";
                }

                if (string.IsNullOrEmpty(where))
                {
                    if (log.DtInicio.HasValue)
                        where += " DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }
                else
                {
                    if (log.DtInicio.HasValue)
                        where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }

                if (log.DtFim.HasValue)
                    where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO <='" + log.DtFim.Value.Year + "-" + log.DtFim.Value.Month.ToString("00") + "-" + log.DtFim.Value.Day.ToString("00") + " " + log.DtFim.Value.Hour.ToString("23") + ":" + log.DtFim.Value.Hour.ToString("59") + ":" + log.DtFim.Value.Hour.ToString("59") + "'";


                string query = string.Format(queryObterContratoRebate,
                    numeroLinhas > 0 ? "TOP " + numeroLinhas : "",
                    string.IsNullOrEmpty(where) ? "" : "WHERE " + where,
                    string.IsNullOrEmpty(ordem) ? orderByDefault : ordem);

                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        lista.Add(Preencher(reader));
                    }
                }
            }
            return lista;
        }

        public IList<LogRebateRetroativo> SelecionarContratosRebatesGuardaChuva(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem)
        {
            IList<LogRebateRetroativo> lista = new List<LogRebateRetroativo>();
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = new List<DbParameter>();

                if (!string.IsNullOrEmpty(ids))
                {
                    where += " CLI.NR_SEQ_CLIENTE_SIC IN(" + ids + ")";
                    where += " AND AR.NR_PERIODICIDADE_SIC in (1,3)";
                }

                if (string.IsNullOrEmpty(where))
                {
                    if (log.DtInicio.HasValue)
                        where += " DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }
                else
                {
                    if (log.DtInicio.HasValue)
                        where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }

                if (log.DtFim.HasValue)
                    where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO <='" + log.DtFim.Value.Year + "-" + log.DtFim.Value.Month.ToString("00") + "-" + log.DtFim.Value.Day.ToString("00") + " " + log.DtFim.Value.Hour.ToString("23") + ":" + log.DtFim.Value.Hour.ToString("59") + ":" + log.DtFim.Value.Hour.ToString("59") + "'";


                string query = string.Format(queryObterContratoRebateGuardaChuva,
                    numeroLinhas > 0 ? "TOP " + numeroLinhas : "",
                    string.IsNullOrEmpty(where) ? "" : "WHERE " + where,
                    string.IsNullOrEmpty(ordem) ? orderByDefault : ordem);

                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        lista.Add(Preencher(reader));
                    }
                }
            }
            return lista;
        }


        public int? SelecionarNumeroContratoGuardaChuva(int? nrSeqClienteSic, int numeroLinhas, string ordem)
        {
            int? contrato = null;
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                IList<DbParameter> parametros = new List<DbParameter>();
                string where = "";

                where += " CC.NR_SEQ_CLIENTE_SIC = " + nrSeqClienteSic;

                string query = string.Format(querySelecionarContratoGuardaChuva,
                numeroLinhas > 0 ? "TOP " + numeroLinhas : "",
                string.IsNullOrEmpty(where) ? "" : "WHERE " + where,
                string.IsNullOrEmpty(ordem) ? orderByDefault : ordem);

                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        contrato = reader.GetNullableInt32(C_NrContrato);
                    }
                }
            }
            return contrato;
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, int numeroLinhas, string ordem)
        {
            IList<LogRebateRetroativo> lista = new List<LogRebateRetroativo>();
            //using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            //{
            //    string where = "";
            //    IList<DbParameter> parametros = CriarParametrosSelecionar(dbManager, log, out where);
            //    string query = string.Format(querySelecionarLog,
            //        numeroLinhas > 0 ? "TOP " + numeroLinhas : "",
            //        string.IsNullOrEmpty(where) ? "" : "WHERE " + where,
            //        string.IsNullOrEmpty(ordem) ? orderByDefault : ordem);

            //    using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
            //    {
            //        while (reader.Read())
            //        {
            //            lista.Add(Preencher(reader));
            //        }
            //    }
            //}
            return lista;
        }

        public IList<LogRebateRetroativo> SelecionarLog(LogRebateRetroativoFiltro log, int numeroLinhas, string ordem)
        {
            IList<LogRebateRetroativo> lista = new List<LogRebateRetroativo>();
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(dbManager, log, out where);

                if (string.IsNullOrEmpty(where))
                {
                    if (log.DtInicio.HasValue)
                        where += " DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }
                else
                {
                    if (log.DtInicio.HasValue)
                        where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO >='" + log.DtInicio.Value.Year + "-" + log.DtInicio.Value.Month.ToString("00") + "-" + log.DtInicio.Value.Day.ToString("00") + "'";
                }

                if (log.DtFim.HasValue)
                    where += " AND DT_LOG_DATETIME_REBATE_RETROATIVO <='" + log.DtFim.Value.Year + "-" + log.DtFim.Value.Month.ToString("00") + "-" + log.DtFim.Value.Day.ToString("00") + " " + log.DtFim.Value.Hour.ToString("23") + ":" + log.DtFim.Value.Hour.ToString("59") + ":" + log.DtFim.Value.Hour.ToString("59") + "'";               


                string query = string.Format(querySelecionarLog,
                    numeroLinhas > 0 ? "TOP " + numeroLinhas : "",
                    string.IsNullOrEmpty(where) ? "" : "WHERE " + where,
                    string.IsNullOrEmpty(ordem) ? orderByDefault : ordem);

                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        lista.Add(PreencherLog(reader));
                    }
                }
            }
            return lista;
        }

        public IList<LogRebateRetroativo> SelecionarTodos()
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string query = "SELECT * FROM TB_EC_LOG_SIC_REBATE_RETROATIVO ";

                IList<DbParameter> parametros = new List<DbParameter>();

                IList<LogRebateRetroativo> logs = new List<LogRebateRetroativo>();
                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        logs.Add(Preencher(reader));
                    }
                }
                return logs;
            }
        }

        public IList<LogRebateRetroativo> SelecionarPorUsuarioEData(string usuario, DateTime dataInicio)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string query = "SELECT * FROM TB_EC_LOG_SIC_REBATE_RETROATIVO WHERE CD_LOG_USUARIO_REBATE_RETROATIVO = @Usuario AND DT_LOG_DATETIME_REBATE_RETROATIVO >= @DataInicio";

                IList<DbParameter> parametros = new List<DbParameter>
                {
                    dbManager.CreateInParameter(DbType.String, "Usuario", usuario, false),
                    dbManager.CreateInParameter(DbType.DateTime, "DataInicio", dataInicio, false)
                };

                IList<LogRebateRetroativo> logs = new List<LogRebateRetroativo>();
                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        logs.Add(Preencher(reader));
                    }
                }
                return logs;
            }
        }

        public IList<LogRebateRetroativo> SelecionarPorId(int nrSeqEntidadeRebateRetroativo)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                string query = "SELECT * FROM TB_EC_LOG_SIC_REBATE_RETROATIVO WHERE nr_seq_entidade_Rebate_retroativo = @Id ";

                IList<DbParameter> parametros = new List<DbParameter>
                {
                    dbManager.CreateInParameter(DbType.Int32, "Id", nrSeqEntidadeRebateRetroativo, false),
                };

                IList<LogRebateRetroativo> logs = new List<LogRebateRetroativo>();
                using (SafeDataReader reader = (SafeDataReader)dbManager.GetsDataReader(query, parametros))
                {
                    while (reader.Read())
                    {
                        logs.Add(Preencher(reader));
                    }
                }
                return logs;
            }
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, string ordem)
        {
            return Selecionar(log, 0, ordem);
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log)
        {
            return Selecionar(log, 0, orderByDefault);
        }

        public IList<LogRebateRetroativo> Selecionar()
        {
            //return Selecionar(new LogRebateRetroativo(), 0, orderByDefault);
            return SelecionarTodos();
        }

        public LogRebateRetroativo SelecionarPrimeiro(LogRebateRetroativo log)
        {
            var lista = Selecionar(log, 1, orderByDefault);
            return lista.Count > 0 ? lista[0] : null;
        }

        public void Incluir(LogRebateRetroativo log)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                log.NrSeqLogRebateRetroativo = Convert.ToInt32(dbManager.GetScalar(queryIncluir, CriarParametrosIncluir(dbManager, log)));
            }
        }

        public void Atualizar(LogRebateRetroativo log)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                dbManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(dbManager, log));
            }
        }

        public void Excluir(LogRebateRetroativo log)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                dbManager.ExecuteCommand(queryExcluir, CriarParametroPK(dbManager, log.NrSeqLogRebateRetroativo));
            }
        }

        #endregion

        #region Métodos Privados
        private LogRebateRetroativo Preencher(SafeDataReader reader)
        {
            return new LogRebateRetroativo
            {
                NrSeqLogRebateRetroativo = reader.GetNullableInt32(C_NrSeqLog),
                NrSeqAplicacaoRebateRetroativo = reader.GetInt32(C_NrSeqAplicacao),
                NrSeqModuloRebateRetroativo = reader.GetInt32(C_NrSeqModulo),
                NrSeqEntidadeRebateRetroativo = reader.GetInt32(C_NrSeqEntidade),
                DtLogDatetimeRebateRetroativo = reader.GetNullableDateTime(C_DtLogDatetime),
                CdLogUsuarioRebateRetroativo = reader.GetString(C_CdLogUsuario),
                XmlLogDetalheRebateRetroativo = reader.GetString(C_XmlLogDetalhe),
                DsIbm = reader.GetString(C_DsIBM),
                NrContrato = reader.GetNullableInt32(C_NrContrato),
                NrSeqClienteSic = reader.GetInt32(C_NrSeqClienteSic)
            };
        }

        private LogRebateRetroativo PreencherLog(SafeDataReader reader)
        {
            return new LogRebateRetroativo
            {
                NrSeqLogRebateRetroativo = reader.GetNullableInt32(C_NrSeqLog),
                NrSeqAplicacaoRebateRetroativo = reader.GetInt32(C_NrSeqAplicacao),
                NrSeqModuloRebateRetroativo = reader.GetInt32(C_NrSeqModulo),
                NrSeqEntidadeRebateRetroativo = reader.GetInt32(C_NrSeqEntidade),
                DtLogDatetimeRebateRetroativo = reader.GetNullableDateTime(C_DtLogDatetime),
                CdLogUsuarioRebateRetroativo = reader.GetString(C_CdLogUsuario),
                XmlLogDetalheRebateRetroativo = reader.GetString(C_XmlLogDetalhe),
                DsIbm = reader.GetString(C_DsIBM),
                NrSeqClienteSic = reader.GetInt32(C_NrSeqClienteSic)
            };
        }

        /// <summary>
        /// Preenche o objeto EcContratoSic a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto EcContratoSic preenchido</returns>
        protected int PreencherContratoSic(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException());
            int contratoSic = reader.GetInt32(C_NrContrato);
            return contratoSic;
        }

        private IList<DbParameter> CriarParametrosIncluir(DatabaseManager dbManager, LogRebateRetroativo log)
        {
            return new List<DbParameter>
            {
                dbManager.CreateInParameter(DbType.Int32, "Aplicacao", log.NrSeqAplicacaoRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.Int32, "Modulo", log.NrSeqModuloRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.Int32, "Entidade", log.NrSeqEntidadeRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.DateTime, "DataLog", log.DtLogDatetimeRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.String, "Usuario", log.CdLogUsuarioRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.String, "XmlDetalhe", log.XmlLogDetalheRebateRetroativo, false)
            };
        }

        private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager dbManager, LogRebateRetroativo log)
        {
            var parametros = CriarParametrosIncluir(dbManager, log);
            parametros.Add(dbManager.CreateInParameter(DbType.Int32, "LogId", log.NrSeqLogRebateRetroativo, false));
            return parametros;
        }

        private IList<DbParameter> CriarParametroPK(DatabaseManager dbManager, int? logId)
        {
            return new List<DbParameter>
            {
                dbManager.CreateInParameter(DbType.Int32, "LogId", logId, false)
            };
        }

        /// <summary>
        /// Cria os parâmetros de seleção com base nos valores fornecidos.
        /// </summary>
        /// <param name="dbManager">Instância de <see cref="DatabaseManager"/></param>
        /// <param name="log">Instância de <see cref="LogRebateRetroativo"/></param>
        /// <param name="where">Cláusula WHERE gerada</param>
        /// <returns>Lista de DbParameter</returns>
        private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager dbManager, LogRebateRetroativoFiltro log, out string where)
        {
            var parametros = new List<DbParameter>();
            where = string.Empty;            
            
            if (!string.IsNullOrEmpty(log.DsIbm))
                parametros.Add(dbManager.CreateWhereParameter(DbType.String, "RS", "NR_IBM_REBATE_SIC", DatabaseManager.SQLOperation.Like, "%" + log.DsIbm + "%", ref where));

            if (!string.IsNullOrEmpty(log.NumContrato))
                parametros.Add(dbManager.CreateWhereParameter(DbType.String, "CO", "NR_SEQ_EC_CONTRATO_SIC", DatabaseManager.SQLOperation.Like, "%" + log.NumContrato + "%", ref where));

            return parametros;
        }




        #endregion
    }
}

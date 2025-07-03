#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : LogIntegracaoSicDAO.cs
// Class Name	        : LogIntegracaoSicDAO
// Author		        : Leandro Oliveira
// Creation Date 	    : 02/12/2024
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : 
//	Date of Modification    : 
//	Reason for modification : 
//	Modification Done       : 
//	Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security;
using System.Text;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    #region classe concreta LogIntegracaoSicDAO
    /// <summary>
    /// Representa funcionalidade relacionada a LogIntegracaoSicDAO
    /// </summary>
    internal partial class LogIntegracaoSicDAO : ILogIntegracaoSicDAO
    {
        #region Constantes
        /// <summary>
        /// Representa ordenação padrão da query Selecionar
        /// </summary>
        public const string orderByDefault = "";
        #endregion  Constantes de TbLogIntegracaoSic

        #region Queries
        #region Query para Selecionar registros
        /// <summary>
        /// String com a query de seleção de registros
        /// </summary>
        private string querySelecionar = new StringBuilder().Append("SELECT {0}")
        .Append(" TB_LOG_INTEGRACAO_SIC.NR_SEQ_LOG_INTEGRACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_METODO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_PAGINA_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.DS_ACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.DT_ACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_USUARIO_SIC")
        .Append(" FROM TB_LOG_INTEGRACAO_SIC")
        .Append(" {1}")
        .Append(" {2}")
        .Append("").ToString();

        /// <summary>
        /// String com a query de seleção de registros
        /// </summary>
        private string querySelecionarFiltro = new StringBuilder().Append("SELECT {0}")
        .Append(" TB_LOG_INTEGRACAO_SIC.NR_SEQ_LOG_INTEGRACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_METODO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_PAGINA_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.DS_ACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.DT_ACAO_SIC")
        .Append(",TB_LOG_INTEGRACAO_SIC.NM_USUARIO_SIC")
        .Append(" FROM TB_LOG_INTEGRACAO_SIC")
        .Append(" {1}")
        .Append(" {2}")
        .Append("").ToString();

        #endregion Query para Selecionar registros
        #endregion Queries

        #region Metodos Publicos
        #region Selecionar
        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic, int numeroLinhas, string ordem)
        {
            IList<LogIntegracaoSic> listLogIntegracaoSic = new List<LogIntegracaoSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, logIntegracaoSic, out where);
                string newQuery = string.Format(querySelecionar,
                    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
                    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
                    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listLogIntegracaoSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listLogIntegracaoSic;
        }

        // <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> SelecionarFiltro(FiltroLogIntegracaoSic logIntegracaoSic, int numeroLinhas, string ordem)
        {
            IList<LogIntegracaoSic> listLogIntegracaoSic = new List<LogIntegracaoSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = new List<DbParameter>();

                where = string.Format("WHERE DT_ACAO_SIC BETWEEN '{0:yyy-MM-dd}' and '{1:yyy-MM-dd 23:59:59}' {2}",
                logIntegracaoSic.DataPeriodoIni,
                logIntegracaoSic.DataPeriodoFim,
                string.IsNullOrEmpty(where) ? "" : "AND " + where);
                
                string newQuery = string.Format(querySelecionarFiltro,
                    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty, where,
                    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listLogIntegracaoSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listLogIntegracaoSic;
        }
        #endregion Selecionar
        #endregion Metodos Publicos

        #region Metodos Privados
        #region Metodos Gerais
        #region Preencher
        /// <summary>
        /// Preenche o objeto LogIntegracaoSic a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto LogIntegracaoSic preenchido</returns>
        protected LogIntegracaoSic Preencher(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException());
            LogIntegracaoSic logIntegracaoSic = new LogIntegracaoSic();
            logIntegracaoSic.NrSeqLogIntegracaoSic = reader.GetNullableInt32(C_NrSeqLogIntegracaoSic);
            logIntegracaoSic.NmMetodoSic = reader.GetString(C_NmMetodoSic);
            logIntegracaoSic.NmPaginaSic = reader.GetString(C_NmPaginaSic);
            logIntegracaoSic.DsAcaoSic = reader.GetString(C_DsAcaoSic);
            logIntegracaoSic.DtAcaoSic = reader.GetDateTime(C_DtAcaoSic);
            logIntegracaoSic.NmUsuarioSic = reader.GetString(C_NmUsuarioSic);
            return logIntegracaoSic;
        }
        #endregion Preencher
        #endregion Common Methods

        #region Criar Parametros
        #region Criar Parametros Selecionar
        /// <summary>
        /// Criar Parametros Selecionar
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <returns>Lista de DbParameter</returns>
        private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, LogIntegracaoSic logIntegracaoSic, out string where)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            where = "";
            if (logIntegracaoSic.NrSeqLogIntegracaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_LOG_INTEGRACAO_SIC", C_NrSeqLogIntegracaoSic, DatabaseManager.SQLOperation.Equal, logIntegracaoSic.NrSeqLogIntegracaoSic, ref where));
            if (logIntegracaoSic.NmMetodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_LOG_INTEGRACAO_SIC", C_NmMetodoSic, DatabaseManager.SQLOperation.Like, "%" + logIntegracaoSic.NmMetodoSic + "%", ref where));
            if (logIntegracaoSic.NmPaginaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_LOG_INTEGRACAO_SIC", C_NmPaginaSic, DatabaseManager.SQLOperation.Like, "%" + logIntegracaoSic.NmPaginaSic + "%", ref where));
            if (logIntegracaoSic.DsAcaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_LOG_INTEGRACAO_SIC", C_DsAcaoSic, DatabaseManager.SQLOperation.Like, "%" + logIntegracaoSic.DsAcaoSic + "%", ref where));
            if (logIntegracaoSic.DtAcaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_LOG_INTEGRACAO_SIC", C_DtAcaoSic, DatabaseManager.SQLOperation.Equal, logIntegracaoSic.DtAcaoSic, ref where));
            if (logIntegracaoSic.NmUsuarioSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_LOG_INTEGRACAO_SIC", C_NmUsuarioSic, DatabaseManager.SQLOperation.Like, "%" + logIntegracaoSic.NmUsuarioSic + "%", ref where));
            return dbParams;
        }
        #endregion Criar Parametros Selecionar
        #endregion Criar Parametros
        #endregion Metodos Privados
    }
    #endregion classe concreta 
}

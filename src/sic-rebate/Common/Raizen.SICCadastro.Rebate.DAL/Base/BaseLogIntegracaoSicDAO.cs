#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseLogIntegracaoSicDAO.cs
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
    #region classe base LogIntegracaoSicDAO
    /// <summary>
    /// Representa funcionalidade relacionada a LogIntegracaoSicDAO
    /// </summary>
    internal partial class LogIntegracaoSicDAO
    {
        #region Construtores
        /// <summary>
        /// Construtor Default 
        /// </summary>
        public LogIntegracaoSicDAO()
        {
        }
        #endregion Construtor Default

        #region Constantes
        private const string C_NrSeqLogIntegracaoSic = "NR_SEQ_LOG_INTEGRACAO_SIC";
        private const string C_NmMetodoSic = "NM_METODO_SIC";
        private const string C_NmPaginaSic = "NM_PAGINA_SIC";
        private const string C_DtAcaoSic = "DT_ACAO_SIC";
        private const string C_DsAcaoSic = "DS_ACAO_SIC";
        private const string C_NmUsuarioSic = "NM_USUARIO_SIC";
        #endregion  Constantes de TbLogIntegracaoSic

        #region Queries
        #region Query Incluir
        /// <summary>
        /// String com a query para inclusão
        /// </summary>
        private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_LOG_INTEGRACAO_SIC")
        .Append("(")
        .Append("NM_METODO_SIC,NM_PAGINA_SIC,DS_ACAO_SIC,DT_ACAO_SIC,NM_USUARIO_SIC")
        .Append(")")
        .Append(" VALUES ")
        .Append("(")
        .Append("@" + C_NmMetodoSic)
        .Append(", ")
        .Append("@" + C_NmPaginaSic)
        .Append(", ")
        .Append("@" + C_DsAcaoSic)
        .Append(", ")
        .Append("@" + C_DtAcaoSic)
        .Append(", ")
        .Append("@" + C_NmUsuarioSic)
        .Append(")")
        .Append("").ToString();
        #endregion Query Incluir

        #region Query Atualizar
        /// <summary>
        /// String com a query para atualizar
        /// </summary>
        private string queryAtualizar = new StringBuilder().Append("UPDATE TB_LOG_INTEGRACAO_SIC SET")
        .Append(" NM_METODO_SIC = ")
        .Append("@" + C_NmMetodoSic)
        .Append(",NM_PAGINA_SIC = ")
        .Append("@" + C_NmPaginaSic)
        .Append(",DS_ACAO_SIC = ")
        .Append("@" + C_NmUsuarioSic)
        .Append(",DT_ACAO_SIC = ")
        .Append("@" + C_DtAcaoSic)
        .Append(",NM_USUARIO_SIC = ")
        .Append("@" + C_NmUsuarioSic)
        .Append(" WHERE")
        .Append(" NR_SEQ_LOG_INTEGRACAO_SIC = ")
        .Append("@" + C_NrSeqLogIntegracaoSic)
        .Append("").ToString();
        #endregion Query Atualizar

        #region Query Excluir
        /// <summary>
        /// String com a query excluir
        /// </summary>
        private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_LOG_INTEGRACAO_SIC")
        .Append(" WHERE")
        .Append(" NR_SEQ_LOG_INTEGRACAO_SIC = ")
        .Append("@" + C_NrSeqLogIntegracaoSic)
        .Append("").ToString();
        #endregion Query Excluir

        #region Query retorna Sequence 
        /// <summary>
        /// Strings with retrieve sequence query
        /// </summary>
        private string queryRetornaSequencia = new StringBuilder().Append("SELECT ")
        .Append(" SCOPE_IDENTITY()").ToString();
        #endregion Retrieve Sequence

        #region Query Verifica se existe
        /// <summary>
        /// String com a query Verifica se existe
        /// </summary>
        private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_LOG_INTEGRACAO_SIC")
        .Append(" WHERE")
        .Append(" NR_SEQ_LOG_INTEGRACAO_SIC = ")
        .Append("@" + C_NrSeqLogIntegracaoSic)
        .Append("").ToString();
        #endregion Query Verifica se existe
        #endregion Queries

        #region Metodos Publicos
        #region Incluir
        /// <summary>
        /// Incluir LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Incluir(LogIntegracaoSic logIntegracaoSic)
        {
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    Incluir(logIntegracaoSic, databaseManager);
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Incluir LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        internal void Incluir(LogIntegracaoSic logIntegracaoSic, DatabaseManager databaseManager)
        {
            string query = queryIncluir + ";" + queryRetornaSequencia;
            if (logIntegracaoSic == null) throw (new ArgumentNullException());

            if (databaseManager.Transaction == null)
                logIntegracaoSic.NrSeqLogIntegracaoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, logIntegracaoSic)));
            else
                logIntegracaoSic.NrSeqLogIntegracaoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, logIntegracaoSic), databaseManager.Transaction));
        }
        #endregion Incluir

        #region Atualizar
        /// <summary>
        /// Atualiza LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Atualizar(LogIntegracaoSic logIntegracaoSic)
        {
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    Atualizar(logIntegracaoSic, databaseManager);
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Atualizar LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        internal void Atualizar(LogIntegracaoSic logIntegracaoSic, DatabaseManager databaseManager)
        {
            if (logIntegracaoSic == null) throw (new ArgumentNullException());
            if (databaseManager.Transaction == null)
            {
                databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, logIntegracaoSic));
            }
            else
            {
                databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, logIntegracaoSic), databaseManager.Transaction);
            }
        }
        #endregion Atualizar

        #region Excluir
        /// <summary>
        /// Exclui logIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Excluir(LogIntegracaoSic logIntegracaoSic)
        {
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    Excluir(logIntegracaoSic, databaseManager);
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Exclui logIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        internal void Excluir(LogIntegracaoSic logIntegracaoSic, DatabaseManager databaseManager)
        {
            if (logIntegracaoSic == null) throw (new ArgumentNullException());
            if (databaseManager.Transaction == null)
            {
                databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, logIntegracaoSic));
            }
            else
            {
                databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, logIntegracaoSic), databaseManager.Transaction);
            }
        }
        #endregion Excluir
        #endregion Metodos Publicos

        #region Metodos Privados
        #region Metodos Gerais

        #region Verificar se Existe LogIntegracaoSic
        /// <summary>
        /// Verifica se o registro já existe
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <returns>Se existe ou não</returns>
        protected bool VerificarSeExiste(LogIntegracaoSic logIntegracaoSic, DatabaseManager databaseManager)
        {
            if (logIntegracaoSic == null) throw (new ArgumentNullException());
            int count;
            if (databaseManager.Transaction == null)
            {
                count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, logIntegracaoSic)).ToString());
            }
            else
            {
                count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, logIntegracaoSic), databaseManager.Transaction).ToString());
            }
            return (count > 0);
        }
        #endregion Verificar se Existe LogIntegracaoSic
        #endregion Metodos Gerais

        #region Criar Parametros
        #region Criar Parametros PK
        /// <summary>
        /// Cria Parametros da chave primaria
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <returns>Lista de DbParameter</returns>
        protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, LogIntegracaoSic logIntegracaoSic)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqLogIntegracaoSic, logIntegracaoSic.NrSeqLogIntegracaoSic, false));
            return dbParams;
        }
        #endregion Criar Parametros PK 

        #region Criar Parametros Incluir
        /// <summary>
        /// Cria Parametros Incluir
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <returns>Lista de DbParameter</returns>
        private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, LogIntegracaoSic logIntegracaoSic)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmMetodoSic, logIntegracaoSic.NmMetodoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmPaginaSic, logIntegracaoSic.NmPaginaSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsAcaoSic, logIntegracaoSic.DsAcaoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAcaoSic, logIntegracaoSic.DtAcaoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUsuarioSic, logIntegracaoSic.NmUsuarioSic, false));
            return dbParams;
        }
        #endregion Criar Parametros Incluir

        #region Criar Parametros Atualizar
        /// <summary>
        /// Cria Parametros Atualizar
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        /// <returns>Collection of DbParameter</returns>
        private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, LogIntegracaoSic logIntegracaoSic)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqLogIntegracaoSic, logIntegracaoSic.NrSeqLogIntegracaoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmMetodoSic, logIntegracaoSic.NmMetodoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmPaginaSic, logIntegracaoSic.NmPaginaSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsAcaoSic, logIntegracaoSic.DsAcaoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAcaoSic, logIntegracaoSic.DtAcaoSic, false));
            dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmUsuarioSic, logIntegracaoSic.NmUsuarioSic, false));
            return dbParams;
        }
        #endregion Criar Parametros Atualizar
        #endregion Criar Parametros
        #endregion Metodos Privados
    }
    #endregion
}

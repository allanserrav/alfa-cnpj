#region Cabeçalho do Arquivo
// <Summary>
// File Name            : BaseLogRebateRetroativoDAO.cs
// Class Name           : BaseLogRebateRetroativoDAO
// Author               : Raphael Simões Andrade
// Creation Date        : 17/12/2024
// </Summary>

// <RevisionHistory>
// <SNo value=1>
// Modified By             : 
// Date of Modification    : 
// Reason for modification : 
// Modification Done       : 
// Defect Id (If any)      : 
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

namespace Raizen.SICCadastro.Rebate.DAL.Base
{
    #region classe base BaseLogRebateRetroativoDAO
    /// <summary>
    /// Representa a funcionalidade base para manipulação de LogRebateRetroativo.
    /// </summary>
    internal abstract class BaseLogRebateRetroativoDAO
    {
        #region Construtores
        /// <summary>
        /// Construtor Default
        /// </summary>
        protected BaseLogRebateRetroativoDAO()
        {
        }
        #endregion Construtores

        #region Constantes
        protected const string C_NrSeqLog = "NR_SEQ_EC_LOG_SIC_REBATE_RETROATIVO";
        protected const string C_NrSeqAplicacao = "NR_SEQ_EC_APLICACAO_SIC_REBATE_RETROATIVO";
        protected const string C_NrSeqModulo = "NR_SEQ_EC_MODULO_SIC_REBATE_RETROATIVO";
        protected const string C_NrSeqEntidade = "NR_SEQ_EC_ENTIDADE_SIC_REBATE_RETROATIVO";
        protected const string C_DtLogDateTime = "DT_EC_LOG_DATETIME_REBATE_RETROATIVO";
        protected const string C_CdUsuario = "CD_EC_LOG_USUARIO_SIC_REBATE_RETROATIVO";
        protected const string C_XmlDetalhe = "XML_EC_LOG_DE_DETALHE_REBATE_RETROATIVO";
        #endregion Constantes

        #region Queries
        /// <summary>
        /// Query de inserção
        /// </summary>
        protected readonly string queryIncluir = new StringBuilder()
            .Append("INSERT INTO TB_EC_LOG_SIC_REBATE_RETROATIVO (")
            .Append("NR_SEQ_EC_APLICACAO_SIC_REBATE_RETROATIVO, ")
            .Append("NR_SEQ_EC_MODULO_SIC_REBATE_RETROATIVO, ")
            .Append("NR_SEQ_EC_ENTIDADE_SIC_REBATE_RETROATIVO, ")
            .Append("DT_EC_LOG_DATETIME_REBATE_RETROATIVO, ")
            .Append("CD_EC_LOG_USUARIO_SIC_REBATE_RETROATIVO, ")
            .Append("XML_EC_LOG_DE_DETALHE_REBATE_RETROATIVO")
            .Append(") VALUES (")
            .Append("@Aplicacao, @Modulo, @Entidade, @DataLog, @Usuario, @XmlDetalhe")
            .Append("); SELECT SCOPE_IDENTITY();")
            .ToString();

        /// <summary>
        /// Query de verificação de existência
        /// </summary>
        protected readonly string queryVerificaSeExiste = new StringBuilder()
            .Append("SELECT COUNT(1) FROM TB_EC_LOG_SIC_REBATE_RETROATIVO ")
            .Append("WHERE NR_SEQ_EC_LOG_SIC_REBATE_RETROATIVO = @LogId")
            .ToString();
        #endregion Queries

        #region Métodos Públicos

        /// <summary>
        /// Insere um novo registro de log no banco de dados.
        /// </summary>
        /// <param name="log">Instância de LogRebateRetroativo</param>
        public void Incluir(LogRebateRetroativo log)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    log.NrSeqLogRebateRetroativo = Convert.ToInt32(dbManager.GetScalar(queryIncluir, CriarParametrosIncluir(dbManager, log)));
                }
                finally
                {
                    dbManager.CloseConnection();
                }
            }
        }

        /// <summary>
        /// Verifica se o registro existe no banco de dados.
        /// </summary>
        /// <param name="logId">ID do log</param>
        /// <returns>Retorna verdadeiro se existir</returns>
        public bool VerificarSeExiste(int logId)
        {
            using (DatabaseManager dbManager = new DatabaseManager("SICCadastro"))
            {
                return Convert.ToInt32(dbManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(dbManager, logId))) > 0;
            }
        }

        #endregion Métodos Públicos

        #region Métodos Privados

        /// <summary>
        /// Cria os parâmetros para inserção.
        /// </summary>
        private IList<DbParameter> CriarParametrosIncluir(DatabaseManager dbManager, LogRebateRetroativo log)
        {
            return new List<DbParameter>
            {
                dbManager.CreateInParameter(DbType.Int32, "Aplicacao", log.NrSeqAplicacaoRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.Int32, "Modulo", log.NrSeqModuloRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.Int32, "Entidade", log.NrSeqEntidadeRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.DateTime, "DataLog", log.DtLogDatetimeRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.String, "Usuario", log.CdLogUsuarioRebateRetroativo, false),
                dbManager.CreateInParameter(DbType.Xml, "XmlDetalhe", log.XmlLogDetalheRebateRetroativo, false)
            };
        }

        /// <summary>
        /// Cria parâmetros para verificação de chave primária.
        /// </summary>
        private IList<DbParameter> CriarParametrosPK(DatabaseManager dbManager, int logId)
        {
            return new List<DbParameter>
            {
                dbManager.CreateInParameter(DbType.Int32, "LogId", logId, false)
            };
        }

        #endregion Métodos Privados
    }
    #endregion classe base BaseLogRebateRetroativoDAO
}

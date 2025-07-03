using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.DBUtil;
using System.Data.Common;
using System.Data;

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Complemento de FaixarebateSicDAO
    /// </summary>
    internal partial class FaixarebateSicDAO
    {
        #region Queries

        #region Query para Selecionar Rebates Por Meses Grupo
        /// <summary>
        /// Selecionar Rebate Por Intervalo de Data da Assinatura do Contratos
        /// </summary>
        private string querySelecionarVigentes = new StringBuilder()
        .AppendLine("SELECT tb_faixarebate_sic.nr_seq_faixarebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_categoria_sic, ")
        .AppendLine("    tb_faixarebate_sic.dt_iniciocalculo_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.dt_fimcalculo_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_volumemensal_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_percminimo_rebate_sic, ")
        //.AppendLine("    tb_faixarebate_sic.vl_percmaximo_rebate_sic, ")
        .AppendLine("(CASE WHEN tb_faixarebate_sic.vl_percmaximo_rebate_sic > 9999999 THEN 9999999 ELSE tb_faixarebate_sic.vl_percmaximo_rebate_sic END) AS vl_percmaximo_rebate_sic,")
        .AppendLine("    tb_faixarebate_sic.vl_bonificacao_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_recebebonus_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_grupo_sic, ")
        .AppendLine("    tb_faixarebate_sic.st_ativo_faixa_sic ")
        .AppendLine("FROM tb_faixarebate_sic ")
        .AppendLine("WHERE (tb_faixarebate_sic.nr_seq_rebate_sic = {0}) ") //@NR_SEQ_REBATE_SIC       
        .AppendLine("        AND (tb_faixarebate_sic.dt_iniciocalculo_rebate_sic <= '{1}') ") //@DT_FIMCALCULO_REBATE_SIC 
        .AppendLine("        AND (tb_faixarebate_sic.dt_fimcalculo_rebate_sic >= '{2}') ") //@DT_INICIOCALCULO_REBATE_SIC
        //.AppendLine(" AND '{1}' BETWEEN tb_faixarebate_sic.dt_iniciocalculo_rebate_sic AND tb_faixarebate_sic.dt_fimcalculo_rebate_sic ")
        .AppendLine("        AND (tb_faixarebate_sic.st_ativo_faixa_sic = 1) ")
        .AppendLine("").ToString();

        private string querySelecionarFaixasAditivo = new StringBuilder()
        .AppendLine("SELECT tb_faixarebate_sic.nr_seq_faixarebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_categoria_sic, ")
        .AppendLine("    tb_faixarebate_sic.dt_iniciocalculo_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.dt_fimcalculo_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_volumemensal_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_percminimo_rebate_sic, ")
        //.AppendLine("    tb_faixarebate_sic.vl_percmaximo_rebate_sic, ")
        .AppendLine("(CASE WHEN tb_faixarebate_sic.vl_percmaximo_rebate_sic > 9999999 THEN 9999999 ELSE tb_faixarebate_sic.vl_percmaximo_rebate_sic END) AS vl_percmaximo_rebate_sic,")
        .AppendLine("    tb_faixarebate_sic.vl_bonificacao_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.vl_recebebonus_rebate_sic, ")
        .AppendLine("    tb_faixarebate_sic.nr_seq_grupo_sic, ")
        .AppendLine("    tb_faixarebate_sic.st_ativo_faixa_sic ")
        .AppendLine("FROM tb_faixarebate_sic ")
        .AppendLine("WHERE (tb_faixarebate_sic.nr_seq_rebate_sic = {0}) ") //@NR_SEQ_REBATE_SIC       
        //.AppendLine("        AND (tb_faixarebate_sic.dt_iniciocalculo_rebate_sic <= '{1}') ") //@DT_FIMCALCULO_REBATE_SIC 
        //.AppendLine("        AND (tb_faixarebate_sic.dt_fimcalculo_rebate_sic >= '{2}') ") //@DT_INICIOCALCULO_REBATE_SIC
        .AppendLine(" AND '{1}' BETWEEN tb_faixarebate_sic.dt_iniciocalculo_rebate_sic AND tb_faixarebate_sic.dt_fimcalculo_rebate_sic ")
        .AppendLine("        AND (tb_faixarebate_sic.st_ativo_faixa_sic = 1) ")
        .AppendLine("").ToString();
        #endregion

        #region Query para Selecionar Faixa Historico
        /// <summary>
        /// Selecionar Rebate Por Intervalo de Data da Assinatura do Contratos
        /// </summary>
        private string querySelecionarFaixaHistorico = new StringBuilder()
              .AppendLine("SELECT DISTINCT ")
                  .AppendLine("FAIXAHIST.[NR_SEQ_FAIXAREBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[NR_SEQ_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[NR_SEQ_CATEGORIA_SIC] ")
                  .AppendLine(",FAIXAHIST.[DT_INICIOCALCULO_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[DT_FIMCALCULO_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[VL_VOLUMEMENSAL_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[VL_PERCMINIMO_REBATE_SIC] ")
                  //.AppendLine(",FAIXAHIST.[VL_PERCMAXIMO_REBATE_SIC] ")
                  .AppendLine(",(CASE WHEN FAIXAHIST.[VL_PERCMAXIMO_REBATE_SIC] > 9999999 THEN 9999999 ELSE FAIXAHIST.[VL_PERCMAXIMO_REBATE_SIC] END) AS VL_PERCMAXIMO_REBATE_SIC")
                  .AppendLine(",FAIXAHIST.[VL_BONIFICACAO_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[VL_RECEBEBONUS_REBATE_SIC] ")
                  .AppendLine(",FAIXAHIST.[NR_SEQ_GRUPO_SIC] ")
                  .AppendLine(",CAST(1 AS BIT) AS ST_ATIVO_FAIXA_SIC")
                .AppendLine("FROM TB_CALCULO_REBATE_FAIXA_SIC (NOLOCK) CALCREBATE ")
                     .AppendLine("JOIN TB_VOLUME_CALCULO_REBATE_FAIXA_SIC (NOLOCK) CALCREBATEFAIXA ON CALCREBATEFAIXA.NR_SEQ_CALCULO_REBATE_FAIXA_SIC = CALCREBATE.NR_SEQ_CALCULO_REBATE_FAIXA_SIC ")
                     .AppendLine("JOIN TB_VOLUME_MENSAL_FAIXA_REBATE_SIC (NOLOCK) VOLMENSALFAIXA ON VOLMENSALFAIXA.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = CALCREBATEFAIXA.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC ")
                     .AppendLine("JOIN TB_FAIXA_REBATE_HISTORICO_SIC (NOLOCK) FAIXAHIST ON ")
                        .AppendLine("FAIXAHIST.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = VOLMENSALFAIXA.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC ")
                        .AppendLine("AND FAIXAHIST.NR_SEQ_FAIXAREBATE_SIC = VOLMENSALFAIXA.NR_SEQ_FAIXAREBATE_SIC ")
                .AppendLine("WHERE CALCREBATE.NR_SEQ_CALCULO_REBATE_SIC = {0} ")
        .AppendLine("").ToString();
        #endregion

        #endregion

        #region Metodos Publicos
        #region Selecionar Faixa Rebate Vigente
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente
        /// </summary>
        /// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de FaixarebateSic</returns>
        public IList<FaixarebateSic> SelecionarFaixasVigentesRebate(FaixarebateSic faixarebateSic)
        {
            IList<FaixarebateSic> listFaixarebateSic = new List<FaixarebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionarFaixasVigentesRebate(databaseManager, new FaixarebateSic(), out where);
                string newQuery = string.Format(querySelecionarVigentes,
                    faixarebateSic.NrSeqRebateSic.Value,
                    faixarebateSic.DtFimcalculoRebateSic.Value.ToString("yyyy-MM-dd"),
                    faixarebateSic.DtIniciocalculoRebateSic.Value.ToString("yyyy-MM-dd"));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listFaixarebateSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listFaixarebateSic;
        }
        #endregion Selecionar Faixa Rebate Vigente

        #region Selecionar Faixa Rebate Vigente para Aditivo
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente para Aditivo
        /// </summary>
        public IList<FaixarebateSic> SelecionarFaixasAditivo(RebateSic rebateSic, DateTime dataInicioAditivo)
        {
            IList<FaixarebateSic> listFaixarebateSic = new List<FaixarebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionarFaixasVigentesRebate(databaseManager, new FaixarebateSic(), out where);
                //string newQuery = string.Format(querySelecionarVigentes,
                string newQuery = string.Format(querySelecionarFaixasAditivo,
                    rebateSic.NrSeqRebateSic.Value,
                    //DateTime.Now.ToString("yyyy-MM-dd"),
                    dataInicioAditivo.ToString("yyyy-MM-dd"));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                        listFaixarebateSic.Add(Preencher(dbDataReader));
                }

                databaseManager.CloseConnection();
            }
            return listFaixarebateSic;
        }
        #endregion Selecionar Faixa Rebate Vigente para Aditivo

        #region Selecionar Faixa Rebate Histórico
        /// <summary>
        /// Selecionar os dados de SelecionarFaixaRebateVigente para Aditivo
        /// </summary>
        public IList<FaixarebateSic> SelecionarFaixasHistorico(int NrSeqCalculoRebateSic)
        {
            IList<FaixarebateSic> listFaixarebateSic = new List<FaixarebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionarFaixasVigentesRebate(databaseManager, new FaixarebateSic(), out where);

                string newQuery = string.Format(querySelecionarFaixaHistorico, NrSeqCalculoRebateSic);

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))                
                    while (dbDataReader.Read())
                        listFaixarebateSic.Add(Preencher(dbDataReader));                

                databaseManager.CloseConnection();
            }
            return listFaixarebateSic;
        }
        #endregion Selecionar Faixa Rebate Vigente para Aditivo

        #endregion Metodos Publicos

        #region Metodos Privados
        #region Criar Parametros
        #region Criar Parametros Selecionar Faixa Rebate Vigente
        /// <summary>
        /// Criar Parametros Selecionar Faixa Rebate Vigente
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
        /// <returns>Lista de DbParameter</returns>
        private IList<DbParameter> CriarParametrosSelecionarFaixasVigentesRebate(DatabaseManager databaseManager, FaixarebateSic faixarebateSic, out string where)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            where = "";
            if (faixarebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXAREBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.NrSeqRebateSic, ref where));

            dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXAREBATE_SIC", C_DtIniciocalculoRebateSic, DatabaseManager.SQLOperation.GreaterThanOrEqual, faixarebateSic.DtIniciocalculoRebateSic, ref where));
            dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXAREBATE_SIC", C_DtFimcalculoRebateSic, DatabaseManager.SQLOperation.GreaterThanOrEqual, faixarebateSic.DtIniciocalculoRebateSic, ref where));
            dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_FAIXAREBATE_SIC", C_StAtivoFaixaSic, DatabaseManager.SQLOperation.Equal, true, ref where));
            return dbParams;
        }
        #endregion Criar Parametros Selecionar Faixa Rebate Vigente
        #endregion Criar Parametros
        #endregion Metodos Privados
    }
}

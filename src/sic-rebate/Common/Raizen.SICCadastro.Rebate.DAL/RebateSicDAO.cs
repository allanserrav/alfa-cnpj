#region Cabeçalho do Arquivo

// <Summary>
// File Name		    : RebateSicDAO.cs
// Class Name	        : RebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 25/07/2014
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

#endregion Cabeçalho do Arquivo

#region Namespaces

using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    #region classe concreta RebateSicDAO

    /// <summary>
    /// Representa funcionalidade relacionada a RebateSicDAO
    /// </summary>
    internal partial class RebateSicDAO : IRebateSicDAO
    {
        #region Constantes

        /// <summary>
        /// Representa ordenação padrão da query Selecionar
        /// </summary>
        public const string orderByDefault = "";

        /// <summary>
        /// C_NR_SEQ_REBATE_SIC
        /// </summary>
        private const string C_NR_SEQ_REBATE_SIC = "NR_SEQ_REBATE_SIC";

        /// <summary>
        /// NM_EC_PARAMETRO_SIC
        /// </summary>
        private const string C_NM_EC_PARAMETRO_SIC = "NM_EC_PARAMETRO_SIC";

        #endregion Constantes

        #region Queries

        #region Query para Selecionar registros

        /// <summary>
        /// String com a query de seleção de registros
        /// </summary>
        private string querySelecionar = new StringBuilder().Append("SELECT {0}")
        .Append(" TB_REBATE_SIC.NR_SEQ_REBATE_SIC")
        .Append(",TB_REBATE_SIC.NR_SEQ_TIPOREBATE_SIC")
        .Append(",TB_REBATE_SIC.NR_SEQ_CLIENTE_SIC")
        .Append(",TB_REBATE_SIC.NR_IBM_REBATE_SIC")
        .Append(",TB_REBATE_SIC.DT_ASSINATURACONTRATO_REBATE_SIC")
        .Append(",TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC")
        .Append(",TB_REBATE_SIC.DT_FIMVIGENCIA_REBATE_SIC")
        .Append(",TB_REBATE_SIC.NR_CODIGOFORNECEDOR_REBATE_SIC")
        .Append(",TB_REBATE_SIC.NR_CODIGOPAGADOR_REBATE_SIC")
        .Append(",TB_REBATE_SIC.ST_CALCULO_REBATE_SIC")
        .Append(",TB_REBATE_SIC.ST_MATRIZ_REBATE_SIC")
        .Append(",TB_REBATE_SIC.DS_OBS_REBATE")
        .Append(",TB_REBATE_SIC.ST_CALCULO_RETROATIVO_SIC")
        .Append(",TB_REBATE_SIC.ST_POSSUI_CALCULO_REBATE_SIC")
        .Append(",TB_REBATE_SIC.ST_NAOENVIARSAP_REBATE_SIC")
        .Append(",TB_REBATE_SIC.VL_VOLUMECONTRATADO_REBATE_SIC")
        .Append(",TB_REBATE_SIC.VL_VOLUMELIMITE_REBATE_SIC")
        .Append(",TB_REBATE_SIC.ST_CONTROLEVOLUME")
        .Append(",TB_REBATE_SIC.ST_PAGAMENTO_PROPORCIONAL")
        .Append(" FROM TB_REBATE_SIC")
        .Append(" {1}")
        .Append(" {2}")
        .Append("").ToString();

        #region Query Ibm pelo RebateSic

        /// <summary>
        /// Selectionar IBM por Rebate
        /// </summary>
        private const string qryIbmRebateSic = @"
        SELECT
            NR_IBM_REBATE_SIC
        FROM
            TB_REBATE_SIC
        WHERE
            NR_SEQ_REBATE_SIC = @NR_SEQ_REBATE_SIC";

        /// <summary>
        /// qryParametroSic
        /// </summary>
        private string qryParametroSic = @"
        SELECT
            DS_EC_PARAMETRO_VALOR_SIC
        FROM
            TB_EC_PARAMETRO_SIC
        WHERE
            NM_EC_PARAMETRO_SIC = @NM_EC_PARAMETRO_SIC";

        #endregion Query Ibm pelo RebateSic

        #endregion Query para Selecionar registros

        #endregion Queries

        #region Metodos Publicos

        #region Selecionar

        /// <summary>
        /// Selecionar os dados de RebateSic
        /// </summary>
        /// <param name="rebateSic">Instância de <see cref="RebateSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de RebateSic</returns>
        public IList<RebateSic> Selecionar(RebateSic rebateSic, int numeroLinhas, string ordem)
        {
            IList<RebateSic> listRebateSic = new List<RebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, rebateSic, out where);
                string newQuery = string.Format(querySelecionar,
                    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
                    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
                    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listRebateSic.Add(Preencher(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listRebateSic;
        }

        /// <summary>
        /// ObterIbmPeloRebate
        /// </summary>
        /// <param name="nrSeqRebate"></param>
        /// <returns></returns>
        public string ObterIbmPeloRebate(int nrSeqRebate)
        {
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                List<DbParameter> paramss = new List<DbParameter>();
                var p = databaseManager.CreateInParameter(DbType.Int32, C_NR_SEQ_REBATE_SIC, nrSeqRebate);
                paramss.Add(p);
                var ret = databaseManager.GetScalar(qryIbmRebateSic, paramss);
                databaseManager.CloseConnection();

                if (ret == null)
                    return string.Empty;
                else
                    return ret.ToString();
            }
        }

        /// <summary>
        /// Método ObterParametroSic
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        public string ObterParametroSic(string chave)
        {
            using (var databaseManager = new DatabaseManager("SICCadastro"))
            {
                List<DbParameter> paramss = new List<DbParameter>();
                var p = databaseManager.CreateInParameter(DbType.String, C_NM_EC_PARAMETRO_SIC, chave);
                paramss.Add(p);
                var str = databaseManager.GetScalar(qryParametroSic, paramss);
                if (str != null)
                    return str.ToString();
                databaseManager.CloseConnection();
            }

            return String.Empty;
        }

        #endregion Selecionar

        #endregion Metodos Publicos

        #region Metodos Privados

        #region Metodos Gerais

        #region Preencher

        /// <summary>
        /// Preenche o objeto RebateSic a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto RebateSic preenchido</returns>
        protected RebateSic Preencher(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException("reader"));
            RebateSic rebateSic = new RebateSic();
            rebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
            rebateSic.NrSeqTiporebateSic = reader.GetNullableInt32(C_NrSeqTiporebateSic);
            rebateSic.NrSeqClienteSic = reader.GetNullableInt32(C_NrSeqClienteSic);
            rebateSic.NrIbmRebateSic = reader.GetString(C_NrIbmRebateSic);
            rebateSic.DtAssinaturacontratoRebateSic = reader.GetNullableDateTime(C_DtAssinaturacontratoRebateSic);
            rebateSic.DtIniciovigenciaRebateSic = reader.GetNullableDateTime(C_DtIniciovigenciaRebateSic);
            rebateSic.DtFimvigenciaRebateSic = reader.GetNullableDateTime(C_DtFimvigenciaRebateSic);
            rebateSic.NrCodigofornecedorRebateSic = reader.GetString(C_NrCodigofornecedorRebateSic);
            rebateSic.NrCodigopagadorRebateSic = reader.GetString(C_NrCodigopagadorRebateSic);
            rebateSic.StCalculoRebateSic = reader.GetNullableBoolean(C_StCalculoRebateSic);
            rebateSic.StMatrizRebateSic = reader.GetNullableBoolean(C_StMatrizRebateSic);
            rebateSic.DsObsRebate = reader.GetString(C_DsObsRebate);
            rebateSic.StCalculoRetroativoSic = reader.GetNullableBoolean(C_StCalculoRetroativoSic);
            rebateSic.StPossuiCalculoRebateSic = reader.GetNullableBoolean(C_StPossuiCalculoRebateSic);
            rebateSic.StNaoenviarsapRebateSic = reader.GetNullableBoolean(C_StNaoenviarsapRebateSic);
            rebateSic.VlVolumecontratadoRebateSic = reader.GetNullableDecimal(C_VlVolumecontratadoRebateSic);
            rebateSic.VlVolumelimiteRebateSic = reader.GetNullableDecimal(C_VlVolumelimiteRebateSic);
            rebateSic.StControlevolume = reader.GetNullableBoolean(C_StControlevolume);
            rebateSic.StPagamentoProporcional = reader.GetNullableBoolean(C_StPagamentoProporcional);
            return rebateSic;
        }

        #endregion Preencher

        #endregion Metodos Gerais

        #region Criar Parametros

        #region Criar Parametros Selecionar

        /// <summary>
        /// Criar Parametros Selecionar
        /// </summary>
        /// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
        /// <param name="rebateSic">Instance of <see cref="RebateSic"/></param>
        /// <returns>Lista de DbParameter</returns>
        private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, RebateSic rebateSic, out string where)
        {
            List<DbParameter> dbParams = new List<DbParameter>();
            where = "";
            if (rebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.NrSeqRebateSic, ref where));
            if (rebateSic.NrSeqTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REBATE_SIC", C_NrSeqTiporebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.NrSeqTiporebateSic, ref where));
            if (rebateSic.NrSeqClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REBATE_SIC", C_NrSeqClienteSic, DatabaseManager.SQLOperation.Equal, rebateSic.NrSeqClienteSic, ref where));
            if (rebateSic.NrIbmRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REBATE_SIC", C_NrIbmRebateSic, DatabaseManager.SQLOperation.Like, "%" + rebateSic.NrIbmRebateSic + "%", ref where));
            if (rebateSic.DtAssinaturacontratoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_REBATE_SIC", C_DtAssinaturacontratoRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.DtAssinaturacontratoRebateSic, ref where));
            if (rebateSic.DtIniciovigenciaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_REBATE_SIC", C_DtIniciovigenciaRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.DtIniciovigenciaRebateSic, ref where));
            if (rebateSic.DtFimvigenciaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_REBATE_SIC", C_DtFimvigenciaRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.DtFimvigenciaRebateSic, ref where));
            if (rebateSic.NrCodigofornecedorRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REBATE_SIC", C_NrCodigofornecedorRebateSic, DatabaseManager.SQLOperation.Like, "%" + rebateSic.NrCodigofornecedorRebateSic + "%", ref where));
            if (rebateSic.NrCodigopagadorRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REBATE_SIC", C_NrCodigopagadorRebateSic, DatabaseManager.SQLOperation.Like, "%" + rebateSic.NrCodigopagadorRebateSic + "%", ref where));
            if (rebateSic.StCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StCalculoRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.StCalculoRebateSic, ref where));
            if (rebateSic.StMatrizRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StMatrizRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.StMatrizRebateSic, ref where));
            if (rebateSic.DsObsRebate != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_REBATE_SIC", C_DsObsRebate, DatabaseManager.SQLOperation.Like, "%" + rebateSic.DsObsRebate + "%", ref where));
            if (rebateSic.StCalculoRetroativoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StCalculoRetroativoSic, DatabaseManager.SQLOperation.Equal, rebateSic.StCalculoRetroativoSic, ref where));
            if (rebateSic.StPossuiCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StPossuiCalculoRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.StPossuiCalculoRebateSic, ref where));
            if (rebateSic.StNaoenviarsapRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StNaoenviarsapRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.StNaoenviarsapRebateSic, ref where));
            if (rebateSic.VlVolumecontratadoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REBATE_SIC", C_VlVolumecontratadoRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.VlVolumecontratadoRebateSic, ref where));
            if (rebateSic.VlVolumelimiteRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REBATE_SIC", C_VlVolumelimiteRebateSic, DatabaseManager.SQLOperation.Equal, rebateSic.VlVolumelimiteRebateSic, ref where));
            if (rebateSic.StControlevolume != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StControlevolume, DatabaseManager.SQLOperation.Equal, rebateSic.StControlevolume, ref where));
            if (rebateSic.StPagamentoProporcional != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REBATE_SIC", C_StPagamentoProporcional, DatabaseManager.SQLOperation.Equal, rebateSic.StPagamentoProporcional, ref where));
            return dbParams;
        }

        #endregion Criar Parametros Selecionar

        #endregion Criar Parametros

        #endregion Metodos Privados
    }

    #endregion classe concreta RebateSicDAO

}
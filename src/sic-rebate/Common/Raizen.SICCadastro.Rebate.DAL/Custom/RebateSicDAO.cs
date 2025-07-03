using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.Util;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Complemento de RebateSicDAO
    /// </summary>
    internal partial class RebateSicDAO
    {
        #region Constantes

        private const string C_NrIbmClienteSic = "NR_IBM_CLIENTE_SIC";
        private const string C_NrCnpjClienteSic = "NR_CNPJ_CLIENTE_SIC";
        private const string C_NmRazsociallojaFranquiaSic = "NM_RAZSOCIALLOJA_FRANQUIA_SIC";
        private const string C_NmTiporebateSic = "NM_TIPOREBATE_SIC";
        private const string C_NrSeqEmpresaSic = "NR_SEQ_EMPRESA_SIC";
        private const string C_NmEmpresaSic = "NM_EMPRESA_SIC";
        private const string C_NrCegrpostoClienteSic = "NR_CEGRPOSTO_CLIENTE_SIC";
        private const string C_NmGalojaClienteSic = "NM_GALOJA_CLIENTE_SIC";
        private const string C_NmGtlojaClienteSic = "NM_GTLOJA_CLIENTE_SIC";
        private const string C_NrSeqStatusSic = "NR_SEQ_STATUS_SIC";
        private const string C_NmStatusSic = "NM_STATUS_SIC";

        #endregion Constantes

        #region Queries

        #region Query para Selecionar Rebates Por Meses Grupo

        /// <summary>
        /// Selecionar Rebate Por Intervalo de Data da Assinatura do Contratos
        /// </summary>
        private string querySelecionarVigentes = new StringBuilder()
        .AppendLine("SELECT DISTINCT")        
        .AppendLine(" TB_REBATE_SIC.NR_SEQ_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.NR_SEQ_TIPOREBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.NR_SEQ_CLIENTE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.NR_IBM_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.DT_ASSINATURACONTRATO_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.DT_FIMVIGENCIA_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.NR_CODIGOFORNECEDOR_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.NR_CODIGOPAGADOR_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.ST_CALCULO_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.ST_MATRIZ_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.DS_OBS_REBATE")
        .AppendLine(" ,TB_REBATE_SIC.ST_CALCULO_RETROATIVO_SIC")
        .AppendLine(" ,TB_REBATE_SIC.ST_POSSUI_CALCULO_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.ST_NAOENVIARSAP_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.VL_VOLUMECONTRATADO_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.VL_VOLUMELIMITE_REBATE_SIC")
        .AppendLine(" ,TB_REBATE_SIC.ST_CONTROLEVOLUME")
        .AppendLine(" ,TB_REBATE_SIC.ST_PAGAMENTO_PROPORCIONAL")
        .AppendLine(" FROM TB_REBATE_SIC")
        .AppendLine(" JOIN TB_TIPOREBATE_SIC TR ON TR.NR_SEQ_TIPOREBATE_SIC = TB_REBATE_SIC.NR_SEQ_TIPOREBATE_SIC")
        .AppendLine(" WHERE")
        .AppendLine(" ( ")
        .AppendLine("     (TB_REBATE_SIC.ST_CALCULO_REBATE_SIC = 0 AND ( ")
        .AppendLine("         (UPPER(LTRIM(RTRIM(TR.NM_TIPOREBATE_SIC))) = 'GLOBAL MEDIA VOLUME' AND TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC <= '{0}' AND TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC >= '{1}') OR ")
        .AppendLine("         (TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC <= '{2}' AND TB_REBATE_SIC.DT_FIMVIGENCIA_REBATE_SIC >= '{3}'))) OR	")
        .AppendLine("     (TB_REBATE_SIC.ST_CALCULO_REBATE_SIC = 1 AND TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC <= '{4}' AND TB_REBATE_SIC.DT_FIMVIGENCIA_REBATE_SIC >= '{5}') ")
        .AppendLine(" ) ")
        //.AppendLine(" AND (TB_REBATE_SIC.ST_CALCULO_RETROATIVO_SIC IS NULL OR TB_REBATE_SIC.ST_CALCULO_RETROATIVO_SIC = 0)") //Somente null ou 0 (false)
        .AppendLine(" AND (SELECT TOP 1 CASE WHEN TB_STATUS_SIC.NM_STATUS_SIC = 'ACEITO' THEN 1 ELSE 0 END")
        .AppendLine(" FROM     TB_CLIENTESTATUS_SIC")
        .AppendLine(" JOIN     TB_STATUS_SIC ON TB_STATUS_SIC.NR_SEQ_STATUS_SIC = TB_CLIENTESTATUS_SIC.NR_SEQ_STATUS_SIC")
        .AppendLine(" WHERE    TB_CLIENTESTATUS_SIC.NR_SEQ_CLIENTE_SIC = TB_REBATE_SIC.NR_SEQ_CLIENTE_SIC")
        .AppendLine(" ORDER BY TB_CLIENTESTATUS_SIC.NR_SEQ_CLIENTESTAUS_SIC DESC) = 1")
        .AppendLine("").ToString();

        #endregion Query para Selecionar Rebates Por Meses Grupo

        #region Query para Selecionar Rebates Reajuste

        /// <summary>
        /// Selecionar Rebate para REajuste
        /// </summary>
        private string querySelecionarVigentesReajuste = new StringBuilder()
        .AppendLine("SELECT DISTINCT ")
        .AppendLine(" REBATE.NR_SEQ_REBATE_SIC")
        .AppendLine(" ,REBATE.NR_SEQ_TIPOREBATE_SIC")
        .AppendLine(" ,REBATE.NR_SEQ_CLIENTE_SIC")
        .AppendLine(" ,REBATE.NR_IBM_REBATE_SIC")
        .AppendLine(" ,REBATE.DT_ASSINATURACONTRATO_REBATE_SIC")
        .AppendLine(" ,REBATE.DT_INICIOVIGENCIA_REBATE_SIC")
        .AppendLine(" ,REBATE.DT_FIMVIGENCIA_REBATE_SIC")
        .AppendLine(" ,REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC")
        .AppendLine(" ,REBATE.NR_CODIGOPAGADOR_REBATE_SIC")
        .AppendLine(" ,REBATE.ST_CALCULO_REBATE_SIC")
        .AppendLine(" ,REBATE.ST_MATRIZ_REBATE_SIC")
        .AppendLine(" ,REBATE.DS_OBS_REBATE")
        .AppendLine(" ,REBATE.ST_CALCULO_RETROATIVO_SIC")
        .AppendLine(" ,REBATE.ST_POSSUI_CALCULO_REBATE_SIC")
        .AppendLine(" ,REBATE.ST_NAOENVIARSAP_REBATE_SIC")
        .AppendLine(" ,REBATE.VL_VOLUMECONTRATADO_REBATE_SIC")
        .AppendLine(" ,REBATE.VL_VOLUMELIMITE_REBATE_SIC")
        .AppendLine(" ,REBATE.ST_CONTROLEVOLUME")
        .AppendLine(" ,REBATE.ST_PAGAMENTO_PROPORCIONAL")
        .AppendLine("   FROM TB_REBATE_SIC REBATE ")
        .AppendLine("   JOIN TB_REAJUSTE_REBATEXFRANQUIA_SIC REAJUSTE ON REAJUSTE.NR_SEQ_REBATE_SIC = REBATE.NR_SEQ_REBATE_SIC ")
        .AppendLine("   WHERE REBATE.DT_INICIOVIGENCIA_REBATE_SIC <= GETDATE() AND REBATE.DT_FIMVIGENCIA_REBATE_SIC >= GETDATE() ")
        .AppendLine("").ToString();

        #endregion Query para Selecionar Rebates Reajuste

        #region Query para Selecionar Rebate Relatorio

        /// <summary>
        /// Selecionar Relatio de Rebate
        /// </summary>
        private string querySelecionarRelatorioRebate = new StringBuilder()
            .AppendLine("SELECT DISTINCT ")
            .AppendLine("   REBATE.NR_SEQ_REBATE_SIC, ")
            .AppendLine("   CLIENTE.NR_SEQ_CLIENTE_SIC, ")
            .AppendLine("   CLIENTE.NR_IBM_CLIENTE_SIC, ")
            .AppendLine("   CLIENTE.NR_CNPJ_CLIENTE_SIC, ")
            .AppendLine("   CLIENTE.NM_RAZSOCIALLOJA_FRANQUIA_SIC, ")
            .AppendLine("   REBATE.NR_SEQ_TIPOREBATE_SIC, ")
            .AppendLine("   TIPOREBATE.NM_TIPOREBATE_SIC, ")
            .AppendLine("   CLIENTE.NR_SEQ_EMPRESA_SIC, ")
            .AppendLine("   EMPRESA.NM_EMPRESA_SIC, ")
            .AppendLine("   CLIENTE.NR_CEGRPOSTO_CLIENTE_SIC, ")
            .AppendLine("   REBATE.NR_CODIGOPAGADOR_REBATE_SIC, ")
            .AppendLine("   REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC, ")
            .AppendLine("   CLIENTE.NM_GALOJA_CLIENTE_SIC, ")
            .AppendLine("   CLIENTE.NM_GTLOJA_CLIENTE_SIC, ")
            .AppendLine("   REBATE.DT_ASSINATURACONTRATO_REBATE_SIC, ")
            .AppendLine("   REBATE.DT_INICIOVIGENCIA_REBATE_SIC, ")
            .AppendLine("   REBATE.DT_FIMVIGENCIA_REBATE_SIC, ")
            .AppendLine("   REBATE.ST_CALCULO_REBATE_SIC, ")
            .AppendLine("   CLISTATUS.NR_SEQ_STATUS_SIC, ")
            .AppendLine("   NMSTATUS.NM_STATUS_SIC		 ")
            .AppendLine("   FROM TB_CLIENTE_SIC CLIENTE ")
            .AppendLine("       JOIN TB_EMPRESA_SIC EMPRESA ON EMPRESA.NR_SEQ_EMPRESA_SIC = CLIENTE.NR_SEQ_EMPRESA_SIC ")
            .AppendLine("       JOIN TB_REBATE_SIC REBATE ON REBATE.NR_SEQ_CLIENTE_SIC = CLIENTE.NR_SEQ_CLIENTE_SIC ")
            .AppendLine("       JOIN TB_TIPOREBATE_SIC TIPOREBATE ON TIPOREBATE.NR_SEQ_TIPOREBATE_SIC = REBATE.NR_SEQ_TIPOREBATE_SIC ")
            .AppendLine("       JOIN TB_CLIENTESTATUS_SIC CLISTATUS ON CLISTATUS.NR_SEQ_CLIENTE_SIC = CLIENTE.NR_SEQ_CLIENTE_SIC AND ")
            .AppendLine("           CLISTATUS.NR_SEQ_STATUS_SIC IN (SELECT TOP (1) NR_SEQ_STATUS_SIC FROM TB_CLIENTESTATUS_SIC ")
            .AppendLine("           WHERE(NR_SEQ_CLIENTE_SIC = CLIENTE.NR_SEQ_CLIENTE_SIC) ORDER  BY NR_SEQ_CLIENTESTAUS_SIC DESC) ")
            .AppendLine("       JOIN TB_STATUS_SIC NMSTATUS ON NMSTATUS.NR_SEQ_STATUS_SIC = CLISTATUS.NR_SEQ_STATUS_SIC ")
            .AppendLine("   WHERE 1=1 ")
            .AppendLine("").ToString();

        #endregion Query para Selecionar Rebate Relatorio

        #endregion Queries

        #region Metodos Publicos

        #region Selecionar SelecionarPorGrupoMensal

        /// <summary>
        /// Seleciona Lista de Rebates Vigentes
        /// </summary>
        /// <param name="meses">lista de meses</param>
        /// <returns></returns>
        public IList<RebateSic> SelecionarVigentes()
        {
            IList<RebateSic> listRebateSic = new List<RebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new RebateSic(), out where);

                DateTime dataAtual = RebateUtil.GetDataAtual();
                DateTime dataInicioMensal = RebateUtil.GetInicioPeriodoMensal(dataAtual);
                DateTime dataFimMensal = RebateUtil.GetFimPeriodoMensal(dataInicioMensal);
                DateTime dataInicioTrimestral = RebateUtil.GetInicioPeriodoTrimestral(dataAtual);
                DateTime dataFimTrimestral = RebateUtil.GetFimPeriodoMensal(dataInicioTrimestral);

                string newQuery = string.Format(querySelecionarVigentes,
                    RebateUtil.GetFimPeriodoMensal(dataFimMensal.AddMonths(1)).ToString("yyyy-MM-dd"), dataInicioMensal.AddMonths(1).ToString("yyyy-MM-dd"),
                    dataFimMensal.ToString("yyyy-MM-dd"), dataInicioMensal.ToString("yyyy-MM-dd"),
                    dataFimTrimestral.ToString("yyyy-MM-dd"), dataInicioTrimestral.ToString("yyyy-MM-dd"));

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

        #endregion Selecionar SelecionarPorGrupoMensal

        #region Selecionar SelecionarVigentesReajuste

        /// <summary>
        /// Seleciona Lista de Rebates Reajuste
        /// </summary>
        /// <param name="meses">lista de meses</param>
        /// <returns></returns>
        public IList<RebateSic> SelecionarVigentesReajuste()
        {
            IList<RebateSic> listRebateSic = new List<RebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new RebateSic(), out where);

                string newQuery = querySelecionarVigentesReajuste;

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                    while (dbDataReader.Read())
                        listRebateSic.Add(Preencher(dbDataReader));

                databaseManager.CloseConnection();
            }
            return listRebateSic;
        }

        #endregion Selecionar SelecionarVigentesReajuste

        #region Selecionar SelecionarRebateRelatorio

        /// <summary>
        /// Seleciona Lista de Rebate Relatorio
        /// </summary>
        public IList<InformacaoRebateRel> SelecionarRelatorioInformacoesRebate(InformacaoRebateRelFiltro filtro)
        {
            IList<InformacaoRebateRel> listInformacaoRebateSic = new List<InformacaoRebateRel>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new RebateSic(), out where);

                string newQuery = querySelecionarRelatorioRebate;

                if (!string.IsNullOrEmpty(filtro.CodigoIBM))
                    newQuery = string.Concat(newQuery, string.Format("AND CLIENTE.NR_IBM_CLIENTE_SIC = '{0}' \n", filtro.CodigoIBM.Trim()));

                newQuery = string.Concat(newQuery, string.Format("AND CLISTATUS.NR_SEQ_STATUS_SIC IN ({0}) \n", filtro.ListaStatus));
                newQuery = string.Concat(newQuery, string.Format("AND REBATE.NR_SEQ_TIPOREBATE_SIC IN ({0}) \n", filtro.ListaTipoRebate));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                    while (dbDataReader.Read())
                        listInformacaoRebateSic.Add(PreencherInformacaoRebateRel(dbDataReader));

                databaseManager.CloseConnection();
            }
            return listInformacaoRebateSic;
        }

        #endregion Selecionar SelecionarRebateRelatorio

        #region AtualizarComTrasacao

        /// <summary>
        /// Atualizar RebateSic
        /// </summary>
        public void AtualizarComTransacao(RebateSic rebateSic, DatabaseManager databaseManager)
        {
            Atualizar(rebateSic, databaseManager);
        }

        #endregion AtualizarComTrasacao

        #region Selecionar Volume Comprado

        public decimal SelecionarVolumeComprado(string IBM, DateTime? de, DateTime? ate)
        {
            decimal result = 0M;

            var dataAte = ate.HasValue ? ate.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd");
            var dataAteAnoMes = ate.HasValue ? ate.Value.ToString("yyyyMM") : DateTime.Now.ToString("yyyyMM");

            string queryBase = $@"

                DECLARE @DATA_DE VARCHAR(10)
                
                ;WITH CTE_CONTRATO AS (
                    SELECT TOP 1 CONTRATO.DT_INICIO_VIGENCIA_SIC
                    FROM TB_CONTRATO_SIC AS CONTRATO
                    INNER JOIN TB_TIPO_CONTRATO_SIC AS TIPO ON CONTRATO.NR_TIPO_CONTRATO_SIC = TIPO.NR_TIPO_CONTRATO_SIC
                    WHERE CONTRATO.NR_IBM_CLIENTE_SIC = '{IBM}' 
		                AND CAST('{dataAte}' AS DATE) BETWEEN CONTRATO.DT_INICIO_VIGENCIA_SIC AND CONTRATO.DT_FIM_VIGENCIA_SIC 
		                AND (SELECT DT_INICIOVIGENCIA_REBATE_SIC FROM TB_REBATE_SIC WHERE NR_IBM_REBATE_SIC = '{IBM}') BETWEEN CONTRATO.DT_INICIO_VIGENCIA_SIC AND CONTRATO.DT_FIM_VIGENCIA_SIC 
		                AND TIPO.ST_VULNERABILIDADE_SIC = 'S' 
		                AND CONTRATO.NR_STATUS_CONTRATO_SIC = 'A' 
		                GROUP BY CONTRATO.DT_INICIO_VIGENCIA_SIC 
		                ORDER BY CONTRATO.DT_INICIO_VIGENCIA_SIC DESC 
                )

                SELECT @DATA_DE = CONVERT(VARCHAR(10), DT_INICIO_VIGENCIA_SIC, 23) FROM CTE_CONTRATO

                SELECT  COALESCE (SUM(QT_MATERIAL_VENDIDO_SIC),0)
                FROM fncMargemVolumeConsolidado('{IBM}', @DATA_DE)
                WHERE NR_PRODUTO_REF_SIC IN (SELECT NR_GRUPO_PRODUTO_REF_SIC FROM TB_GRUPO_PRODUTO_SIC WHERE NR_GRUPO_PRODUTO_REF_SIC IS NOT NULL) AND
                    NR_ANO_MES_LANCAMENTO_SIC <= '{dataAteAnoMes}'
            ";

            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    object obj = databaseManager.GetScalar(queryBase, new List<DbParameter>());
                    result = (decimal)obj;
                    result = result / 1000M; //ALTERANDO DE LITROS PARA METROS CÚBICOS
                }
                catch(Exception ex) { System.Diagnostics.Debug.WriteLineIf(ex != null, ex.Message); }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
            return result;
        }

        #endregion Selecionar Volume Comprado

        #endregion Metodos Publicos

        #region Metodos Privados

        #region Preencher

        /// <summary>
        /// Preenche o objeto InformacaoRebateRel a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto InformacaoRebateRel preenchido</returns>
        protected InformacaoRebateRel PreencherInformacaoRebateRel(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException("reader"));
            InformacaoRebateRel informacaoRebateRel = new InformacaoRebateRel();
            informacaoRebateRel.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
            informacaoRebateRel.NrSeqClienteSic = reader.GetNullableInt32(C_NrSeqClienteSic);
            informacaoRebateRel.NrIbmClienteSic = reader.GetString(C_NrIbmClienteSic);
            informacaoRebateRel.NrCnpjClienteSic = reader.GetString(C_NrCnpjClienteSic);
            informacaoRebateRel.NmRazsociallojaFranquiaSic = reader.GetString(C_NmRazsociallojaFranquiaSic);
            informacaoRebateRel.NrSeqTiporebateSic = reader.GetNullableInt32(C_NrSeqTiporebateSic);
            informacaoRebateRel.NmTiporebateSic = reader.GetString(C_NmTiporebateSic);
            informacaoRebateRel.NrSeqEmpresaSic = reader.GetNullableInt32(C_NrSeqEmpresaSic);
            informacaoRebateRel.NmEmpresaSic = reader.GetString(C_NmEmpresaSic);
            informacaoRebateRel.NrCegrpostoClienteSic = reader.GetString(C_NrCegrpostoClienteSic);
            informacaoRebateRel.NrCodigopagadorRebateSic = reader.GetString(C_NrCodigopagadorRebateSic);
            informacaoRebateRel.NrCodigofornecedorRebateSic = reader.GetString(C_NrCodigofornecedorRebateSic);
            informacaoRebateRel.NmGalojaClienteSic = reader.GetString(C_NmGalojaClienteSic);
            informacaoRebateRel.NmGtlojaClienteSic = reader.GetString(C_NmGtlojaClienteSic);
            informacaoRebateRel.DtAssinaturacontratoRebateSic = reader.GetNullableDateTime(C_DtAssinaturacontratoRebateSic);
            informacaoRebateRel.DtIniciovigenciaRebateSic = reader.GetNullableDateTime(C_DtIniciovigenciaRebateSic);
            informacaoRebateRel.DtFimvigenciaRebateSic = reader.GetNullableDateTime(C_DtFimvigenciaRebateSic);
            informacaoRebateRel.StCalculoRebateSic = reader.GetNullableBoolean(C_StCalculoRebateSic);
            informacaoRebateRel.NrSeqStatusSic = reader.GetNullableInt32(C_NrSeqStatusSic);
            informacaoRebateRel.NmStatusSic = reader.GetString(C_NmStatusSic);
            return informacaoRebateRel;
        }

        #endregion Preencher

        #endregion Metodos Privados
    }
}
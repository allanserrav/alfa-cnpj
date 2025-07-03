#region Cabeçalho do Arquivo

// <Summary>
// File Name		    : CalculoRebateSicDAO.cs
// Class Name	        : CalculoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
using COSAN.Framework.Factory;
using COSAN.Framework.Util;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    #region classe concreta CalculoRebateSicDAO

    /// <summary>
    /// Representa funcionalidade relacionada a CalculoRebateSicDAO
    /// </summary>
    internal partial class CalculoRebateSicDAO : ICalculoRebateSicDAO
    {
        #region Constantes

        private const string C_NR_SEQ_CALCULO_REBATE_SIC = "NR_SEQ_CALCULO_REBATE_SIC";
        private const string C_NR_SEQ_REBATE_SIC = "NR_SEQ_REBATE_SIC";
        private const string C_NR_IBM_REBATE_SIC = "NR_IBM_REBATE_SIC";
        private const string C_NR_CODIGOFORNECEDOR_REBATE_SIC = "NR_CODIGOFORNECEDOR_REBATE_SIC";
        private const string C_NM_RAZSOCIALLOJA_FRANQUIA_SIC = "NM_RAZSOCIALLOJA_FRANQUIA_SIC";
        private const string C_NM_CANAL_CLIENTE_SIC = "NM_CANAL_CLIENTE_SIC";
        private const string C_VL_BONIFICACAO_TOTAL_SIC = "VL_BONIFICACAO_TOTAL_SIC";
        private const string C_BONIFICACAO_ANTERIOR = "BONIFICACAO_ANTERIOR";
        private const string C_VL_DEBITO_SIC = "VL_DEBITO_SIC";
        private const string C_DT_PAGAMENTO_SIC = "DT_PAGAMENTO_SIC";
        private const string C_NR_SEQ_STATUS_CALCULO_REBATE_SIC = "NR_SEQ_STATUS_CALCULO_REBATE_SIC";
        private const string C_NM_STATUS_CALCULO_REBATE_SIC = "NM_STATUS_CALCULO_REBATE_SIC";
        private const string C_PERIODICIDADE_PAGAMENTO = "PERIODICIDADE_PAGAMENTO";
        private const string C_PERIODO_CALCULO = "PERIODO_CALCULO";
        private const string C_NM_TIPOREBATE_SIC = "NM_TIPOREBATE_SIC";
        private const string C_ST_APROVADO_ANALISTA_SIC = "ST_APROVADO_ANALISTA_SIC";
        private const string C_ST_ENVIADO_APROVACAO_GERENTE_SIC = "ST_ENVIADO_APROVACAO_GERENTE_SIC";
        private const string C_ST_APROVADO_GERENTE_SIC = "ST_APROVADO_GERENTE_SIC";
        private const string C_ST_ADITIVO_SIC = "ST_ADITIVO_SIC";
        private const string C_VL_VOLUME_CONSUMIDO_SIC = "VL_VOLUME_CONSUMIDO_SIC";
        private const string C_VL_VOLUME_LIMITE_REBATE_SIC = "VL_VOLUME_LIMITE_REBATE_SIC";
        private const string C_ST_ACERTO_SIC = "ST_ACERTO_SIC";

        #endregion Constantes

        #region Queries

        #region Excluir Cálculo Rebate por Período

        private string queryApagarCalculoRebatePeriodo = new StringBuilder()
            .AppendLine(" BEGIN TRAN ")
            .AppendLine("  ")
            .AppendLine(" DECLARE @NR_REBATE INT  ")
            .AppendLine(" DECLARE @DT_PERIODO_VOL_INICIO SMALLDATETIME  ")
            .AppendLine(" DECLARE @DT_PERIODO_VOL_FIM SMALLDATETIME  ")
            .AppendLine(" DECLARE @DT_PERIODO_CALCULO SMALLDATETIME  ")
            .AppendLine(" DECLARE @VL_CREDITO DECIMAL(12,3)  ")
            .AppendLine(" DECLARE @VL_SALDO_ATUAL DECIMAL(12,3)  ")
            .AppendLine(" ")
            .AppendLine(" SET @NR_REBATE = {0}  ")
            .AppendLine(" SET @DT_PERIODO_VOL_INICIO = '{1}'  ")
            .AppendLine(" SET @DT_PERIODO_VOL_FIM = '{2}'  ")
            .AppendLine(" SET @DT_PERIODO_CALCULO = '{3}'  ")
            .AppendLine(" ")
            .AppendLine(" SELECT @VL_CREDITO = (ISNULL(VL_BONIFICACAO_TOTAL_SIC,0) * (-1)) FROM TB_CALCULO_REBATE_SIC WHERE NR_SEQ_REBATE_SIC = @NR_REBATE AND ST_ADITIVO_SIC = 0 ")
            .AppendLine(" ")
            .AppendLine(" SELECT TOP 1 @VL_SALDO_ATUAL = ISNULL(VL_SALDO_ATUAL_SIC,0)  FROM TB_SALDO_REBATE_SIC WHERE NR_SEQ_REBATE_SIC = @NR_REBATE ORDER BY NR_SEQ_SALDO_REBATE_SIC DESC  ")
            .AppendLine(" ")
            .AppendLine(" INSERT INTO TB_SALDO_REBATE_SIC ")
            .AppendLine("	(NR_SEQ_REBATE_SIC, VL_LANCAMENTO_SIC, VL_SALDO_ATUAL_SIC, DT_LANCAMENTO_SIC, DS_OBS_COMPLEMENTO_SIC)  ")
            .AppendLine(" VALUES  ")
            .AppendLine("	(@NR_REBATE, ISNULL(@VL_CREDITO,0), (ISNULL((@VL_SALDO_ATUAL + @VL_CREDITO),0)), GETDATE(), ('Recálculo Bonificação Período ' + RIGHT(REPLICATE('0', 2) + LTRIM(CAST(MONTH(@DT_PERIODO_CALCULO) AS VARCHAR)), 2) + '/' + CAST(YEAR(@DT_PERIODO_CALCULO) AS VARCHAR)))  ")
            .AppendLine("  ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO ATUALIZAR SALDO' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_VOLUME_CALCULO_REBATE_FAIXA_SIC  ")
            .AppendLine(" WHERE NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC IN ")
            .AppendLine(" ( ")
            .AppendLine("	SELECT NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC  ")
            .AppendLine("	FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC  ")
            .AppendLine("	WHERE NR_SEQ_FAIXA_REBATE_HISTORICO_SIC IN (  ")
            .AppendLine("		SELECT NR_SEQ_FAIXA_REBATE_HISTORICO_SIC  FROM TB_FAIXA_REBATE_HISTORICO_SIC  WHERE NR_SEQ_REBATE_SIC = @NR_REBATE  ")
            .AppendLine("	) AND  ")
            .AppendLine("	DT_PERIODO_SIC BETWEEN @DT_PERIODO_VOL_INICIO AND @DT_PERIODO_VOL_FIM) ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER VOLUMES DAS FAIXAS DE CALCULO' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_VOLUME_MENSAL_FAIXA_REBATE_SIC WHERE  ")
            .AppendLine("	NR_SEQ_FAIXA_REBATE_HISTORICO_SIC IN (  ")
            .AppendLine("		SELECT NR_SEQ_FAIXA_REBATE_HISTORICO_SIC  FROM TB_FAIXA_REBATE_HISTORICO_SIC  WHERE NR_SEQ_REBATE_SIC = @NR_REBATE  ")
            .AppendLine("	) AND  ")
            .AppendLine("	DT_PERIODO_SIC BETWEEN @DT_PERIODO_VOL_INICIO AND @DT_PERIODO_VOL_FIM ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER VOLUMES MENSAIS DAS FAIXAS DE CALCULO' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_CALCULO_REBATE_FAIXA_SIC WHERE NR_SEQ_CALCULO_REBATE_SIC IN (  ")
            .AppendLine("	SELECT NR_SEQ_CALCULO_REBATE_SIC  ")
            .AppendLine("	FROM TB_CALCULO_REBATE_SIC  ")
            .AppendLine("	WHERE  ")
            .AppendLine("		NR_SEQ_REBATE_SIC = @NR_REBATE AND  ")
            .AppendLine("		DT_PERIODO_SIC = @DT_PERIODO_CALCULO  ")
            .AppendLine(" )  ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER AS FAIXAS DE CÁLCULO' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_CALCULO_REBATE_PROPORCIONAL_SIC WHERE NR_SEQ_CALCULO_REBATE_SIC IN (  ")
            .AppendLine("	 SELECT NR_SEQ_CALCULO_REBATE_SIC  ")
            .AppendLine("	 FROM TB_CALCULO_REBATE_SIC  ")
            .AppendLine("	 WHERE NR_SEQ_REBATE_SIC = @NR_REBATE AND DT_PERIODO_SIC = @DT_PERIODO_CALCULO  ")
            .AppendLine(" )  ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER CÁLCULOS PROPORCIONAIS' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_STATUS_CALCULO_REBATE_HISTORICO_SIC WHERE NR_SEQ_CALCULO_REBATE_SIC IN (  ")
            .AppendLine("	 SELECT NR_SEQ_CALCULO_REBATE_SIC  ")
            .AppendLine("	 FROM TB_CALCULO_REBATE_SIC  ")
            .AppendLine("	 WHERE NR_SEQ_REBATE_SIC = @NR_REBATE AND DT_PERIODO_SIC = @DT_PERIODO_CALCULO  ")
            .AppendLine(" )  ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER STATUS HISTÓRICOS' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" DELETE FROM TB_CALCULO_REBATE_SIC WHERE NR_SEQ_REBATE_SIC = @NR_REBATE AND DT_PERIODO_SIC = @DT_PERIODO_CALCULO  ")
            .AppendLine(" ")
            .AppendLine(" IF @@ERROR != 0 ")
            .AppendLine(" BEGIN ")
            .AppendLine("  ROLLBACK TRAN ")
            .AppendLine("  PRINT 'ERRO AO REMOVER CÁLCULO' ")
            .AppendLine("  RETURN ")
            .AppendLine(" END ")
            .AppendLine(" ")
            .AppendLine(" COMMIT TRAN ")
        .AppendLine("").ToString();

        #endregion Excluir Cálculo Rebate por Período

        #region Selecionar Bonificação

        /// <summary>
        /// Excluir Cálculo Rebate por Período
        /// </summary>
        private string querySelecionarBonificacaoFiltros = new StringBuilder()
            .AppendLine(" SELECT DISTINCT")
            .AppendLine(" CALCULO.NR_SEQ_CALCULO_REBATE_SIC, ")
            .AppendLine(" REBATE.NR_SEQ_REBATE_SIC, ")
            .AppendLine(" REBATE.NR_IBM_REBATE_SIC, ")
            .AppendLine(" REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC, ")
            .AppendLine(" CLIENTE.NM_RAZSOCIALLOJA_FRANQUIA_SIC, ")
            .AppendLine(" CLIENTE.NM_CANAL_CLIENTE_SIC, ")
            .AppendLine(" CALCULO.VL_BONIFICACAO_TOTAL_SIC, ")
            .AppendLine(" CASE WHEN CALCULO.ST_ADITIVO_SIC = 1 THEN 0 ELSE (SELECT TOP 1 CALCULO_ANT.VL_BONIFICACAO_TOTAL_SIC FROM TB_CALCULO_REBATE_SIC CALCULO_ANT ")
            .AppendLine("       WHERE CALCULO_ANT.NR_SEQ_CALCULO_REBATE_SIC < CALCULO.NR_SEQ_CALCULO_REBATE_SIC ")
            .AppendLine("       AND CALCULO_ANT.NR_SEQ_REBATE_SIC = CALCULO.NR_SEQ_REBATE_SIC ORDER BY CALCULO_ANT.NR_SEQ_CALCULO_REBATE_SIC DESC) END AS BONIFICACAO_ANTERIOR, ")
            .AppendLine(" (SELECT TOP 1 ISNULL(D.VL_DEBITO_SIC,0) FROM TB_DEBITO_REBATE_SIC D ")
            .AppendLine("       WHERE D.NR_SEQ_REBATE_SIC = REBATE.NR_SEQ_REBATE_SIC ")
            .AppendLine("       ORDER BY D.NR_SEQ_DEBITO_REBATE_SIC DESC) VL_DEBITO_SIC, ")
            .AppendLine(" CALCULO.DT_PAGAMENTO_SIC, ")
            .AppendLine(" CALCULO.NR_SEQ_STATUS_CALCULO_REBATE_SIC, ")
            .AppendLine(" ST.NM_STATUS_CALCULO_REBATE_SIC AS NM_STATUS_CALCULO_REBATE_SIC,")
            .AppendLine(" REBATE.ST_CALCULO_REBATE_SIC PERIODICIDADE_PAGAMENTO, ")
            .AppendLine(" CALCULO.DT_PERIODO_SIC PERIODO_CALCULO, ")
            .AppendLine(" TPREBATE.NM_TIPOREBATE_SIC, ")
            .AppendLine(" CALCULO.ST_APROVADO_ANALISTA_SIC, ")
            .AppendLine(" CALCULO.ST_ENVIADO_APROVACAO_GERENTE_SIC, ")
            .AppendLine(" CALCULO.ST_APROVADO_GERENTE_SIC, ")
            .AppendLine(" CALCULO.ST_ADITIVO_SIC ")
            .AppendLine(" , CALCULO.VL_VOLUME_CONSUMIDO_SIC ")
            .AppendLine(" , CASE ISNULL(REBATE.VL_VOLUMELIMITE_REBATE_SIC,0) ")
            .AppendLine("       WHEN 0 THEN REBATE.VL_VOLUMECONTRATADO_REBATE_SIC ")
            .AppendLine("       ELSE REBATE.VL_VOLUMELIMITE_REBATE_SIC ")
            .AppendLine(" END AS VL_VOLUME_LIMITE_REBATE_SIC ")
            .AppendLine(", CALCULO.ST_ACERTO_SIC ")
            .AppendLine(" FROM TB_CALCULO_REBATE_SIC CALCULO ")
            .AppendLine(" JOIN	TB_REBATE_SIC REBATE ON REBATE.NR_SEQ_REBATE_SIC = CALCULO.NR_SEQ_REBATE_SIC ")
            .AppendLine(" JOIN	TB_CLIENTE_SIC CLIENTE ON CLIENTE.NR_SEQ_CLIENTE_SIC = REBATE.NR_SEQ_CLIENTE_SIC ")
            .AppendLine(" JOIN	TB_STATUS_CALCULO_REBATE_SIC ST ON ST.NR_SEQ_STATUS_CALCULO_REBATE_SIC = CALCULO.NR_SEQ_STATUS_CALCULO_REBATE_SIC ")
            .AppendLine(" JOIN	TB_TIPOREBATE_SIC TPREBATE on TPREBATE.NR_SEQ_TIPOREBATE_SIC = REBATE.NR_SEQ_TIPOREBATE_SIC ")
            .AppendLine(" WHERE 1=1 ")
            .Append("").ToString();

        #endregion Selecionar Bonificação

        #region Selecionar Bonificação Retroativo

        /// <summary>
        /// Excluir Cálculo Rebate por Período
        /// </summary>
        private string querySelecionarRebateSemCalculo = new StringBuilder()
            .AppendLine(" SELECT DISTINCT ")            
            .AppendLine(" REBATE.NR_SEQ_REBATE_SIC AS NR_SEQ_CALCULO_REBATE_SIC, ") //Por ser retroativo, ao invés de retornar 0 retornamos o próprio codigo do rebate como sendo o código do cálculo
            .AppendLine(" REBATE.NR_SEQ_REBATE_SIC, ")
            .AppendLine(" REBATE.NR_IBM_REBATE_SIC, ")
            .AppendLine(" REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC, ")
            .AppendLine(" CLIENTE.NM_RAZSOCIALLOJA_FRANQUIA_SIC, ")
            .AppendLine(" CLIENTE.NM_CANAL_CLIENTE_SIC, ")
            .AppendLine(" NULL AS VL_BONIFICACAO_TOTAL_SIC, ")
            .AppendLine(" NULL AS BONIFICACAO_ANTERIOR, ")
            .AppendLine(" NULL AS VL_DEBITO_SIC, ")
            .AppendLine(" NULL AS DT_PAGAMENTO_SIC, ")
            .AppendLine(" NULL AS NR_SEQ_STATUS_CALCULO_REBATE_SIC, ")
            .AppendLine(" 'Calculo Retroativo' AS  NM_STATUS_CALCULO_REBATE_SIC, ")
            .AppendLine(" REBATE.ST_CALCULO_REBATE_SIC PERIODICIDADE_PAGAMENTO, ")
            .AppendLine(" NULL AS PERIODO_CALCULO, ")
            .AppendLine(" TPREBATE.NM_TIPOREBATE_SIC, ")
            .AppendLine(" NULL AS ST_APROVADO_ANALISTA_SIC, ")
            .AppendLine(" NULL AS ST_ENVIADO_APROVACAO_GERENTE_SIC, ")
            .AppendLine(" NULL AS ST_APROVADO_GERENTE_SIC, ")
            .AppendLine(" CALCULO.ST_ADITIVO_SIC ")
            .AppendLine(" , CALCULO.VL_VOLUME_CONSUMIDO_SIC ")
            .AppendLine(" , CASE ISNULL(REBATE.VL_VOLUMELIMITE_REBATE_SIC,0) ")
            .AppendLine("       WHEN 0 THEN REBATE.VL_VOLUMECONTRATADO_REBATE_SIC ")
            .AppendLine("       ELSE REBATE.VL_VOLUMELIMITE_REBATE_SIC ")
            .AppendLine(" END AS VL_VOLUME_LIMITE_REBATE_SIC ")
            .AppendLine(", CALCULO.ST_ACERTO_SIC ")
            .AppendLine(" FROM       TB_CALCULO_REBATE_SIC CALCULO ")
            .AppendLine(" RIGHT JOIN TB_REBATE_SIC REBATE ON REBATE.NR_SEQ_REBATE_SIC = CALCULO.NR_SEQ_REBATE_SIC ")
            .AppendLine(" JOIN	     TB_CLIENTE_SIC CLIENTE ON CLIENTE.NR_SEQ_CLIENTE_SIC = REBATE.NR_SEQ_CLIENTE_SIC ")
            .AppendLine(" JOIN	     TB_TIPOREBATE_SIC TPREBATE on TPREBATE.NR_SEQ_TIPOREBATE_SIC = REBATE.NR_SEQ_TIPOREBATE_SIC ")
            .AppendLine(" WHERE  (REBATE.ST_CALCULO_RETROATIVO_SIC = 1) AND ")
            .AppendLine("   ('{0}'='NULL' OR REBATE.NR_IBM_REBATE_SIC = '{0}') AND ")
            .AppendLine("   (REBATE.NR_SEQ_TIPOREBATE_SIC IN ({1})) ")
            .AppendLine("").ToString();

        #endregion Selecionar Bonificação Retroativo

        #endregion Queries

        #region Metodos Publicos

        #region IncluirCalculoBonificacaoLista

        /// <summary>
        /// Insere na base os cálculos de bonificação para um período
        /// </summary>
        /// <param name="listVolumeCalculoRebateFaixaSic">listVolumeCalculoRebateFaixaSic</param>
        /// <param name="listCalculoRebateFaixaSic">listCalculoRebateFaixaSic</param>
        /// <param name="listCalculoRebateSic">listCalculoRebateSic</param>
        /// <param name="listStatusCalculoRebateHistoricoSic">listStatusCalculoRebateHistoricoSic</param>
        /// <param name="listSaldoRebateSic">listSaldoRebateSic</param>
        /// <param name="listDebitoRebateSic">listDebitoRebateSic</param>
        public void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic,
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic,
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic,
            IList<SaldoRebateSic> listSaldoRebateSic)
        {
            this.IncluirCalculoBonificacaoLista(
                listVolumeCalculoRebateFaixaSic,
                listCalculoRebateFaixaSic,
                listCalculoRebateProporcionalSic,
                listCalculoRebateSic,
                listStatusCalculoRebateHistoricoSic,
                listSaldoRebateSic,
                new List<RebateSic>());
        }

        /// <summary>
        /// Insere na base os cálculos de bonificação para um período informando rebate calculado
        /// </summary>
        /// <param name="listVolumeCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateFaixaSic"></param>
        /// <param name="listCalculoRebateSic"></param>
        /// <param name="listStatusCalculoRebateHistoricoSic"></param>
        /// <param name="listSaldoRebateSic"></param>
        /// <param name="listRebateSicPrimeiroCalculo"></param>
        public void IncluirCalculoBonificacaoLista(
            List<VolumeCalculoRebateFaixaSic> listVolumeCalculoRebateFaixaSic,
            List<CalculoRebateFaixaSic> listCalculoRebateFaixaSic,
            IList<CalculoRebateProporcionalSic> listCalculoRebateProporcionalSic,
            List<CalculoRebateSic> listCalculoRebateSic,
            IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic,
            IList<SaldoRebateSic> listSaldoRebateSic,
            List<RebateSic> listRebateSicPrimeiroCalculo)
        {
            //Fluxo de Inseção - Volume
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                databaseManager.Transaction = databaseManager.BeginTransaction();
                List<CalculoRebateFaixaSic> calculoRebateFaixaSics = new List<CalculoRebateFaixaSic>();

                try
                {
                    //Cálculo_Rebate
                    foreach (CalculoRebateSic calculoRebateSic in listCalculoRebateSic)
                    {
                        //Recupera registros com Id provisório
                        List<CalculoRebateFaixaSic> faixas = listCalculoRebateFaixaSic.Where(f => f.NrSeqCalculoRebateSic == calculoRebateSic.NrSeqCalculoRebateSic).ToList();
                        List<CalculoRebateProporcionalSic> proporcoes = listCalculoRebateProporcionalSic.Where(r => r.NrSeqCalculoRebateSic == calculoRebateSic.NrSeqCalculoRebateSic).ToList();
                        List<StatusCalculoRebateHistoricoSic> historicos = listStatusCalculoRebateHistoricoSic.Where(h => h.NrSeqCalculoRebateSic == calculoRebateSic.NrSeqCalculoRebateSic).ToList();

                        //Insere o cálculo
                        Incluir(calculoRebateSic, databaseManager);

                        //Atribui Id correto
                        faixas.ForEach(f => f.NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic);
                        proporcoes.ForEach(r => r.NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic);
                        historicos.ForEach(h => h.NrSeqCalculoRebateSic = calculoRebateSic.NrSeqCalculoRebateSic);
                    }

                    //Faixa_Calculo_Rebate
                    ICalculoRebateFaixaSicDAO calculoRebateFaixaSicDAO = Factory.CreateFactoryInstance().CreateInstance<ICalculoRebateFaixaSicDAO>("CalculoRebateFaixaSicDAO");
                    foreach (CalculoRebateFaixaSic calculoRebateFaixaSic in listCalculoRebateFaixaSic)
                    {
                        //Recupera volumes com Id provisório
                        List<VolumeCalculoRebateFaixaSic> volumes = listVolumeCalculoRebateFaixaSic.Where(v => v.NrSeqCalculoRebateFaixaSic == calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic).ToList();

                        //Insere o cálculo
                        calculoRebateFaixaSicDAO.IncluirComTransacao(calculoRebateFaixaSic, databaseManager);
                        calculoRebateFaixaSics.Add(calculoRebateFaixaSic);

                        //Atribui Id correto
                        volumes.ForEach(v => v.NrSeqCalculoRebateFaixaSic = calculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic);
                    }

                    //CALCULO PROPORCIONAL
                    var calculoRebateProporcionalSicDAO = Factory
                        .CreateFactoryInstance()
                        .CreateInstance<ICalculoRebateProporcionalSicDAO>("CalculoRebateProporcionalSicDAO");
                    foreach (var calculoRebateProporcional in listCalculoRebateProporcionalSic)
                    {
                        calculoRebateProporcionalSicDAO.IncluirComTransacao(calculoRebateProporcional, databaseManager);
                    }

                    //Volume_Faixa_Calculo
                    IVolumeCalculoRebateFaixaSicDAO volumeCalculoRebateFaixaSicDAO = Factory.CreateFactoryInstance().CreateInstance<IVolumeCalculoRebateFaixaSicDAO>("VolumeCalculoRebateFaixaSicDAO");
                    foreach (VolumeCalculoRebateFaixaSic volumeCalculoRebateFaixaSic in listVolumeCalculoRebateFaixaSic)
                    {
                        if (calculoRebateFaixaSics.Where(x => x.NrSeqCalculoRebateFaixaSic == volumeCalculoRebateFaixaSic.NrSeqCalculoRebateFaixaSic).ToList().Count > 0)
                               volumeCalculoRebateFaixaSicDAO.IncluirComTransacao(volumeCalculoRebateFaixaSic, databaseManager);
                    }
                        

                    //Saldo_Rebate
                    ISaldoRebateSicDAO saldoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicDAO>("SaldoRebateSicDAO");
                    foreach (SaldoRebateSic saldoRebateSic in listSaldoRebateSic)
                        saldoRebateSicDAO.IncluirComTransacao(saldoRebateSic, databaseManager);

                    //Historico_Rebate
                    IStatusCalculoRebateHistoricoSicDAO statusCalculoRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicDAO>("StatusCalculoRebateHistoricoSicDAO");
                    foreach (StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic in listStatusCalculoRebateHistoricoSic)
                        statusCalculoRebateHistoricoSicDAO.IncluirComTransacao(statusCalculoRebateHistoricoSic, databaseManager);

                    //Rebates_Primeiro_Calculo
                    IRebateSicDAO rebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IRebateSicDAO>("RebateSicDAO");
                    foreach (RebateSic rebateSic in listRebateSicPrimeiroCalculo)
                        rebateSicDAO.Atualizar(rebateSic);

                    //Commit
                    databaseManager.CommitTransaction();
                }
                catch (Exception ex)
                {
                    LogError.Debug(string.Format("Erro na gravação dos cálculos de bonificação | {0} | {1} ", ex.Message, ex.StackTrace));
                    databaseManager.RollbackTransaction();
                    throw;
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        #endregion IncluirCalculoBonificacaoLista

        #region AtualizarCalculoGeracaoArquivo

        /// <summary>
        /// Atualiza os dados do cálculo após geração dos arquivos
        /// </summary>
        /// <param name="listCalculoRebateSic">listCalculoRebateSic</param>
        /// <param name="listStatusCalculoRebateHistoricoSic">listStatusCalculoRebateHistoricoSic</param>
        /// <param name="listSaldoRebateSic">listSaldoRebateSic</param>
        /// <param name="dadosArquivoRebateSic">dadosArquivoRebateSic</param>
        public void AtualizarCalculoGeracaoArquivo(IList<CalculoRebateSic> listCalculoRebateSic, IList<StatusCalculoRebateHistoricoSic> listStatusCalculoRebateHistoricoSic,
            IList<SaldoRebateSic> listSaldoRebateSic, DadosArquivoRebateSic dadosArquivoRebateSic)
        {
            //Fluxo de Inseção - Volume
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                databaseManager.Transaction = databaseManager.BeginTransaction();

                try
                {
                    //Atualiza o Cálculo_Rebate
                    foreach (CalculoRebateSic calculoRebateSic in listCalculoRebateSic)
                        Atualizar(calculoRebateSic, databaseManager);

                    //Saldo_Rebate
                    ISaldoRebateSicDAO saldoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<ISaldoRebateSicDAO>("SaldoRebateSicDAO");
                    foreach (SaldoRebateSic saldoRebateSic in listSaldoRebateSic)
                        saldoRebateSicDAO.IncluirComTransacao(saldoRebateSic, databaseManager);

                    //Historico_Rebate
                    IStatusCalculoRebateHistoricoSicDAO statusCalculoRebateHistoricoSicDAO = Factory.CreateFactoryInstance().CreateInstance<IStatusCalculoRebateHistoricoSicDAO>("StatusCalculoRebateHistoricoSicDAO");
                    foreach (StatusCalculoRebateHistoricoSic statusCalculoRebateHistoricoSic in listStatusCalculoRebateHistoricoSic)
                        statusCalculoRebateHistoricoSicDAO.IncluirComTransacao(statusCalculoRebateHistoricoSic, databaseManager);

                    //Dados_Arquivo_Rebate
                    IDadosArquivoRebateSicDAO dadosArquivoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IDadosArquivoRebateSicDAO>("DadosArquivoRebateSicDAO");
                    dadosArquivoRebateSicDAO.AtualizarComTransacao(dadosArquivoRebateSic, databaseManager);

                    //Commit
                    databaseManager.CommitTransaction();
                }
                catch (Exception ex)
                {
                    databaseManager.RollbackTransaction();
                    LogError.Error("Erro ao atualizar calculo para geração do arquivo", ex);
                    throw;
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        #endregion AtualizarCalculoGeracaoArquivo

        #region ExcluirCalculoPeriodo

        /// <summary>
        /// Exclui o cálculo rebate e volumes de um periodo
        /// </summary>
        /// <param name="rebateSic"></param>
        /// <param name="dataPeriodoCalculo"></param>
        /// <param name="dataPeriodoVolumeInicio"></param>
        /// <param name="dataPeriodoVolumeFim"></param>
        public void ExcluirCalculoPeriodo(RebateSic rebateSic, DateTime dataPeriodoCalculo, DateTime dataPeriodoVolumeInicio, DateTime dataPeriodoVolumeFim)
        {
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                try
                {
                    string query = string.Format(
                        queryApagarCalculoRebatePeriodo,
                        rebateSic.NrSeqRebateSic,
                        dataPeriodoVolumeInicio.ToString("yyyy-MM-dd"),
                        dataPeriodoVolumeFim.ToString("yyyy-MM-dd"),
                        dataPeriodoCalculo.ToString("yyyy-MM-dd"));

                    databaseManager.ExecuteCommand(query, CriarParametrosPK(databaseManager, new CalculoRebateSic { NrSeqCalculoRebateSic = 0 }));
                }
                catch (SqlException sqlex)
                {
                    throw new Exception(sqlex.Errors[sqlex.Errors.Count - 1].Message, sqlex);
                }
                catch (Exception ex)
                {
                    LogError.Error("Erro ao excluir cálculo do período", ex);
                    throw;
                }
                finally
                {
                    databaseManager.CloseConnection();
                }
            }
        }

        #endregion ExcluirCalculoPeriodo

        #region SelecionarBonificacao

        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        public IList<BonificacaoGrid> SelecionarBonificacao(FiltroBonificacaoGrid filtro)
        {
            IList<BonificacaoGrid> listBonificacaoGrid = new List<BonificacaoGrid>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new CalculoRebateSic(), out where);

                string newQuery = querySelecionarBonificacaoFiltros;

                //Periodo
                if (filtro.DataPeriodo.HasValue)
                    newQuery = string.Concat(newQuery, string.Format(" AND (CALCULO.DT_PERIODO_SIC = '{0}') \n", filtro.DataPeriodo.Value.ToString("yyyy-MM-dd")));

                //IBM
                if (!string.IsNullOrEmpty(filtro.CodigoIBM))
                    newQuery = string.Concat(newQuery, string.Format(" AND (REBATE.NR_IBM_REBATE_SIC = '{0}') \n", filtro.CodigoIBM));

                //Status
                if (!string.IsNullOrEmpty(filtro.ListaStatus))
                    newQuery = string.Concat(newQuery, string.Format(" AND (CALCULO.NR_SEQ_STATUS_CALCULO_REBATE_SIC IN ({0}) " +
                        (filtro.ListaStatus.Equals(Convert.ToInt16(StatusCalculoRebate.Pago).ToString())
                        || filtro.ListaStatus.Equals(Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento).ToString())
                        ? ") \n" : " AND CALCULO.ST_ENVIADO_APROVACAO_GERENTE_SIC = 0 AND CALCULO.ST_APROVADO_ANALISTA_SIC = 0) \n"),
                        filtro.ListaStatus));

                //Aprovado Analista
                if (filtro.AprovadoAnalista.HasValue)
                    newQuery = string.Concat(newQuery, string.Format(
                        " AND (CALCULO.ST_APROVADO_ANALISTA_SIC = {0} AND CALCULO.ST_ENVIADO_APROVACAO_GERENTE_SIC = 0) \n", (filtro.AprovadoAnalista.Value ? "1" : "0")));

                //Enviado Gestor
                if (filtro.EnviadoGestor.HasValue)
                    newQuery = string.Concat(newQuery, string.Format(
                        " AND (CALCULO.ST_ENVIADO_APROVACAO_GERENTE_SIC = {0} AND CALCULO.ST_APROVADO_ANALISTA_SIC = 1 AND CALCULO.NR_SEQ_STATUS_CALCULO_REBATE_SIC NOT IN ({1},{2})) \n",
                        (filtro.EnviadoGestor.Value ? "1" : "0"), Convert.ToInt16(StatusCalculoRebate.Pago), Convert.ToInt16(StatusCalculoRebate.EnviadoPagamento)));

                //Tipo Rebate
                newQuery = string.Concat(newQuery, string.Format(" AND (REBATE.NR_SEQ_TIPOREBATE_SIC IN ({0})) \n", filtro.ListaTipoRebate));

                // Aprovação Massiva
                if (filtro.AprovacaoMassiva.Value)
                {
                    // 1) Status Apto para pagamento
                    newQuery = string.Concat(newQuery, " AND (CALCULO.NR_SEQ_STATUS_CALCULO_REBATE_SIC = 1 AND CALCULO.ST_APROVADO_ANALISTA_SIC = 0) \n");
                    // 2) Código de vendor tem que ser numérico
                    newQuery = string.Concat(newQuery, " AND (ISNUMERIC(REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC) = 1) \n");
                    // 3)	Ignorar da regra os códigos vendor parametrizados através da tela disponível em: Emissão > Administração >Configurações. ‎Listados na chave: Rebate_Vendor_excecao.
                    newQuery = string.Concat(newQuery, " AND (REBATE.NR_CODIGOFORNECEDOR_REBATE_SIC NOT IN (SELECT * from dbo.fnSplitStringValues((SELECT Valor FROM TB_CONFIGURACAO WHERE Chave = 'Rebate_Vendor_excecao'),','))) \n");
                }
                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                        listBonificacaoGrid.Add(PreencherBonificacaoGrid(dbDataReader));
                }
                databaseManager.CloseConnection();
            }
            return listBonificacaoGrid;
        }

        #endregion SelecionarBonificacao

        #region SelecionarBonificacaoRetroativo

        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        public IList<BonificacaoGrid> SelecionarRebatesSemCalculo(FiltroBonificacaoGrid filtro)
        {
            IList<BonificacaoGrid> listBonificacaoGrid = new List<BonificacaoGrid>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new CalculoRebateSic(), out where);

                string newQuery = string.Format(querySelecionarRebateSemCalculo,
                   string.IsNullOrEmpty(filtro.CodigoIBM) ? "NULL" : filtro.CodigoIBM,
                   filtro.ListaTipoRebate);

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                        listBonificacaoGrid.Add(PreencherBonificacaoGrid(dbDataReader));
                }
                databaseManager.CloseConnection();
            }
            return listBonificacaoGrid;
        }

        #endregion SelecionarBonificacaoRetroativo

        #endregion Metodos Publicos

        #region Metodos Privados

        #region Metodos Gerais

        #region Preencher

        /// <summary>
        /// Preenche o objeto BonificacaoGrid a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto BonificacaoGrid preenchido</returns>
        protected BonificacaoGrid PreencherBonificacaoGrid(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException("reader"));
            BonificacaoGrid bonificacaoGrid = new BonificacaoGrid();
            bonificacaoGrid.CodigoCalculoRebate = reader.GetNullableInt32(C_NR_SEQ_CALCULO_REBATE_SIC);
            bonificacaoGrid.CodigoRebate = reader.GetNullableInt32(C_NR_SEQ_REBATE_SIC);
            bonificacaoGrid.CodigoIBM = reader.GetString(C_NR_IBM_REBATE_SIC);
            bonificacaoGrid.CodigoIBMFornecedor = reader.GetString(C_NR_CODIGOFORNECEDOR_REBATE_SIC);
            bonificacaoGrid.NomeCliente = reader.GetString(C_NM_RAZSOCIALLOJA_FRANQUIA_SIC);
            bonificacaoGrid.ValorBonificacao = reader.GetNullableDecimal(C_VL_BONIFICACAO_TOTAL_SIC);
            bonificacaoGrid.ValorBonificacaoAnterior = reader.GetNullableDecimal(C_BONIFICACAO_ANTERIOR);
            bonificacaoGrid.ValorDebito = reader.GetNullableDecimal(C_VL_DEBITO_SIC);
            bonificacaoGrid.DataPagamento = reader.GetNullableDateTime(C_DT_PAGAMENTO_SIC);
            bonificacaoGrid.CodigoStatus = reader.GetNullableInt32(C_NR_SEQ_STATUS_CALCULO_REBATE_SIC);
            bonificacaoGrid.DescricaoStatusBanco = reader.GetString(C_NM_STATUS_CALCULO_REBATE_SIC);
            bonificacaoGrid.Mensal = !reader.GetBoolean(C_PERIODICIDADE_PAGAMENTO);
            bonificacaoGrid.DataPeriodoCalculo = reader.GetDateTime(C_PERIODO_CALCULO);
            bonificacaoGrid.DescricaoTipoRebate = reader.GetString(C_NM_TIPOREBATE_SIC);
            bonificacaoGrid.AprovadoAnalista = reader.GetNullableBoolean(C_ST_APROVADO_ANALISTA_SIC);
            bonificacaoGrid.EnviadoGerente = reader.GetNullableBoolean(C_ST_ENVIADO_APROVACAO_GERENTE_SIC);
            bonificacaoGrid.AprovadoGerente = reader.GetNullableBoolean(C_ST_APROVADO_GERENTE_SIC);
            bonificacaoGrid.Aditivo = reader.GetNullableBoolean(C_ST_ADITIVO_SIC);
            bonificacaoGrid.NomeCanal = reader.GetString(C_NM_CANAL_CLIENTE_SIC);
            bonificacaoGrid.VolumeLimite = reader.GetNullableDecimal(C_VL_VOLUME_CONSUMIDO_SIC);
            bonificacaoGrid.VolumeConsumido = reader.GetNullableDecimal(C_VL_VOLUME_LIMITE_REBATE_SIC);
            bonificacaoGrid.Acerto = reader.GetNullableBoolean(C_ST_ACERTO_SIC);
            return bonificacaoGrid;
        }

        #endregion Preencher

        #endregion Metodos Gerais

        #endregion Metodos Privados
    }

    #endregion classe concreta CalculoRebateSicDAO
}
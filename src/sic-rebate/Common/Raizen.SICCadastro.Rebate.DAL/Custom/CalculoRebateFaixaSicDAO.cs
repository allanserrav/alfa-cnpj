#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateFaixaSicDAO.cs
// Class Name	        : CalculoRebateFaixaSicDAO
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
	#region classe concreta CalculoRebateFaixaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateFaixaSicDAO
	/// </summary>
	internal partial class CalculoRebateFaixaSicDAO : ICalculoRebateFaixaSicDAO
    {
        #region Constantes
        private const string C_NomeCategoria = "NM_CATEGORIA_SIC";
        private const string C_BonificacaoUnitaria = "VL_BONIFICACAO_REBATE_SIC";
        private const string C_VolumeContratado = "VL_VOLUMEMENSAL_REBATE_SIC";
        private const string C_PercentualMinimo = "VL_PERCMINIMO_REBATE_SIC";
        private const string C_PercentualMáximo = "VL_PERCMAXIMO_REBATE_SIC";
        private const string C_VolumeMinimo = "VL_VOLUME_MINIMO_SIC";
        private const string C_VolumeMaximo = "VL_VOLUME_MAXIMO_SIC";
        private const string C_VolumeCompradoPeriodo = "VL_VOLUME_CALCULADO_SIC";
        private const string C_ValorBonificacaoCategoria = "VL_BONIFICACAO_CALCULADO_SIC";
        private const string C_NR_SEQ_GRUPO_SIC = "NR_SEQ_GRUPO_SIC";
        #endregion  Constantes de BonificacaoGridDetalhe

        #region Querys

        #region Bonificacao Detalhe
        /// <summary>
        /// String com a query para buscar detalhes da bonificação
        /// </summary>
        private string queryBonificacaoDetalhe = new StringBuilder().Append("SELECT DISTINCT ")
                .Append("CAT.NM_CATEGORIA_SIC ")
                .Append(",FAIXAHIST.VL_BONIFICACAO_REBATE_SIC ")
                .Append(",FAIXAHIST.VL_VOLUMEMENSAL_REBATE_SIC ")
                .Append(",FAIXAHIST.VL_PERCMINIMO_REBATE_SIC ")
                //.Append(",FAIXAHIST.VL_PERCMAXIMO_REBATE_SIC ")
                .Append(",(CASE WHEN FAIXAHIST.VL_PERCMAXIMO_REBATE_SIC > 9999999 THEN 9999999 ELSE FAIXAHIST.VL_PERCMAXIMO_REBATE_SIC END) AS VL_PERCMAXIMO_REBATE_SIC")          
                .Append(",CALCREBATE.VL_VOLUME_MINIMO_SIC ")
                .Append(",CALCREBATE.VL_VOLUME_MAXIMO_SIC ")
                .Append(",CALCREBATE.VL_VOLUME_CALCULADO_SIC ")
                .Append(",CALCREBATE.VL_BONIFICACAO_CALCULADO_SIC ")
                .Append(",FAIXAHIST.NR_SEQ_GRUPO_SIC ")
                .Append(",CALCREBATEFAIXA.NR_SEQ_CALCULO_REBATE_FAIXA_SIC  ")
                .Append("FROM ")
                .Append("TB_CALCULO_REBATE_FAIXA_SIC (NOLOCK) CALCREBATE ")
                .Append("JOIN TB_VOLUME_CALCULO_REBATE_FAIXA_SIC (NOLOCK) CALCREBATEFAIXA ON CALCREBATEFAIXA.NR_SEQ_CALCULO_REBATE_FAIXA_SIC = CALCREBATE.NR_SEQ_CALCULO_REBATE_FAIXA_SIC ")
                .Append("JOIN TB_VOLUME_MENSAL_FAIXA_REBATE_SIC (NOLOCK) VOLMENSALFAIXA ON VOLMENSALFAIXA.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC = CALCREBATEFAIXA.NR_SEQ_VOLUME_MENSAL_FAIXA_REBATE_SIC ")
                .Append("JOIN TB_FAIXA_REBATE_HISTORICO_SIC (NOLOCK) FAIXAHIST ON FAIXAHIST.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = VOLMENSALFAIXA.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC AND FAIXAHIST.NR_SEQ_FAIXAREBATE_SIC = VOLMENSALFAIXA.NR_SEQ_FAIXAREBATE_SIC ")
                .Append("JOIN TB_CATEGORIA_SIC (NOLOCK) CAT ON CAT.NR_SEQ_CATEGORIA_SIC = FAIXAHIST.NR_SEQ_CATEGORIA_SIC ")
                .Append("WHERE ")
                .Append("CALCREBATE.NR_SEQ_CALCULO_REBATE_SIC = {0} ")
                .Append("AND VOLMENSALFAIXA.DT_PERIODO_SIC = '{1}' ")
                .Append("ORDER BY CAT.NM_CATEGORIA_SIC DESC").ToString();
                
        
        #endregion Bonificacao Detalhe

        #endregion Querys

        /// <summary>
        /// Incluir CalculoRebateFaixaSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="CalculoRebateFaixaSic"/></param>
        public void IncluirComTransacao(CalculoRebateFaixaSic calculoRebateFaixaSic, DatabaseManager databaseManager)
        {
            Incluir(calculoRebateFaixaSic, databaseManager);
        }

        #region Selecionar Bonificacao Detalhe

        public IList<BonificacaoGridDetalhe> SelecionarBonificacaoDetalhe(int NrSeqCalculoRebateSic, DateTime dtPeriodo)
        {
            IList<BonificacaoGridDetalhe> listBonificacaoGridDetalhes = new List<BonificacaoGridDetalhe>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new CalculoRebateFaixaSic(), out where);
                string newQuery = string.Format(queryBonificacaoDetalhe, NrSeqCalculoRebateSic, dtPeriodo.AddMonths(-1).ToString("yyyy-MM-dd"));

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listBonificacaoGridDetalhes.Add(PreencherBonificacaoGridDetalhe(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listBonificacaoGridDetalhes;
        }

        #region PreencherBonificacaoGridDetalhe
        /// <summary>
        /// Preenche o objeto BonificacaoGridDetalhe a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto BonificacaoGridDetalhe preenchido</returns>
        protected BonificacaoGridDetalhe PreencherBonificacaoGridDetalhe (SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException());
            BonificacaoGridDetalhe bonificacaoGridDetalhe = new BonificacaoGridDetalhe();
            bonificacaoGridDetalhe.NomeCategoria = reader.GetString(C_NomeCategoria);
            bonificacaoGridDetalhe.BonificacaoUnitaria = reader.GetNullableDecimal(C_BonificacaoUnitaria);
            bonificacaoGridDetalhe.VolumeContratado = reader.GetNullableDecimal(C_VolumeContratado);
            bonificacaoGridDetalhe.PercentualMinimo = reader.GetNullableDecimal(C_PercentualMinimo);
            bonificacaoGridDetalhe.PercentualMáximo = reader.GetNullableDecimal(C_PercentualMáximo);
            bonificacaoGridDetalhe.VolumeMinimo = reader.GetNullableDecimal(C_VolumeMinimo);
            bonificacaoGridDetalhe.VolumeMaximo = reader.GetNullableDecimal(C_VolumeMaximo);
            bonificacaoGridDetalhe.VolumeCompradoPeriodo = reader.GetNullableDecimal(C_VolumeCompradoPeriodo);
            bonificacaoGridDetalhe.ValorBonificacaoCategoria = reader.GetNullableDecimal(C_ValorBonificacaoCategoria);
            bonificacaoGridDetalhe.SeqGrupo = reader.GetNullableInt32(C_NR_SEQ_GRUPO_SIC);

            return bonificacaoGridDetalhe;
        }
        #endregion PreencherBonificacaoGridDetalhe

        #endregion Selecionar Bonificacao Detalhe


    }
	#endregion classe concreta 
}

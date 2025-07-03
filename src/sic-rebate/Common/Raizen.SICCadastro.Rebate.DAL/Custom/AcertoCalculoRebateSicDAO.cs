#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AcertoCalculoRebateSicDAO.cs
// Class Name	        : AcertoCalculoRebateSicDAO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 23/01/2020
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
using System.Linq;
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using COSAN.Framework.Util;
using System.Data.SqlClient;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
    #region classe concreta CalculoRebateSicDAO
    /// <summary>
    /// Representa funcionalidade relacionada a CalculoRebateSicDAO
    /// </summary>
    internal partial class AcertoCalculoRebateSicDAO : IAcertoCalculoRebateSicDAO
    {
        #region Constantes
        private const string C_NR_SEQ_CALCULO_REBATE_SIC = "NR_SEQ_CALCULO_REBATE_SIC";
        private const string C_NR_SEQ_REBATE_SIC = "NR_SEQ_REBATE_SIC";
        private const string C_DT_PERIODO_SIC = "DT_PERIODO_SIC";
        private const string C_VL_BONIFICACAO_TOTAL_SIC = "VL_BONIFICACAO_TOTAL_SIC";
        private const string C_ST_CALCULO_REBATE_SIC = "ST_CALCULO_REBATE_SIC";
        #endregion

        #region Queries

        #endregion

        #region Selecionar Acerto Bonificação
        /// <summary>
        /// Selecionar Cálculos de Bonificação Rebate
        /// </summary>
        private string querySelecionarAcertoBonificacao = new StringBuilder()
            .AppendLine(" SELECT TB_CALCULO_REBATE_SIC .NR_SEQ_CALCULO_REBATE_SIC")
            .AppendLine(" 	    ,TB_CALCULO_REBATE_SIC .NR_SEQ_REBATE_SIC")
            .AppendLine(" 	    ,TB_CALCULO_REBATE_SIC .DT_PERIODO_SIC")
            .AppendLine(" 	    ,TB_REBATE_SIC.ST_CALCULO_REBATE_SIC")
            .AppendLine("   FROM TB_CALCULO_REBATE_SIC ")
            .AppendLine("   JOIN TB_REBATE_SIC")
            .AppendLine("     ON TB_REBATE_SIC.NR_SEQ_REBATE_SIC = TB_CALCULO_REBATE_SIC .NR_SEQ_REBATE_SIC")
            .AppendLine("  WHERE TB_REBATE_SIC.NR_IBM_REBATE_SIC = {0}")
            .AppendLine("    AND DT_PERIODO_SIC BETWEEN TB_REBATE_SIC.DT_INICIOVIGENCIA_REBATE_SIC AND TB_REBATE_SIC.DT_FIMVIGENCIA_REBATE_SIC")
            .AppendLine("  ORDER BY DT_PERIODO_SIC").ToString();

        #endregion

        #region Metodos Publicos

        #region SelecionarAcertoBonificacao
        /// <summary>
        /// Seleciona uma lista de bonificação
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns></returns>
        public IList<AcertoCalculoRebateSic> Selecionar(string ibm)
        {
            IList<AcertoCalculoRebateSic> listAcertoCalculoRebateSic = new List<AcertoCalculoRebateSic>();
            using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
            {
                List<DbParameter> dbParams = new List<DbParameter>();
                string newQuery = querySelecionarAcertoBonificacao;
                //IBM
                if (!string.IsNullOrEmpty(ibm))
                    newQuery = string.Format(newQuery, ibm);

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, dbParams))
                {
                    while (dbDataReader.Read())
                        listAcertoCalculoRebateSic.Add(PreencherAcertoCalculoBonificacao(dbDataReader));
                }
                databaseManager.CloseConnection();
            }
            return listAcertoCalculoRebateSic;
        }
        #endregion       

        #endregion Metodos Publicos

        #region Metodos Privados
        #region Metodos Gerais

        #region Preencher
        /// <summary>
        /// Preenche o objeto BonificacaoGrid a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto BonificacaoGrid preenchido</returns>
        protected AcertoCalculoRebateSic PreencherAcertoCalculoBonificacao(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException());
            AcertoCalculoRebateSic acertoCalculoRebateSic = new AcertoCalculoRebateSic();
            return acertoCalculoRebateSic;
        }
        #endregion Preencher
        #endregion Common Methods
        #endregion Metodos Privados
    }
    #endregion classe concreta
}
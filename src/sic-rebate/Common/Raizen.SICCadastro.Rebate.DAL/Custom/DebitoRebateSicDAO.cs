using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.DBUtil;
using System.Data.Common;

namespace Raizen.SICCadastro.Rebate.DAL
{
    /// <summary>
    /// Complemento de DebitoRebateSicDAO
    /// </summary>
    internal partial class DebitoRebateSicDAO : IDebitoRebateSicDAO
    {

        #region Constantes
        public const string C_ClientePagador = "NR_CLIENTE_PAGADOR";
        public const string C_DtVencimentoOriginal = "DT_VENCIMENTO_ORIGINAL";
        public const string C_VlMontante = "VL_MONTANTE";
        #endregion  Constantes

        #region Queries
        #region Query para Selecionar Rebates Por Meses Grupo
        /// <summary>
        /// Selecionar Debitos
        /// </summary>
        private string querySelecionarDebitoRbc = new StringBuilder()
            .AppendLine(" SELECT ")
                .AppendLine(" COD_CLIENTE_PAGADOR NR_CLIENTE_PAGADOR, ")
                .AppendLine(" DAT_VENCIMENTO_ORIGINAL DT_VENCIMENTO_ORIGINAL, ")
                .AppendLine(" VAL_MONTANTE VL_MONTANTE ")
            .AppendLine(" FROM RBC.CONTA_RECEBER ")
            .AppendLine(" WHERE DAT_PAGAMENTO IS NULL ")
                .AppendLine(" AND COD_STATUS_DOCUMENTO = 'O' ")
                .AppendLine(" AND (COD_CONDICAO_PAGAMENTO <> 'ZPA' OR COD_CONDICAO_PAGAMENTO IS NULL) ")
                .AppendLine(" AND IND_DOCUMENTO_PRE_EDITADO = 'N' ")
                .AppendLine(" AND COD_CLIENTE_PAGADOR IN ('{0}') ")
                //.AppendLine(" AND DAT_VENCIMENTO_ORIGINAL <= '{1}' ")
                //.AppendLine(" AND TO_DATE(TO_CHAR(DAT_VENCIMENTO_ORIGINAL), 'DD/MM/YYYY') <= TO_DATE('{1}', 'DD/MM/YYYY') ")
                .AppendLine(" AND ( ")
                .AppendLine(" (DAT_VENCIMENTO_PRORROGADA >= DAT_VENCIMENTO_ORIGINAL AND DAT_VENCIMENTO_PRORROGADA <= TO_DATE('{1}', 'DD/MM/YYYY')) OR ")
                .AppendLine(" (DAT_VENCIMENTO_PRORROGADA <= DAT_VENCIMENTO_ORIGINAL AND DAT_VENCIMENTO_ORIGINAL <= TO_DATE('{1}', 'DD/MM/YYYY')) ")
                .AppendLine(" ) ")
                .AppendLine(" AND COD_REGIME_ESPECIAL NOT IN ('{2}') ")
            .AppendLine("").ToString();

        #endregion
        #endregion

        #region Metodos Publicos
        #region Selecionar SelecionarPorGrupoMensal
        /// <summary>
        /// Seleciona em lote os dados do Debito do Cliente na base RBC (Oracle)
        /// </summary>
        /// <param name="dataConsultaAte">Data para buscar débitos anteriores</param>
        /// <param name="listIBM">Lista de IBMs</param>
        /// <param name="listMotivoRegimeEspecial">Lista de motivos exclusiovs à busca</param>
        /// <returns></returns>
        public IList<DebitoRbc> SelecionarDebitoRbc(DateTime dataConsultaAte, List<string> listIBM, List<string> listMotivoRegimeEspecial)
        {
            IList<DebitoRbc> listDebitoRbc = new List<DebitoRbc>();
            using (DatabaseManager databaseManager = new DatabaseManager("APPSIC"))
            {
                string where = "";
                IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, new DebitoRebateSic(), out where);

                string newQuery = string.Format(querySelecionarDebitoRbc,
                   string.Join("','", listIBM.ToArray()),
                   dataConsultaAte.ToString("dd/MM/yyyy"),
                   string.Join("','", listMotivoRegimeEspecial.ToArray()));                

                using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
                {
                    while (dbDataReader.Read())
                    {
                        listDebitoRbc.Add(PreencherDebitoRbc(dbDataReader));
                    }
                }
                databaseManager.CloseConnection();
            }
            return listDebitoRbc;
        }
        #endregion Selecionar SelecionarPorGrupoMensal

        #region Incluir
        /// <summary>
        /// Incluir DebitoRebateSic
        /// </summary>
        /// <param name="volumeCalculoRebateFaixaSic">Instance of <see cref="DebitoRebateSic"/></param>
        public void IncluirComTransacao(DebitoRebateSic debitoRebateSic, DatabaseManager databaseManager)
        {
            Incluir(debitoRebateSic, databaseManager);
        }
        #endregion

        #endregion Metodos Publicos

        #region Metodos Privados
        #region Metodos Gerais
        #region Preencher

        /// <summary>
        /// Preenche o objeto DebitoRbc a partir do SafeDataReader.
        /// </summary>
        /// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
        /// <returns>O objeto DebitoRbc preenchido</returns>
        protected DebitoRbc PreencherDebitoRbc(SafeDataReader reader)
        {
            if (reader == null) throw (new ArgumentNullException());
            DebitoRbc debitoRbc = new DebitoRbc();
            debitoRbc.NrClientePagador = reader.GetString(C_ClientePagador);
            debitoRbc.DtVencimentoOriginal = reader.GetDateTime(C_DtVencimentoOriginal);
            debitoRbc.VlMontante = reader.GetDecimal(C_VlMontante);
            return debitoRbc;
        }

        #endregion Preencher
        #endregion Common Methods

        #endregion Metodos Privados
    }
}

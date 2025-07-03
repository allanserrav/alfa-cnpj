#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebateHistoricoSicDAO.cs
// Class Name	        : ReajusteRebateHistoricoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	#region classe concreta ReajusteRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteRebateHistoricoSicDAO
	/// </summary>
	internal partial class ReajusteRebateHistoricoSicDAO : IReajusteRebateHistoricoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbReajusteRebateHistoricoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_SEQ_FAIXAREBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.VL_BONIFICACAO_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_SEQ_REAJUSTE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.VL_IGPM_REAJUSTE_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.VL_MANUAL_REAJUSTE_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.NR_PERIODO_REAJUSTE_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATE_HISTORICO_SIC.DT_ALTERACAO_SIC")
		.Append(" FROM TB_REAJUSTE_REBATE_HISTORICO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instância de <see cref="ReajusteRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebateHistoricoSic</returns>
		public IList<ReajusteRebateHistoricoSic> Selecionar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			IList<ReajusteRebateHistoricoSic> listReajusteRebateHistoricoSic = new List<ReajusteRebateHistoricoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, reajusteRebateHistoricoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listReajusteRebateHistoricoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listReajusteRebateHistoricoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ReajusteRebateHistoricoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ReajusteRebateHistoricoSic preenchido</returns>
		protected ReajusteRebateHistoricoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ReajusteRebateHistoricoSic reajusteRebateHistoricoSic = new ReajusteRebateHistoricoSic();
			reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic = reader.GetNullableInt32(C_NrSeqReajusteRebateHistoricoSic);
			reajusteRebateHistoricoSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			reajusteRebateHistoricoSic.NrSeqFaixarebateSic = reader.GetNullableInt32(C_NrSeqFaixarebateSic);
			reajusteRebateHistoricoSic.VlBonificacaoRebateSic = reader.GetNullableDecimal(C_VlBonificacaoRebateSic);
			reajusteRebateHistoricoSic.NrSeqReajusteSic = reader.GetNullableInt32(C_NrSeqReajusteSic);
			reajusteRebateHistoricoSic.VlIgpmReajusteRebateSic = reader.GetNullableDecimal(C_VlIgpmReajusteRebateSic);
			reajusteRebateHistoricoSic.VlManualReajusteRebateSic = reader.GetNullableDecimal(C_VlManualReajusteRebateSic);
			reajusteRebateHistoricoSic.NrPeriodoReajusteRebateSic = reader.GetNullableInt32(C_NrPeriodoReajusteRebateSic);
			reajusteRebateHistoricoSic.DtAlteracaoSic = reader.GetNullableDateTime(C_DtAlteracaoSic);
			return reajusteRebateHistoricoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_NrSeqReajusteRebateHistoricoSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic, ref where));
			if (reajusteRebateHistoricoSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.NrSeqRebateSic, ref where));
			if (reajusteRebateHistoricoSic.NrSeqFaixarebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_NrSeqFaixarebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.NrSeqFaixarebateSic, ref where));
			if (reajusteRebateHistoricoSic.VlBonificacaoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_VlBonificacaoRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.VlBonificacaoRebateSic, ref where));
			if (reajusteRebateHistoricoSic.NrSeqReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_NrSeqReajusteSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.NrSeqReajusteSic, ref where));
			if (reajusteRebateHistoricoSic.VlIgpmReajusteRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_VlIgpmReajusteRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.VlIgpmReajusteRebateSic, ref where));
			if (reajusteRebateHistoricoSic.VlManualReajusteRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_VlManualReajusteRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.VlManualReajusteRebateSic, ref where));
			if (reajusteRebateHistoricoSic.NrPeriodoReajusteRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_NrPeriodoReajusteRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.NrPeriodoReajusteRebateSic, ref where));
			if (reajusteRebateHistoricoSic.DtAlteracaoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_REAJUSTE_REBATE_HISTORICO_SIC", C_DtAlteracaoSic, DatabaseManager.SQLOperation.Equal, reajusteRebateHistoricoSic.DtAlteracaoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

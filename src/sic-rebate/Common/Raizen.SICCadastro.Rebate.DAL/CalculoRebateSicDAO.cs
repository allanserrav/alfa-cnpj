#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CalculoRebateSicDAO.cs
// Class Name	        : CalculoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 08/08/2014
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
	#region classe concreta CalculoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateSicDAO
	/// </summary>
	internal partial class CalculoRebateSicDAO : ICalculoRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbCalculoRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CALCULO_REBATE_SIC.NR_SEQ_CALCULO_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DT_PERIODO_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DT_PAGAMENTO_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.VL_BONIFICACAO_TOTAL_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.VL_VOLUME_TOTAL")
		.Append(",TB_CALCULO_REBATE_SIC.DS_OBS_CALCULO_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.NR_SEQ_STATUS_CALCULO_REBATE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.ST_APROVADO_ANALISTA_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DT_APROVADO_ANALISTA_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.ST_ENVIADO_APROVACAO_GERENTE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DT_ENVIADO_APROVACAO_GERENTE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.ST_APROVADO_GERENTE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DT_APROVADO_GERENTE_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.ST_ADITIVO_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.ST_PAGTO_MANUAL_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.DS_OBS_PAGTO_SIC")
		.Append(",TB_CALCULO_REBATE_SIC.VL_VOLUME_CONSUMIDO_SIC")
		.Append(" FROM TB_CALCULO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<CalculoRebateSic> Selecionar(CalculoRebateSic calculoRebateSic, int numeroLinhas, string ordem)
		{
			IList<CalculoRebateSic> listCalculoRebateSic = new List<CalculoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, calculoRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listCalculoRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listCalculoRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto CalculoRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto CalculoRebateSic preenchido</returns>
		protected CalculoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			CalculoRebateSic calculoRebateSic = new CalculoRebateSic();
			calculoRebateSic.NrSeqCalculoRebateSic = reader.GetNullableInt32(C_NrSeqCalculoRebateSic);
			calculoRebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			calculoRebateSic.DtPeriodoSic = reader.GetNullableDateTime(C_DtPeriodoSic);
			calculoRebateSic.DtPagamentoSic = reader.GetNullableDateTime(C_DtPagamentoSic);
			calculoRebateSic.VlBonificacaoTotalSic = reader.GetNullableDecimal(C_VlBonificacaoTotalSic);
			calculoRebateSic.VlVolumeTotal = reader.GetNullableDecimal(C_VlVolumeTotal);
			calculoRebateSic.DsObsCalculoSic = reader.GetString(C_DsObsCalculoSic);
			calculoRebateSic.NrSeqStatusCalculoRebateSic = reader.GetNullableInt32(C_NrSeqStatusCalculoRebateSic);
			calculoRebateSic.StAprovadoAnalistaSic = reader.GetNullableBoolean(C_StAprovadoAnalistaSic);
			calculoRebateSic.DtAprovadoAnalistaSic = reader.GetNullableDateTime(C_DtAprovadoAnalistaSic);
			calculoRebateSic.StEnviadoAprovacaoGerenteSic = reader.GetNullableBoolean(C_StEnviadoAprovacaoGerenteSic);
			calculoRebateSic.DtEnviadoAprovacaoGerenteSic = reader.GetNullableDateTime(C_DtEnviadoAprovacaoGerenteSic);
			calculoRebateSic.StAprovadoGerenteSic = reader.GetNullableBoolean(C_StAprovadoGerenteSic);
			calculoRebateSic.DtAprovadoGerenteSic = reader.GetNullableDateTime(C_DtAprovadoGerenteSic);
			calculoRebateSic.StAditivoSic = reader.GetNullableBoolean(C_StAditivoSic);
			calculoRebateSic.StPagtoManualSic = reader.GetNullableBoolean(C_StPagtoManualSic);
			calculoRebateSic.DsObsPagtoSic = reader.GetString(C_DsObsPagtoSic);
			calculoRebateSic.VlVolumeConsumidoSic = reader.GetNullableDecimal(C_VlVolumeConsumidoSic);
			return calculoRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, CalculoRebateSic calculoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (calculoRebateSic.NrSeqCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_SIC", C_NrSeqCalculoRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.NrSeqCalculoRebateSic, ref where));
			if (calculoRebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.NrSeqRebateSic, ref where));
			if (calculoRebateSic.DtPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CALCULO_REBATE_SIC", C_DtPeriodoSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.DtPeriodoSic, ref where));
			if (calculoRebateSic.DtPagamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CALCULO_REBATE_SIC", C_DtPagamentoSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.DtPagamentoSic, ref where));
			if (calculoRebateSic.VlBonificacaoTotalSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_SIC", C_VlBonificacaoTotalSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.VlBonificacaoTotalSic, ref where));
			if (calculoRebateSic.VlVolumeTotal != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_SIC", C_VlVolumeTotal, DatabaseManager.SQLOperation.Equal, calculoRebateSic.VlVolumeTotal, ref where));
			if (calculoRebateSic.DsObsCalculoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CALCULO_REBATE_SIC", C_DsObsCalculoSic, DatabaseManager.SQLOperation.Like, "%" + calculoRebateSic.DsObsCalculoSic + "%", ref where));
			if (calculoRebateSic.NrSeqStatusCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CALCULO_REBATE_SIC", C_NrSeqStatusCalculoRebateSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.NrSeqStatusCalculoRebateSic, ref where));
			if (calculoRebateSic.StAprovadoAnalistaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CALCULO_REBATE_SIC", C_StAprovadoAnalistaSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.StAprovadoAnalistaSic, ref where));
			if (calculoRebateSic.DtAprovadoAnalistaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CALCULO_REBATE_SIC", C_DtAprovadoAnalistaSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.DtAprovadoAnalistaSic, ref where));
			if (calculoRebateSic.StEnviadoAprovacaoGerenteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CALCULO_REBATE_SIC", C_StEnviadoAprovacaoGerenteSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.StEnviadoAprovacaoGerenteSic, ref where));
			if (calculoRebateSic.DtEnviadoAprovacaoGerenteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CALCULO_REBATE_SIC", C_DtEnviadoAprovacaoGerenteSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.DtEnviadoAprovacaoGerenteSic, ref where));
			if (calculoRebateSic.StAprovadoGerenteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CALCULO_REBATE_SIC", C_StAprovadoGerenteSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.StAprovadoGerenteSic, ref where));
			if (calculoRebateSic.DtAprovadoGerenteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_CALCULO_REBATE_SIC", C_DtAprovadoGerenteSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.DtAprovadoGerenteSic, ref where));
			if (calculoRebateSic.StAditivoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CALCULO_REBATE_SIC", C_StAditivoSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.StAditivoSic, ref where));
			if (calculoRebateSic.StPagtoManualSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CALCULO_REBATE_SIC", C_StPagtoManualSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.StPagtoManualSic, ref where));
			if (calculoRebateSic.DsObsPagtoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CALCULO_REBATE_SIC", C_DsObsPagtoSic, DatabaseManager.SQLOperation.Like, "%" + calculoRebateSic.DsObsPagtoSic + "%", ref where));
			if (calculoRebateSic.VlVolumeConsumidoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_CALCULO_REBATE_SIC", C_VlVolumeConsumidoSic, DatabaseManager.SQLOperation.Equal, calculoRebateSic.VlVolumeConsumidoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

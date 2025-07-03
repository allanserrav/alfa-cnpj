#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ReajusteRebatexfranquiaSicDAO.cs
// Class Name	        : ReajusteRebatexfranquiaSicDAO
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
	#region classe concreta ReajusteRebatexfranquiaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteRebatexfranquiaSicDAO
	/// </summary>
	internal partial class ReajusteRebatexfranquiaSicDAO : IReajusteRebatexfranquiaSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbReajusteRebatexfranquiaSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_SEQ_REAJUSTE_REBATEXFRANQUIA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_SEQ_FRANQUIA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_SEQ_FAIXA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_SEQ_REAJUSTE_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.VL_MANUAL_REAJUSTEREBATEXFRANQUIA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.NR_PERIODO_REAJUSTEREBATEXFRANQUIA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.ST_FEEMINIMO_FAIXA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.ST_FEEMAXIMO_FAIXA_SIC")
		.Append(",TB_REAJUSTE_REBATEXFRANQUIA_SIC.ST_VALORES_FAIXA_SIC")
		.Append(" FROM TB_REAJUSTE_REBATEXFRANQUIA_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instância de <see cref="ReajusteRebatexfranquiaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ReajusteRebatexfranquiaSic</returns>
		public IList<ReajusteRebatexfranquiaSic> Selecionar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, int numeroLinhas, string ordem)
		{
			IList<ReajusteRebatexfranquiaSic> listReajusteRebatexfranquiaSic = new List<ReajusteRebatexfranquiaSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, reajusteRebatexfranquiaSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listReajusteRebatexfranquiaSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listReajusteRebatexfranquiaSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ReajusteRebatexfranquiaSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ReajusteRebatexfranquiaSic preenchido</returns>
		protected ReajusteRebatexfranquiaSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic = new ReajusteRebatexfranquiaSic();
			reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic = reader.GetNullableInt32(C_NrSeqReajusteRebatexfranquiaSic);
			reajusteRebatexfranquiaSic.NrSeqFranquiaSic = reader.GetNullableInt32(C_NrSeqFranquiaSic);
			reajusteRebatexfranquiaSic.NrSeqFaixaSic = reader.GetNullableInt32(C_NrSeqFaixaSic);
			reajusteRebatexfranquiaSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			reajusteRebatexfranquiaSic.NrSeqReajusteSic = reader.GetNullableInt32(C_NrSeqReajusteSic);
			reajusteRebatexfranquiaSic.VlManualReajusterebatexfranquiaSic = reader.GetNullableDecimal(C_VlManualReajusterebatexfranquiaSic);
			reajusteRebatexfranquiaSic.NrPeriodoReajusterebatexfranquiaSic = reader.GetNullableInt32(C_NrPeriodoReajusterebatexfranquiaSic);
			reajusteRebatexfranquiaSic.StFeeminimoFaixaSic = reader.GetNullableBoolean(C_StFeeminimoFaixaSic);
			reajusteRebatexfranquiaSic.StFeemaximoFaixaSic = reader.GetNullableBoolean(C_StFeemaximoFaixaSic);
			reajusteRebatexfranquiaSic.StValoresFaixaSic = reader.GetNullableBoolean(C_StValoresFaixaSic);
			return reajusteRebatexfranquiaSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrSeqReajusteRebatexfranquiaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic, ref where));
			if (reajusteRebatexfranquiaSic.NrSeqFranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrSeqFranquiaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrSeqFranquiaSic, ref where));
			if (reajusteRebatexfranquiaSic.NrSeqFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrSeqFaixaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrSeqFaixaSic, ref where));
			if (reajusteRebatexfranquiaSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrSeqRebateSic, ref where));
			if (reajusteRebatexfranquiaSic.NrSeqReajusteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrSeqReajusteSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrSeqReajusteSic, ref where));
			if (reajusteRebatexfranquiaSic.VlManualReajusterebatexfranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_VlManualReajusterebatexfranquiaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.VlManualReajusterebatexfranquiaSic, ref where));
			if (reajusteRebatexfranquiaSic.NrPeriodoReajusterebatexfranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_NrPeriodoReajusterebatexfranquiaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.NrPeriodoReajusterebatexfranquiaSic, ref where));
			if (reajusteRebatexfranquiaSic.StFeeminimoFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_StFeeminimoFaixaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.StFeeminimoFaixaSic, ref where));
			if (reajusteRebatexfranquiaSic.StFeemaximoFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_StFeemaximoFaixaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.StFeemaximoFaixaSic, ref where));
			if (reajusteRebatexfranquiaSic.StValoresFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_REAJUSTE_REBATEXFRANQUIA_SIC", C_StValoresFaixaSic, DatabaseManager.SQLOperation.Equal, reajusteRebatexfranquiaSic.StValoresFaixaSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

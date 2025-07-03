#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : SaldoRebateSicDAO.cs
// Class Name	        : SaldoRebateSicDAO
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
	#region classe concreta SaldoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a SaldoRebateSicDAO
	/// </summary>
	internal partial class SaldoRebateSicDAO : ISaldoRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbSaldoRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_SALDO_REBATE_SIC.NR_SEQ_SALDO_REBATE_SIC")
		.Append(",TB_SALDO_REBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_SALDO_REBATE_SIC.VL_SALDO_ATUAL_SIC")
		.Append(",TB_SALDO_REBATE_SIC.VL_LANCAMENTO_SIC")
		.Append(",TB_SALDO_REBATE_SIC.DT_LANCAMENTO_SIC")
		.Append(",TB_SALDO_REBATE_SIC.DS_OBS_COMPLEMENTO_SIC")
		.Append(" FROM TB_SALDO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instância de <see cref="SaldoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de SaldoRebateSic</returns>
		public IList<SaldoRebateSic> Selecionar(SaldoRebateSic saldoRebateSic, int numeroLinhas, string ordem)
		{
			IList<SaldoRebateSic> listSaldoRebateSic = new List<SaldoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, saldoRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listSaldoRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listSaldoRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto SaldoRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto SaldoRebateSic preenchido</returns>
		protected SaldoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			SaldoRebateSic saldoRebateSic = new SaldoRebateSic();
			saldoRebateSic.NrSeqSaldoRebateSic = reader.GetNullableInt32(C_NrSeqSaldoRebateSic);
			saldoRebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			saldoRebateSic.VlSaldoAtualSic = reader.GetNullableDecimal(C_VlSaldoAtualSic);
			saldoRebateSic.VlLancamentoSic = reader.GetNullableDecimal(C_VlLancamentoSic);
			saldoRebateSic.DtLancamentoSic = reader.GetNullableDateTime(C_DtLancamentoSic);
			saldoRebateSic.DsObsComplementoSic = reader.GetString(C_DsObsComplementoSic);
			return saldoRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, SaldoRebateSic saldoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (saldoRebateSic.NrSeqSaldoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_SALDO_REBATE_SIC", C_NrSeqSaldoRebateSic, DatabaseManager.SQLOperation.Equal, saldoRebateSic.NrSeqSaldoRebateSic, ref where));
			if (saldoRebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_SALDO_REBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, saldoRebateSic.NrSeqRebateSic, ref where));
			if (saldoRebateSic.VlSaldoAtualSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_SALDO_REBATE_SIC", C_VlSaldoAtualSic, DatabaseManager.SQLOperation.Equal, saldoRebateSic.VlSaldoAtualSic, ref where));
			if (saldoRebateSic.VlLancamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_SALDO_REBATE_SIC", C_VlLancamentoSic, DatabaseManager.SQLOperation.Equal, saldoRebateSic.VlLancamentoSic, ref where));
			if (saldoRebateSic.DtLancamentoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_SALDO_REBATE_SIC", C_DtLancamentoSic, DatabaseManager.SQLOperation.Equal, saldoRebateSic.DtLancamentoSic, ref where));
			if (saldoRebateSic.DsObsComplementoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_SALDO_REBATE_SIC", C_DsObsComplementoSic, DatabaseManager.SQLOperation.Like, "%" + saldoRebateSic.DsObsComplementoSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : FaixaRebateHistoricoSicDAO.cs
// Class Name	        : FaixaRebateHistoricoSicDAO
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
	#region classe concreta FaixaRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a FaixaRebateHistoricoSicDAO
	/// </summary>
	internal partial class FaixaRebateHistoricoSicDAO : IFaixaRebateHistoricoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbFaixaRebateHistoricoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_FAIXA_REBATE_HISTORICO_SIC.NR_SEQ_FAIXA_REBATE_HISTORICO_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.NR_SEQ_FAIXAREBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.DT_INICIOCALCULO_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.DT_FIMCALCULO_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.VL_VOLUMEMENSAL_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.VL_PERCMINIMO_REBATE_SIC")
		//.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.VL_PERCMAXIMO_REBATE_SIC")
		.Append(",(CASE WHEN TB_FAIXA_REBATE_HISTORICO_SIC.VL_PERCMAXIMO_REBATE_SIC > 9999999 THEN 9999999 ELSE TB_FAIXA_REBATE_HISTORICO_SIC.VL_PERCMAXIMO_REBATE_SIC END) AS VL_PERCMAXIMO_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.VL_BONIFICACAO_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.VL_RECEBEBONUS_REBATE_SIC")
		.Append(",TB_FAIXA_REBATE_HISTORICO_SIC.NR_SEQ_GRUPO_SIC")
		.Append(" FROM TB_FAIXA_REBATE_HISTORICO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instância de <see cref="FaixaRebateHistoricoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixaRebateHistoricoSic</returns>
		public IList<FaixaRebateHistoricoSic> Selecionar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, int numeroLinhas, string ordem)
		{
			IList<FaixaRebateHistoricoSic> listFaixaRebateHistoricoSic = new List<FaixaRebateHistoricoSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, faixaRebateHistoricoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listFaixaRebateHistoricoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listFaixaRebateHistoricoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto FaixaRebateHistoricoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto FaixaRebateHistoricoSic preenchido</returns>
		protected FaixaRebateHistoricoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			FaixaRebateHistoricoSic faixaRebateHistoricoSic = new FaixaRebateHistoricoSic();
			faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic = reader.GetNullableInt32(C_NrSeqFaixaRebateHistoricoSic);
			faixaRebateHistoricoSic.NrSeqFaixarebateSic = reader.GetNullableInt32(C_NrSeqFaixarebateSic);
			faixaRebateHistoricoSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			faixaRebateHistoricoSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			faixaRebateHistoricoSic.DtIniciocalculoRebateSic = reader.GetNullableDateTime(C_DtIniciocalculoRebateSic);
			faixaRebateHistoricoSic.DtFimcalculoRebateSic = reader.GetNullableDateTime(C_DtFimcalculoRebateSic);
			faixaRebateHistoricoSic.VlVolumemensalRebateSic = reader.GetNullableDecimal(C_VlVolumemensalRebateSic);
			faixaRebateHistoricoSic.VlPercminimoRebateSic = reader.GetNullableDecimal(C_VlPercminimoRebateSic);
			faixaRebateHistoricoSic.VlPercmaximoRebateSic = reader.GetNullableDecimal(C_VlPercmaximoRebateSic);
			faixaRebateHistoricoSic.VlBonificacaoRebateSic = reader.GetNullableDecimal(C_VlBonificacaoRebateSic);
			faixaRebateHistoricoSic.VlRecebebonusRebateSic = reader.GetNullableDecimal(C_VlRecebebonusRebateSic);
			faixaRebateHistoricoSic.NrSeqGrupoSic = reader.GetNullableInt32(C_NrSeqGrupoSic);
			return faixaRebateHistoricoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, FaixaRebateHistoricoSic faixaRebateHistoricoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXA_REBATE_HISTORICO_SIC", C_NrSeqFaixaRebateHistoricoSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic, ref where));
			if (faixaRebateHistoricoSic.NrSeqFaixarebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXA_REBATE_HISTORICO_SIC", C_NrSeqFaixarebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.NrSeqFaixarebateSic, ref where));
			if (faixaRebateHistoricoSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXA_REBATE_HISTORICO_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.NrSeqRebateSic, ref where));
			if (faixaRebateHistoricoSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXA_REBATE_HISTORICO_SIC", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.NrSeqCategoriaSic, ref where));
			if (faixaRebateHistoricoSic.DtIniciocalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXA_REBATE_HISTORICO_SIC", C_DtIniciocalculoRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.DtIniciocalculoRebateSic, ref where));
			if (faixaRebateHistoricoSic.DtFimcalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXA_REBATE_HISTORICO_SIC", C_DtFimcalculoRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.DtFimcalculoRebateSic, ref where));
			if (faixaRebateHistoricoSic.VlVolumemensalRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXA_REBATE_HISTORICO_SIC", C_VlVolumemensalRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.VlVolumemensalRebateSic, ref where));
			if (faixaRebateHistoricoSic.VlPercminimoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXA_REBATE_HISTORICO_SIC", C_VlPercminimoRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.VlPercminimoRebateSic, ref where));
			if (faixaRebateHistoricoSic.VlPercmaximoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXA_REBATE_HISTORICO_SIC", C_VlPercmaximoRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.VlPercmaximoRebateSic, ref where));
			if (faixaRebateHistoricoSic.VlBonificacaoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXA_REBATE_HISTORICO_SIC", C_VlBonificacaoRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.VlBonificacaoRebateSic, ref where));
			if (faixaRebateHistoricoSic.VlRecebebonusRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXA_REBATE_HISTORICO_SIC", C_VlRecebebonusRebateSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.VlRecebebonusRebateSic, ref where));
			if (faixaRebateHistoricoSic.NrSeqGrupoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXA_REBATE_HISTORICO_SIC", C_NrSeqGrupoSic, DatabaseManager.SQLOperation.Equal, faixaRebateHistoricoSic.NrSeqGrupoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : FaixarebateSicDAO.cs
// Class Name	        : FaixarebateSicDAO
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
	#region classe concreta FaixarebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a FaixarebateSicDAO
	/// </summary>
	internal partial class FaixarebateSicDAO : IFaixarebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbFaixarebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_FAIXAREBATE_SIC.NR_SEQ_FAIXAREBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.NR_SEQ_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_FAIXAREBATE_SIC.DT_INICIOCALCULO_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.DT_FIMCALCULO_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.VL_VOLUMEMENSAL_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.VL_PERCMINIMO_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.VL_PERCMAXIMO_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.VL_BONIFICACAO_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.VL_RECEBEBONUS_REBATE_SIC")
		.Append(",TB_FAIXAREBATE_SIC.NR_SEQ_GRUPO_SIC")
		.Append(",TB_FAIXAREBATE_SIC.ST_ATIVO_FAIXA_SIC")
		.Append(" FROM TB_FAIXAREBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instância de <see cref="FaixarebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de FaixarebateSic</returns>
		public IList<FaixarebateSic> Selecionar(FaixarebateSic faixarebateSic, int numeroLinhas, string ordem)
		{
			IList<FaixarebateSic> listFaixarebateSic = new List<FaixarebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, faixarebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listFaixarebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listFaixarebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto FaixarebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto FaixarebateSic preenchido</returns>
		protected FaixarebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			FaixarebateSic faixarebateSic = new FaixarebateSic();
			faixarebateSic.NrSeqFaixarebateSic = reader.GetNullableInt32(C_NrSeqFaixarebateSic);
			faixarebateSic.NrSeqRebateSic = reader.GetNullableInt32(C_NrSeqRebateSic);
			faixarebateSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			faixarebateSic.DtIniciocalculoRebateSic = reader.GetNullableDateTime(C_DtIniciocalculoRebateSic);
			faixarebateSic.DtFimcalculoRebateSic = reader.GetNullableDateTime(C_DtFimcalculoRebateSic);
			faixarebateSic.VlVolumemensalRebateSic = reader.GetNullableDecimal(C_VlVolumemensalRebateSic);
			faixarebateSic.VlPercminimoRebateSic = reader.GetNullableDecimal(C_VlPercminimoRebateSic);
			faixarebateSic.VlPercmaximoRebateSic = reader.GetNullableDecimal(C_VlPercmaximoRebateSic);
			faixarebateSic.VlBonificacaoRebateSic = reader.GetNullableDecimal(C_VlBonificacaoRebateSic);
			faixarebateSic.VlRecebebonusRebateSic = reader.GetNullableDecimal(C_VlRecebebonusRebateSic);
			faixarebateSic.NrSeqGrupoSic = reader.GetNullableInt32(C_NrSeqGrupoSic);
			faixarebateSic.StAtivoFaixaSic = reader.GetNullableBoolean(C_StAtivoFaixaSic);
			return faixarebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, FaixarebateSic faixarebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (faixarebateSic.NrSeqFaixarebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXAREBATE_SIC", C_NrSeqFaixarebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.NrSeqFaixarebateSic, ref where));
			if (faixarebateSic.NrSeqRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXAREBATE_SIC", C_NrSeqRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.NrSeqRebateSic, ref where));
			if (faixarebateSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXAREBATE_SIC", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.NrSeqCategoriaSic, ref where));
			if (faixarebateSic.DtIniciocalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXAREBATE_SIC", C_DtIniciocalculoRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.DtIniciocalculoRebateSic, ref where));
			if (faixarebateSic.DtFimcalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_FAIXAREBATE_SIC", C_DtFimcalculoRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.DtFimcalculoRebateSic, ref where));
			if (faixarebateSic.VlVolumemensalRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXAREBATE_SIC", C_VlVolumemensalRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.VlVolumemensalRebateSic, ref where));
			if (faixarebateSic.VlPercminimoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXAREBATE_SIC", C_VlPercminimoRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.VlPercminimoRebateSic, ref where));
			if (faixarebateSic.VlPercmaximoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXAREBATE_SIC", C_VlPercmaximoRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.VlPercmaximoRebateSic, ref where));
			if (faixarebateSic.VlBonificacaoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXAREBATE_SIC", C_VlBonificacaoRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.VlBonificacaoRebateSic, ref where));
			if (faixarebateSic.VlRecebebonusRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_FAIXAREBATE_SIC", C_VlRecebebonusRebateSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.VlRecebebonusRebateSic, ref where));
			if (faixarebateSic.NrSeqGrupoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_FAIXAREBATE_SIC", C_NrSeqGrupoSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.NrSeqGrupoSic, ref where));
			if (faixarebateSic.StAtivoFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_FAIXAREBATE_SIC", C_StAtivoFaixaSic, DatabaseManager.SQLOperation.Equal, faixarebateSic.StAtivoFaixaSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoRebateDAO.cs
// Class Name	        : DadosCalculoRebateDAO
// Author		        : CDI
// Creation Date 	    : 22/01/2020
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
using COSAN.Framework.DBUtil;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.DAL
{
	#region classe concreta DadosCalculoRebateDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DadosCalculoRebateDAO
	/// </summary>
	public class DadosCalculoRebateSicDAO : IDadosCalculoRebateSicDAO
	{
		#region CONSTANTES 

		public const string orderByDefault = "";
		private const string C_NR_SEQ_DADOS_CALCULO_REBATE_SIC = "NR_SEQ_DADOS_CALCULO_REBATE_SIC";
		private const string C_NR_SEQ_CLIENTE_SIC = "NR_SEQ_CLIENTE_SIC";
		private const string C_NR_IBM_CLIENTE_SIC = "NR_IBM_CLIENTE_SIC";
		private const string C_DT_PERIODO_SIC = "DT_PERIODO_SIC";
		private const string C_NR_SEQ_TIPOREBATE = "NR_SEQ_TIPOREBATE";
		private const string C_ST_CALCULO_REBATE_SIC = "ST_CALCULO_REBATE_SIC";
		private const string C_NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC = "NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC";
		private const string C_NR_SEQ_CATEGORIA_SIC = "NR_SEQ_CATEGORIA_SIC";
		private const string C_VL_VOLUMEMENSAL_REBATE_SIC = "VL_VOLUMEMENSAL_REBATE_SIC";
		private const string C_VL_PERCMINIMO_REBATE_SIC = "VL_PERCMINIMO_REBATE_SIC";
		private const string C_VL_PERCMAXIMO_REBATE_SIC = "VL_PERCMAXIMO_REBATE_SIC";
		private const string C_VL_BONIFICACAO_REBATE_SIC = "VL_BONIFICACAO_REBATE_SIC";

		#endregion

		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_DADOS_CALCULO_REBATE_SIC.NR_SEQ_DADOS_CALCULO_REBATE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_SIC.NR_SEQ_CLIENTE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_SIC.NR_IBM_CLIENTE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_SIC.DT_PERIODO_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_SIC.NR_SEQ_TIPOREBATE")
		.Append(",TB_DADOS_CALCULO_REBATE_SIC.ST_CALCULO_REBATE_SIC")
		.Append(" FROM TB_DADOS_CALCULO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries

		#region SQL / DDL

		/// <summary>
		/// cmdDadosCalculoRebateSicInsert
		/// </summary>
		private const string cmdDadosCalculoRebateSicInsert = @"
		INSERT INTO TB_DADOS_CALCULO_REBATE_SIC(
			 NR_SEQ_CLIENTE_SIC
			,NR_IBM_CLIENTE_SIC
			,DT_PERIODO_SIC
			,NR_SEQ_TIPOREBATE
			,ST_CALCULO_REBATE_SIC
		) VALUES ( 			
			@NR_SEQ_CLIENTE_SIC
			,@NR_IBM_CLIENTE_SIC
			,@DT_PERIODO_SIC
			,@NR_SEQ_TIPOREBATE
			,@ST_CALCULO_REBATE_SIC
		); SELECT SCOPE_IDENTITY()";

		private const string cmdDadosCalculoRebateFaixaSicInsert = @"
		INSERT INTO TB_DADOS_CALCULO_REBATE_FAIXA_SIC(
			 NR_SEQ_DADOS_CALCULO_REBATE_SIC
			,NR_SEQ_CATEGORIA_SIC
			,VL_VOLUMEMENSAL_REBATE_SIC
			,VL_PERCMINIMO_REBATE_SIC
			,VL_PERCMAXIMO_REBATE_SIC
			,VL_BONIFICACAO_REBATE_SIC
		) VALUES ( 
			 @NR_SEQ_DADOS_CALCULO_REBATE_SIC
			,@NR_SEQ_CATEGORIA_SIC
			,@VL_VOLUMEMENSAL_REBATE_SIC
			,@VL_PERCMINIMO_REBATE_SIC
			,@VL_PERCMAXIMO_REBATE_SIC
			,@VL_BONIFICACAO_REBATE_SIC
		)";

		#endregion

		#region METODOS PUBLICOS		

		/// <summary>
		/// Incluir
		/// </summary>
		/// <param name="dados"></param>
		public void Incluir(DadosCalculoRebateSic dados)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				databaseManager.Transaction = databaseManager.BeginTransaction();

				try
				{
					//Cabeçalho
					var paramss = this.CriarParamsDadosCalculoRebate(databaseManager, dados);
					var seq = databaseManager.GetScalar(cmdDadosCalculoRebateSicInsert, paramss, databaseManager.Transaction);
					dados.NrSeqDadosCalculoRebateSic = Int32.Parse(seq.ToString());

					//Itens
					foreach (var faixa in dados.Faixas)
					{
						faixa.NrSeqDadosCalculoRebateSic = dados.NrSeqDadosCalculoRebateSic;
						var paramss2 = this.CriarParamsDadosCalculoRebateFaixa(databaseManager, faixa);
						databaseManager.GetScalar(cmdDadosCalculoRebateFaixaSicInsert, paramss2, databaseManager.Transaction);
					}

					//Commit
					databaseManager.CommitTransaction();
				}
				catch 
				{
					try 
					{ 
						databaseManager.RollbackTransaction(); 
					} 
					catch (Exception ex) 					
					{
                        COSAN.Framework.Util.LogError.Error("Erro ao executar o rollback", ex);
					}
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}

		#region Selecionar
		/// <summary>
		/// Selecionar
		/// </summary>
		/// <param name="calculoRebateSic"></param>
		/// <param name="numeroLinhas"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, int numeroLinhas, string ordem)
		{
			IList<DadosCalculoRebateSic> listCalculoRebateSic = new List<DadosCalculoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, dadosCalculoRebateSic, out where);
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

		#endregion

		#region METODOS PRIVADOS

		/// <summary>
		/// Método CriarParamsDadosCalculoRebate
		/// </summary>
		/// <param name="db"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private List<DbParameter> CriarParamsDadosCalculoRebate(DatabaseManager db, DadosCalculoRebateSic obj)
		{
			List<DbParameter> paramss = new List<DbParameter>();
			if (obj.NrSeqDadosCalculoRebateSic > 0)
				paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_DADOS_CALCULO_REBATE_SIC, obj.NrSeqDadosCalculoRebateSic));
			paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_CLIENTE_SIC, obj.NrSeqClienteSic));
			paramss.Add(db.CreateInParameter(DbType.String, C_NR_IBM_CLIENTE_SIC, obj.NrIbmClienteSic));
			paramss.Add(db.CreateInParameter(DbType.DateTime, C_DT_PERIODO_SIC, obj.DtPeriodoSic));
			paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_TIPOREBATE, obj.NrSeqTipoRebate));
			paramss.Add(db.CreateInParameter(DbType.Boolean, C_ST_CALCULO_REBATE_SIC, obj.StCalculoRebateSic));
			return paramss;
		}

		/// <summary>
		/// Método CriarParamsDadosCalculoRebateFaixa
		/// </summary>
		/// <param name="db"></param>
		/// <param name="obj"></param>
		/// <returns></returns>
		private List<DbParameter> CriarParamsDadosCalculoRebateFaixa(DatabaseManager db, DadosCalculoRebateFaixaSic obj)
		{
			List<DbParameter> paramss = new List<DbParameter>();
			if (obj.NrSeqDadosCalculoRebateFaixaSic > 0)
				paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC, obj.NrSeqDadosCalculoRebateFaixaSic));
			paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_DADOS_CALCULO_REBATE_SIC, obj.NrSeqDadosCalculoRebateSic));
			paramss.Add(db.CreateInParameter(DbType.Int32, C_NR_SEQ_CATEGORIA_SIC, obj.NrSeqCategoriaSic));
			paramss.Add(db.CreateInParameter(DbType.Decimal, C_VL_VOLUMEMENSAL_REBATE_SIC, obj.VlVolumeMensalRebateSic));
			paramss.Add(db.CreateInParameter(DbType.Decimal, C_VL_PERCMINIMO_REBATE_SIC, obj.VlPercMinimoRebateSic));
			paramss.Add(db.CreateInParameter(DbType.Decimal, C_VL_PERCMAXIMO_REBATE_SIC, obj.VlPercMaximoRebateSic));
			paramss.Add(db.CreateInParameter(DbType.Decimal, C_VL_BONIFICACAO_REBATE_SIC, obj.VlBonificacaoRebateSic));
			return paramss;
		}

		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, DadosCalculoRebateSic dadosCalculoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_SIC", C_NR_SEQ_DADOS_CALCULO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic, ref where));
			if (dadosCalculoRebateSic.NrSeqClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_SIC", C_NR_SEQ_CLIENTE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.NrSeqClienteSic, ref where));
			if (dadosCalculoRebateSic.NrIbmClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_DADOS_CALCULO_REBATE_SIC", C_NR_IBM_CLIENTE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.NrIbmClienteSic, ref where));
			if (dadosCalculoRebateSic.DtPeriodoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_DADOS_CALCULO_REBATE_SIC", C_DT_PERIODO_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.DtPeriodoSic, ref where));
			if (dadosCalculoRebateSic.NrSeqTipoRebate != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_SIC", C_NR_SEQ_TIPOREBATE, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.NrSeqTipoRebate, ref where));
			if (dadosCalculoRebateSic.StCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_DADOS_CALCULO_REBATE_SIC", C_ST_CALCULO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateSic.StCalculoRebateSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros

		#region Preencher
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		protected DadosCalculoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			DadosCalculoRebateSic dadosCalculoRebateSic = new DadosCalculoRebateSic();
			dadosCalculoRebateSic.NrSeqDadosCalculoRebateSic = reader.GetInt32(C_NR_SEQ_DADOS_CALCULO_REBATE_SIC);
			dadosCalculoRebateSic.NrSeqClienteSic = reader.GetInt32(C_NR_SEQ_CLIENTE_SIC);
			dadosCalculoRebateSic.NrIbmClienteSic = reader.GetString(C_NR_IBM_CLIENTE_SIC);
			dadosCalculoRebateSic.DtPeriodoSic = reader.GetDateTime(C_DT_PERIODO_SIC);
			dadosCalculoRebateSic.NrSeqTipoRebate = reader.GetInt32(C_NR_SEQ_TIPOREBATE);
			dadosCalculoRebateSic.StCalculoRebateSic = reader.GetBoolean(C_ST_CALCULO_REBATE_SIC);
			return dadosCalculoRebateSic;
		}
		#endregion Preencher

		#endregion


	}
	#endregion classe concreta 
}
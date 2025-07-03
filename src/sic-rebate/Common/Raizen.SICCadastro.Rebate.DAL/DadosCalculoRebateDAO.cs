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
	#region classe concreta DadosCalculoRebateDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DadosCalculoRebateDAO
	/// </summary>
	public class DadosCalculoRebateDAO : IDadosCalculoRebateDAO
	{
		#region CONSTANTES 

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
		/// InserirDadosCalculoRebate
		/// </summary>
		/// <param name="dados"></param>
		public void InserirDadosCalculoRebate(DadosCalculoRebateSic dados)
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
				catch (Exception ex)
				{
					try { databaseManager.RollbackTransaction(); } catch (Exception) { }
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}

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

		#endregion


	}
	#endregion classe concreta 
}

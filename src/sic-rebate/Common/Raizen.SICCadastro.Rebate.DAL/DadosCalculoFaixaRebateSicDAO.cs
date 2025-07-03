#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoFaixaRebateSicDAO.cs
// Class Name	        : DadosCalculoFaixaRebateSicDAO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 27/01/2020
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
	#region classe concreta FaixarebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a FaixarebateSicDAO
	/// </summary>
	internal partial class DadosCalculoFaixaRebateSicDAO : IDadosCalculoFaixaRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		private const string C_NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC = "NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC";
		private const string C_NR_SEQ_DADOS_CALCULO_REBATE_SIC = "NR_SEQ_DADOS_CALCULO_REBATE_SIC";
		private const string C_NR_SEQ_CATEGORIA_SIC = "NR_SEQ_CATEGORIA_SIC";
		private const string C_VL_VOLUMEMENSAL_REBATE_SIC = "VL_VOLUMEMENSAL_REBATE_SIC";
		private const string C_VL_PERCMINIMO_REBATE_SIC = "VL_PERCMINIMO_REBATE_SIC";
		private const string C_VL_PERCMAXIMO_REBATE_SIC = "VL_PERCMAXIMO_REBATE_SIC";
		private const string C_VL_BONIFICACAO_REBATE_SIC = "VL_BONIFICACAO_REBATE_SIC";
		#endregion  Constantes 

		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_DADOS_CALCULO_REBATE_FAIXA_SIC.NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.NR_SEQ_DADOS_CALCULO_REBATE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_VOLUMEMENSAL_REBATE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_PERCMINIMO_REBATE_SIC")
		//.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_PERCMAXIMO_REBATE_SIC")
		.Append(",(CASE WHEN TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_PERCMAXIMO_REBATE_SIC > 9999999 THEN 9999999 ELSE TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_PERCMAXIMO_REBATE_SIC END) AS VL_PERCMAXIMO_REBATE_SIC")
		.Append(",TB_DADOS_CALCULO_REBATE_FAIXA_SIC.VL_BONIFICACAO_REBATE_SIC")
		.Append(" FROM TB_DADOS_CALCULO_REBATE_FAIXA_SIC")
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
		public IList<DadosCalculoRebateFaixaSic> Selecionar(DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, int numeroLinhas, string ordem)
		{
			IList<DadosCalculoRebateFaixaSic> listDadosCalculoRebateFaixaSic = new List<DadosCalculoRebateFaixaSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, dadosCalculoRebateFaixaSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listDadosCalculoRebateFaixaSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listDadosCalculoRebateFaixaSic;
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
		protected DadosCalculoRebateFaixaSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic = new DadosCalculoRebateFaixaSic();
			dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateFaixaSic = reader.GetNullableInt32(C_NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC);
			dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateSic = reader.GetNullableInt32(C_NR_SEQ_DADOS_CALCULO_REBATE_SIC);
			dadosCalculoRebateFaixaSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NR_SEQ_CATEGORIA_SIC);
			dadosCalculoRebateFaixaSic.VlVolumeMensalRebateSic = reader.GetNullableDecimal(C_VL_VOLUMEMENSAL_REBATE_SIC);
			dadosCalculoRebateFaixaSic.VlPercMinimoRebateSic = reader.GetNullableDecimal(C_VL_PERCMINIMO_REBATE_SIC);
			dadosCalculoRebateFaixaSic.VlPercMaximoRebateSic = reader.GetNullableDecimal(C_VL_PERCMAXIMO_REBATE_SIC);
			dadosCalculoRebateFaixaSic.VlBonificacaoRebateSic = reader.GetNullableDecimal(C_VL_BONIFICACAO_REBATE_SIC);
			return dadosCalculoRebateFaixaSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, DadosCalculoRebateFaixaSic dadosCalculoRebateFaixaSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateFaixaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_NR_SEQ_DADOS_CALCULO_REBATE_FAIXA_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateFaixaSic, ref where));
			if (dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_NR_SEQ_DADOS_CALCULO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.NrSeqDadosCalculoRebateSic, ref where));
			if (dadosCalculoRebateFaixaSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_NR_SEQ_CATEGORIA_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.NrSeqCategoriaSic, ref where));
			if (dadosCalculoRebateFaixaSic.VlVolumeMensalRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_VL_VOLUMEMENSAL_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.VlVolumeMensalRebateSic, ref where));
			if (dadosCalculoRebateFaixaSic.VlPercMinimoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_VL_PERCMINIMO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.VlPercMinimoRebateSic, ref where));
			if (dadosCalculoRebateFaixaSic.VlPercMaximoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_VL_PERCMAXIMO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.VlPercMaximoRebateSic, ref where));
			if (dadosCalculoRebateFaixaSic.VlBonificacaoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Decimal, "TB_DADOS_CALCULO_REBATE_FAIXA_SIC", C_VL_BONIFICACAO_REBATE_SIC, DatabaseManager.SQLOperation.Equal, dadosCalculoRebateFaixaSic.VlBonificacaoRebateSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}
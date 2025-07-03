#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosArquivoRebateSicDAO.cs
// Class Name	        : DadosArquivoRebateSicDAO
// Author		        : Paulo Gerage / Leandro A. Morelato
// Creation Date 	    : 17/01/2013
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
	#region classe concreta DadosArquivoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a DadosArquivoRebateSicDAO
	/// </summary>
	internal partial class DadosArquivoRebateSicDAO : IDadosArquivoRebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbDadosArquivoRebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_DADOS_ARQUIVO_REBATE_SIC.NR_SEQ_DADOS_ARQUIVO_REBATE_SIC")
		.Append(",TB_DADOS_ARQUIVO_REBATE_SIC.NR_REFERENCIA_SEQ_SIC")
		.Append(",TB_DADOS_ARQUIVO_REBATE_SIC.NR_ARQUIVO_SBOP_SEQ_SIC")
		.Append(",TB_DADOS_ARQUIVO_REBATE_SIC.NR_ARQUIVO_SAAB_SEQ_SIC")
		.Append(",TB_DADOS_ARQUIVO_REBATE_SIC.NR_ARQUIVO_MIME_SEQ_SIC")
		.Append(" FROM TB_DADOS_ARQUIVO_REBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de DadosArquivoRebateSic
		/// </summary>
		/// <param name="dadosArquivoRebateSic">Instância de <see cref="DadosArquivoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de DadosArquivoRebateSic</returns>
		public IList<DadosArquivoRebateSic> Selecionar(DadosArquivoRebateSic dadosArquivoRebateSic, int numeroLinhas, string ordem)
		{
			IList<DadosArquivoRebateSic> listDadosArquivoRebateSic = new List<DadosArquivoRebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, dadosArquivoRebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listDadosArquivoRebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listDadosArquivoRebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto DadosArquivoRebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto DadosArquivoRebateSic preenchido</returns>
		protected DadosArquivoRebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			DadosArquivoRebateSic dadosArquivoRebateSic = new DadosArquivoRebateSic();
			dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic = reader.GetNullableInt32(C_NrSeqDadosArquivoRebateSic);
			dadosArquivoRebateSic.NrReferenciaSeqSic = reader.GetNullableInt32(C_NrReferenciaSeqSic);
			dadosArquivoRebateSic.NrArquivoSbopSeqSic = reader.GetNullableInt32(C_NrArquivoSbopSeqSic);
			dadosArquivoRebateSic.NrArquivoSaabSeqSic = reader.GetNullableInt32(C_NrArquivoSaabSeqSic);
			dadosArquivoRebateSic.NrArquivoMimeSeqSic = reader.GetNullableInt32(C_NrArquivoMimeSeqSic);
			return dadosArquivoRebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="dadosArquivoRebateSic">Instance of <see cref="DadosArquivoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, DadosArquivoRebateSic dadosArquivoRebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_ARQUIVO_REBATE_SIC", C_NrSeqDadosArquivoRebateSic, DatabaseManager.SQLOperation.Equal, dadosArquivoRebateSic.NrSeqDadosArquivoRebateSic, ref where));
			if (dadosArquivoRebateSic.NrReferenciaSeqSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_ARQUIVO_REBATE_SIC", C_NrReferenciaSeqSic, DatabaseManager.SQLOperation.Equal, dadosArquivoRebateSic.NrReferenciaSeqSic, ref where));
			if (dadosArquivoRebateSic.NrArquivoSbopSeqSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_ARQUIVO_REBATE_SIC", C_NrArquivoSbopSeqSic, DatabaseManager.SQLOperation.Equal, dadosArquivoRebateSic.NrArquivoSbopSeqSic, ref where));
			if (dadosArquivoRebateSic.NrArquivoSaabSeqSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_ARQUIVO_REBATE_SIC", C_NrArquivoSaabSeqSic, DatabaseManager.SQLOperation.Equal, dadosArquivoRebateSic.NrArquivoSaabSeqSic, ref where));
			if (dadosArquivoRebateSic.NrArquivoMimeSeqSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_DADOS_ARQUIVO_REBATE_SIC", C_NrArquivoMimeSeqSic, DatabaseManager.SQLOperation.Equal, dadosArquivoRebateSic.NrArquivoMimeSeqSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

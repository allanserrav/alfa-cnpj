#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MensagemSicDAO.cs
// Class Name	        : MensagemSicDAO
// Author		        : Romildo Cruz
// Creation Date 	    : 22/10/2012
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//	Modified By             : Paulo Gerage
//	Date of Modification    : 18/12/2012
//	Reason for modification : Change namespace SICCadastro to SICCadastro.Rebate
//	Modification Done       : 18/12/2012
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
	#region classe concreta MensagemSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a MensagemSicDAO
	/// </summary>
	internal partial class MensagemSicDAO : IMensagemSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbMensagemSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_MENSAGEM_SIC.NR_SEQ_MENSAGEM_SIC")
		.Append(",TB_MENSAGEM_SIC.NM_MENSAGEM_SIC")
		.Append(",TB_MENSAGEM_SIC.DS_MENSAGEM_SIC")
		.Append(",TB_MENSAGEM_SIC.DS_EMAIL_MENSAGEM_SIC")
		.Append(" FROM TB_MENSAGEM_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MensagemSic
		/// </summary>
		/// <param name="mensagemSic">Instância de <see cref="MensagemSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MensagemSic</returns>
		public IList<MensagemSic> Selecionar(MensagemSic mensagemSic, int numeroLinhas, string ordem)
		{
			IList<MensagemSic> listMensagemSic = new List<MensagemSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, mensagemSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listMensagemSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listMensagemSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto MensagemSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto MensagemSic preenchido</returns>
		protected MensagemSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			MensagemSic mensagemSic = new MensagemSic();
			mensagemSic.NrSeqMensagemSic = reader.GetNullableInt32(C_NrSeqMensagemSic);
			mensagemSic.NmMensagemSic = reader.GetString(C_NmMensagemSic);
			mensagemSic.DsMensagemSic = reader.GetString(C_DsMensagemSic);
			mensagemSic.DsEmailMensagemSic = reader.GetString(C_DsEmailMensagemSic);
			return mensagemSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="mensagemSic">Instance of <see cref="MensagemSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, MensagemSic mensagemSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (mensagemSic.NrSeqMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_MENSAGEM_SIC", C_NrSeqMensagemSic, DatabaseManager.SQLOperation.Equal, mensagemSic.NrSeqMensagemSic, ref where));
			if (mensagemSic.NmMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MENSAGEM_SIC", C_NmMensagemSic, DatabaseManager.SQLOperation.Like, "%" + mensagemSic.NmMensagemSic + "%", ref where));
			if (mensagemSic.DsMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MENSAGEM_SIC", C_DsMensagemSic, DatabaseManager.SQLOperation.Like, "%" + mensagemSic.DsMensagemSic + "%", ref where));
			if (mensagemSic.DsEmailMensagemSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_MENSAGEM_SIC", C_DsEmailMensagemSic, DatabaseManager.SQLOperation.Like, "%" + mensagemSic.DsEmailMensagemSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

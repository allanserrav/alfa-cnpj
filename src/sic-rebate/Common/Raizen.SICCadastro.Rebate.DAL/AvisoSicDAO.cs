#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AvisoSicDAO.cs
// Class Name	        : AvisoSicDAO
// Author		        : Hélio Jânio Ferreira
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
	#region classe concreta AvisoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a AvisoSicDAO
	/// </summary>
	internal partial class AvisoSicDAO : IAvisoSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbAvisoSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_AVISO_SIC.NR_SEQ_AVISO_SIC")
		.Append(",TB_AVISO_SIC.NR_SEQ_TIPOCLIENTE_SIC")
		.Append(",TB_AVISO_SIC.DS_AVISO_SIC")
		.Append(",TB_AVISO_SIC.ST_AVISO_SIC")
		.Append(",TB_AVISO_SIC.NM_USUARIOEX_SIC")
		.Append(",TB_AVISO_SIC.DT_EXCLUSAOAVISO_SIC")
		.Append(",TB_AVISO_SIC.NR_IBM_AVISO_SIC")
		.Append(",TB_AVISO_SIC.NR_SEQ_TIPO_AVISO_SIC")
		.Append(",TB_AVISO_SIC.DT_INCLUSAOAVISO_SIC")
		.Append(" FROM TB_AVISO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de AvisoSic
		/// </summary>
		/// <param name="avisoSic">Instância de <see cref="AvisoSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de AvisoSic</returns>
		public IList<AvisoSic> Selecionar(AvisoSic avisoSic, int numeroLinhas, string ordem)
		{
			IList<AvisoSic> listAvisoSic = new List<AvisoSic>();
			using (DatabaseManager databaseManager  = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, avisoSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listAvisoSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listAvisoSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto AvisoSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto AvisoSic preenchido</returns>
		protected AvisoSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			AvisoSic avisoSic = new AvisoSic();
			avisoSic.NrSeqAvisoSic = reader.GetNullableInt32(C_NrSeqAvisoSic);
			avisoSic.NrSeqTipoclienteSic = reader.GetNullableInt32(C_NrSeqTipoclienteSic);
			avisoSic.DsAvisoSic = reader.GetString(C_DsAvisoSic);
			avisoSic.StAvisoSic = reader.GetNullableBoolean(C_StAvisoSic);
			avisoSic.NmUsuarioexSic = reader.GetString(C_NmUsuarioexSic);
			avisoSic.DtExclusaoavisoSic = reader.GetNullableDateTime(C_DtExclusaoavisoSic);
			avisoSic.NrIbmAvisoSic = reader.GetString(C_NrIbmAvisoSic);
			avisoSic.NrSeqTipoAvisoSic = reader.GetNullableInt32(C_NrSeqTipoAvisoSic);
			avisoSic.DtInclusaoavisoSic = reader.GetNullableDateTime(C_DtInclusaoavisoSic);
			return avisoSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="avisoSic">Instance of <see cref="AvisoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, AvisoSic avisoSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (avisoSic.NrSeqAvisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AVISO_SIC", C_NrSeqAvisoSic, DatabaseManager.SQLOperation.Equal, avisoSic.NrSeqAvisoSic, ref where));
			if (avisoSic.NrSeqTipoclienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AVISO_SIC", C_NrSeqTipoclienteSic, DatabaseManager.SQLOperation.Equal, avisoSic.NrSeqTipoclienteSic, ref where));
			if (avisoSic.DsAvisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AVISO_SIC", C_DsAvisoSic, DatabaseManager.SQLOperation.Like, "%" + avisoSic.DsAvisoSic + "%", ref where));
			if (avisoSic.StAvisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_AVISO_SIC", C_StAvisoSic, DatabaseManager.SQLOperation.Equal, avisoSic.StAvisoSic, ref where));
			if (avisoSic.NmUsuarioexSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AVISO_SIC", C_NmUsuarioexSic, DatabaseManager.SQLOperation.Like, "%" + avisoSic.NmUsuarioexSic + "%", ref where));
			if (avisoSic.DtExclusaoavisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_AVISO_SIC", C_DtExclusaoavisoSic, DatabaseManager.SQLOperation.Equal, avisoSic.DtExclusaoavisoSic, ref where));
			if (avisoSic.NrIbmAvisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_AVISO_SIC", C_NrIbmAvisoSic, DatabaseManager.SQLOperation.Like, "%" + avisoSic.NrIbmAvisoSic + "%", ref where));
			if (avisoSic.NrSeqTipoAvisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_AVISO_SIC", C_NrSeqTipoAvisoSic, DatabaseManager.SQLOperation.Equal, avisoSic.NrSeqTipoAvisoSic, ref where));
			if (avisoSic.DtInclusaoavisoSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.DateTime, "TB_AVISO_SIC", C_DtInclusaoavisoSic, DatabaseManager.SQLOperation.Equal, avisoSic.DtInclusaoavisoSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

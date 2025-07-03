#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : TiporebateSicDAO.cs
// Class Name	        : TiporebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 05/11/2012
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
	#region classe concreta TiporebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TiporebateSicDAO
	/// </summary>
	internal partial class TiporebateSicDAO : ITiporebateSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbTiporebateSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_TIPOREBATE_SIC.NR_SEQ_TIPOREBATE_SIC")
		.Append(",TB_TIPOREBATE_SIC.NM_TIPOREBATE_SIC")
		.Append(",TB_TIPOREBATE_SIC.DS_TIPOREBATE_SIC")
		.Append(" FROM TB_TIPOREBATE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instância de <see cref="TiporebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TiporebateSic</returns>
		public IList<TiporebateSic> Selecionar(TiporebateSic tiporebateSic, int numeroLinhas, string ordem)
		{
			IList<TiporebateSic> listTiporebateSic = new List<TiporebateSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, tiporebateSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listTiporebateSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listTiporebateSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto TiporebateSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto TiporebateSic preenchido</returns>
		protected TiporebateSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			TiporebateSic tiporebateSic = new TiporebateSic();
			tiporebateSic.NrSeqTiporebateSic = reader.GetNullableInt32(C_NrSeqTiporebateSic);
			tiporebateSic.NmTiporebateSic = reader.GetString(C_NmTiporebateSic);
			tiporebateSic.DsTiporebateSic = reader.GetString(C_DsTiporebateSic);
			return tiporebateSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, TiporebateSic tiporebateSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (tiporebateSic.NrSeqTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_TIPOREBATE_SIC", C_NrSeqTiporebateSic, DatabaseManager.SQLOperation.Equal, tiporebateSic.NrSeqTiporebateSic, ref where));
			if (tiporebateSic.NmTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_TIPOREBATE_SIC", C_NmTiporebateSic, DatabaseManager.SQLOperation.Like, "%" + tiporebateSic.NmTiporebateSic + "%", ref where));
			if (tiporebateSic.DsTiporebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_TIPOREBATE_SIC", C_DsTiporebateSic, DatabaseManager.SQLOperation.Like, "%" + tiporebateSic.DsTiporebateSic + "%", ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

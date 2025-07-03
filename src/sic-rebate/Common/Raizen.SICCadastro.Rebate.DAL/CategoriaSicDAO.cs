#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : CategoriaSicDAO.cs
// Class Name	        : CategoriaSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 31/10/2012
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
	#region classe concreta CategoriaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CategoriaSicDAO
	/// </summary>
	internal partial class CategoriaSicDAO : ICategoriaSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbCategoriaSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CATEGORIA_SIC.NR_SEQ_CATEGORIA_SIC")
		.Append(",TB_CATEGORIA_SIC.NM_CATEGORIA_SIC")
		.Append(",TB_CATEGORIA_SIC.DS_CATEGORIA_SIC")
		.Append(",TB_CATEGORIA_SIC.ST_CATEGORIA_PISTA_SIC")
		.Append(",TB_CATEGORIA_SIC.ST_CATEGORIA_LOJA_SIC")
		.Append(",TB_CATEGORIA_SIC.ST_CATEGORIA_FRANQUIA_SIC")
		.Append(",TB_CATEGORIA_SIC.ST_CATEGORIA_REBATE_SIC")
		.Append(" FROM TB_CATEGORIA_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instância de <see cref="CategoriaSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CategoriaSic</returns>
		public IList<CategoriaSic> Selecionar(CategoriaSic categoriaSic, int numeroLinhas, string ordem)
		{
			IList<CategoriaSic> listCategoriaSic = new List<CategoriaSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, categoriaSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listCategoriaSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listCategoriaSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto CategoriaSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto CategoriaSic preenchido</returns>
		protected CategoriaSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			CategoriaSic categoriaSic = new CategoriaSic();
			categoriaSic.NrSeqCategoriaSic = reader.GetNullableInt32(C_NrSeqCategoriaSic);
			categoriaSic.NmCategoriaSic = reader.GetString(C_NmCategoriaSic);
			categoriaSic.DsCategoriaSic = reader.GetString(C_DsCategoriaSic);
			categoriaSic.StCategoriaPistaSic = reader.GetNullableBoolean(C_StCategoriaPistaSic);
			categoriaSic.StCategoriaLojaSic = reader.GetNullableBoolean(C_StCategoriaLojaSic);
			categoriaSic.StCategoriaFranquiaSic = reader.GetNullableBoolean(C_StCategoriaFranquiaSic);
			categoriaSic.StCategoriaRebateSic = reader.GetNullableBoolean(C_StCategoriaRebateSic);
			return categoriaSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, CategoriaSic categoriaSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (categoriaSic.NrSeqCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CATEGORIA_SIC", C_NrSeqCategoriaSic, DatabaseManager.SQLOperation.Equal, categoriaSic.NrSeqCategoriaSic, ref where));
			if (categoriaSic.NmCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CATEGORIA_SIC", C_NmCategoriaSic, DatabaseManager.SQLOperation.Like, "%" + categoriaSic.NmCategoriaSic + "%", ref where));
			if (categoriaSic.DsCategoriaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CATEGORIA_SIC", C_DsCategoriaSic, DatabaseManager.SQLOperation.Like, "%" + categoriaSic.DsCategoriaSic + "%", ref where));
			if (categoriaSic.StCategoriaPistaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CATEGORIA_SIC", C_StCategoriaPistaSic, DatabaseManager.SQLOperation.Equal, categoriaSic.StCategoriaPistaSic, ref where));
			if (categoriaSic.StCategoriaLojaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CATEGORIA_SIC", C_StCategoriaLojaSic, DatabaseManager.SQLOperation.Equal, categoriaSic.StCategoriaLojaSic, ref where));
			if (categoriaSic.StCategoriaFranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CATEGORIA_SIC", C_StCategoriaFranquiaSic, DatabaseManager.SQLOperation.Equal, categoriaSic.StCategoriaFranquiaSic, ref where));
			if (categoriaSic.StCategoriaRebateSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CATEGORIA_SIC", C_StCategoriaRebateSic, DatabaseManager.SQLOperation.Equal, categoriaSic.StCategoriaRebateSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

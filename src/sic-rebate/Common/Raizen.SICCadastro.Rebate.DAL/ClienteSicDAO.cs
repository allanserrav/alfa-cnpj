#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ClienteSicDAO.cs
// Class Name	        : ClienteSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 21/03/2013
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
	#region classe concreta ClienteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ClienteSicDAO
	/// </summary>
	internal partial class ClienteSicDAO : IClienteSicDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbClienteSic
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_CLIENTE_SIC.NR_SEQ_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NR_IBM_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NR_CNPJ_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NR_SEQ_EMPRESA_SIC")
		.Append(",TB_CLIENTE_SIC.NR_SEQ_SISTEMA_SIC")
		.Append(",TB_CLIENTE_SIC.NR_INSCESTADLOJA_FRANQUIA_SIC")
		.Append(",TB_CLIENTE_SIC.NR_SEQ_AREA_SIC")
		.Append(",TB_CLIENTE_SIC.NM_RAZSOCIALLOJA_FRANQUIA_SIC")
		.Append(",TB_CLIENTE_SIC.NM_GTLOJA_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NM_GALOJA_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NR_CEGRPOSTO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_DESCONTOIMPOSTO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_REBRANDING_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_ENVIOCALENDARIO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_PROCESSOJUDICIAL_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_FOODSERVFULL_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_PRGCAFE_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_SANDUICHE_QUENTE_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_VENDECARTAO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_ATM_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_OI_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_ABRI_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_A0_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_A4_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_GALHARDESTES_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_CARTAZCOLUNA_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_STATIONPOSTER_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.DS_OBS_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NM_CANAL_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.NM_SEGMERCADO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_SANDUICHE_FRIO_CLIENTE_SIC")
		.Append(",TB_CLIENTE_SIC.ST_FOODSERVSELF_CLIENTE_SIC")
		.Append(" FROM TB_CLIENTE_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instância de <see cref="ClienteSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de ClienteSic</returns>
		public IList<ClienteSic> Selecionar(ClienteSic clienteSic, int numeroLinhas, string ordem)
		{
			IList<ClienteSic> listClienteSic = new List<ClienteSic>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, clienteSic, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listClienteSic.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listClienteSic;
		}
		#endregion Selecionar
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto ClienteSic a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto ClienteSic preenchido</returns>
		protected ClienteSic Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			ClienteSic clienteSic = new ClienteSic();
			clienteSic.NrSeqClienteSic = reader.GetNullableInt32(C_NrSeqClienteSic);
			clienteSic.NrIbmClienteSic = reader.GetString(C_NrIbmClienteSic);
			clienteSic.NrCnpjClienteSic = reader.GetString(C_NrCnpjClienteSic);
			clienteSic.NrSeqEmpresaSic = reader.GetNullableInt32(C_NrSeqEmpresaSic);
			clienteSic.NrSeqSistemaSic = reader.GetNullableInt32(C_NrSeqSistemaSic);
			clienteSic.NrInscestadlojaFranquiaSic = reader.GetString(C_NrInscestadlojaFranquiaSic);
			clienteSic.NrSeqAreaSic = reader.GetNullableInt32(C_NrSeqAreaSic);
			clienteSic.NmRazsociallojaFranquiaSic = reader.GetString(C_NmRazsociallojaFranquiaSic);
			clienteSic.NmGtlojaClienteSic = reader.GetString(C_NmGtlojaClienteSic);
			clienteSic.NmGalojaClienteSic = reader.GetString(C_NmGalojaClienteSic);
			clienteSic.NrCegrpostoClienteSic = reader.GetString(C_NrCegrpostoClienteSic);
			clienteSic.StDescontoimpostoClienteSic = reader.GetNullableBoolean(C_StDescontoimpostoClienteSic);
			clienteSic.StRebrandingClienteSic = reader.GetNullableBoolean(C_StRebrandingClienteSic);
			clienteSic.StEnviocalendarioClienteSic = reader.GetNullableBoolean(C_StEnviocalendarioClienteSic);
			clienteSic.StProcessojudicialClienteSic = reader.GetNullableBoolean(C_StProcessojudicialClienteSic);
			clienteSic.StFoodservfullClienteSic = reader.GetNullableBoolean(C_StFoodservfullClienteSic);
			clienteSic.StPrgcafeClienteSic = reader.GetNullableBoolean(C_StPrgcafeClienteSic);
			clienteSic.StSanduicheQuenteClienteSic = reader.GetNullableBoolean(C_StSanduicheQuenteClienteSic);
			clienteSic.StVendecartaoClienteSic = reader.GetNullableBoolean(C_StVendecartaoClienteSic);
			clienteSic.StAtmClienteSic = reader.GetNullableBoolean(C_StAtmClienteSic);
			clienteSic.StOiClienteSic = reader.GetNullableBoolean(C_StOiClienteSic);
			clienteSic.StAbriClienteSic = reader.GetNullableBoolean(C_StAbriClienteSic);
			clienteSic.StA0ClienteSic = reader.GetNullableBoolean(C_StA0ClienteSic);
			clienteSic.StA4ClienteSic = reader.GetNullableBoolean(C_StA4ClienteSic);
			clienteSic.StGalhardestesClienteSic = reader.GetNullableBoolean(C_StGalhardestesClienteSic);
			clienteSic.StCartazcolunaClienteSic = reader.GetNullableBoolean(C_StCartazcolunaClienteSic);
			clienteSic.StStationposterClienteSic = reader.GetNullableBoolean(C_StStationposterClienteSic);
			clienteSic.DsObsClienteSic = reader.GetString(C_DsObsClienteSic);
			clienteSic.NmCanalClienteSic = reader.GetString(C_NmCanalClienteSic);
			clienteSic.NmSegmercadoClienteSic = reader.GetString(C_NmSegmercadoClienteSic);
			clienteSic.StSanduicheFrioClienteSic = reader.GetNullableBoolean(C_StSanduicheFrioClienteSic);
			clienteSic.StFoodservselfClienteSic = reader.GetNullableBoolean(C_StFoodservselfClienteSic);
			return clienteSic;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, ClienteSic clienteSic, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (clienteSic.NrSeqClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTE_SIC", C_NrSeqClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.NrSeqClienteSic, ref where));
			if (clienteSic.NrIbmClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NrIbmClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NrIbmClienteSic + "%", ref where));
			if (clienteSic.NrCnpjClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NrCnpjClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NrCnpjClienteSic + "%", ref where));
			if (clienteSic.NrSeqEmpresaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTE_SIC", C_NrSeqEmpresaSic, DatabaseManager.SQLOperation.Equal, clienteSic.NrSeqEmpresaSic, ref where));
			if (clienteSic.NrSeqSistemaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTE_SIC", C_NrSeqSistemaSic, DatabaseManager.SQLOperation.Equal, clienteSic.NrSeqSistemaSic, ref where));
			if (clienteSic.NrInscestadlojaFranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NrInscestadlojaFranquiaSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NrInscestadlojaFranquiaSic + "%", ref where));
			if (clienteSic.NrSeqAreaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_CLIENTE_SIC", C_NrSeqAreaSic, DatabaseManager.SQLOperation.Equal, clienteSic.NrSeqAreaSic, ref where));
			if (clienteSic.NmRazsociallojaFranquiaSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NmRazsociallojaFranquiaSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NmRazsociallojaFranquiaSic + "%", ref where));
			if (clienteSic.NmGtlojaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NmGtlojaClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NmGtlojaClienteSic + "%", ref where));
			if (clienteSic.NmGalojaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NmGalojaClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NmGalojaClienteSic + "%", ref where));
			if (clienteSic.NrCegrpostoClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NrCegrpostoClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NrCegrpostoClienteSic + "%", ref where));
			if (clienteSic.StDescontoimpostoClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StDescontoimpostoClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StDescontoimpostoClienteSic, ref where));
			if (clienteSic.StRebrandingClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StRebrandingClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StRebrandingClienteSic, ref where));
			if (clienteSic.StEnviocalendarioClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StEnviocalendarioClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StEnviocalendarioClienteSic, ref where));
			if (clienteSic.StProcessojudicialClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StProcessojudicialClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StProcessojudicialClienteSic, ref where));
			if (clienteSic.StFoodservfullClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StFoodservfullClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StFoodservfullClienteSic, ref where));
			if (clienteSic.StPrgcafeClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StPrgcafeClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StPrgcafeClienteSic, ref where));
			if (clienteSic.StSanduicheQuenteClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StSanduicheQuenteClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StSanduicheQuenteClienteSic, ref where));
			if (clienteSic.StVendecartaoClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StVendecartaoClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StVendecartaoClienteSic, ref where));
			if (clienteSic.StAtmClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StAtmClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StAtmClienteSic, ref where));
			if (clienteSic.StOiClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StOiClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StOiClienteSic, ref where));
			if (clienteSic.StAbriClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StAbriClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StAbriClienteSic, ref where));
			if (clienteSic.StA0ClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StA0ClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StA0ClienteSic, ref where));
			if (clienteSic.StA4ClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StA4ClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StA4ClienteSic, ref where));
			if (clienteSic.StGalhardestesClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StGalhardestesClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StGalhardestesClienteSic, ref where));
			if (clienteSic.StCartazcolunaClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StCartazcolunaClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StCartazcolunaClienteSic, ref where));
			if (clienteSic.StStationposterClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StStationposterClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StStationposterClienteSic, ref where));
			if (clienteSic.DsObsClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_DsObsClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.DsObsClienteSic + "%", ref where));
			if (clienteSic.NmCanalClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NmCanalClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NmCanalClienteSic + "%", ref where));
			if (clienteSic.NmSegmercadoClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_CLIENTE_SIC", C_NmSegmercadoClienteSic, DatabaseManager.SQLOperation.Like, "%" + clienteSic.NmSegmercadoClienteSic + "%", ref where));
			if (clienteSic.StSanduicheFrioClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StSanduicheFrioClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StSanduicheFrioClienteSic, ref where));
			if (clienteSic.StFoodservselfClienteSic != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Boolean, "TB_CLIENTE_SIC", C_StFoodservselfClienteSic, DatabaseManager.SQLOperation.Equal, clienteSic.StFoodservselfClienteSic, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

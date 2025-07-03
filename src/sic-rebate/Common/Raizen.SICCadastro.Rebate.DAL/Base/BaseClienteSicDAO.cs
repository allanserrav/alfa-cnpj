#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseClienteSicDAO.cs
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
	#region classe base ClienteSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ClienteSicDAO
	/// </summary>
	internal partial class ClienteSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ClienteSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqClienteSic = "NR_SEQ_CLIENTE_SIC";
		private const string C_NrIbmClienteSic = "NR_IBM_CLIENTE_SIC";
		private const string C_NrCnpjClienteSic = "NR_CNPJ_CLIENTE_SIC";
		private const string C_NrSeqEmpresaSic = "NR_SEQ_EMPRESA_SIC";
		private const string C_NrSeqSistemaSic = "NR_SEQ_SISTEMA_SIC";
		private const string C_NrInscestadlojaFranquiaSic = "NR_INSCESTADLOJA_FRANQUIA_SIC";
		private const string C_NrSeqAreaSic = "NR_SEQ_AREA_SIC";
		private const string C_NmRazsociallojaFranquiaSic = "NM_RAZSOCIALLOJA_FRANQUIA_SIC";
		private const string C_NmGtlojaClienteSic = "NM_GTLOJA_CLIENTE_SIC";
		private const string C_NmGalojaClienteSic = "NM_GALOJA_CLIENTE_SIC";
		private const string C_NrCegrpostoClienteSic = "NR_CEGRPOSTO_CLIENTE_SIC";
		private const string C_StDescontoimpostoClienteSic = "ST_DESCONTOIMPOSTO_CLIENTE_SIC";
		private const string C_StRebrandingClienteSic = "ST_REBRANDING_CLIENTE_SIC";
		private const string C_StEnviocalendarioClienteSic = "ST_ENVIOCALENDARIO_CLIENTE_SIC";
		private const string C_StProcessojudicialClienteSic = "ST_PROCESSOJUDICIAL_CLIENTE_SIC";
		private const string C_StFoodservfullClienteSic = "ST_FOODSERVFULL_CLIENTE_SIC";
		private const string C_StPrgcafeClienteSic = "ST_PRGCAFE_CLIENTE_SIC";
		private const string C_StSanduicheQuenteClienteSic = "ST_SANDUICHE_QUENTE_CLIENTE_SIC";
		private const string C_StVendecartaoClienteSic = "ST_VENDECARTAO_CLIENTE_SIC";
		private const string C_StAtmClienteSic = "ST_ATM_CLIENTE_SIC";
		private const string C_StOiClienteSic = "ST_OI_CLIENTE_SIC";
		private const string C_StAbriClienteSic = "ST_ABRI_CLIENTE_SIC";
		private const string C_StA0ClienteSic = "ST_A0_CLIENTE_SIC";
		private const string C_StA4ClienteSic = "ST_A4_CLIENTE_SIC";
		private const string C_StGalhardestesClienteSic = "ST_GALHARDESTES_CLIENTE_SIC";
		private const string C_StCartazcolunaClienteSic = "ST_CARTAZCOLUNA_CLIENTE_SIC";
		private const string C_StStationposterClienteSic = "ST_STATIONPOSTER_CLIENTE_SIC";
		private const string C_DsObsClienteSic = "DS_OBS_CLIENTE_SIC";
		private const string C_NmCanalClienteSic = "NM_CANAL_CLIENTE_SIC";
		private const string C_NmSegmercadoClienteSic = "NM_SEGMERCADO_CLIENTE_SIC";
		private const string C_StSanduicheFrioClienteSic = "ST_SANDUICHE_FRIO_CLIENTE_SIC";
		private const string C_StFoodservselfClienteSic = "ST_FOODSERVSELF_CLIENTE_SIC";
		#endregion  Constantes de TbClienteSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CLIENTE_SIC")
		.Append("(")
		.Append("NR_IBM_CLIENTE_SIC,NR_CNPJ_CLIENTE_SIC,NR_SEQ_EMPRESA_SIC,NR_SEQ_SISTEMA_SIC,NR_INSCESTADLOJA_FRANQUIA_SIC,NR_SEQ_AREA_SIC,NM_RAZSOCIALLOJA_FRANQUIA_SIC,NM_GTLOJA_CLIENTE_SIC,NM_GALOJA_CLIENTE_SIC,NR_CEGRPOSTO_CLIENTE_SIC,ST_DESCONTOIMPOSTO_CLIENTE_SIC,ST_REBRANDING_CLIENTE_SIC,ST_ENVIOCALENDARIO_CLIENTE_SIC,ST_PROCESSOJUDICIAL_CLIENTE_SIC,ST_FOODSERVFULL_CLIENTE_SIC,ST_PRGCAFE_CLIENTE_SIC,ST_SANDUICHE_QUENTE_CLIENTE_SIC,ST_VENDECARTAO_CLIENTE_SIC,ST_ATM_CLIENTE_SIC,ST_OI_CLIENTE_SIC,ST_ABRI_CLIENTE_SIC,ST_A0_CLIENTE_SIC,ST_A4_CLIENTE_SIC,ST_GALHARDESTES_CLIENTE_SIC,ST_CARTAZCOLUNA_CLIENTE_SIC,ST_STATIONPOSTER_CLIENTE_SIC,DS_OBS_CLIENTE_SIC,NM_CANAL_CLIENTE_SIC,NM_SEGMERCADO_CLIENTE_SIC,ST_SANDUICHE_FRIO_CLIENTE_SIC,ST_FOODSERVSELF_CLIENTE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrIbmClienteSic)
		.Append(", ")
		.Append("@" + C_NrCnpjClienteSic)
		.Append(", ")
		.Append("@" + C_NrSeqEmpresaSic)
		.Append(", ")
		.Append("@" + C_NrSeqSistemaSic)
		.Append(", ")
		.Append("@" + C_NrInscestadlojaFranquiaSic)
		.Append(", ")
		.Append("@" + C_NrSeqAreaSic)
		.Append(", ")
		.Append("@" + C_NmRazsociallojaFranquiaSic)
		.Append(", ")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(", ")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(", ")
		.Append("@" + C_NrCegrpostoClienteSic)
		.Append(", ")
		.Append("@" + C_StDescontoimpostoClienteSic)
		.Append(", ")
		.Append("@" + C_StRebrandingClienteSic)
		.Append(", ")
		.Append("@" + C_StEnviocalendarioClienteSic)
		.Append(", ")
		.Append("@" + C_StProcessojudicialClienteSic)
		.Append(", ")
		.Append("@" + C_StFoodservfullClienteSic)
		.Append(", ")
		.Append("@" + C_StPrgcafeClienteSic)
		.Append(", ")
		.Append("@" + C_StSanduicheQuenteClienteSic)
		.Append(", ")
		.Append("@" + C_StVendecartaoClienteSic)
		.Append(", ")
		.Append("@" + C_StAtmClienteSic)
		.Append(", ")
		.Append("@" + C_StOiClienteSic)
		.Append(", ")
		.Append("@" + C_StAbriClienteSic)
		.Append(", ")
		.Append("@" + C_StA0ClienteSic)
		.Append(", ")
		.Append("@" + C_StA4ClienteSic)
		.Append(", ")
		.Append("@" + C_StGalhardestesClienteSic)
		.Append(", ")
		.Append("@" + C_StCartazcolunaClienteSic)
		.Append(", ")
		.Append("@" + C_StStationposterClienteSic)
		.Append(", ")
		.Append("@" + C_DsObsClienteSic)
		.Append(", ")
		.Append("@" + C_NmCanalClienteSic)
		.Append(", ")
		.Append("@" + C_NmSegmercadoClienteSic)
		.Append(", ")
		.Append("@" + C_StSanduicheFrioClienteSic)
		.Append(", ")
		.Append("@" + C_StFoodservselfClienteSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CLIENTE_SIC SET")
		.Append(" NR_IBM_CLIENTE_SIC = ")
		.Append("@" + C_NrIbmClienteSic)
		.Append(",NR_CNPJ_CLIENTE_SIC = ")
		.Append("@" + C_NrCnpjClienteSic)
		.Append(",NR_SEQ_EMPRESA_SIC = ")
		.Append("@" + C_NrSeqEmpresaSic)
		.Append(",NR_SEQ_SISTEMA_SIC = ")
		.Append("@" + C_NrSeqSistemaSic)
		.Append(",NR_INSCESTADLOJA_FRANQUIA_SIC = ")
		.Append("@" + C_NrInscestadlojaFranquiaSic)
		.Append(",NR_SEQ_AREA_SIC = ")
		.Append("@" + C_NrSeqAreaSic)
		.Append(",NM_RAZSOCIALLOJA_FRANQUIA_SIC = ")
		.Append("@" + C_NmRazsociallojaFranquiaSic)
		.Append(",NM_GTLOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(",NM_GALOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(",NR_CEGRPOSTO_CLIENTE_SIC = ")
		.Append("@" + C_NrCegrpostoClienteSic)
		.Append(",ST_DESCONTOIMPOSTO_CLIENTE_SIC = ")
		.Append("@" + C_StDescontoimpostoClienteSic)
		.Append(",ST_REBRANDING_CLIENTE_SIC = ")
		.Append("@" + C_StRebrandingClienteSic)
		.Append(",ST_ENVIOCALENDARIO_CLIENTE_SIC = ")
		.Append("@" + C_StEnviocalendarioClienteSic)
		.Append(",ST_PROCESSOJUDICIAL_CLIENTE_SIC = ")
		.Append("@" + C_StProcessojudicialClienteSic)
		.Append(",ST_FOODSERVFULL_CLIENTE_SIC = ")
		.Append("@" + C_StFoodservfullClienteSic)
		.Append(",ST_PRGCAFE_CLIENTE_SIC = ")
		.Append("@" + C_StPrgcafeClienteSic)
		.Append(",ST_SANDUICHE_QUENTE_CLIENTE_SIC = ")
		.Append("@" + C_StSanduicheQuenteClienteSic)
		.Append(",ST_VENDECARTAO_CLIENTE_SIC = ")
		.Append("@" + C_StVendecartaoClienteSic)
		.Append(",ST_ATM_CLIENTE_SIC = ")
		.Append("@" + C_StAtmClienteSic)
		.Append(",ST_OI_CLIENTE_SIC = ")
		.Append("@" + C_StOiClienteSic)
		.Append(",ST_ABRI_CLIENTE_SIC = ")
		.Append("@" + C_StAbriClienteSic)
		.Append(",ST_A0_CLIENTE_SIC = ")
		.Append("@" + C_StA0ClienteSic)
		.Append(",ST_A4_CLIENTE_SIC = ")
		.Append("@" + C_StA4ClienteSic)
		.Append(",ST_GALHARDESTES_CLIENTE_SIC = ")
		.Append("@" + C_StGalhardestesClienteSic)
		.Append(",ST_CARTAZCOLUNA_CLIENTE_SIC = ")
		.Append("@" + C_StCartazcolunaClienteSic)
		.Append(",ST_STATIONPOSTER_CLIENTE_SIC = ")
		.Append("@" + C_StStationposterClienteSic)
		.Append(",DS_OBS_CLIENTE_SIC = ")
		.Append("@" + C_DsObsClienteSic)
		.Append(",NM_CANAL_CLIENTE_SIC = ")
		.Append("@" + C_NmCanalClienteSic)
		.Append(",NM_SEGMERCADO_CLIENTE_SIC = ")
		.Append("@" + C_NmSegmercadoClienteSic)
		.Append(",ST_SANDUICHE_FRIO_CLIENTE_SIC = ")
		.Append("@" + C_StSanduicheFrioClienteSic)
		.Append(",ST_FOODSERVSELF_CLIENTE_SIC = ")
		.Append("@" + C_StFoodservselfClienteSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CLIENTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append("").ToString();
		#endregion Query Excluir
		
		#region Query retorna Sequence 
		/// <summary>
		/// Strings with retrieve sequence query
		/// </summary>
		private string queryRetornaSequencia = new StringBuilder().Append("SELECT ")
		.Append(" SCOPE_IDENTITY()").ToString();
		#endregion Retrieve Sequence
		
		#region Query Verifica se existe
		/// <summary>
		/// String com a query Verifica se existe
		/// </summary>
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CLIENTE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Incluir(ClienteSic clienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(clienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ClienteSic clienteSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (clienteSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				clienteSic.NrSeqClienteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, clienteSic)));
			else
				clienteSic.NrSeqClienteSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, clienteSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Atualizar(ClienteSic clienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(clienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ClienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ClienteSic clienteSic, DatabaseManager databaseManager)
		{
			if (clienteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, clienteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, clienteSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui clienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		public void Excluir(ClienteSic clienteSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(clienteSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui clienteSic
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ClienteSic clienteSic, DatabaseManager databaseManager)
		{
			if (clienteSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, clienteSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, clienteSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ClienteSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ClienteSic clienteSic, DatabaseManager databaseManager)
		{
			if (clienteSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, clienteSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, clienteSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ClienteSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ClienteSic clienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, clienteSic.NrSeqClienteSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros verifica se IX_TB_CLIENTE_SIC existe 
		/// <summary>
		/// Cria Parametros verifica se IX_TB_CLIENTE_SIC existe 
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosVerificaSeExisteIxTbClienteSic(DatabaseManager databaseManager, ClienteSic clienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, clienteSic.NrIbmClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, clienteSic.NrSeqClienteSic, false));
			return dbParams;
		}
		#endregion Criar Parametros verifica se IX_TB_CLIENTE_SIC existe 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ClienteSic clienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, clienteSic.NrIbmClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCnpjClienteSic, clienteSic.NrCnpjClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqEmpresaSic, clienteSic.NrSeqEmpresaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqSistemaSic, clienteSic.NrSeqSistemaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrInscestadlojaFranquiaSic, clienteSic.NrInscestadlojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAreaSic, clienteSic.NrSeqAreaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmRazsociallojaFranquiaSic, clienteSic.NmRazsociallojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, clienteSic.NmGtlojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, clienteSic.NmGalojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCegrpostoClienteSic, clienteSic.NrCegrpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StDescontoimpostoClienteSic, clienteSic.StDescontoimpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StRebrandingClienteSic, clienteSic.StRebrandingClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StEnviocalendarioClienteSic, clienteSic.StEnviocalendarioClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StProcessojudicialClienteSic, clienteSic.StProcessojudicialClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFoodservfullClienteSic, clienteSic.StFoodservfullClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPrgcafeClienteSic, clienteSic.StPrgcafeClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StSanduicheQuenteClienteSic, clienteSic.StSanduicheQuenteClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StVendecartaoClienteSic, clienteSic.StVendecartaoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAtmClienteSic, clienteSic.StAtmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StOiClienteSic, clienteSic.StOiClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAbriClienteSic, clienteSic.StAbriClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StA0ClienteSic, clienteSic.StA0ClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StA4ClienteSic, clienteSic.StA4ClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StGalhardestesClienteSic, clienteSic.StGalhardestesClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCartazcolunaClienteSic, clienteSic.StCartazcolunaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StStationposterClienteSic, clienteSic.StStationposterClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsClienteSic, clienteSic.DsObsClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCanalClienteSic, clienteSic.NmCanalClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmSegmercadoClienteSic, clienteSic.NmSegmercadoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StSanduicheFrioClienteSic, clienteSic.StSanduicheFrioClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFoodservselfClienteSic, clienteSic.StFoodservselfClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="clienteSic">Instance of <see cref="ClienteSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ClienteSic clienteSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, clienteSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, clienteSic.NrIbmClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCnpjClienteSic, clienteSic.NrCnpjClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqEmpresaSic, clienteSic.NrSeqEmpresaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqSistemaSic, clienteSic.NrSeqSistemaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrInscestadlojaFranquiaSic, clienteSic.NrInscestadlojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqAreaSic, clienteSic.NrSeqAreaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmRazsociallojaFranquiaSic, clienteSic.NmRazsociallojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, clienteSic.NmGtlojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, clienteSic.NmGalojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCegrpostoClienteSic, clienteSic.NrCegrpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StDescontoimpostoClienteSic, clienteSic.StDescontoimpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StRebrandingClienteSic, clienteSic.StRebrandingClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StEnviocalendarioClienteSic, clienteSic.StEnviocalendarioClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StProcessojudicialClienteSic, clienteSic.StProcessojudicialClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFoodservfullClienteSic, clienteSic.StFoodservfullClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPrgcafeClienteSic, clienteSic.StPrgcafeClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StSanduicheQuenteClienteSic, clienteSic.StSanduicheQuenteClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StVendecartaoClienteSic, clienteSic.StVendecartaoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAtmClienteSic, clienteSic.StAtmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StOiClienteSic, clienteSic.StOiClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAbriClienteSic, clienteSic.StAbriClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StA0ClienteSic, clienteSic.StA0ClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StA4ClienteSic, clienteSic.StA4ClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StGalhardestesClienteSic, clienteSic.StGalhardestesClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCartazcolunaClienteSic, clienteSic.StCartazcolunaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StStationposterClienteSic, clienteSic.StStationposterClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsClienteSic, clienteSic.DsObsClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCanalClienteSic, clienteSic.NmCanalClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmSegmercadoClienteSic, clienteSic.NmSegmercadoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StSanduicheFrioClienteSic, clienteSic.StSanduicheFrioClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFoodservselfClienteSic, clienteSic.StFoodservselfClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

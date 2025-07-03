#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseCategoriaSicDAO.cs
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
	#region classe base CategoriaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CategoriaSicDAO
	/// </summary>
	internal partial class CategoriaSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public CategoriaSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqCategoriaSic = "NR_SEQ_CATEGORIA_SIC";
		private const string C_NmCategoriaSic = "NM_CATEGORIA_SIC";
		private const string C_DsCategoriaSic = "DS_CATEGORIA_SIC";
		private const string C_StCategoriaPistaSic = "ST_CATEGORIA_PISTA_SIC";
		private const string C_StCategoriaLojaSic = "ST_CATEGORIA_LOJA_SIC";
		private const string C_StCategoriaFranquiaSic = "ST_CATEGORIA_FRANQUIA_SIC";
		private const string C_StCategoriaRebateSic = "ST_CATEGORIA_REBATE_SIC";
		#endregion  Constantes de TbCategoriaSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CATEGORIA_SIC")
		.Append("(")
		.Append("NM_CATEGORIA_SIC,DS_CATEGORIA_SIC,ST_CATEGORIA_PISTA_SIC,ST_CATEGORIA_LOJA_SIC,ST_CATEGORIA_FRANQUIA_SIC,ST_CATEGORIA_REBATE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmCategoriaSic)
		.Append(", ")
		.Append("@" + C_DsCategoriaSic)
		.Append(", ")
		.Append("@" + C_StCategoriaPistaSic)
		.Append(", ")
		.Append("@" + C_StCategoriaLojaSic)
		.Append(", ")
		.Append("@" + C_StCategoriaFranquiaSic)
		.Append(", ")
		.Append("@" + C_StCategoriaRebateSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CATEGORIA_SIC SET")
		.Append(" NM_CATEGORIA_SIC = ")
		.Append("@" + C_NmCategoriaSic)
		.Append(",DS_CATEGORIA_SIC = ")
		.Append("@" + C_DsCategoriaSic)
		.Append(",ST_CATEGORIA_PISTA_SIC = ")
		.Append("@" + C_StCategoriaPistaSic)
		.Append(",ST_CATEGORIA_LOJA_SIC = ")
		.Append("@" + C_StCategoriaLojaSic)
		.Append(",ST_CATEGORIA_FRANQUIA_SIC = ")
		.Append("@" + C_StCategoriaFranquiaSic)
		.Append(",ST_CATEGORIA_REBATE_SIC = ")
		.Append("@" + C_StCategoriaRebateSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CATEGORIA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CATEGORIA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Incluir(CategoriaSic categoriaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(categoriaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(CategoriaSic categoriaSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (categoriaSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				categoriaSic.NrSeqCategoriaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, categoriaSic)));
			else
				categoriaSic.NrSeqCategoriaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, categoriaSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Atualizar(CategoriaSic categoriaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(categoriaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar CategoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(CategoriaSic categoriaSic, DatabaseManager databaseManager)
		{
			if (categoriaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, categoriaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, categoriaSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui categoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		public void Excluir(CategoriaSic categoriaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(categoriaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui categoriaSic
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(CategoriaSic categoriaSic, DatabaseManager databaseManager)
		{
			if (categoriaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, categoriaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, categoriaSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe CategoriaSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(CategoriaSic categoriaSic, DatabaseManager databaseManager)
		{
			if (categoriaSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, categoriaSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, categoriaSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe CategoriaSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, CategoriaSic categoriaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, categoriaSic.NrSeqCategoriaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, CategoriaSic categoriaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCategoriaSic, categoriaSic.NmCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsCategoriaSic, categoriaSic.DsCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaPistaSic, categoriaSic.StCategoriaPistaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaLojaSic, categoriaSic.StCategoriaLojaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaFranquiaSic, categoriaSic.StCategoriaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaRebateSic, categoriaSic.StCategoriaRebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="categoriaSic">Instance of <see cref="CategoriaSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, CategoriaSic categoriaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, categoriaSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCategoriaSic, categoriaSic.NmCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsCategoriaSic, categoriaSic.DsCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaPistaSic, categoriaSic.StCategoriaPistaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaLojaSic, categoriaSic.StCategoriaLojaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaFranquiaSic, categoriaSic.StCategoriaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StCategoriaRebateSic, categoriaSic.StCategoriaRebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

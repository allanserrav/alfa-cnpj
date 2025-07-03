#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseTiporebateSicDAO.cs
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
	#region classe base TiporebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TiporebateSicDAO
	/// </summary>
	internal partial class TiporebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public TiporebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqTiporebateSic = "NR_SEQ_TIPOREBATE_SIC";
		private const string C_NmTiporebateSic = "NM_TIPOREBATE_SIC";
		private const string C_DsTiporebateSic = "DS_TIPOREBATE_SIC";
		#endregion  Constantes de TbTiporebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_TIPOREBATE_SIC")
		.Append("(")
		.Append("NM_TIPOREBATE_SIC,DS_TIPOREBATE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmTiporebateSic)
		.Append(", ")
		.Append("@" + C_DsTiporebateSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_TIPOREBATE_SIC SET")
		.Append(" NM_TIPOREBATE_SIC = ")
		.Append("@" + C_NmTiporebateSic)
		.Append(",DS_TIPOREBATE_SIC = ")
		.Append("@" + C_DsTiporebateSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_TIPOREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_TIPOREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Incluir(TiporebateSic tiporebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(tiporebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(TiporebateSic tiporebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (tiporebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				tiporebateSic.NrSeqTiporebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tiporebateSic)));
			else
				tiporebateSic.NrSeqTiporebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tiporebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Atualizar(TiporebateSic tiporebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(tiporebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar TiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(TiporebateSic tiporebateSic, DatabaseManager databaseManager)
		{
			if (tiporebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tiporebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tiporebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		public void Excluir(TiporebateSic tiporebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(tiporebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui tiporebateSic
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(TiporebateSic tiporebateSic, DatabaseManager databaseManager)
		{
			if (tiporebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tiporebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tiporebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe TiporebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(TiporebateSic tiporebateSic, DatabaseManager databaseManager)
		{
			if (tiporebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tiporebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tiporebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe TiporebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, TiporebateSic tiporebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, tiporebateSic.NrSeqTiporebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, TiporebateSic tiporebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTiporebateSic, tiporebateSic.NmTiporebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTiporebateSic, tiporebateSic.DsTiporebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tiporebateSic">Instance of <see cref="TiporebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, TiporebateSic tiporebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, tiporebateSic.NrSeqTiporebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTiporebateSic, tiporebateSic.NmTiporebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTiporebateSic, tiporebateSic.DsTiporebateSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

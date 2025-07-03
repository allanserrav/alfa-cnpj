#region Cabeçalho do Arquivo
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
	#region classe base RestricaoDAO
	/// <summary>
	/// Representa funcionalidade relacionada a RestricaoTipoRestricaoDAO
	/// </summary>
	internal partial class RestricaoTipoRestricaoDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public RestricaoTipoRestricaoDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqRestricao = "NR_SEQ_IBM_TIPO_RESTRICAO_SIC";
		private const string C_NrSeqIbmRestricao = "NR_SEQ_IBM_RESTRICAO_SIC";
		private const string C_NrSeqTipoRestricao = "NR_SEQ_TIPO_RESTRICAO_SIC";
		#endregion  Constantes de TbRestricaoTipoRestricao

		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_IBM_TIPO_RESTRICAO_SIC")
		.Append("(")
		.Append("NR_SEQ_IBM_RESTRICAO_SIC, ")
		.Append("NR_SEQ_TIPO_RESTRICAO_SIC, ")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqIbmRestricao)		
		.Append(",")
		.Append("@" + C_NrSeqTipoRestricao)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_IBM_TIPO_RESTRICAO_SIC SET")		
		.Append(" NR_SEQ_IBM_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqIbmRestricao)
		.Append(", NR_SEQ_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqTipoRestricao)
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqRestricao)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_IBM_TIPO_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqRestricao)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_IBM_TIPO_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqRestricao)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Incluir(RestricaoTipoRestricao restricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(restricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(RestricaoTipoRestricao restricao, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (restricao == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				restricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, restricao)));
			else
				restricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, restricao), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Atualizar(RestricaoTipoRestricao restricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(restricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(RestricaoTipoRestricao restricao, DatabaseManager databaseManager)
		{
			if (restricao == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, restricao));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, restricao), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Excluir(RestricaoTipoRestricao restricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(restricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(RestricaoTipoRestricao restricao, DatabaseManager databaseManager)
		{
			if (restricao == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, restricao));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, restricao), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe Restricao
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(RestricaoTipoRestricao restricao, DatabaseManager databaseManager)
		{
			if (restricao == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, restricao)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, restricao), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe Restricao
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, RestricaoTipoRestricao restricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRestricao, restricao.NrSeqRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, RestricaoTipoRestricao restricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqIbmRestricao, restricao.NrSeqIbmTipoRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoRestricao, restricao.NrSeqTipoRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, RestricaoTipoRestricao restricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRestricao, restricao.NrSeqRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqIbmRestricao, restricao.NrSeqIbmTipoRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoRestricao, restricao.NrSeqTipoRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

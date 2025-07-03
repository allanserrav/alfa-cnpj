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
	#region classe base TipoRestricaoDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TipoRestricaoDAO
	/// </summary>
	internal partial class TipoRestricaoDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public TipoRestricaoDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqTipoRestricao = "NR_SEQ_TIPO_RESTRICAO_SIC";
		private const string C_DsTipoRestricao = "DS_TIPO_RESTRICAO";
		#endregion  Constantes de TbTipoRestricao
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_TIPO_RESTRICAO_SIC")
		.Append("(")
		.Append("DS_TIPO_RESTRICAO")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_DsTipoRestricao)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_TIPO_RESTRICAO_SIC SET")		
		.Append(",DS_TIPO_RESTRICAO = ")
		.Append("@" + C_DsTipoRestricao)
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqTipoRestricao)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_TIPO_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqTipoRestricao)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_TIPO_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_TIPO_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqTipoRestricao)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Incluir(TipoRestricao tipoRestricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(tipoRestricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(TipoRestricao tipoRestricao, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (tipoRestricao == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				tipoRestricao.NrSeqTipoRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tipoRestricao)));
			else
				tipoRestricao.NrSeqTipoRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, tipoRestricao), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Atualizar(TipoRestricao tipoRestricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(tipoRestricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(TipoRestricao tipoRestricao, DatabaseManager databaseManager)
		{
			if (tipoRestricao == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tipoRestricao));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, tipoRestricao), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui tipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		public void Excluir(TipoRestricao tipoRestricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(tipoRestricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui tipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(TipoRestricao tipoRestricao, DatabaseManager databaseManager)
		{
			if (tipoRestricao == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tipoRestricao));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, tipoRestricao), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe TipoRestricao
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(TipoRestricao tipoRestricao, DatabaseManager databaseManager)
		{
			if (tipoRestricao == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tipoRestricao)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, tipoRestricao), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe TipoRestricao
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, TipoRestricao tipoRestricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoRestricao, tipoRestricao.NrSeqTipoRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, TipoRestricao tipoRestricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTipoRestricao, tipoRestricao.DsTipoRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="tipoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, TipoRestricao tipoRestricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoRestricao, tipoRestricao.NrSeqTipoRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsTipoRestricao, tipoRestricao.DsTipoRestricao, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

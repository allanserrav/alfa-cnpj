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
	/// Representa funcionalidade relacionada a RestricaoDAO
	/// </summary>
	internal partial class RestricaoDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public RestricaoDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqRestricao = "NR_SEQ_IBM_RESTRICAO_SIC";
		private const string C_DsMotivo = "MOTIVO";
		private const string C_DsIbm = "IBM";
		private const string C_NrSeqTipoRestricao = "NR_SEQ_TIPO_RESTRICAO_SIC";
		private const string C_DsTipoRestricao = "DS_TIPO_RESTRICAO";

		#endregion  Constantes de TbRestricao

		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_IBM_RESTRICAO_SIC")
		.Append("(")
		.Append("MOTIVO, ")
		.Append("IBM ")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_DsMotivo)		
		.Append(",")
		.Append("@" + C_DsIbm)
		.Append(")")
		.Append("").ToString();


		private string queryIncluirRestricaoTipoRestricao = new StringBuilder().Append("INSERT INTO TB_IBM_TIPO_RESTRICAO_SIC")
		.Append("(")
		.Append("NR_SEQ_IBM_RESTRICAO_SIC, ")
		.Append("NR_SEQ_TIPO_RESTRICAO_SIC ")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRestricao)
		.Append(",")
		.Append("@" + C_NrSeqTipoRestricao)
		.Append(")")
		.Append("").ToString();
		
		#endregion Query Incluir

		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_IBM_RESTRICAO_SIC SET")		
		.Append(" MOTIVO = ")
		.Append("@" + C_DsMotivo)
		.Append(", IBM = ")
		.Append("@" + C_DsIbm)
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqRestricao)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_IBM_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_RESTRICAO_SIC = ")
		.Append("@" + C_NrSeqRestricao)
		.Append("").ToString();

		private string queryExcluirTiposRestricoes = new StringBuilder().Append("DELETE FROM TB_IBM_TIPO_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_RESTRICAO_SIC = ")
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_IBM_RESTRICAO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_IBM_RESTRICAO_SIC = ")
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
		public void Incluir(Restricao restricao)
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
		internal void Incluir(Restricao restricao, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (restricao == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				restricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, restricao)));
			else
				restricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, restricao), databaseManager.Transaction));
		}


		public void IncluirTiposRestricoes(RestricaoTipoRestricao tipoRestricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					IncluirTiposRestricoes(tipoRestricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		internal void IncluirTiposRestricoes(RestricaoTipoRestricao tipoRestricao, DatabaseManager databaseManager)
		{
			string query = queryIncluirRestricaoTipoRestricao + ";" + queryRetornaSequencia;
			if (tipoRestricao == null) throw (new ArgumentNullException());

			if (databaseManager.Transaction == null)
				tipoRestricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluirTipoRestricao(databaseManager, tipoRestricao)));
			else
				tipoRestricao.NrSeqRestricao = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluirTipoRestricao(databaseManager, tipoRestricao), databaseManager.Transaction));
		}
		#endregion Incluir

		#region Atualizar
		/// <summary>
		/// Atualiza Restricao
		/// </summary>
		/// <param name="restricao">Instance of <see cref="Restricao"/></param>
		public void Atualizar(Restricao restricao)
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
		internal void Atualizar(Restricao restricao, DatabaseManager databaseManager)
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
		public void Excluir(Restricao restricao)
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
		internal void Excluir(Restricao restricao, DatabaseManager databaseManager)
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

		public void ExcluirTiposRestricoes(Restricao restricao)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					ExcluirTiposRestricoes(restricao, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}

		internal void ExcluirTiposRestricoes(Restricao restricao, DatabaseManager databaseManager)
		{
			if (restricao == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluirTiposRestricoes, CriarParametrosPK(databaseManager, restricao));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluirTiposRestricoes, CriarParametrosPK(databaseManager, restricao), databaseManager.Transaction);
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
		protected bool VerificarSeExiste(Restricao restricao, DatabaseManager databaseManager)
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
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, Restricao restricao)
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
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, Restricao restricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMotivo, restricao.DsMotivo, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsIbm, restricao.DsIbm, false));
			return dbParams;
		}

		private IList<DbParameter> CriarParametrosIncluirTipoRestricao(DatabaseManager databaseManager, RestricaoTipoRestricao tipoRestricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRestricao, tipoRestricao.NrSeqRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipoRestricao, tipoRestricao.NrSeqIbmTipoRestricao, false));
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
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, Restricao restricao)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRestricao, restricao.NrSeqRestricao, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsMotivo, restricao.DsMotivo, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsIbm, restricao.DsIbm, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

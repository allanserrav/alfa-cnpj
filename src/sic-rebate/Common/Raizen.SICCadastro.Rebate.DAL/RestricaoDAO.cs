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
	#region classe concreta RestricaoDAO
	/// <summary>
	/// Representa funcionalidade relacionada a RestricaoDAO
	/// </summary>
	internal partial class RestricaoDAO : IRestricaoDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbRestricao
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_IBM_RESTRICAO_SIC.NR_SEQ_IBM_RESTRICAO_SIC")
		.Append(",TB_IBM_RESTRICAO_SIC.IBM")
		.Append(",TB_IBM_RESTRICAO_SIC.MOTIVO")
		.Append(" FROM TB_IBM_RESTRICAO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();

		private string querySelecionarPorRestricaoId = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_IBM_TIPO_RESTRICAO_SIC.NR_SEQ_IBM_TIPO_RESTRICAO_SIC")
		.Append(",TB_IBM_TIPO_RESTRICAO_SIC.NR_SEQ_IBM_RESTRICAO_SIC")
		.Append(",TB_IBM_TIPO_RESTRICAO_SIC.NR_SEQ_TIPO_RESTRICAO_SIC")
		.Append(" FROM TB_IBM_TIPO_RESTRICAO_SIC")
		.Append(" {1}")
		.Append("").ToString();

		private string querySelecionarExport = new StringBuilder().Append("SELECT {0}")
		.Append(" R.IBM")
		.Append(",R.MOTIVO")
		.Append(",T.DS_TIPO_RESTRICAO")
		.Append(" FROM TB_IBM_TIPO_RESTRICAO_SIC TR")
		.Append(" LEFT JOIN TB_TIPO_RESTRICAO_SIC T ON T.NR_SEQ_TIPO_RESTRICAO_SIC = TR.NR_SEQ_TIPO_RESTRICAO_SIC")
		.Append(" LEFT JOIN TB_IBM_RESTRICAO_SIC R ON R.NR_SEQ_IBM_RESTRICAO_SIC = TR.NR_SEQ_IBM_RESTRICAO_SIC")
		.Append("").ToString();




		#endregion Query para Selecionar registros
		#endregion Queries

		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de Restricao
		/// </summary>
		/// <param name="restricao">Instância de <see cref="Restricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de Restricao</returns>
		public IList<Restricao> Selecionar(Restricao restricao, int numeroLinhas, string ordem)
		{
			IList<Restricao> listRestricao = new List<Restricao>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, restricao, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listRestricao.Add(Preencher(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listRestricao;
		}

		public IList<RestricaoTipoRestricao> SelecionarPorRestricaoId(int restricaoId, int numeroLinhas, string ordem)
		{
			IList<RestricaoTipoRestricao> listTipoRestricao = new List<RestricaoTipoRestricao>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionarPorRestricaoId(databaseManager, restricaoId, out where);
				string newQuery = string.Format(querySelecionarPorRestricaoId,
					(numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
					(string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
					(string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listTipoRestricao.Add(PreencherTipoRestricao(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listTipoRestricao;
		}

		public IList<RestricaoExport> SelecionarExport(int numeroLinhas, string ordem)
		{
			IList<RestricaoExport> listTipoRestricao = new List<RestricaoExport>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionarPorRestricaoId(databaseManager, 0, out where);
				string newQuery = string.Format(querySelecionarExport,
					(numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
					(string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
					(string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listTipoRestricao.Add(PreencherRestricaoExport(dbDataReader));
					}
				}
				databaseManager.CloseConnection();
			}
			return listTipoRestricao;
		}
		#endregion Selecionar
		#endregion Metodos Publicos

		#region Metodos Privados
		#region Metodos Gerais
		#region Preencher
		/// <summary>
		/// Preenche o objeto Restricao a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto Restricao preenchido</returns>
		protected Restricao Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			Restricao restricao = new Restricao();
			restricao.NrSeqRestricao = reader.GetNullableInt32(C_NrSeqRestricao);
			restricao.DsIbm = reader.GetString(C_DsIbm);
			restricao.DsMotivo = reader.GetString(C_DsMotivo);		
			return restricao;
		}

		protected RestricaoTipoRestricao PreencherTipoRestricao(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			RestricaoTipoRestricao tipoRestricao = new RestricaoTipoRestricao();
			tipoRestricao.NrSeqRestricao = reader.GetNullableInt32(C_NrSeqRestricao);
			tipoRestricao.NrSeqIbmTipoRestricao= reader.GetNullableInt32(C_NrSeqRestricao);
			tipoRestricao.NrSeqTipoRestricao= reader.GetNullableInt32(C_NrSeqTipoRestricao);
			return tipoRestricao;
		}

		protected RestricaoExport PreencherRestricaoExport(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			RestricaoExport restricaoExport = new RestricaoExport();
			restricaoExport.DsIbm = reader.GetString(C_DsIbm);
			restricaoExport.DsMotivo = reader.GetString(C_DsMotivo);
			restricaoExport.DsTipoRestricao = reader.GetString(C_DsTipoRestricao);
			return restricaoExport;
		}

		#endregion Preencher
		#endregion Common Methods

		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="ripoRestricao">Instance of <see cref="Restricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, Restricao restricao, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (restricao.NrSeqRestricao != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_IBM_RESTRICAO_SIC", C_NrSeqRestricao, DatabaseManager.SQLOperation.Equal, restricao.NrSeqRestricao, ref where));
			if (restricao.DsMotivo != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_IBM_RESTRICAO_SIC", C_DsMotivo, DatabaseManager.SQLOperation.Like, "%" + restricao.DsMotivo + "%", ref where));
			if (restricao.DsIbm != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.String, "TB_IBM_RESTRICAO_SIC", C_DsIbm, DatabaseManager.SQLOperation.Equal, restricao.DsIbm, ref where));
			return dbParams;
		}

		private IList<DbParameter> CriarParametrosSelecionarPorRestricaoId(DatabaseManager databaseManager, int restricaoId, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (restricaoId != 0) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_IBM_TIPO_RESTRICAO_SIC", C_NrSeqRestricao, DatabaseManager.SQLOperation.Equal, restricaoId, ref where));
			return dbParams;
		}

		
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

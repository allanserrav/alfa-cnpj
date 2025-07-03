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
	#region classe concreta TipoRestricaoDAO
	/// <summary>
	/// Representa funcionalidade relacionada a TipoRestricaoDAO
	/// </summary>
	internal partial class TipoRestricaoDAO : ITipoRestricaoDAO
	{
		#region Constantes
		/// <summary>
		/// Representa ordenação padrão da query Selecionar
		/// </summary>
		public const string orderByDefault = "";
		#endregion  Constantes de TbTipoRestricao
		
		#region Queries
		#region Query para Selecionar registros
		/// <summary>
		/// String com a query de seleção de registros
		/// </summary>
		private string querySelecionar = new StringBuilder().Append("SELECT {0}")
		.Append(" TB_TIPO_RESTRICAO_SIC.NR_SEQ_TIPO_RESTRICAO_SIC")
		.Append(",TB_TIPO_RESTRICAO_SIC.DS_TIPO_RESTRICAO")
		.Append(" FROM TB_TIPO_RESTRICAO_SIC")
		.Append(" {1}")
		.Append(" {2}")
		.Append("").ToString();
		#endregion Query para Selecionar registros
		#endregion Queries
		
		#region Metodos Publicos
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de TipoRestricao
		/// </summary>
		/// <param name="tipoRestricao">Instância de <see cref="TipoRestricao"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de TipoRestricao</returns>
		public IList<TipoRestricao> Selecionar(TipoRestricao tipoRestricao, int numeroLinhas, string ordem)
		{
			IList<TipoRestricao> listTipoRestricao = new List<TipoRestricao>();
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				string where = "";
				IList<DbParameter> parametros = CriarParametrosSelecionar(databaseManager, tipoRestricao, out where);
				string newQuery = string.Format(querySelecionar,
				    (numeroLinhas > 0) ? "top " + numeroLinhas : String.Empty,
				    (string.IsNullOrEmpty(where)) ? String.Empty : "WHERE " + where,
				    (string.IsNullOrEmpty(ordem) && string.IsNullOrEmpty(orderByDefault)) ? String.Empty : ("ORDER BY " + ((string.IsNullOrEmpty(ordem)) ? orderByDefault : ordem)));
				using (SafeDataReader dbDataReader = (SafeDataReader)databaseManager.GetsDataReader(newQuery, parametros))
				{
					while (dbDataReader.Read())
					{
						listTipoRestricao.Add(Preencher(dbDataReader));
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
		/// Preenche o objeto TipoRestricao a partir do SafeDataReader.
		/// </summary>
		/// <param name="reader">Instance of <see cref="SafeDataReader"/></param>
		/// <returns>O objeto TipoRestricao preenchido</returns>
		protected TipoRestricao Preencher(SafeDataReader reader)
		{
			if (reader == null) throw (new ArgumentNullException());
			TipoRestricao tipoRestricao = new TipoRestricao();
			tipoRestricao.NrSeqTipoRestricao = reader.GetNullableInt32(C_NrSeqTipoRestricao);
			tipoRestricao.DsTipoRestricao = reader.GetString(C_DsTipoRestricao);		
			return tipoRestricao;
		}
		#endregion Preencher
		#endregion Common Methods
		
		#region Criar Parametros
		#region Criar Parametros Selecionar
		/// <summary>
		/// Criar Parametros Selecionar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="ripoRestricao">Instance of <see cref="TipoRestricao"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosSelecionar(DatabaseManager databaseManager, TipoRestricao tipoRestricao, out string where)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			where = "";
			if (tipoRestricao.NrSeqTipoRestricao != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_TIPO_RESTRICAO_SIC", C_NrSeqTipoRestricao, DatabaseManager.SQLOperation.Equal, tipoRestricao.NrSeqTipoRestricao, ref where));
			if (tipoRestricao.DsTipoRestricao != null) dbParams.Add(databaseManager.CreateWhereParameter(DbType.Int32, "TB_TIPO_RESTRICAO_SIC", C_DsTipoRestricao, DatabaseManager.SQLOperation.Equal, tipoRestricao.DsTipoRestricao, ref where));
			return dbParams;
		}
		#endregion Criar Parametros Selecionar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion classe concreta 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseSaldoRebateSicDAO.cs
// Class Name	        : SaldoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/11/2012
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
	#region classe base SaldoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a SaldoRebateSicDAO
	/// </summary>
	internal partial class SaldoRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public SaldoRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqSaldoRebateSic = "NR_SEQ_SALDO_REBATE_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_VlSaldoAtualSic = "VL_SALDO_ATUAL_SIC";
		private const string C_VlLancamentoSic = "VL_LANCAMENTO_SIC";
		private const string C_DtLancamentoSic = "DT_LANCAMENTO_SIC";
		private const string C_DsObsComplementoSic = "DS_OBS_COMPLEMENTO_SIC";
		#endregion  Constantes de TbSaldoRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_SALDO_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,VL_SALDO_ATUAL_SIC,VL_LANCAMENTO_SIC,DT_LANCAMENTO_SIC,DS_OBS_COMPLEMENTO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_VlSaldoAtualSic)
		.Append(", ")
		.Append("@" + C_VlLancamentoSic)
		.Append(", ")
		.Append("@" + C_DtLancamentoSic)
		.Append(", ")
		.Append("@" + C_DsObsComplementoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_SALDO_REBATE_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",VL_SALDO_ATUAL_SIC = ")
		.Append("@" + C_VlSaldoAtualSic)
		.Append(",VL_LANCAMENTO_SIC = ")
		.Append("@" + C_VlLancamentoSic)
		.Append(",DT_LANCAMENTO_SIC = ")
		.Append("@" + C_DtLancamentoSic)
		.Append(",DS_OBS_COMPLEMENTO_SIC = ")
		.Append("@" + C_DsObsComplementoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_SALDO_REBATE_SIC = ")
		.Append("@" + C_NrSeqSaldoRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_SALDO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_SALDO_REBATE_SIC = ")
		.Append("@" + C_NrSeqSaldoRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_SALDO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_SALDO_REBATE_SIC = ")
		.Append("@" + C_NrSeqSaldoRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Incluir(SaldoRebateSic saldoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(saldoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (saldoRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				saldoRebateSic.NrSeqSaldoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, saldoRebateSic)));
			else
				saldoRebateSic.NrSeqSaldoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, saldoRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Atualizar(SaldoRebateSic saldoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(saldoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar SaldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager)
		{
			if (saldoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, saldoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, saldoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui saldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		public void Excluir(SaldoRebateSic saldoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(saldoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui saldoRebateSic
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager)
		{
			if (saldoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, saldoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, saldoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe SaldoRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(SaldoRebateSic saldoRebateSic, DatabaseManager databaseManager)
		{
			if (saldoRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, saldoRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, saldoRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe SaldoRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, SaldoRebateSic saldoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqSaldoRebateSic, saldoRebateSic.NrSeqSaldoRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, SaldoRebateSic saldoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, saldoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlSaldoAtualSic, saldoRebateSic.VlSaldoAtualSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlLancamentoSic, saldoRebateSic.VlLancamentoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtLancamentoSic, saldoRebateSic.DtLancamentoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsComplementoSic, saldoRebateSic.DsObsComplementoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="saldoRebateSic">Instance of <see cref="SaldoRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, SaldoRebateSic saldoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqSaldoRebateSic, saldoRebateSic.NrSeqSaldoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, saldoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlSaldoAtualSic, saldoRebateSic.VlSaldoAtualSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlLancamentoSic, saldoRebateSic.VlLancamentoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtLancamentoSic, saldoRebateSic.DtLancamentoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsComplementoSic, saldoRebateSic.DsObsComplementoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

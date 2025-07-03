#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseReajusteRebateHistoricoSicDAO.cs
// Class Name	        : ReajusteRebateHistoricoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/01/2013
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
	#region classe base ReajusteRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteRebateHistoricoSicDAO
	/// </summary>
	internal partial class ReajusteRebateHistoricoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ReajusteRebateHistoricoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqReajusteRebateHistoricoSic = "NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrSeqFaixarebateSic = "NR_SEQ_FAIXAREBATE_SIC";
		private const string C_VlBonificacaoRebateSic = "VL_BONIFICACAO_REBATE_SIC";
		private const string C_NrSeqReajusteSic = "NR_SEQ_REAJUSTE_SIC";
		private const string C_VlIgpmReajusteRebateSic = "VL_IGPM_REAJUSTE_REBATE_SIC";
		private const string C_VlManualReajusteRebateSic = "VL_MANUAL_REAJUSTE_REBATE_SIC";
		private const string C_NrPeriodoReajusteRebateSic = "NR_PERIODO_REAJUSTE_REBATE_SIC";
		private const string C_DtAlteracaoSic = "DT_ALTERACAO_SIC";
		#endregion  Constantes de TbReajusteRebateHistoricoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_REAJUSTE_REBATE_HISTORICO_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,NR_SEQ_FAIXAREBATE_SIC,VL_BONIFICACAO_REBATE_SIC,NR_SEQ_REAJUSTE_SIC,VL_IGPM_REAJUSTE_REBATE_SIC,VL_MANUAL_REAJUSTE_REBATE_SIC,NR_PERIODO_REAJUSTE_REBATE_SIC,DT_ALTERACAO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append(", ")
		.Append("@" + C_VlIgpmReajusteRebateSic)
		.Append(", ")
		.Append("@" + C_VlManualReajusteRebateSic)
		.Append(", ")
		.Append("@" + C_NrPeriodoReajusteRebateSic)
		.Append(", ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_REAJUSTE_REBATE_HISTORICO_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(",VL_BONIFICACAO_REBATE_SIC = ")
		.Append("@" + C_VlBonificacaoRebateSic)
		.Append(",NR_SEQ_REAJUSTE_SIC = ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append(",VL_IGPM_REAJUSTE_REBATE_SIC = ")
		.Append("@" + C_VlIgpmReajusteRebateSic)
		.Append(",VL_MANUAL_REAJUSTE_REBATE_SIC = ")
		.Append("@" + C_VlManualReajusteRebateSic)
		.Append(",NR_PERIODO_REAJUSTE_REBATE_SIC = ")
		.Append("@" + C_NrPeriodoReajusteRebateSic)
		.Append(",DT_ALTERACAO_SIC = ")
		.Append("@" + C_DtAlteracaoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqReajusteRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_REAJUSTE_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqReajusteRebateHistoricoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_REAJUSTE_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqReajusteRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Incluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(reajusteRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (reajusteRebateHistoricoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteRebateHistoricoSic)));
			else
				reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteRebateHistoricoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Atualizar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(reajusteRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ReajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (reajusteRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		public void Excluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(reajusteRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui reajusteRebateHistoricoSic
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (reajusteRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ReajusteRebateHistoricoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ReajusteRebateHistoricoSic reajusteRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (reajusteRebateHistoricoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteRebateHistoricoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteRebateHistoricoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ReajusteRebateHistoricoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteRebateHistoricoSic, reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, reajusteRebateHistoricoSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, reajusteRebateHistoricoSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, reajusteRebateHistoricoSic.VlBonificacaoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteRebateHistoricoSic.NrSeqReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlIgpmReajusteRebateSic, reajusteRebateHistoricoSic.VlIgpmReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlManualReajusteRebateSic, reajusteRebateHistoricoSic.VlManualReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrPeriodoReajusteRebateSic, reajusteRebateHistoricoSic.NrPeriodoReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, reajusteRebateHistoricoSic.DtAlteracaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebateHistoricoSic">Instance of <see cref="ReajusteRebateHistoricoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ReajusteRebateHistoricoSic reajusteRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteRebateHistoricoSic, reajusteRebateHistoricoSic.NrSeqReajusteRebateHistoricoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, reajusteRebateHistoricoSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, reajusteRebateHistoricoSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, reajusteRebateHistoricoSic.VlBonificacaoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteRebateHistoricoSic.NrSeqReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlIgpmReajusteRebateSic, reajusteRebateHistoricoSic.VlIgpmReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlManualReajusteRebateSic, reajusteRebateHistoricoSic.VlManualReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrPeriodoReajusteRebateSic, reajusteRebateHistoricoSic.NrPeriodoReajusteRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAlteracaoSic, reajusteRebateHistoricoSic.DtAlteracaoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

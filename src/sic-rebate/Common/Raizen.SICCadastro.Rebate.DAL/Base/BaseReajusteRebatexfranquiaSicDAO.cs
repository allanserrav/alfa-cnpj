#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseReajusteRebatexfranquiaSicDAO.cs
// Class Name	        : ReajusteRebatexfranquiaSicDAO
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
	#region classe base ReajusteRebatexfranquiaSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ReajusteRebatexfranquiaSicDAO
	/// </summary>
	internal partial class ReajusteRebatexfranquiaSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ReajusteRebatexfranquiaSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqReajusteRebatexfranquiaSic = "NR_SEQ_REAJUSTE_REBATEXFRANQUIA_SIC";
		private const string C_NrSeqFranquiaSic = "NR_SEQ_FRANQUIA_SIC";
		private const string C_NrSeqFaixaSic = "NR_SEQ_FAIXA_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrSeqReajusteSic = "NR_SEQ_REAJUSTE_SIC";
		private const string C_VlManualReajusterebatexfranquiaSic = "VL_MANUAL_REAJUSTEREBATEXFRANQUIA_SIC";
		private const string C_NrPeriodoReajusterebatexfranquiaSic = "NR_PERIODO_REAJUSTEREBATEXFRANQUIA_SIC";
		private const string C_StFeeminimoFaixaSic = "ST_FEEMINIMO_FAIXA_SIC";
		private const string C_StFeemaximoFaixaSic = "ST_FEEMAXIMO_FAIXA_SIC";
		private const string C_StValoresFaixaSic = "ST_VALORES_FAIXA_SIC";
		#endregion  Constantes de TbReajusteRebatexfranquiaSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_REAJUSTE_REBATEXFRANQUIA_SIC")
		.Append("(")
		.Append("NR_SEQ_FRANQUIA_SIC,NR_SEQ_FAIXA_SIC,NR_SEQ_REBATE_SIC,NR_SEQ_REAJUSTE_SIC,VL_MANUAL_REAJUSTEREBATEXFRANQUIA_SIC,NR_PERIODO_REAJUSTEREBATEXFRANQUIA_SIC,ST_FEEMINIMO_FAIXA_SIC,ST_FEEMAXIMO_FAIXA_SIC,ST_VALORES_FAIXA_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqFranquiaSic)
		.Append(", ")
		.Append("@" + C_NrSeqFaixaSic)
		.Append(", ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append(", ")
		.Append("@" + C_VlManualReajusterebatexfranquiaSic)
		.Append(", ")
		.Append("@" + C_NrPeriodoReajusterebatexfranquiaSic)
		.Append(", ")
		.Append("@" + C_StFeeminimoFaixaSic)
		.Append(", ")
		.Append("@" + C_StFeemaximoFaixaSic)
		.Append(", ")
		.Append("@" + C_StValoresFaixaSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_REAJUSTE_REBATEXFRANQUIA_SIC SET")
		.Append(" NR_SEQ_FRANQUIA_SIC = ")
		.Append("@" + C_NrSeqFranquiaSic)
		.Append(",NR_SEQ_FAIXA_SIC = ")
		.Append("@" + C_NrSeqFaixaSic)
		.Append(",NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",NR_SEQ_REAJUSTE_SIC = ")
		.Append("@" + C_NrSeqReajusteSic)
		.Append(",VL_MANUAL_REAJUSTEREBATEXFRANQUIA_SIC = ")
		.Append("@" + C_VlManualReajusterebatexfranquiaSic)
		.Append(",NR_PERIODO_REAJUSTEREBATEXFRANQUIA_SIC = ")
		.Append("@" + C_NrPeriodoReajusterebatexfranquiaSic)
		.Append(",ST_FEEMINIMO_FAIXA_SIC = ")
		.Append("@" + C_StFeeminimoFaixaSic)
		.Append(",ST_FEEMAXIMO_FAIXA_SIC = ")
		.Append("@" + C_StFeemaximoFaixaSic)
		.Append(",ST_VALORES_FAIXA_SIC = ")
		.Append("@" + C_StValoresFaixaSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATEXFRANQUIA_SIC = ")
		.Append("@" + C_NrSeqReajusteRebatexfranquiaSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_REAJUSTE_REBATEXFRANQUIA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATEXFRANQUIA_SIC = ")
		.Append("@" + C_NrSeqReajusteRebatexfranquiaSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_REAJUSTE_REBATEXFRANQUIA_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_REAJUSTE_REBATEXFRANQUIA_SIC = ")
		.Append("@" + C_NrSeqReajusteRebatexfranquiaSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Incluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(reajusteRebatexfranquiaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (reajusteRebatexfranquiaSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteRebatexfranquiaSic)));
			else
				reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, reajusteRebatexfranquiaSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Atualizar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(reajusteRebatexfranquiaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ReajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, DatabaseManager databaseManager)
		{
			if (reajusteRebatexfranquiaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteRebatexfranquiaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, reajusteRebatexfranquiaSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui reajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		public void Excluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(reajusteRebatexfranquiaSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui reajusteRebatexfranquiaSic
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, DatabaseManager databaseManager)
		{
			if (reajusteRebatexfranquiaSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteRebatexfranquiaSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, reajusteRebatexfranquiaSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe ReajusteRebatexfranquiaSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic, DatabaseManager databaseManager)
		{
			if (reajusteRebatexfranquiaSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteRebatexfranquiaSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, reajusteRebatexfranquiaSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe ReajusteRebatexfranquiaSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteRebatexfranquiaSic, reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFranquiaSic, reajusteRebatexfranquiaSic.NrSeqFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaSic, reajusteRebatexfranquiaSic.NrSeqFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, reajusteRebatexfranquiaSic.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteRebatexfranquiaSic.NrSeqReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlManualReajusterebatexfranquiaSic, reajusteRebatexfranquiaSic.VlManualReajusterebatexfranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrPeriodoReajusterebatexfranquiaSic, reajusteRebatexfranquiaSic.NrPeriodoReajusterebatexfranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFeeminimoFaixaSic, reajusteRebatexfranquiaSic.StFeeminimoFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFeemaximoFaixaSic, reajusteRebatexfranquiaSic.StFeemaximoFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StValoresFaixaSic, reajusteRebatexfranquiaSic.StValoresFaixaSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="reajusteRebatexfranquiaSic">Instance of <see cref="ReajusteRebatexfranquiaSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ReajusteRebatexfranquiaSic reajusteRebatexfranquiaSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteRebatexfranquiaSic, reajusteRebatexfranquiaSic.NrSeqReajusteRebatexfranquiaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFranquiaSic, reajusteRebatexfranquiaSic.NrSeqFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaSic, reajusteRebatexfranquiaSic.NrSeqFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, reajusteRebatexfranquiaSic.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqReajusteSic, reajusteRebatexfranquiaSic.NrSeqReajusteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlManualReajusterebatexfranquiaSic, reajusteRebatexfranquiaSic.VlManualReajusterebatexfranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrPeriodoReajusterebatexfranquiaSic, reajusteRebatexfranquiaSic.NrPeriodoReajusterebatexfranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFeeminimoFaixaSic, reajusteRebatexfranquiaSic.StFeeminimoFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StFeemaximoFaixaSic, reajusteRebatexfranquiaSic.StFeemaximoFaixaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StValoresFaixaSic, reajusteRebatexfranquiaSic.StValoresFaixaSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

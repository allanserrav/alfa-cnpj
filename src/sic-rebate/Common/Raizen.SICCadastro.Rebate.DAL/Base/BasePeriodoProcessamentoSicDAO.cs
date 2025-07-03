#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BasePeriodoProcessamentoSicDAO.cs
// Class Name	        : PeriodoProcessamentoSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 18/01/2013
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
	#region classe base PeriodoProcessamentoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a PeriodoProcessamentoSicDAO
	/// </summary>
	internal partial class PeriodoProcessamentoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public PeriodoProcessamentoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqPeriodoProcessamentoSic = "NR_SEQ_PERIODO_PROCESSAMENTO_SIC";
		private const string C_NrSeqTipofranquiaSic = "NR_SEQ_TIPOFRANQUIA_SIC";
		private const string C_NrSeqTiporebateSic = "NR_SEQ_TIPOREBATE_SIC";
		private const string C_NrDiaInicioPeriodoProcessamentoSic = "NR_DIA_INICIO_PERIODO_PROCESSAMENTO_SIC";
		private const string C_NrDiaFimPeriodoProcessamentoSic = "NR_DIA_FIM_PERIODO_PROCESSAMENTO_SIC";
		private const string C_NrDiaInicioCalculoSic = "NR_DIA_INICIO_CALCULO_SIC";
		private const string C_NrDiaEmissaoCobranca = "NR_DIA_EMISSAO_COBRANCA";
		#endregion  Constantes de TbPeriodoProcessamentoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_PERIODO_PROCESSAMENTO_SIC")
		.Append("(")
		.Append("NR_SEQ_TIPOFRANQUIA_SIC,NR_SEQ_TIPOREBATE_SIC,NR_DIA_INICIO_PERIODO_PROCESSAMENTO_SIC,NR_DIA_FIM_PERIODO_PROCESSAMENTO_SIC,NR_DIA_INICIO_CALCULO_SIC,NR_DIA_EMISSAO_COBRANCA")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqTipofranquiaSic)
		.Append(", ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(", ")
		.Append("@" + C_NrDiaInicioPeriodoProcessamentoSic)
		.Append(", ")
		.Append("@" + C_NrDiaFimPeriodoProcessamentoSic)
		.Append(", ")
		.Append("@" + C_NrDiaInicioCalculoSic)
		.Append(", ")
		.Append("@" + C_NrDiaEmissaoCobranca)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_PERIODO_PROCESSAMENTO_SIC SET")
		.Append(" NR_SEQ_TIPOFRANQUIA_SIC = ")
		.Append("@" + C_NrSeqTipofranquiaSic)
		.Append(",NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(",NR_DIA_INICIO_PERIODO_PROCESSAMENTO_SIC = ")
		.Append("@" + C_NrDiaInicioPeriodoProcessamentoSic)
		.Append(",NR_DIA_FIM_PERIODO_PROCESSAMENTO_SIC = ")
		.Append("@" + C_NrDiaFimPeriodoProcessamentoSic)
		.Append(",NR_DIA_INICIO_CALCULO_SIC = ")
		.Append("@" + C_NrDiaInicioCalculoSic)
		.Append(",NR_DIA_EMISSAO_COBRANCA = ")
		.Append("@" + C_NrDiaEmissaoCobranca)
		.Append(" WHERE")
		.Append(" NR_SEQ_PERIODO_PROCESSAMENTO_SIC = ")
		.Append("@" + C_NrSeqPeriodoProcessamentoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_PERIODO_PROCESSAMENTO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_PERIODO_PROCESSAMENTO_SIC = ")
		.Append("@" + C_NrSeqPeriodoProcessamentoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_PERIODO_PROCESSAMENTO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_PERIODO_PROCESSAMENTO_SIC = ")
		.Append("@" + C_NrSeqPeriodoProcessamentoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Incluir(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(periodoProcessamentoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(PeriodoProcessamentoSic periodoProcessamentoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (periodoProcessamentoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, periodoProcessamentoSic)));
			else
				periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, periodoProcessamentoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Atualizar(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(periodoProcessamentoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar PeriodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(PeriodoProcessamentoSic periodoProcessamentoSic, DatabaseManager databaseManager)
		{
			if (periodoProcessamentoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, periodoProcessamentoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, periodoProcessamentoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui periodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		public void Excluir(PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(periodoProcessamentoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui periodoProcessamentoSic
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(PeriodoProcessamentoSic periodoProcessamentoSic, DatabaseManager databaseManager)
		{
			if (periodoProcessamentoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, periodoProcessamentoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, periodoProcessamentoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe PeriodoProcessamentoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(PeriodoProcessamentoSic periodoProcessamentoSic, DatabaseManager databaseManager)
		{
			if (periodoProcessamentoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, periodoProcessamentoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, periodoProcessamentoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe PeriodoProcessamentoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqPeriodoProcessamentoSic, periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipofranquiaSic, periodoProcessamentoSic.NrSeqTipofranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, periodoProcessamentoSic.NrSeqTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaInicioPeriodoProcessamentoSic, periodoProcessamentoSic.NrDiaInicioPeriodoProcessamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaFimPeriodoProcessamentoSic, periodoProcessamentoSic.NrDiaFimPeriodoProcessamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaInicioCalculoSic, periodoProcessamentoSic.NrDiaInicioCalculoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaEmissaoCobranca, periodoProcessamentoSic.NrDiaEmissaoCobranca, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="periodoProcessamentoSic">Instance of <see cref="PeriodoProcessamentoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, PeriodoProcessamentoSic periodoProcessamentoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqPeriodoProcessamentoSic, periodoProcessamentoSic.NrSeqPeriodoProcessamentoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTipofranquiaSic, periodoProcessamentoSic.NrSeqTipofranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, periodoProcessamentoSic.NrSeqTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaInicioPeriodoProcessamentoSic, periodoProcessamentoSic.NrDiaInicioPeriodoProcessamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaFimPeriodoProcessamentoSic, periodoProcessamentoSic.NrDiaFimPeriodoProcessamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaInicioCalculoSic, periodoProcessamentoSic.NrDiaInicioCalculoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrDiaEmissaoCobranca, periodoProcessamentoSic.NrDiaEmissaoCobranca, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

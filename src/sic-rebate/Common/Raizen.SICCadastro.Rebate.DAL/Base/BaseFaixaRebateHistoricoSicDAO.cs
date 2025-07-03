#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseFaixaRebateHistoricoSicDAO.cs
// Class Name	        : FaixaRebateHistoricoSicDAO
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
	#region classe base FaixaRebateHistoricoSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a FaixaRebateHistoricoSicDAO
	/// </summary>
	internal partial class FaixaRebateHistoricoSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public FaixaRebateHistoricoSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqFaixaRebateHistoricoSic = "NR_SEQ_FAIXA_REBATE_HISTORICO_SIC";
		private const string C_NrSeqFaixarebateSic = "NR_SEQ_FAIXAREBATE_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_NrSeqCategoriaSic = "NR_SEQ_CATEGORIA_SIC";
		private const string C_DtIniciocalculoRebateSic = "DT_INICIOCALCULO_REBATE_SIC";
		private const string C_DtFimcalculoRebateSic = "DT_FIMCALCULO_REBATE_SIC";
		private const string C_VlVolumemensalRebateSic = "VL_VOLUMEMENSAL_REBATE_SIC";
		private const string C_VlPercminimoRebateSic = "VL_PERCMINIMO_REBATE_SIC";
		private const string C_VlPercmaximoRebateSic = "VL_PERCMAXIMO_REBATE_SIC";
		private const string C_VlBonificacaoRebateSic = "VL_BONIFICACAO_REBATE_SIC";
		private const string C_VlRecebebonusRebateSic = "VL_RECEBEBONUS_REBATE_SIC";
		private const string C_NrSeqGrupoSic = "NR_SEQ_GRUPO_SIC";
		#endregion  Constantes de TbFaixaRebateHistoricoSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_FAIXA_REBATE_HISTORICO_SIC")
		.Append("(")
		.Append("NR_SEQ_FAIXAREBATE_SIC,NR_SEQ_REBATE_SIC,NR_SEQ_CATEGORIA_SIC,DT_INICIOCALCULO_REBATE_SIC,DT_FIMCALCULO_REBATE_SIC,VL_VOLUMEMENSAL_REBATE_SIC,VL_PERCMINIMO_REBATE_SIC,VL_PERCMAXIMO_REBATE_SIC,VL_BONIFICACAO_REBATE_SIC,VL_RECEBEBONUS_REBATE_SIC,NR_SEQ_GRUPO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(", ")
		.Append("@" + C_DtIniciocalculoRebateSic)
		.Append(", ")
		.Append("@" + C_DtFimcalculoRebateSic)
		.Append(", ")
		.Append("@" + C_VlVolumemensalRebateSic)
		.Append(", ")
		.Append("@" + C_VlPercminimoRebateSic)
		.Append(", ")
		.Append("@" + C_VlPercmaximoRebateSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoRebateSic)
		.Append(", ")
		.Append("@" + C_VlRecebebonusRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqGrupoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_FAIXA_REBATE_HISTORICO_SIC SET")
		.Append(" NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(",NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(",DT_INICIOCALCULO_REBATE_SIC = ")
		.Append("@" + C_DtIniciocalculoRebateSic)
		.Append(",DT_FIMCALCULO_REBATE_SIC = ")
		.Append("@" + C_DtFimcalculoRebateSic)
		.Append(",VL_VOLUMEMENSAL_REBATE_SIC = ")
		.Append("@" + C_VlVolumemensalRebateSic)
		.Append(",VL_PERCMINIMO_REBATE_SIC = ")
		.Append("@" + C_VlPercminimoRebateSic)
		.Append(",VL_PERCMAXIMO_REBATE_SIC = ")
		.Append("@" + C_VlPercmaximoRebateSic)
		.Append(",VL_BONIFICACAO_REBATE_SIC = ")
		.Append("@" + C_VlBonificacaoRebateSic)
		.Append(",VL_RECEBEBONUS_REBATE_SIC = ")
		.Append("@" + C_VlRecebebonusRebateSic)
		.Append(",NR_SEQ_GRUPO_SIC = ")
		.Append("@" + C_NrSeqGrupoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqFaixaRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_FAIXA_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqFaixaRebateHistoricoSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_FAIXA_REBATE_HISTORICO_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXA_REBATE_HISTORICO_SIC = ")
		.Append("@" + C_NrSeqFaixaRebateHistoricoSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Incluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(faixaRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (faixaRebateHistoricoSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, faixaRebateHistoricoSic)));
			else
				faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, faixaRebateHistoricoSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Atualizar(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(faixaRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar FaixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(FaixaRebateHistoricoSic faixaRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (faixaRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, faixaRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, faixaRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui faixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		public void Excluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(faixaRebateHistoricoSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui faixaRebateHistoricoSic
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(FaixaRebateHistoricoSic faixaRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (faixaRebateHistoricoSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, faixaRebateHistoricoSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, faixaRebateHistoricoSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe FaixaRebateHistoricoSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(FaixaRebateHistoricoSic faixaRebateHistoricoSic, DatabaseManager databaseManager)
		{
			if (faixaRebateHistoricoSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, faixaRebateHistoricoSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, faixaRebateHistoricoSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe FaixaRebateHistoricoSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaRebateHistoricoSic, faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, faixaRebateHistoricoSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, faixaRebateHistoricoSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, faixaRebateHistoricoSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, faixaRebateHistoricoSic.DtIniciocalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, faixaRebateHistoricoSic.DtFimcalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, faixaRebateHistoricoSic.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, faixaRebateHistoricoSic.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, faixaRebateHistoricoSic.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, faixaRebateHistoricoSic.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, faixaRebateHistoricoSic.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, faixaRebateHistoricoSic.NrSeqGrupoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixaRebateHistoricoSic">Instance of <see cref="FaixaRebateHistoricoSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, FaixaRebateHistoricoSic faixaRebateHistoricoSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixaRebateHistoricoSic, faixaRebateHistoricoSic.NrSeqFaixaRebateHistoricoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, faixaRebateHistoricoSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, faixaRebateHistoricoSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, faixaRebateHistoricoSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, faixaRebateHistoricoSic.DtIniciocalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, faixaRebateHistoricoSic.DtFimcalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, faixaRebateHistoricoSic.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, faixaRebateHistoricoSic.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, faixaRebateHistoricoSic.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, faixaRebateHistoricoSic.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, faixaRebateHistoricoSic.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, faixaRebateHistoricoSic.NrSeqGrupoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

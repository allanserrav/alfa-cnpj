#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseFaixarebateSicDAO.cs
// Class Name	        : FaixarebateSicDAO
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
	#region classe base FaixarebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a FaixarebateSicDAO
	/// </summary>
	internal partial class FaixarebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public FaixarebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
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
		private const string C_StAtivoFaixaSic = "ST_ATIVO_FAIXA_SIC";
		#endregion  Constantes de TbFaixarebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_FAIXAREBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,NR_SEQ_CATEGORIA_SIC,DT_INICIOCALCULO_REBATE_SIC,DT_FIMCALCULO_REBATE_SIC,VL_VOLUMEMENSAL_REBATE_SIC,VL_PERCMINIMO_REBATE_SIC,VL_PERCMAXIMO_REBATE_SIC,VL_BONIFICACAO_REBATE_SIC,VL_RECEBEBONUS_REBATE_SIC,NR_SEQ_GRUPO_SIC,ST_ATIVO_FAIXA_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
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
		.Append(", ")
		.Append("@" + C_StAtivoFaixaSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_FAIXAREBATE_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
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
		.Append(",ST_ATIVO_FAIXA_SIC = ")
		.Append("@" + C_StAtivoFaixaSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_FAIXAREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_FAIXAREBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Incluir(FaixarebateSic faixarebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(faixarebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(FaixarebateSic faixarebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (faixarebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				faixarebateSic.NrSeqFaixarebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, faixarebateSic)));
			else
				faixarebateSic.NrSeqFaixarebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, faixarebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Atualizar(FaixarebateSic faixarebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(faixarebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar FaixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(FaixarebateSic faixarebateSic, DatabaseManager databaseManager)
		{
			if (faixarebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, faixarebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, faixarebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui faixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		public void Excluir(FaixarebateSic faixarebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(faixarebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui faixarebateSic
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(FaixarebateSic faixarebateSic, DatabaseManager databaseManager)
		{
			if (faixarebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, faixarebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, faixarebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe FaixarebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(FaixarebateSic faixarebateSic, DatabaseManager databaseManager)
		{
			if (faixarebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, faixarebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, faixarebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe FaixarebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, FaixarebateSic faixarebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, faixarebateSic.NrSeqFaixarebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, FaixarebateSic faixarebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, faixarebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, faixarebateSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, faixarebateSic.DtIniciocalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, faixarebateSic.DtFimcalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, faixarebateSic.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, faixarebateSic.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, faixarebateSic.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, faixarebateSic.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, faixarebateSic.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, faixarebateSic.NrSeqGrupoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAtivoFaixaSic, faixarebateSic.StAtivoFaixaSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="faixarebateSic">Instance of <see cref="FaixarebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, FaixarebateSic faixarebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, faixarebateSic.NrSeqFaixarebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, faixarebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, faixarebateSic.NrSeqCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, faixarebateSic.DtIniciocalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, faixarebateSic.DtFimcalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, faixarebateSic.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, faixarebateSic.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, faixarebateSic.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, faixarebateSic.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, faixarebateSic.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, faixarebateSic.NrSeqGrupoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAtivoFaixaSic, faixarebateSic.StAtivoFaixaSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

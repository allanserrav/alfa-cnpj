#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseCalculoRebateSicDAO.cs
// Class Name	        : CalculoRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Murilo Beltrame
// Creation Date 	    : 08/08/2014
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
	#region classe base CalculoRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateSicDAO
	/// </summary>
	internal partial class CalculoRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public CalculoRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqCalculoRebateSic = "NR_SEQ_CALCULO_REBATE_SIC";
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_DtPeriodoSic = "DT_PERIODO_SIC";
		private const string C_DtPagamentoSic = "DT_PAGAMENTO_SIC";
		private const string C_VlBonificacaoTotalSic = "VL_BONIFICACAO_TOTAL_SIC";
		private const string C_VlVolumeTotal = "VL_VOLUME_TOTAL";
		private const string C_DsObsCalculoSic = "DS_OBS_CALCULO_SIC";
		private const string C_NrSeqStatusCalculoRebateSic = "NR_SEQ_STATUS_CALCULO_REBATE_SIC";
		private const string C_StAprovadoAnalistaSic = "ST_APROVADO_ANALISTA_SIC";
		private const string C_DtAprovadoAnalistaSic = "DT_APROVADO_ANALISTA_SIC";
		private const string C_StEnviadoAprovacaoGerenteSic = "ST_ENVIADO_APROVACAO_GERENTE_SIC";
		private const string C_DtEnviadoAprovacaoGerenteSic = "DT_ENVIADO_APROVACAO_GERENTE_SIC";
		private const string C_StAprovadoGerenteSic = "ST_APROVADO_GERENTE_SIC";
		private const string C_DtAprovadoGerenteSic = "DT_APROVADO_GERENTE_SIC";
		private const string C_StAditivoSic = "ST_ADITIVO_SIC";
		private const string C_StPagtoManualSic = "ST_PAGTO_MANUAL_SIC";
		private const string C_DsObsPagtoSic = "DS_OBS_PAGTO_SIC";
		private const string C_VlVolumeConsumidoSic = "VL_VOLUME_CONSUMIDO_SIC";
		private const string C_StAcertoSic = "ST_ACERTO_SIC";
		#endregion  Constantes de TbCalculoRebateSic

		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CALCULO_REBATE_SIC")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,DT_PERIODO_SIC,DT_PAGAMENTO_SIC,VL_BONIFICACAO_TOTAL_SIC,VL_VOLUME_TOTAL,DS_OBS_CALCULO_SIC,NR_SEQ_STATUS_CALCULO_REBATE_SIC,ST_APROVADO_ANALISTA_SIC,DT_APROVADO_ANALISTA_SIC,ST_ENVIADO_APROVACAO_GERENTE_SIC,DT_ENVIADO_APROVACAO_GERENTE_SIC,ST_APROVADO_GERENTE_SIC,DT_APROVADO_GERENTE_SIC,ST_ADITIVO_SIC,ST_PAGTO_MANUAL_SIC,DS_OBS_PAGTO_SIC,VL_VOLUME_CONSUMIDO_SIC,ST_ACERTO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_DtPeriodoSic)
		.Append(", ")
		.Append("@" + C_DtPagamentoSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoTotalSic)
		.Append(", ")
		.Append("@" + C_VlVolumeTotal)
		.Append(", ")
		.Append("@" + C_DsObsCalculoSic)
		.Append(", ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_StAprovadoAnalistaSic)
		.Append(", ")
		.Append("@" + C_DtAprovadoAnalistaSic)
		.Append(", ")
		.Append("@" + C_StEnviadoAprovacaoGerenteSic)
		.Append(", ")
		.Append("@" + C_DtEnviadoAprovacaoGerenteSic)
		.Append(", ")
		.Append("@" + C_StAprovadoGerenteSic)
		.Append(", ")
		.Append("@" + C_DtAprovadoGerenteSic)
		.Append(", ")
		.Append("@" + C_StAditivoSic)
		.Append(", ")
		.Append("@" + C_StPagtoManualSic)
		.Append(", ")
		.Append("@" + C_DsObsPagtoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeConsumidoSic)
		.Append(", ")
		.Append("@" + C_StAcertoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CALCULO_REBATE_SIC SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",DT_PERIODO_SIC = ")
		.Append("@" + C_DtPeriodoSic)
		.Append(",DT_PAGAMENTO_SIC = ")
		.Append("@" + C_DtPagamentoSic)
		.Append(",VL_BONIFICACAO_TOTAL_SIC = ")
		.Append("@" + C_VlBonificacaoTotalSic)
		.Append(",VL_VOLUME_TOTAL = ")
		.Append("@" + C_VlVolumeTotal)
		.Append(",DS_OBS_CALCULO_SIC = ")
		.Append("@" + C_DsObsCalculoSic)
		.Append(",NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(",ST_APROVADO_ANALISTA_SIC = ")
		.Append("@" + C_StAprovadoAnalistaSic)
		.Append(",DT_APROVADO_ANALISTA_SIC = ")
		.Append("@" + C_DtAprovadoAnalistaSic)
		.Append(",ST_ENVIADO_APROVACAO_GERENTE_SIC = ")
		.Append("@" + C_StEnviadoAprovacaoGerenteSic)
		.Append(",DT_ENVIADO_APROVACAO_GERENTE_SIC = ")
		.Append("@" + C_DtEnviadoAprovacaoGerenteSic)
		.Append(",ST_APROVADO_GERENTE_SIC = ")
		.Append("@" + C_StAprovadoGerenteSic)
		.Append(",DT_APROVADO_GERENTE_SIC = ")
		.Append("@" + C_DtAprovadoGerenteSic)
		.Append(",ST_ADITIVO_SIC = ")
		.Append("@" + C_StAditivoSic)
		.Append(",ST_PAGTO_MANUAL_SIC = ")
		.Append("@" + C_StPagtoManualSic)
		.Append(",DS_OBS_PAGTO_SIC = ")
		.Append("@" + C_DsObsPagtoSic)
		.Append(",VL_VOLUME_CONSUMIDO_SIC = ")
		.Append("@" + C_VlVolumeConsumidoSic)
		.Append(",ST_ACERTO_SIC = ")
		.Append("@" + C_StAcertoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CALCULO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CALCULO_REBATE_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Incluir(CalculoRebateSic calculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(calculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(CalculoRebateSic calculoRebateSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (calculoRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				calculoRebateSic.NrSeqCalculoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateSic)));
			else
				calculoRebateSic.NrSeqCalculoRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Atualizar(CalculoRebateSic calculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(calculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(CalculoRebateSic calculoRebateSic, DatabaseManager databaseManager)
		{
			if (calculoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		public void Excluir(CalculoRebateSic calculoRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(calculoRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui calculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(CalculoRebateSic calculoRebateSic, DatabaseManager databaseManager)
		{
			if (calculoRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe CalculoRebateSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(CalculoRebateSic calculoRebateSic, DatabaseManager databaseManager)
		{
			if (calculoRebateSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe CalculoRebateSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, CalculoRebateSic calculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateSic.NrSeqCalculoRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, CalculoRebateSic calculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, calculoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, calculoRebateSic.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPagamentoSic, calculoRebateSic.DtPagamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoTotalSic, calculoRebateSic.VlBonificacaoTotalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeTotal, calculoRebateSic.VlVolumeTotal, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsCalculoSic, calculoRebateSic.DsObsCalculoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, calculoRebateSic.NrSeqStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAprovadoAnalistaSic, calculoRebateSic.StAprovadoAnalistaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAprovadoAnalistaSic, calculoRebateSic.DtAprovadoAnalistaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StEnviadoAprovacaoGerenteSic, calculoRebateSic.StEnviadoAprovacaoGerenteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtEnviadoAprovacaoGerenteSic, calculoRebateSic.DtEnviadoAprovacaoGerenteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAprovadoGerenteSic, calculoRebateSic.StAprovadoGerenteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAprovadoGerenteSic, calculoRebateSic.DtAprovadoGerenteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAditivoSic, calculoRebateSic.StAditivoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPagtoManualSic, calculoRebateSic.StPagtoManualSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsPagtoSic, calculoRebateSic.DsObsPagtoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeConsumidoSic, calculoRebateSic.VlVolumeConsumidoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAcertoSic, calculoRebateSic.StAcertoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateSic">Instance of <see cref="CalculoRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, CalculoRebateSic calculoRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateSic.NrSeqCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, calculoRebateSic.NrSeqRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, calculoRebateSic.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPagamentoSic, calculoRebateSic.DtPagamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoTotalSic, calculoRebateSic.VlBonificacaoTotalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeTotal, calculoRebateSic.VlVolumeTotal, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsCalculoSic, calculoRebateSic.DsObsCalculoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, calculoRebateSic.NrSeqStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAprovadoAnalistaSic, calculoRebateSic.StAprovadoAnalistaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAprovadoAnalistaSic, calculoRebateSic.DtAprovadoAnalistaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StEnviadoAprovacaoGerenteSic, calculoRebateSic.StEnviadoAprovacaoGerenteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtEnviadoAprovacaoGerenteSic, calculoRebateSic.DtEnviadoAprovacaoGerenteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAprovadoGerenteSic, calculoRebateSic.StAprovadoGerenteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAprovadoGerenteSic, calculoRebateSic.DtAprovadoGerenteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAditivoSic, calculoRebateSic.StAditivoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StPagtoManualSic, calculoRebateSic.StPagtoManualSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_DsObsPagtoSic, calculoRebateSic.DsObsPagtoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeConsumidoSic, calculoRebateSic.VlVolumeConsumidoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAcertoSic, calculoRebateSic.StAcertoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

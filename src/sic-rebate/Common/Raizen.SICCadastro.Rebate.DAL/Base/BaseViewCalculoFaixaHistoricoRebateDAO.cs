#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseViewCalculoFaixaHistoricoRebateDAO.cs
// Class Name	        : ViewCalculoFaixaHistoricoRebateDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 29/01/2013
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
	#region classe base ViewCalculoFaixaHistoricoRebateDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ViewCalculoFaixaHistoricoRebateDAO
	/// </summary>
	internal partial class ViewCalculoFaixaHistoricoRebateDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ViewCalculoFaixaHistoricoRebateDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqRebateSic = "NR_SEQ_REBATE_SIC";
		private const string C_DtPeriodoSic = "DT_PERIODO_SIC";
		private const string C_VlBonificacaoTotalSic = "VL_BONIFICACAO_TOTAL_SIC";
		private const string C_StAditivoSic = "ST_ADITIVO_SIC";
		private const string C_DtPeriodoVolume = "DT_PERIODO_VOLUME";
		private const string C_NrSeqFaixarebateSic = "NR_SEQ_FAIXAREBATE_SIC";
		private const string C_NrSeqCategoriaSic = "NR_SEQ_CATEGORIA_SIC";
		private const string C_VlVolumeContratadoSic = "VL_VOLUME_CONTRATADO_SIC";
		private const string C_VlVolumeMaximoSic = "VL_VOLUME_MAXIMO_SIC";
		private const string C_VlVolumeMinimoSic = "VL_VOLUME_MINIMO_SIC";
		private const string C_VlBonificacaoCalculadoSic = "VL_BONIFICACAO_CALCULADO_SIC";
		private const string C_DtIniciocalculoRebateSic = "DT_INICIOCALCULO_REBATE_SIC";
		private const string C_DtFimcalculoRebateSic = "DT_FIMCALCULO_REBATE_SIC";
		private const string C_VlVolumemensalRebateSic = "VL_VOLUMEMENSAL_REBATE_SIC";
		private const string C_VlPercminimoRebateSic = "VL_PERCMINIMO_REBATE_SIC";
		private const string C_VlPercmaximoRebateSic = "VL_PERCMAXIMO_REBATE_SIC";
		private const string C_VlBonificacaoRebateSic = "VL_BONIFICACAO_REBATE_SIC";
		private const string C_VlRecebebonusRebateSic = "VL_RECEBEBONUS_REBATE_SIC";
		private const string C_NmCategoriaSic = "NM_CATEGORIA_SIC";
		private const string C_NmRazsociallojaFranquiaSic = "NM_RAZSOCIALLOJA_FRANQUIA_SIC";
		private const string C_NrIbmClienteSic = "NR_IBM_CLIENTE_SIC";
		private const string C_NrCegrpostoClienteSic = "NR_CEGRPOSTO_CLIENTE_SIC";
		private const string C_NmGalojaClienteSic = "NM_GALOJA_CLIENTE_SIC";
		private const string C_NmGtlojaClienteSic = "NM_GTLOJA_CLIENTE_SIC";
		private const string C_NmCanalClienteSic = "NM_CANAL_CLIENTE_SIC";
		private const string C_NrCodigopagadorRebateSic = "NR_CODIGOPAGADOR_REBATE_SIC";
		private const string C_NrCodigofornecedorRebateSic = "NR_CODIGOFORNECEDOR_REBATE_SIC";
		private const string C_DtAssinaturacontratoRebateSic = "DT_ASSINATURACONTRATO_REBATE_SIC";
		private const string C_DtFimvigenciaRebateSic = "DT_FIMVIGENCIA_REBATE_SIC";
		private const string C_DtPagamentoSic = "DT_PAGAMENTO_SIC";
		private const string C_NrSeqTiporebateSic = "NR_SEQ_TIPOREBATE_SIC";
		private const string C_NmTiporebateSic = "NM_TIPOREBATE_SIC";
		private const string C_NrSeqGrupoSic = "NR_SEQ_GRUPO_SIC";
		private const string C_NmEmpresaSic = "NM_EMPRESA_SIC";
		private const string C_VlDebitoSic = "VL_DEBITO_SIC";
		private const string C_NrSeqStatusCalculoRebateSic = "NR_SEQ_STATUS_CALCULO_REBATE_SIC";
		private const string C_NmStatusCalculoRebateSic = "NM_STATUS_CALCULO_REBATE_SIC";
		private const string C_VlVolumeCompradoSic = "VL_VOLUME_COMPRADO_SIC";
		#endregion  Constantes de TbViewCalculoFaixaHistoricoRebate
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO VIEW_CALCULO_FAIXA_HISTORICO_REBATE")
		.Append("(")
		.Append("NR_SEQ_REBATE_SIC,DT_PERIODO_SIC,VL_BONIFICACAO_TOTAL_SIC,ST_ADITIVO_SIC,DT_PERIODO_VOLUME,NR_SEQ_FAIXAREBATE_SIC,NR_SEQ_CATEGORIA_SIC,VL_VOLUME_CONTRATADO_SIC,VL_VOLUME_MAXIMO_SIC,VL_VOLUME_MINIMO_SIC,VL_BONIFICACAO_CALCULADO_SIC,DT_INICIOCALCULO_REBATE_SIC,DT_FIMCALCULO_REBATE_SIC,VL_VOLUMEMENSAL_REBATE_SIC,VL_PERCMINIMO_REBATE_SIC,VL_PERCMAXIMO_REBATE_SIC,VL_BONIFICACAO_REBATE_SIC,VL_RECEBEBONUS_REBATE_SIC,NM_CATEGORIA_SIC,NM_RAZSOCIALLOJA_FRANQUIA_SIC,NR_IBM_CLIENTE_SIC,NR_CEGRPOSTO_CLIENTE_SIC,NM_GALOJA_CLIENTE_SIC,NM_GTLOJA_CLIENTE_SIC,NM_CANAL_CLIENTE_SIC,NR_CODIGOPAGADOR_REBATE_SIC,NR_CODIGOFORNECEDOR_REBATE_SIC,DT_ASSINATURACONTRATO_REBATE_SIC,DT_FIMVIGENCIA_REBATE_SIC,DT_PAGAMENTO_SIC,NR_SEQ_TIPOREBATE_SIC,NM_TIPOREBATE_SIC,NR_SEQ_GRUPO_SIC,NM_EMPRESA_SIC,VL_DEBITO_SIC,NR_SEQ_STATUS_CALCULO_REBATE_SIC,NM_STATUS_CALCULO_REBATE_SIC,VL_VOLUME_COMPRADO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqRebateSic)
		.Append(", ")
		.Append("@" + C_DtPeriodoSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoTotalSic)
		.Append(", ")
		.Append("@" + C_StAditivoSic)
		.Append(", ")
		.Append("@" + C_DtPeriodoVolume)
		.Append(", ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(", ")
		.Append("@" + C_VlVolumeContratadoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeMaximoSic)
		.Append(", ")
		.Append("@" + C_VlVolumeMinimoSic)
		.Append(", ")
		.Append("@" + C_VlBonificacaoCalculadoSic)
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
		.Append("@" + C_NmCategoriaSic)
		.Append(", ")
		.Append("@" + C_NmRazsociallojaFranquiaSic)
		.Append(", ")
		.Append("@" + C_NrIbmClienteSic)
		.Append(", ")
		.Append("@" + C_NrCegrpostoClienteSic)
		.Append(", ")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(", ")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(", ")
		.Append("@" + C_NmCanalClienteSic)
		.Append(", ")
		.Append("@" + C_NrCodigopagadorRebateSic)
		.Append(", ")
		.Append("@" + C_NrCodigofornecedorRebateSic)
		.Append(", ")
		.Append("@" + C_DtAssinaturacontratoRebateSic)
		.Append(", ")
		.Append("@" + C_DtFimvigenciaRebateSic)
		.Append(", ")
		.Append("@" + C_DtPagamentoSic)
		.Append(", ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(", ")
		.Append("@" + C_NmTiporebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqGrupoSic)
		.Append(", ")
		.Append("@" + C_NmEmpresaSic)
		.Append(", ")
		.Append("@" + C_VlDebitoSic)
		.Append(", ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_NmStatusCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_VlVolumeCompradoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE VIEW_CALCULO_FAIXA_HISTORICO_REBATE SET")
		.Append(" NR_SEQ_REBATE_SIC = ")
		.Append("@" + C_NrSeqRebateSic)
		.Append(",DT_PERIODO_SIC = ")
		.Append("@" + C_DtPeriodoSic)
		.Append(",VL_BONIFICACAO_TOTAL_SIC = ")
		.Append("@" + C_VlBonificacaoTotalSic)
		.Append(",ST_ADITIVO_SIC = ")
		.Append("@" + C_StAditivoSic)
		.Append(",DT_PERIODO_VOLUME = ")
		.Append("@" + C_DtPeriodoVolume)
		.Append(",NR_SEQ_FAIXAREBATE_SIC = ")
		.Append("@" + C_NrSeqFaixarebateSic)
		.Append(",NR_SEQ_CATEGORIA_SIC = ")
		.Append("@" + C_NrSeqCategoriaSic)
		.Append(",VL_VOLUME_CONTRATADO_SIC = ")
		.Append("@" + C_VlVolumeContratadoSic)
		.Append(",VL_VOLUME_MAXIMO_SIC = ")
		.Append("@" + C_VlVolumeMaximoSic)
		.Append(",VL_VOLUME_MINIMO_SIC = ")
		.Append("@" + C_VlVolumeMinimoSic)
		.Append(",VL_BONIFICACAO_CALCULADO_SIC = ")
		.Append("@" + C_VlBonificacaoCalculadoSic)
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
		.Append(",NM_CATEGORIA_SIC = ")
		.Append("@" + C_NmCategoriaSic)
		.Append(",NM_RAZSOCIALLOJA_FRANQUIA_SIC = ")
		.Append("@" + C_NmRazsociallojaFranquiaSic)
		.Append(",NR_IBM_CLIENTE_SIC = ")
		.Append("@" + C_NrIbmClienteSic)
		.Append(",NR_CEGRPOSTO_CLIENTE_SIC = ")
		.Append("@" + C_NrCegrpostoClienteSic)
		.Append(",NM_GALOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(",NM_GTLOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(",NM_CANAL_CLIENTE_SIC = ")
		.Append("@" + C_NmCanalClienteSic)
		.Append(",NR_CODIGOPAGADOR_REBATE_SIC = ")
		.Append("@" + C_NrCodigopagadorRebateSic)
		.Append(",NR_CODIGOFORNECEDOR_REBATE_SIC = ")
		.Append("@" + C_NrCodigofornecedorRebateSic)
		.Append(",DT_ASSINATURACONTRATO_REBATE_SIC = ")
		.Append("@" + C_DtAssinaturacontratoRebateSic)
		.Append(",DT_FIMVIGENCIA_REBATE_SIC = ")
		.Append("@" + C_DtFimvigenciaRebateSic)
		.Append(",DT_PAGAMENTO_SIC = ")
		.Append("@" + C_DtPagamentoSic)
		.Append(",NR_SEQ_TIPOREBATE_SIC = ")
		.Append("@" + C_NrSeqTiporebateSic)
		.Append(",NM_TIPOREBATE_SIC = ")
		.Append("@" + C_NmTiporebateSic)
		.Append(",NR_SEQ_GRUPO_SIC = ")
		.Append("@" + C_NrSeqGrupoSic)
		.Append(",NM_EMPRESA_SIC = ")
		.Append("@" + C_NmEmpresaSic)
		.Append(",VL_DEBITO_SIC = ")
		.Append("@" + C_VlDebitoSic)
		.Append(",NR_SEQ_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqStatusCalculoRebateSic)
		.Append(",NM_STATUS_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NmStatusCalculoRebateSic)
		.Append(",VL_VOLUME_COMPRADO_SIC = ")
		.Append("@" + C_VlVolumeCompradoSic)
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM VIEW_CALCULO_FAIXA_HISTORICO_REBATE")
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Excluir
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Incluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(viewCalculoFaixaHistoricoRebate, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, DatabaseManager databaseManager)
		{
			if (viewCalculoFaixaHistoricoRebate == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewCalculoFaixaHistoricoRebate));
			else
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewCalculoFaixaHistoricoRebate), databaseManager.Transaction);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Atualizar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(viewCalculoFaixaHistoricoRebate, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ViewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, DatabaseManager databaseManager)
		{
			if (viewCalculoFaixaHistoricoRebate == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewCalculoFaixaHistoricoRebate));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewCalculoFaixaHistoricoRebate), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		public void Excluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(viewCalculoFaixaHistoricoRebate, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui viewCalculoFaixaHistoricoRebate
		/// </summary>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate, DatabaseManager databaseManager)
		{
			if (viewCalculoFaixaHistoricoRebate == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewCalculoFaixaHistoricoRebate));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewCalculoFaixaHistoricoRebate), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			//No PK found
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, viewCalculoFaixaHistoricoRebate.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, viewCalculoFaixaHistoricoRebate.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoTotalSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoTotalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAditivoSic, viewCalculoFaixaHistoricoRebate.StAditivoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoVolume, viewCalculoFaixaHistoricoRebate.DtPeriodoVolume, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, viewCalculoFaixaHistoricoRebate.NrSeqFaixarebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, viewCalculoFaixaHistoricoRebate.NrSeqCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeContratadoSic, viewCalculoFaixaHistoricoRebate.VlVolumeContratadoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMaximoSic, viewCalculoFaixaHistoricoRebate.VlVolumeMaximoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMinimoSic, viewCalculoFaixaHistoricoRebate.VlVolumeMinimoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoCalculadoSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoCalculadoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, viewCalculoFaixaHistoricoRebate.DtIniciocalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, viewCalculoFaixaHistoricoRebate.DtFimcalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, viewCalculoFaixaHistoricoRebate.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, viewCalculoFaixaHistoricoRebate.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, viewCalculoFaixaHistoricoRebate.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, viewCalculoFaixaHistoricoRebate.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCategoriaSic, viewCalculoFaixaHistoricoRebate.NmCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmRazsociallojaFranquiaSic, viewCalculoFaixaHistoricoRebate.NmRazsociallojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, viewCalculoFaixaHistoricoRebate.NrIbmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCegrpostoClienteSic, viewCalculoFaixaHistoricoRebate.NrCegrpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, viewCalculoFaixaHistoricoRebate.NmGalojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, viewCalculoFaixaHistoricoRebate.NmGtlojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCanalClienteSic, viewCalculoFaixaHistoricoRebate.NmCanalClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigopagadorRebateSic, viewCalculoFaixaHistoricoRebate.NrCodigopagadorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigofornecedorRebateSic, viewCalculoFaixaHistoricoRebate.NrCodigofornecedorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAssinaturacontratoRebateSic, viewCalculoFaixaHistoricoRebate.DtAssinaturacontratoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimvigenciaRebateSic, viewCalculoFaixaHistoricoRebate.DtFimvigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPagamentoSic, viewCalculoFaixaHistoricoRebate.DtPagamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, viewCalculoFaixaHistoricoRebate.NrSeqTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTiporebateSic, viewCalculoFaixaHistoricoRebate.NmTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, viewCalculoFaixaHistoricoRebate.NrSeqGrupoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmEmpresaSic, viewCalculoFaixaHistoricoRebate.NmEmpresaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlDebitoSic, viewCalculoFaixaHistoricoRebate.VlDebitoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, viewCalculoFaixaHistoricoRebate.NrSeqStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusCalculoRebateSic, viewCalculoFaixaHistoricoRebate.NmStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCompradoSic, viewCalculoFaixaHistoricoRebate.VlVolumeCompradoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewCalculoFaixaHistoricoRebate">Instance of <see cref="ViewCalculoFaixaHistoricoRebate"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ViewCalculoFaixaHistoricoRebate viewCalculoFaixaHistoricoRebate)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqRebateSic, viewCalculoFaixaHistoricoRebate.NrSeqRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoSic, viewCalculoFaixaHistoricoRebate.DtPeriodoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoTotalSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoTotalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Boolean, C_StAditivoSic, viewCalculoFaixaHistoricoRebate.StAditivoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPeriodoVolume, viewCalculoFaixaHistoricoRebate.DtPeriodoVolume, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqFaixarebateSic, viewCalculoFaixaHistoricoRebate.NrSeqFaixarebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCategoriaSic, viewCalculoFaixaHistoricoRebate.NrSeqCategoriaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeContratadoSic, viewCalculoFaixaHistoricoRebate.VlVolumeContratadoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMaximoSic, viewCalculoFaixaHistoricoRebate.VlVolumeMaximoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeMinimoSic, viewCalculoFaixaHistoricoRebate.VlVolumeMinimoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoCalculadoSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoCalculadoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtIniciocalculoRebateSic, viewCalculoFaixaHistoricoRebate.DtIniciocalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimcalculoRebateSic, viewCalculoFaixaHistoricoRebate.DtFimcalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumemensalRebateSic, viewCalculoFaixaHistoricoRebate.VlVolumemensalRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercminimoRebateSic, viewCalculoFaixaHistoricoRebate.VlPercminimoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlPercmaximoRebateSic, viewCalculoFaixaHistoricoRebate.VlPercmaximoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlBonificacaoRebateSic, viewCalculoFaixaHistoricoRebate.VlBonificacaoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlRecebebonusRebateSic, viewCalculoFaixaHistoricoRebate.VlRecebebonusRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCategoriaSic, viewCalculoFaixaHistoricoRebate.NmCategoriaSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmRazsociallojaFranquiaSic, viewCalculoFaixaHistoricoRebate.NmRazsociallojaFranquiaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, viewCalculoFaixaHistoricoRebate.NrIbmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCegrpostoClienteSic, viewCalculoFaixaHistoricoRebate.NrCegrpostoClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, viewCalculoFaixaHistoricoRebate.NmGalojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, viewCalculoFaixaHistoricoRebate.NmGtlojaClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmCanalClienteSic, viewCalculoFaixaHistoricoRebate.NmCanalClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigopagadorRebateSic, viewCalculoFaixaHistoricoRebate.NrCodigopagadorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrCodigofornecedorRebateSic, viewCalculoFaixaHistoricoRebate.NrCodigofornecedorRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtAssinaturacontratoRebateSic, viewCalculoFaixaHistoricoRebate.DtAssinaturacontratoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtFimvigenciaRebateSic, viewCalculoFaixaHistoricoRebate.DtFimvigenciaRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.DateTime, C_DtPagamentoSic, viewCalculoFaixaHistoricoRebate.DtPagamentoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqTiporebateSic, viewCalculoFaixaHistoricoRebate.NrSeqTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmTiporebateSic, viewCalculoFaixaHistoricoRebate.NmTiporebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqGrupoSic, viewCalculoFaixaHistoricoRebate.NrSeqGrupoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmEmpresaSic, viewCalculoFaixaHistoricoRebate.NmEmpresaSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlDebitoSic, viewCalculoFaixaHistoricoRebate.VlDebitoSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqStatusCalculoRebateSic, viewCalculoFaixaHistoricoRebate.NrSeqStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmStatusCalculoRebateSic, viewCalculoFaixaHistoricoRebate.NmStatusCalculoRebateSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCompradoSic, viewCalculoFaixaHistoricoRebate.VlVolumeCompradoSic, false));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseCalculoRebateProporcionalSicDAO.cs
// Class Name	        : CalculoRebateProporcionalSicDAO
// Author		        : Murilo Beltrame
// Creation Date 	    : 22/08/2014
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
	#region classe base CalculoRebateProporcionalSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a CalculoRebateProporcionalSicDAO
	/// </summary>
	internal partial class CalculoRebateProporcionalSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public CalculoRebateProporcionalSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NrSeqCalculoProporcionalRebateSic = "NR_SEQ_CALCULO_PROPORCIONAL_REBATE_SIC";
		private const string C_NrSeqCalculoRebateSic = "NR_SEQ_CALCULO_REBATE_SIC";
		private const string C_NrSeqClienteSic = "NR_SEQ_CLIENTE_SIC";
		private const string C_NrIbmClienteSic = "NR_IBM_CLIENTE_SIC";
		private const string C_VlProporcaoSic = "VL_PROPORCAO_SIC";
		private const string C_VlValorBonificacaoProporcionalSic = "VL_VALOR_BONIFICACAO_PROPORCIONAL_SIC";
		private const string C_VlVolumeCalculadoSic = "VL_VOLUME_CALCULADO_SIC";
		#endregion  Constantes de TbCalculoRebateProporcionalSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO TB_CALCULO_REBATE_PROPORCIONAL_SIC")
		.Append("(")
		.Append("NR_SEQ_CALCULO_REBATE_SIC,NR_SEQ_CLIENTE_SIC,NR_IBM_CLIENTE_SIC,VL_PROPORCAO_SIC,VL_VALOR_BONIFICACAO_PROPORCIONAL_SIC,VL_VOLUME_CALCULADO_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(", ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(", ")
		.Append("@" + C_NrIbmClienteSic)
		.Append(", ")
		.Append("@" + C_VlProporcaoSic)
		.Append(", ")
		.Append("@" + C_VlValorBonificacaoProporcionalSic)
		.Append(", ")
		.Append("@" + C_VlVolumeCalculadoSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE TB_CALCULO_REBATE_PROPORCIONAL_SIC SET")
		.Append(" NR_SEQ_CALCULO_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoRebateSic)
		.Append(",NR_SEQ_CLIENTE_SIC = ")
		.Append("@" + C_NrSeqClienteSic)
		.Append(",NR_IBM_CLIENTE_SIC = ")
		.Append("@" + C_NrIbmClienteSic)
		.Append(",VL_PROPORCAO_SIC = ")
		.Append("@" + C_VlProporcaoSic)
		.Append(",VL_VALOR_BONIFICACAO_PROPORCIONAL_SIC = ")
		.Append("@" + C_VlValorBonificacaoProporcionalSic)
		.Append(",VL_VOLUME_CALCULADO_SIC = ")
		.Append("@" + C_VlVolumeCalculadoSic)
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_PROPORCIONAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoProporcionalRebateSic)
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM TB_CALCULO_REBATE_PROPORCIONAL_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_PROPORCIONAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoProporcionalRebateSic)
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
		private string queryVerificaSeExiste = new StringBuilder().Append("SELECT COUNT(1) FROM TB_CALCULO_REBATE_PROPORCIONAL_SIC")
		.Append(" WHERE")
		.Append(" NR_SEQ_CALCULO_PROPORCIONAL_REBATE_SIC = ")
		.Append("@" + C_NrSeqCalculoProporcionalRebateSic)
		.Append("").ToString();
		#endregion Query Verifica se existe
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Incluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(calculoRebateProporcionalSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic, DatabaseManager databaseManager)
		{
			string query = queryIncluir + ";" + queryRetornaSequencia;
			if (calculoRebateProporcionalSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateProporcionalSic)));
			else
				calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic = Convert.ToInt32(databaseManager.GetScalar(query, CriarParametrosIncluir(databaseManager, calculoRebateProporcionalSic), databaseManager.Transaction));
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Atualizar(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(calculoRebateProporcionalSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar CalculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(CalculoRebateProporcionalSic calculoRebateProporcionalSic, DatabaseManager databaseManager)
		{
			if (calculoRebateProporcionalSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateProporcionalSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, calculoRebateProporcionalSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui calculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		public void Excluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(calculoRebateProporcionalSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui calculoRebateProporcionalSic
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(CalculoRebateProporcionalSic calculoRebateProporcionalSic, DatabaseManager databaseManager)
		{
			if (calculoRebateProporcionalSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateProporcionalSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, calculoRebateProporcionalSic), databaseManager.Transaction);
			}
		}
		#endregion Excluir
		#endregion Metodos Publicos
		
		#region Metodos Privados
		#region Metodos Gerais
		
		#region Verificar se Existe CalculoRebateProporcionalSic
		/// <summary>
		/// Verifica se o registro já existe
		/// </summary>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <returns>Se existe ou não</returns>
		protected bool VerificarSeExiste(CalculoRebateProporcionalSic calculoRebateProporcionalSic, DatabaseManager databaseManager)
		{
			if (calculoRebateProporcionalSic == null) throw (new ArgumentNullException());
			int count;
			if (databaseManager.Transaction == null)
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateProporcionalSic)).ToString());
			}
			else
			{
				count = int.Parse(databaseManager.GetScalar(queryVerificaSeExiste, CriarParametrosPK(databaseManager, calculoRebateProporcionalSic), databaseManager.Transaction).ToString());
			}
			return (count > 0);
		}
		#endregion Verificar se Existe CalculoRebateProporcionalSic
		#endregion Metodos Gerais
		
		#region Criar Parametros
		#region Criar Parametros PK
		/// <summary>
		/// Cria Parametros da chave primaria
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoProporcionalRebateSic, calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic, false));
			return dbParams;
		}
		#endregion Criar Parametros PK 
		
		#region Criar Parametros Incluir
		/// <summary>
		/// Cria Parametros Incluir
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateProporcionalSic.NrSeqCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, calculoRebateProporcionalSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, calculoRebateProporcionalSic.NrIbmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlProporcaoSic, calculoRebateProporcionalSic.VlProporcaoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlValorBonificacaoProporcionalSic, calculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCalculadoSic, calculoRebateProporcionalSic.VlVolumeCalculadoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="calculoRebateProporcionalSic">Instance of <see cref="CalculoRebateProporcionalSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, CalculoRebateProporcionalSic calculoRebateProporcionalSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoProporcionalRebateSic, calculoRebateProporcionalSic.NrSeqCalculoProporcionalRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqCalculoRebateSic, calculoRebateProporcionalSic.NrSeqCalculoRebateSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Int32, C_NrSeqClienteSic, calculoRebateProporcionalSic.NrSeqClienteSic, false));
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NrIbmClienteSic, calculoRebateProporcionalSic.NrIbmClienteSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlProporcaoSic, calculoRebateProporcionalSic.VlProporcaoSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlValorBonificacaoProporcionalSic, calculoRebateProporcionalSic.VlValorBonificacaoProporcionalSic, true));
			dbParams.Add(databaseManager.CreateInParameter(DbType.Decimal, C_VlVolumeCalculadoSic, calculoRebateProporcionalSic.VlVolumeCalculadoSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

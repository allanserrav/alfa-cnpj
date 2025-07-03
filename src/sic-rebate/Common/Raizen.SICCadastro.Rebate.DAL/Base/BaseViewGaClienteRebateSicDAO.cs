#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseViewGaClienteRebateSicDAO.cs
// Class Name	        : ViewGaClienteRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage / Romildo Cruz
// Creation Date 	    : 24/01/2013
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
	#region classe base ViewGaClienteRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ViewGaClienteRebateSicDAO
	/// </summary>
	internal partial class ViewGaClienteRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ViewGaClienteRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NmGalojaClienteSic = "NM_GALOJA_CLIENTE_SIC";
		#endregion  Constantes de TbViewGaClienteRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO View_GA_Cliente_Rebate_SIC")
		.Append("(")
		.Append("NM_GALOJA_CLIENTE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE View_GA_Cliente_Rebate_SIC SET")
		.Append(" NM_GALOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGalojaClienteSic)
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM View_GA_Cliente_Rebate_SIC")
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Excluir
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Incluir(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(viewGaClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ViewGaClienteRebateSic viewGaClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGaClienteRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewGaClienteRebateSic));
			else
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewGaClienteRebateSic), databaseManager.Transaction);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Atualizar(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(viewGaClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ViewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ViewGaClienteRebateSic viewGaClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGaClienteRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewGaClienteRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewGaClienteRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		public void Excluir(ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(viewGaClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui viewGaClienteRebateSic
		/// </summary>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ViewGaClienteRebateSic viewGaClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGaClienteRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewGaClienteRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewGaClienteRebateSic), databaseManager.Transaction);
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
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ViewGaClienteRebateSic viewGaClienteRebateSic)
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
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, viewGaClienteRebateSic.NmGalojaClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewGaClienteRebateSic">Instance of <see cref="ViewGaClienteRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ViewGaClienteRebateSic viewGaClienteRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGalojaClienteSic, viewGaClienteRebateSic.NmGalojaClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

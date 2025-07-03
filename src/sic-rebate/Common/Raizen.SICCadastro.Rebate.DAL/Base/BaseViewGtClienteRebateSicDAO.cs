#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : BaseViewGtClienteRebateSicDAO.cs
// Class Name	        : ViewGtClienteRebateSicDAO
// Author		        : Leandro A. Morelato / Paulo Gerage
// Creation Date 	    : 08/02/2013
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
	#region classe base ViewGtClienteRebateSicDAO
	/// <summary>
	/// Representa funcionalidade relacionada a ViewGtClienteRebateSicDAO
	/// </summary>
	internal partial class ViewGtClienteRebateSicDAO
	{
		#region Construtores
		/// <summary>
		/// Construtor Default 
		/// </summary>
		public ViewGtClienteRebateSicDAO()
		{
		}
		#endregion Construtor Default
		
		#region Constantes
		private const string C_NmGtlojaClienteSic = "NM_GTLOJA_CLIENTE_SIC";
		#endregion  Constantes de TbViewGtClienteRebateSic
		
		#region Queries
		#region Query Incluir
		/// <summary>
		/// String com a query para inclusão
		/// </summary>
		private string queryIncluir = new StringBuilder().Append("INSERT INTO VIEW_GT_CLIENTE_REBATE_SIC")
		.Append("(")
		.Append("NM_GTLOJA_CLIENTE_SIC")
		.Append(")")
		.Append(" VALUES ")
		.Append("(")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(")")
		.Append("").ToString();
		#endregion Query Incluir
		
		#region Query Atualizar
		/// <summary>
		/// String com a query para atualizar
		/// </summary>
		private string queryAtualizar = new StringBuilder().Append("UPDATE VIEW_GT_CLIENTE_REBATE_SIC SET")
		.Append(" NM_GTLOJA_CLIENTE_SIC = ")
		.Append("@" + C_NmGtlojaClienteSic)
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Atualizar
		
		#region Query Excluir
		/// <summary>
		/// String com a query excluir
		/// </summary>
		private string queryExcluir = new StringBuilder().Append("DELETE FROM VIEW_GT_CLIENTE_REBATE_SIC")
		.Append(" WHERE")
		.Append(" PK não encontrada ")
		.Append("").ToString();
		#endregion Query Excluir
		#endregion Queries
		
		#region Metodos Publicos
		#region Incluir
		/// <summary>
		/// Incluir ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Incluir(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Incluir(viewGtClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Incluir ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Incluir(ViewGtClienteRebateSic viewGtClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGtClienteRebateSic == null) throw (new ArgumentNullException());
			
			if (databaseManager.Transaction == null)
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewGtClienteRebateSic));
			else
				databaseManager.ExecuteCommand(queryIncluir, CriarParametrosIncluir(databaseManager, viewGtClienteRebateSic), databaseManager.Transaction);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualiza ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Atualizar(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Atualizar(viewGtClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Atualizar ViewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Atualizar(ViewGtClienteRebateSic viewGtClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGtClienteRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewGtClienteRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryAtualizar, CriarParametrosAtualizar(databaseManager, viewGtClienteRebateSic), databaseManager.Transaction);
			}
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Exclui viewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		public void Excluir(ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			using (DatabaseManager databaseManager = new DatabaseManager("SICCadastro"))
			{
				try
				{
					Excluir(viewGtClienteRebateSic, databaseManager);
				}
				finally
				{
					databaseManager.CloseConnection();
				}
			}
		}
		
		/// <summary>
		/// Exclui viewGtClienteRebateSic
		/// </summary>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		internal void Excluir(ViewGtClienteRebateSic viewGtClienteRebateSic, DatabaseManager databaseManager)
		{
			if (viewGtClienteRebateSic == null) throw (new ArgumentNullException());
			if (databaseManager.Transaction == null)
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewGtClienteRebateSic));
			}
			else
			{
				databaseManager.ExecuteCommand(queryExcluir, CriarParametrosPK(databaseManager, viewGtClienteRebateSic), databaseManager.Transaction);
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
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		protected IList<DbParameter> CriarParametrosPK(DatabaseManager databaseManager, ViewGtClienteRebateSic viewGtClienteRebateSic)
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
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <returns>Lista de DbParameter</returns>
		private IList<DbParameter> CriarParametrosIncluir(DatabaseManager databaseManager, ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, viewGtClienteRebateSic.NmGtlojaClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Incluir
		
		#region Criar Parametros Atualizar
		/// <summary>
		/// Cria Parametros Atualizar
		/// </summary>
		/// <param name="databaseManager">Instance of <see cref="DatabaseManager"/></param>
		/// <param name="viewGtClienteRebateSic">Instance of <see cref="ViewGtClienteRebateSic"/></param>
		/// <returns>Collection of DbParameter</returns>
		private IList<DbParameter> CriarParametrosAtualizar(DatabaseManager databaseManager, ViewGtClienteRebateSic viewGtClienteRebateSic)
		{
			List<DbParameter> dbParams = new List<DbParameter>();
			dbParams.Add(databaseManager.CreateInParameter(DbType.String, C_NmGtlojaClienteSic, viewGtClienteRebateSic.NmGtlojaClienteSic, true));
			return dbParams;
		}
		#endregion Criar Parametros Atualizar
		#endregion Criar Parametros
		#endregion Metodos Privados
	}
	#endregion 
}

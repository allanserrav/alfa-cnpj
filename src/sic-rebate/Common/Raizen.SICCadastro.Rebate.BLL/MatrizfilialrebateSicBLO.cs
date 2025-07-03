#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : MatrizfilialrebateSicBLO.cs
// Class Name	        : MatrizfilialrebateSicBLO
// Author		        : Murilo Beltrame
// Creation Date 	    : 07/29/2014
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
#endregion Cabeçalho do Arquivo

#region Namespaces
using System;
using System.Collections.Generic;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  MatrizfilialrebateSicBLO
	/// </summary>
	internal class MatrizfilialrebateSicBLO : IMatrizfilialrebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de MatrizfilialrebateSicDAO 
		/// </summary>
		private readonly IMatrizfilialrebateSicDAO matrizfilialrebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public MatrizfilialrebateSicBLO()
		{
			this.matrizfilialrebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IMatrizfilialrebateSicDAO>("MatrizfilialrebateSicDAO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		public IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic, int numeroLinhas, string ordem)
		{
			return this.matrizfilialrebateSicDAO.Selecionar(matrizfilialrebateSic, numeroLinhas, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		public IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic, string ordem)
		{
			return this.Selecionar(matrizfilialrebateSic, 0, ordem);
		}
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		public IList<MatrizfilialrebateSic> Selecionar(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			return this.Selecionar(matrizfilialrebateSic, 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar os dados de MatrizfilialrebateSic
		/// </summary>
		/// <returns>Retorna lista de MatrizfilialrebateSic</returns>
		public IList<MatrizfilialrebateSic> Selecionar()
		{
			return this.Selecionar(new MatrizfilialrebateSic(), 0, String.Empty);
		}
		
		/// <summary>
		/// Selecionar o primeiro registro referente aos dados de MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instância de <see cref="MatrizfilialrebateSic"/> para filtrar os dados</param>
		/// <returns>Retorna uma instância de MatrizfilialrebateSic</returns>
		public MatrizfilialrebateSic SelecionarPrimeiro(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			IList<MatrizfilialrebateSic> lista = this.Selecionar(matrizfilialrebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new MatrizfilialrebateSic();
		}
		#endregion Selecionar
		
		#region Incluir
		/// <summary>
		/// Incluir MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Incluir(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			if (null == matrizfilialrebateSic) throw (new ArgumentNullException());
			this.matrizfilialrebateSicDAO.Incluir(matrizfilialrebateSic);
		}
		#endregion Incluir
		
		#region Atualizar
		/// <summary>
		/// Atualizar MatrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Atualizar(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			if (null == matrizfilialrebateSic) throw (new ArgumentNullException());
			this.matrizfilialrebateSicDAO.Atualizar(matrizfilialrebateSic);
		}
		#endregion Atualizar
		
		#region Excluir
		/// <summary>
		/// Excluir matrizfilialrebateSic
		/// </summary>
		/// <param name="matrizfilialrebateSic">Instance of <see cref="MatrizfilialrebateSic"/></param>
		public void Excluir(MatrizfilialrebateSic matrizfilialrebateSic)
		{
			if (null == matrizfilialrebateSic) throw (new ArgumentNullException());
			this.matrizfilialrebateSicDAO.Excluir(matrizfilialrebateSic);
		}
		#endregion Excluir
		
		#endregion Public Methods
	}
}


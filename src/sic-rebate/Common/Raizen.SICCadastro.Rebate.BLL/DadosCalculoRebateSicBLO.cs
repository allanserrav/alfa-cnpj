#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : DadosCalculoRebateSicBLO.cs
// Class Name	        : DadosCalculoRebateSicBLO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 27/01/2020
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
	/// Representa funcionalidade relacionada a  CalculoRebateSicBLO
	/// </summary>
	internal partial class DadosCalculoRebateSicBLO : IDadosCalculoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CalculoRebateSicDAO 
		/// </summary>
		private readonly IDadosCalculoRebateSicDAO dadosCalculoRebateSicDAO = null;
		#endregion Private Variables
		
		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public DadosCalculoRebateSicBLO()
		{
			this.dadosCalculoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IDadosCalculoRebateSicDAO>("DadosCalculoRebateSicDAO");
		}
		#endregion Construtor

		#region Metodos Publicos

		#region Selecionar
		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <param name="numeroLinhas"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, int numeroLinhas, string ordem)
		{
			return this.dadosCalculoRebateSicDAO.Selecionar(dadosCalculoRebateSic, numeroLinhas, ordem);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <param name="ordem"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic, string ordem)
		{
			return this.Selecionar(dadosCalculoRebateSic, 0, ordem);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <returns></returns>
		public IList<DadosCalculoRebateSic> Selecionar(DadosCalculoRebateSic dadosCalculoRebateSic)
		{
			return this.Selecionar(dadosCalculoRebateSic, 0, String.Empty);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <returns></returns>
		public IList<DadosCalculoRebateSic> Selecionar()
		{
			return this.Selecionar(new DadosCalculoRebateSic(), 0, String.Empty);
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <returns></returns>
		public DadosCalculoRebateSic SelecionarPrimeiro(DadosCalculoRebateSic dadosCalculoRebateSic)
		{
			IList<DadosCalculoRebateSic> lista = this.Selecionar(dadosCalculoRebateSic, 1, String.Empty);
			if (lista.Count > 0)
				return lista[0];
			else
				return new DadosCalculoRebateSic();
		}

		/// <summary>
		/// Selecionar DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		/// <returns></returns>
		public DadosCalculoRebateSic SelecionarUltimo(DadosCalculoRebateSic dadosCalculoRebateSic)
		{
			IList<DadosCalculoRebateSic> lista = this.Selecionar(dadosCalculoRebateSic, 1, "TB_DADOS_CALCULO_REBATE_SIC.NR_SEQ_DADOS_CALCULO_REBATE_SIC DESC");
			if (lista.Count > 0)
				return lista[0];
			else
				return new DadosCalculoRebateSic();
		}

		#endregion Selecionar

		#region Incluir
		/// <summary>
		/// Incluir DadosCalculoRebateSic
		/// </summary>
		/// <param name="dadosCalculoRebateSic"></param>
		public void Incluir(DadosCalculoRebateSic dadosCalculoRebateSic)
		{
			if (null == dadosCalculoRebateSic) throw (new ArgumentNullException());
			this.dadosCalculoRebateSicDAO.Incluir(dadosCalculoRebateSic);
		}
		#endregion Incluir
		
		#endregion Public Methods
	}
}
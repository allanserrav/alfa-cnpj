#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : AcertoCalculoRebateSicBLO.cs
// Class Name	        : AcertoCalculoRebateSicBLO
// Author		        : João Rodolfo Cunha
// Creation Date 	    : 23/01/2020
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
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Model;
using System;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
	/// <summary>
	/// Representa funcionalidade relacionada a  CalculoRebateSicBLO
	/// </summary>
	internal partial class AcertoCalculoRebateSicBLO : IAcertoCalculoRebateSicBLO
	{
		#region Variaveis Privadas
		/// <summary>
		/// Instancia de CalculoRebateSicDAO 
		/// </summary>
		private IAcertoCalculoRebateSicDAO acertoCalculoRebateSicDAO = null;

		/// <summary>
		/// Instancia de ClienteSicBLO
		/// </summary>
		private readonly IClienteSicBLO clienteSicBLO = null;

		/// <summary>
		/// Instancia de RebateSicBLO 
		/// </summary>
		private readonly IRebateSicBLO rebateSicBLO = null;

		/// <summary>
		/// Retorna Instancia de RebateSicBLO
		/// </summary>
		private IRebateSicBLO RebateSicBLOService { get; set; }

		/// <summary>
		/// Retorna Instancia de CalculoRebateSicDAO
		/// </summary>
		private ICalculoBonificacaoRebateBLO CalculoBonificacaoRebateBLO = null;

		#endregion Private Variables

		#region Construtor
		///<summary>
		///Construtor Default
		///</summary>
		public AcertoCalculoRebateSicBLO()
		{
			this.acertoCalculoRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IAcertoCalculoRebateSicDAO>("AcertoCalculoRebateSicDAO");
			this.clienteSicBLO = Factory.CreateFactoryInstance().CreateInstance<IClienteSicBLO>("ClienteSicBLO");
			this.rebateSicBLO = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
			this.CalculoBonificacaoRebateBLO = Factory.CreateFactoryInstance().CreateInstance<CalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
		}
		#endregion Construtor
		
		#region Metodos Publicos
		
		#region Selecionar
		/// <summary>
		/// Selecionar os dados de CalculoRebateSic
		/// </summary>
		/// <param name="calculoRebateSic">Instância de <see cref="CalculoRebateSic"/> para filtrar os dados</param>
		/// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
		/// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
		/// <returns>Retorna lista de CalculoRebateSic</returns>
		public IList<AcertoCalculoRebateSic> Selecionar(string ibm)
		{
			this.RebateSicBLOService = Factory.CreateFactoryInstance().CreateInstance<IRebateSicBLO>("RebateSicBLO");
			this.CalculoBonificacaoRebateBLO = Factory.CreateFactoryInstance().CreateInstance<ICalculoBonificacaoRebateBLO>("CalculoBonificacaoRebateBLO");
			RebateSic rebateSic = RebateSicBLOService.SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibm });
			return this.CalculoBonificacaoRebateBLO.CalcularAcerto(rebateSic,"","");
		}
		#endregion Selecionar

		#region PesquisarPorIBM
		/// <summary>
		/// Método PesquisarPorIBM
		/// </summary>		
		/// <returns></returns>
		public List<AcertoCalculoRebateSic> PesquisarPorIBM(ClienteSic cli)
		{
			if (String.IsNullOrEmpty(cli.NrIbmClienteSic))
				throw new Exception("IBM inválido.");
			
			var aux = clienteSicBLO.SelecionarPrimeiro(cli);
			cli.NmRazsociallojaFranquiaSic = aux.NmRazsociallojaFranquiaSic;

			//1. Pesquisar se IBM é válido
			bool isIBMvalido = !String.IsNullOrEmpty(cli.NmRazsociallojaFranquiaSic);
			if (!isIBMvalido)
				throw new Exception("IBM não encontrado.");

			//2. Verifica se IBM tem rebate
			var rsic = new RebateSic();
			rsic.NrIbmRebateSic = Int32.Parse(cli.NrIbmClienteSic).ToString();
			var rebate = rebateSicBLO.Selecionar(rsic);
			bool find = false;
			foreach (var r in rebate)
			{
				if (r.NrIbmRebateSic == cli.NrIbmClienteSic)
					find = true;
			}
			if (!find)
				throw new Exception("IBM não encontrado.");

			return this.Calcular(cli.NrIbmClienteSic);
		}
		#endregion

		/// <summary>
		/// LancarAjustes
		/// </summary>
		/// <param name="list"></param>
		public void LancarAjustes(List<AcertoCalculoRebateSic> list)
		{
			this.CalculoBonificacaoRebateBLO.LancarAcertos(list);
		}

		/// <summary>
		/// Método Calcular
		/// </summary>
		/// <returns></returns>
		private List<AcertoCalculoRebateSic> Calcular(string ibm)
		{
			List<AcertoCalculoRebateSic> list = new List<AcertoCalculoRebateSic>();
			list = this.CalculoBonificacaoRebateBLO.CalcularAcerto(this.rebateSicBLO.SelecionarPrimeiro(new RebateSic { NrIbmRebateSic = ibm }));
			return list;
		}

		#region InjecaoDao
		/// <summary>
		/// InjecaoDao utilizado para classe de testes
		/// </summary>
		/// <param name="dao"></param>
		public void InjecaoDao(IAcertoCalculoRebateSicDAO dao)
		{
			this.acertoCalculoRebateSicDAO = dao;
		}
		#endregion

		#endregion Public Methods
	}
}
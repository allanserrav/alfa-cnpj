#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : LogIntegracaoSicBLO.cs
// Class Name	        : LogIntegracaoSicBLO
// Author		        : Leandro Oliveira
// Creation Date 	    : 02/12/2024
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
    /// Representa funcionalidade relacionada a  LogIntegracaoSicBLO
    /// </summary>
    internal class LogIntegracaoSicBLO : ILogIntegracaoSicBLO
    {
        #region Variaveis Privadas
        /// <summary>
        /// Instancia de LogIntegracaoSicDAO 
        /// </summary>
        private readonly ILogIntegracaoSicDAO logIntegracaoSicDAO = null;
        #endregion Private Variables

        #region Construtor
        ///<summary>
        ///Construtor Default
        ///</summary>
        public LogIntegracaoSicBLO()
        {
            this.logIntegracaoSicDAO = Factory.CreateFactoryInstance().CreateInstance<ILogIntegracaoSicDAO>("LogIntegracaoSicDAO");
        }
        #endregion Construtor

        #region Metodos Publicos

        #region Selecionar
        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic, int numeroLinhas, string ordem)
        {
            return this.logIntegracaoSicDAO.Selecionar(logIntegracaoSic, numeroLinhas, ordem);
        }

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="FiltroLogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> SelecionarFiltro(FiltroLogIntegracaoSic logIntegracaoSic, int numeroLinhas, string ordem)
        {
            return this.logIntegracaoSicDAO.SelecionarFiltro(logIntegracaoSic, numeroLinhas, ordem);
        }

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="FiltroLogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> SelecionarFiltro(FiltroLogIntegracaoSic logIntegracaoSic)
        {
            return this.logIntegracaoSicDAO.SelecionarFiltro(logIntegracaoSic, 0, String.Empty);
        }

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic, string ordem)
        {
            return this.Selecionar(logIntegracaoSic, 0, ordem);
        }

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic)
        {
            return this.Selecionar(logIntegracaoSic, 0, String.Empty);
        }

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        public IList<LogIntegracaoSic> Selecionar()
        {
            return this.Selecionar(new LogIntegracaoSic(), 0, String.Empty);
        }

        /// <summary>
        /// Selecionar o primeiro registro referente aos dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <returns>Retorna uma instância de LogIntegracaoSic</returns>
        public LogIntegracaoSic SelecionarPrimeiro(LogIntegracaoSic logIntegracaoSic)
        {
            IList<LogIntegracaoSic> lista = this.Selecionar(logIntegracaoSic, 1, String.Empty);
            if (lista.Count > 0)
                return lista[0];
            else
                return new LogIntegracaoSic();
        }
        #endregion Selecionar

        #region Incluir
        /// <summary>
        /// Incluir LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Incluir(LogIntegracaoSic logIntegracaoSic)
        {
            if (null == logIntegracaoSic) throw (new ArgumentNullException());
            this.logIntegracaoSicDAO.Incluir(logIntegracaoSic);
        }


        /// <summary>
        /// Incluir LogIntegracaoSic
        /// </summary>
        /// <param name="pagina">Instância de <see cref="string"/> para gravar os dados</param>
        /// <param name="metodo">Instância de <see cref="string"/> para gravar os dados</param>
        /// <param name="descricao">Instância de <see cref="string"/> para gravar os dados</param>
        /// <param name="usuario">Instância de <see cref="string"/> para gravar os dados</param>
        public void IncluirLogDescricao(string pagina, string metodo, string descricao, string usuario)
        {
            LogIntegracaoSic logIntegracaoSic = new LogIntegracaoSic();

            logIntegracaoSic.NmPaginaSic = pagina;
            logIntegracaoSic.NmMetodoSic = metodo;
            logIntegracaoSic.DsAcaoSic = descricao;
            logIntegracaoSic.NmUsuarioSic = usuario;
            logIntegracaoSic.DtAcaoSic = DateTime.Now;

           this.logIntegracaoSicDAO.Incluir(logIntegracaoSic);
        }


        #endregion Incluir

        #region Atualizar
        /// <summary>
        /// Atualizar LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Atualizar(LogIntegracaoSic logIntegracaoSic)
        {
            if (null == logIntegracaoSic) throw (new ArgumentNullException());
            this.logIntegracaoSicDAO.Atualizar(logIntegracaoSic);
        }
        #endregion Atualizar

        #region Excluir
        /// <summary>
        /// Excluir logIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        public void Excluir(LogIntegracaoSic logIntegracaoSic)
        {
            if (null == logIntegracaoSic) throw (new ArgumentNullException());
            this.logIntegracaoSicDAO.Excluir(logIntegracaoSic);
        }
        #endregion Excluir

        #endregion Public Methodsf
    }
}


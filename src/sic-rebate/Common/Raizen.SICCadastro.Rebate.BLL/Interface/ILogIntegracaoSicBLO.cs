#region Cabeçalho do Arquivo
// <Summary>
// File Name		    : ILogIntegracaoSicBLO.cs
// Class Name	        : ILogIntegracaoSicBLO
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
#endregion

#region Namespaces
using System;
using Raizen.SICCadastro.Rebate.Model;
using Raizen.SICCadastro.Rebate.DAL;
using System.Collections.Generic;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Representa funcionalidade relacionada a ILogIntegracaoSicBLO
    /// </summary>
    public interface ILogIntegracaoSicBLO
    {
        #region Metodos de ILogIntegracaoSicBLO 

        #region Selecionar
        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="numeroLinhas">Número de linhas para ser trazidos ou 0 para todos.</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic, int numeroLinhas, string ordem);

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <param name="ordem">Ordem dos dados retornados ou branco/nulo para ordem padrão</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic, string ordem);

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        IList<LogIntegracaoSic> Selecionar(LogIntegracaoSic logIntegracaoSic);

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        IList<LogIntegracaoSic> Selecionar();

        /// <summary>
        /// Selecionar os dados de LogIntegracaoSic
        /// </summary>
        /// <returns>Retorna lista de LogIntegracaoSic</returns>
        IList<LogIntegracaoSic> SelecionarFiltro(FiltroLogIntegracaoSic logIntegracaoSic);

        /// <summary>
        /// Selecionar o primeiro registro referente aos dados de LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instância de <see cref="LogIntegracaoSic"/> para filtrar os dados</param>
        /// <returns>Retorna uma instância de LogIntegracaoSic</returns>
        LogIntegracaoSic SelecionarPrimeiro(LogIntegracaoSic logIntegracaoSic);
        #endregion Selecionar

        #region Incluir
        /// <summary>
        /// Incluir LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        void Incluir(LogIntegracaoSic logIntegracaoSic);

        void IncluirLogDescricao(string pagina, string metodo, string descricao, string usuario);

        #endregion Incluir

        #region Atualizar
        /// <summary>
        /// Atualiza LogIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        void Atualizar(LogIntegracaoSic logIntegracaoSic);
        #endregion Atualizar

        #region Excluir
        /// <summary>
        /// Exclui logIntegracaoSic
        /// </summary>
        /// <param name="logIntegracaoSic">Instance of <see cref="LogIntegracaoSic"/></param>
        void Excluir(LogIntegracaoSic logIntegracaoSic);
        #endregion Excluir

        #endregion ILogIntegracaoSicBLO
    }
}

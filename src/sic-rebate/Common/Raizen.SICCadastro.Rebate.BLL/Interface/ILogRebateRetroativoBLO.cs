#region Cabeçalho do Arquivo
// <Summary>
// File Name            : ILogRebateRetroativoBLO.cs
// Class Name           : ILogRebateRetroativoBLO
// Author               : Raphael Simões Andrade
// Creation Date        : 17/12/2024
// </Summary>

// <RevisionHistory>
// <SNo value=1>
//  Modified By             : 
//  Date of Modification    : 
//  Reason for modification : 
//  Modification Done       : 
//  Defect Id (If any)      : 
// <SNo>
// </RevisionHistory>
#endregion

#region Namespaces
using System;
using System.Collections.Generic;
using Raizen.SICCadastro.Rebate.Model;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Interface de camada de negócio para LogRebateRetroativo
    /// </summary>
    public interface ILogRebateRetroativoBLO
    {
        #region Métodos Selecionar

        IList<LogRebateRetroativo> SelecionarContratosRebates(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem);

        IList<LogRebateRetroativo> SelecionarContratosRebatesGuardaChuva(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem);

        IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, int numeroLinhas, string ordem);

        IList<LogRebateRetroativo> SelecionarLog(LogRebateRetroativoFiltro log, int numeroLinhas, string ordem);

        int? SelecionarNumeroContratoGuardaChuva(int? nrSeqClienteSic, int numeroLinhas, string ordem); 

        IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, string ordem);

        IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log);

        IList<LogRebateRetroativo> Selecionar();

        LogRebateRetroativo SelecionarPrimeiro(LogRebateRetroativo log);

        /// <summary>
        /// Seleciona os logs de cálculo retroativo de um usuário específico na mesma data/hora.
        /// </summary>
        /// <param name="usuario">Usuário responsável pelo cálculo.</param>
        /// <param name="dataInicio">Data/hora de início do cálculo.</param>
        /// <returns>Lista de logs filtrados.</returns>
        IList<LogRebateRetroativo> SelecionarPorUsuarioEData(string usuario, DateTime dataInicio);

        IList<LogRebateRetroativo> SelecionarPorId(int nrSeqEntidadeRebateRetroativo);


        #endregion

        #region Métodos Incluir

        void Incluir(LogRebateRetroativo log);

        #endregion

        #region Métodos Atualizar

        void Atualizar(LogRebateRetroativo log);

        #endregion

        #region Métodos Excluir

        void Excluir(LogRebateRetroativo log);

        #endregion
    }
}

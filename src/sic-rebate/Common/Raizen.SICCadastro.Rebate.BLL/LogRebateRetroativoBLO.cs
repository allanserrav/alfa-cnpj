#region Cabeçalho do Arquivo
// <Summary>
// File Name            : LogRebateRetroativoBLO.cs
// Class Name           : LogRebateRetroativoBLO
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
using Raizen.SICCadastro.Rebate.DAL;
using COSAN.Framework.Factory;
using System.Data.Common;
using System.Data;
#endregion Namespaces

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Implementação de camada de negócio para LogRebateRetroativo
    /// </summary>
    public class LogRebateRetroativoBLO : ILogRebateRetroativoBLO
    {
        #region Variáveis Privadas
        private readonly ILogRebateRetroativoDAO logRebateRetroativoDAO = null;
        #endregion

        #region Construtor
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public LogRebateRetroativoBLO()
        {
            this.logRebateRetroativoDAO = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoDAO>("LogRebateRetroativoDAO");
        }
        #endregion

        #region Métodos Públicos

        #region Selecionar

        public IList<LogRebateRetroativo> SelecionarContratosRebates(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem)
        {
            return this.logRebateRetroativoDAO.SelecionarContratosRebates(log, ids, numeroLinhas, ordem);
        }

        public IList<LogRebateRetroativo> SelecionarContratosRebatesGuardaChuva(LogRebateRetroativoFiltro log, string ids, int numeroLinhas, string ordem)
        {
            return this.logRebateRetroativoDAO.SelecionarContratosRebatesGuardaChuva(log, ids, numeroLinhas, ordem);
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, int numeroLinhas, string ordem)
        {
            return this.logRebateRetroativoDAO.Selecionar(log, numeroLinhas, ordem);
        }

        public IList<LogRebateRetroativo> SelecionarLog(LogRebateRetroativoFiltro log, int numeroLinhas, string ordem)
        {
            return this.logRebateRetroativoDAO.SelecionarLog(log, numeroLinhas, ordem);
        }

        public int? SelecionarNumeroContratoGuardaChuva(int? nrSeqClienteSic, int numeroLinhas, string ordem)
        {
            return this.logRebateRetroativoDAO.SelecionarNumeroContratoGuardaChuva(nrSeqClienteSic, numeroLinhas, ordem);
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log, string ordem)
        {
            return this.Selecionar(log, 0, ordem);
        }

        public IList<LogRebateRetroativo> Selecionar(LogRebateRetroativo log)
        {
            return this.Selecionar(log, 0, string.Empty);
        }

        public IList<LogRebateRetroativo> Selecionar()
        {
            return this.logRebateRetroativoDAO.Selecionar();
        }

        public LogRebateRetroativo SelecionarPrimeiro(LogRebateRetroativo log)
        {
            IList<LogRebateRetroativo> lista = this.Selecionar(log, 1, string.Empty);
            return lista.Count > 0 ? lista[0] : new LogRebateRetroativo();
        }

        /// <summary>
        /// Seleciona os logs de cálculo retroativo de um usuário específico na mesma data/hora.
        /// </summary>
        /// <param name="usuario">Usuário responsável pelo cálculo.</param>
        /// <param name="dataInicio">Data/hora de início do cálculo.</param>
        /// <returns>Lista de logs filtrados.</returns>
        public IList<LogRebateRetroativo> SelecionarPorUsuarioEData(string usuario, DateTime dataInicio)
        {
            try
            {
                var logDAO = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoDAO>("LogRebateRetroativoDAO");
                var filtro = new LogRebateRetroativo
                {
                    CdLogUsuarioRebateRetroativo = usuario,
                    DtLogDatetimeRebateRetroativo = dataInicio
                };

                // Busca todos os registros com filtro de usuário e data/hora
                return logDAO.Selecionar(filtro);
            }
            catch (Exception ex)
            {
                var logDAO = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoDAO>("LogRebateRetroativoDAO");
                return logDAO.SelecionarPorUsuarioEData(usuario, dataInicio);
            }
        }

        /// <summary>
        /// Seleciona os logs de cálculo retroativo de um usuário específico na mesma data/hora.
        /// </summary>
        /// <param name="usuario">Usuário responsável pelo cálculo.</param>
        /// <param name="dataInicio">Data/hora de início do cálculo.</param>
        /// <returns>Lista de logs filtrados.</returns>
        public IList<LogRebateRetroativo> SelecionarPorId(int nrSeqEntidadeRebateRetroativo)
        {
            try
            {
                var logDAO = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoDAO>("LogRebateRetroativoDAO");
                var filtro = new LogRebateRetroativo
                {
                    NrSeqEntidadeRebateRetroativo = nrSeqEntidadeRebateRetroativo
                };

                // Busca todos os registros com filtro de usuário e data/hora
                return logDAO.Selecionar(filtro);
            }
            catch (Exception ex)
            {
                var logDAO = Factory.CreateFactoryInstance().CreateInstance<ILogRebateRetroativoDAO>("LogRebateRetroativoDAO");
                return logDAO.SelecionarPorId(nrSeqEntidadeRebateRetroativo);
            }
        }





        #endregion

        #region Incluir

        public void Incluir(LogRebateRetroativo log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            this.logRebateRetroativoDAO.Incluir(log);
        }

        #endregion

        #region Atualizar

        public void Atualizar(LogRebateRetroativo log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            this.logRebateRetroativoDAO.Atualizar(log);
        }

        #endregion

        #region Excluir

        public void Excluir(LogRebateRetroativo log)
        {
            if (log == null) throw new ArgumentNullException(nameof(log));
            this.logRebateRetroativoDAO.Excluir(log);
        }

        #endregion

        #endregion
    }
}

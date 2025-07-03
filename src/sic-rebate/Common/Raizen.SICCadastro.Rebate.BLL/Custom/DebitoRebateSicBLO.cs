using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raizen.SICCadastro.Rebate.Model;
using COSAN.Framework.Factory;
using Raizen.SICCadastro.Rebate.DAL;
using Raizen.SICCadastro.Rebate.Util;

namespace Raizen.SICCadastro.Rebate.BLL
{
    /// <summary>
    /// Complemento de DebitoRebateSicBLO
    /// </summary>
    internal partial class DebitoRebateSicBLO
    {
        #region Variaveis Privadas
        /// <summary>
        /// Instancia de DebitoRebateSicDAO
        /// </summary>
        private IMotivoRegimeEspecialRebateSicDAO _MotivoRegimeEspecialRebateSicDAO = null;

        /// <summary>
        /// Retorna Instancia de DebitoRebateSicDAO
        /// </summary>
        private IMotivoRegimeEspecialRebateSicDAO motivoRegimeEspecialRebateSicDAOService
        {
            get
            {
                if (_MotivoRegimeEspecialRebateSicDAO == null)
                    _MotivoRegimeEspecialRebateSicDAO = Factory.CreateFactoryInstance().CreateInstance<IMotivoRegimeEspecialRebateSicDAO>("MotivoRegimeEspecialRebateSicDAO");

                return _MotivoRegimeEspecialRebateSicDAO;
            }
        }
        #endregion

        #region Metodos de IDebitoRebateSicDAO

        #region Selecionar SelecionarDebitoRbc
        /// <summary>
        /// Seleciona em lote os dados do Debito do Cliente na base RBC (Oracle)
        /// </summary>        
        /// <param name="listIBM">Lista de IBMs</param>        
        /// <returns></returns>
        public IList<DebitoRbc> SelecionarDebitoRbc(List<RebateSic> listRebateSic)
        {
            //Formata data limite
            DateTime dataConsultaAte = RebateUtil.GetDataAtual().AddDays(-1);            
            
            //Motivos exclusivos à busca
            IList<MotivoRegimeEspecialRebateSic> listMotivos = 
                this.motivoRegimeEspecialRebateSicDAOService.Selecionar(new MotivoRegimeEspecialRebateSic(), 0, null);

            //Busca os débitos
            return this.debitoRebateSicDAO.SelecionarDebitoRbc(dataConsultaAte,
                listRebateSic.Select(r => RebateUtil.FormatarIBM(r.NrCodigopagadorRebateSic)).ToList(), //alterado de NrIbmRebateSic para NrCodigopagadorRebateSic
                listMotivos.Select(m => m.CdMotivoSic).ToList());
        }
        #endregion

        #endregion
    }
}

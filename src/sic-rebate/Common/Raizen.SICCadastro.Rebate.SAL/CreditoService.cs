using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Raizen.SICCadastro.Rebate.SAL
{
    /// <summary>
    /// Classe para acesso ao webservice rede.cosan.cpsvsappid01.Credito_OutService
    /// </summary>
    public class CreditoService : wsCredito.Credito_OutService
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public CreditoService()
        {
            this.Credentials = new NetworkCredential
            {
                Password = ConfigurationManager.AppSettings["SENHA_SAP"],
                UserName = ConfigurationManager.AppSettings["USUARIO_SAP"]
            };
            this.Url = ConfigurationManager.AppSettings["URL_SAP_CREDITO"];
        }

        /// <summary>
        /// CriarRequestCreditoService
        /// </summary>
        /// <param name="ibmCliente"></param>
        /// <returns></returns>
        private wsCredito.ConsultarRequest CriarRequestCreditoService(string ibmCliente)
        {
            var request = new wsCredito.ConsultarRequest();
            request.Ambiente = "FUELS";
            request.AreaCredito = "CCAO";
            request.Cliente = ibmCliente;
            request.Data = DateTime.Today.ToString("yyyy-MM-dd");
            return request;
        }

        /// <summary>
        /// ObterIbmControlador
        /// </summary>
        /// <param name="ibm"></param>
        /// <returns></returns>
        public string ObterIbmControlador(string ibm)
        {
            var req = this.CriarRequestCreditoService(ibm);
            var ret = this.Consultar_Sync(req);
            return ret.Conta;
        }
    }
}

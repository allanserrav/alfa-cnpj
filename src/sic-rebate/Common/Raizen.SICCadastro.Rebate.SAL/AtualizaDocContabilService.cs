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
    /// Classe para acesso ao webservice wsAtualizaDocContabil.SIC_SyncOutAtualizaDocContabilService
    /// </summary>
    public class AtualizaDocContabilService : wsAtualizaDocContabil.SIC_SyncOutAtualizaDocContabilService
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public AtualizaDocContabilService()
        {
            this.Credentials = new NetworkCredential
            {
                Password = ConfigurationManager.AppSettings["SENHA_SAP"],
                UserName = ConfigurationManager.AppSettings["USUARIO_SAP"]
            };
            this.Url = ConfigurationManager.AppSettings["URL_SAP_DEBITO"];
        }

        /// <summary>
        /// IsCadeiaTemDebito
        /// </summary>
        /// <param name="ibm"></param>
        /// <returns></returns>
        public bool IsCadeiaTemDebito(string ibm)
        {
            var request = new wsAtualizaDocContabil.RequestAtualizaDocContabil();
            request.Debito = new wsAtualizaDocContabil.RequestAtualizaDocContabilDebito();
            request.Debito.NoCliente = ibm;
            request.Debito.Empresa = "CCAO";
            var resp = this.SIC_SyncOutAtualizaDocContabil(request);
#if DEBUG
            Console.WriteLine("IBM: " + ibm + " IBM CONTROLADOR: " + ibm + " Débito: " + resp.Debito.Sucesso);
#endif
            return resp.Debito.Sucesso == "X";
        }
    }
}

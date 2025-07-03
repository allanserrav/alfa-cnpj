using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Model
{
    public class MensagemControleValidacao
    {
        #region Contrutor

        public MensagemControleValidacao()
        { 
        
        }
        public MensagemControleValidacao(string clientID, string mensagem)
        {
            this.ClientID = clientID;
            this.Mensagem = mensagem;
        }

        #endregion

        #region Propriedades

        public string ClientID { get; set; }
        public string Mensagem { get; set; }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raizen.SICCadastro.Rebate.Util
{
    /// <summary>
    /// Armazena as constantes utilizadas pela aplicação
    /// </summary>
    public static class ConstantesRebate
    {
        //Tipo Rebate
        public const string TIPO_REBATE_GLOBAL_MEDIA_VOLUME = "GLOBAL MEDIA VOLUME";
        public const string TIPO_REBATE_GLOBAL_SOMA_VOLUME = "GLOBAL SOMA VOLUME";
        public const string TIPO_REBATE_FAIXA_VOLUME = "FAIXA VOLUME";
        public const string TIPO_REBATE_FAIXA_VOLUME_PERCENTUAL = "FAIXA VOLUME PERCENTUAL";
        public const string TIPO_REBATE_ESCALONADO = "ESCALONADO";

        //Status Cliente
        public const string STATUS_CLIENTE_ACEITO = "ACEITO";
        public const string STATUS_CLIENTE_CORRECAO = "CORRECAO";
        public const string STATUS_CLIENTE_ANALISE = "ANALISE";

        //Reajuste
        public const string TIPO_REAJUSTE_IGPM = "IGPM";
        public const string TIPO_REAJUSTE_MANUAL = "MANUAL";

        //Débitos
        public const decimal VALOR_MAXIMO_MONTANTE_DEBITO = 1000;
        public const int DIAS_MAXIMO_ATRASO_DEBITO = 4;

        //Contrato Rebate
        public const int DIAS_MINIMO_PERIODO_CONTRATO_REBATE_MENSAL = 30;
        public const int DIAS_MINIMO_PERIODO_CONTRATO_REBATE_TRIMESTRAL = 90;

        //Extrato Rebate
        public const string DS_EXTRATO_APTO_PAGAMENTO = "Crédito Bonificação Período {0} - Apto Pagamento";
        public const string DS_EXTRATO_PAGO = "Pagamento Bonificação Período {0}";
        public const string DS_EXTRATO_INFORMACOES_INCONSISTENTES = "Crédito Bonificação Período {0} - Informações Inconsistentes";
        public const string DS_EXTRATO_CANCELADO = "Bonificação Cancelada Período {0}";

        //Histórico Rebate
        public const string DS_HISTORICO_APTO_PAGAMENTO = "Apto Pagamento: Rebate {0}, Período {1}, Valor R${2}";
        public const string DS_HISTORICO_PENDENTE_DEBITO = "Pendente Débito: Rebate {0}, Período {1}, Valor R${2}";
                public const string DS_HISTORICO_ENVIADO_PAGAMENTO = "Enviado Pagamento: Rebate {0}, Período {1}, Valor R${2}";
        public const string DS_HISTORICO_PAGO = "Pago: Rebate {0}, Período {1}, Valor R${2} (referente a {3}% do total de R${4})";
        public const string DS_HISTORICO_INFORMACOES_INCONSISTENTES = "Informações Inconsistentes: Rebate {0}, Período {1}, Valor R${2}";
        public const string DS_NAO_ATINGIU_LIMITE_MINIMO = "Não Atingiu o Limite Mínimo: Rebate {0}, Período {1}";
        public const string DS_HISTORICO_SEM_DEBITO = "Débito Quitado";
        public const string DS_HISTORICO_CANCELADO = "Cancelado";
        public const string DS_HISTORICO_GENERICO = "{0}: Rebate {1}, Período {2}, Valor R${3}";
        public const string USUARIO_SERVICO = "REBATE_SERVICE";

        //Filtro Combo Tela Calculo Rebate
        public const string DDL_SELECIONE = "0";        
        public const string DDL_PENDENTE_PAGAMENTO = "1";
        public const string DDL_APROVADO_ANALISTA = "2";
        public const string DDL_ENVIADO_APROVACAO_GERENCIAL = "3";
        public const string DDL_ENVIADO_PAGAMENTO = "4";
        public const string DDL_PAGO = "5";
        public const string DDL_CANCELADO = "6";
        public const string DDL_CALCULO_RETROATIVO_PENDENTE = "7";
        public const string DDL_PENDENTE_DEBITO = "8";

        //Constantes Tela Cálculo Rebate
        public const string APROVAR_ANALISTA = "APROVAR_ANALISTA_REBATE";
        public const string ENVIAR_APROVACAO_GERENCIAL = "ENVIAR_APROVACAO_GESTOR_REBATE"; //Caso alterar valor da constante, deverá alterar o campo NM_MENSAGEM_SIC na tabela TB_MENSAGEM_SIC
        public const string APROVAR_GERENTE = "APROVAR_GERENTE_REBATE";
        public const string REPROVAR_GERENTE = "REPROVAR_GERENTE_REBATE"; //Caso alterar valor da constante, deverá alterar o campo NM_MENSAGEM_SIC na tabela TB_MENSAGEM_SIC
        public const string ADITIVO_REBATE = "ADITIVO_REBATE";
        public const string RECALCULO_REBATE = "RECALCULO_REBATE";
        public const string CONSULTA_DEBITO = "CONSULTA_DEBITO";
        public const string OUTRAS_OPCOES = "OUTRAS_OPCOES";
        public const string CALCULO_RETROATIVO = "CALCULO_RETROATIVO_REBATE";
        public const string ALTERAR_STATUS = "ALTERAR_STATUS_REBATE";
        public const string PAGTO_MANUAL = "PAGTO_MANUAL";

        //Constantes Perfil Tela Rebate
        public const string ANALISTA = "A";
        public const string GESTOR = "G";

        //User System
        public const string SiglaSIC = "SICR";
        public const string SICCadastro = "SIC.Cadastro";
        public const string SICCadastroAvancado = "SIC.CadastroAvancado";
        public const string SICConsulta = "SIC.Consulta";
        public const string GrupoOperacoes = "SicRebateOperacoes@cosan.rede";
        public const string GrupoGestao = "SicRebateGestao@cosan.rede";
    }
}


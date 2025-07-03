<%@ Page Title="Log Rebate Retroativo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LogRebateRetroativo.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.LogRebateRetroativo" %>

<%@ Register Src="Controls/ucPaginacaoRodape.ascx" TagPrefix="RZ" TagName="ucPaginacaoRodape" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        input[type="submit"] {
            font-family: Arial;
            font-size: small !important;
        }

        .content {
            width: 1057px;
        }
    </style>
    <script type="text/javascript">

        //Validação Data Inicial
        $(document).ready(function () {
            $("#<%= txtDataInicio.ClientID %>").mask("99/99/9999");

            $("#<%= txtDataInicio.ClientID %>").focusout(function () {
                    if (isPeriodo($("#<%= txtDataInicio.ClientID %>").val()) == false) {
                        $("#<%= txtDataInicio.ClientID %>").val("");
                        $(ShowMessage("Por favor, digite uma data inicial válida."));
                    } 
                });
            });

            //Validação Data Final
            $(document).ready(function () {
                $("#<%= txtDataFim.ClientID %>").mask("99/99/9999");

                $("#<%= txtDataFim.ClientID %>").focusout(function () {
                    if (isPeriodo($("#<%= txtDataFim.ClientID %>").val()) == false) {
                        $("#<%= txtDataFim.ClientID %>").val("");
                        $(ShowMessage("Por favor, digite uma data final válida."));
                    } 
                });

            $("#<%= txtIBM.ClientID %>").focusout(function () {
                formatIBM("<%= txtIBM.ClientID %>");
            });

            $("#<%= txtIBM.ClientID %>").keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    formatIBM("<%= txtIBM.ClientID %>");
                }
            });
        });


        //Verifica se um periodo informado é valido
        function isPeriodo(txtDate) {
            var currVal = txtDate;
            if (currVal == "__/__/____" || currVal == "01/__/____")
                return true;
            if (currVal == '')
                return false;

            //Declare Regex 
            var rxDatePattern = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?
            if (dtArray == null)
                return false;

            //Checks for mm/dd/yyyy format.
            dtMonth = dtArray[3];
            dtDay = dtArray[1];
            dtYear = dtArray[5];

            var dataAtual = new Date();
            var dataForm = new Date(dtYear, dtMonth - 1, dtDay);

            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            //else if (dataForm > dataAtual)
            //    return false;
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
                return false;
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
                if (dtDay > 29 || (dtDay == 29 && !isleap))
                    return false;
            }
            return true;
        }

        //Formata IBM
        function formatIBM(txtIBM) {
            if (document.getElementById(txtIBM).value == '' || document.getElementById(txtIBM).value == 0)
                return;

            var str = '' + document.getElementById(txtIBM).value;

            while (str.length < 10) {
                str = '0' + str;
            }
            document.getElementById(txtIBM).value = str;
        }

        function ShowMessage(message) {
            $(document).ready(function () {
                $("#dialog").text(message);
                $("#dialog").dialog(
                    {
                        title: 'Mensagem',
                        modal: true,
                        resizable: false,
                        draggable: false
                    });
            });
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div id="dialog" style="display: none; width: 300px; height: 300px;"></div>
    <asp:Panel ID="pnlConsulta" runat="server" DefaultButton="btnConsultar">
        <fieldset>
            <legend>Consulta Log Rebate Retroativo</legend>
            <br />
            <table style="width: 800px" border="0px" cellpadding="10" cellspacing="5" >
                <tr>
                    <td class="editor-field" style="width: 60px">
                        <asp:Label ID="lblIBM" Text="IBM Cliente: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px">
                        <asp:TextBox runat="server" ID="txtIBM" MaxLength="15" />                    
                    </td>
                    
                    <td class="editor-field" style="width: 40px">
                        <asp:Label ID="lblContrato" Text="Número Contrato: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px">
                        <asp:TextBox runat="server" ID="txtContrato" MaxLength="15" />                     
                    </td>
                    
                </tr>
                <tr><td colspan="4">&nbsp;</td></tr>
                <tr>
                    <td class="editor-field" style="width: 60px">
                        <asp:Label ID="lblDataInicio" Text="Data Início: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px" >
                        <asp:TextBox runat="server" ID="txtDataInicio" CssClass="mask-data" />
                    </td>
                    <td class="editor-field" style="width: 40px">
                        <asp:Label ID="lblDataFim" Text="Data Fim: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px" >
                        <asp:TextBox runat="server" ID="txtDataFim" CssClass="mask-data" />
                    </td>
              
                </tr>
                <tr>                   
                    <td class="editor-field" style="width: 60px"; text-align: left" colspan="1">
                        <br /><asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
                    </td>
                    <td class="editor-field" style="width: 600px"; text-align: right" colspan="3">
                        <br /><asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <fieldset>
        <legend>Resultado</legend>
        <br />
        <asp:GridView ID="grvResultado" runat="server" GridLines="None" BorderStyle="None"
                    RowStyle-Height="26" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="20" OnDataBound="grvResultado_DataBound">
                    <RowStyle Height="26px"></RowStyle>
             <PagerTemplate>
                        <RZ:ucPaginacaoRodape ID="ucPaginacaoRodape" runat="server" OnComando="ucPaginacaoRodape_Comando" />
                    </PagerTemplate>
            <EmptyDataTemplate>
                <div style="text-align: center;">
                    Nenhum Registro Encontrado.
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField HeaderText="Data e Hora" DataField="Timestamp" ItemStyle-Width="100px" />
                <asp:BoundField HeaderText="Usuário" DataField="User"  ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField HeaderText="Etapa" DataField="Step"  ItemStyle-Width="640px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField HeaderText="Número Rebate" DataField="NrSeqRebateSic"  ItemStyle-Width="70px"/>
                <asp:BoundField HeaderText="IBM" DataField="NrIbmRebateSic"  ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField HeaderText="Contrato" DataField="NrContrato"  ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center"/>
            </Columns>
        </asp:GridView>
    </fieldset>
    <div style="text-align: right">
        <asp:Button ID="btnGerarExcel" runat="server" Text="Gerar Excel" OnClick="btnGerarExcel_Click" />
    </div>
</asp:Content>

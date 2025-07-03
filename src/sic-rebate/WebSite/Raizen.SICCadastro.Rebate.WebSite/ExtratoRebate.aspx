<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExtratoRebate.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.ExtratoRebate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        //Validação Data Inicial
        $(document).ready(function () {
            $("#<%= txtDataInicial.ClientID %>").mask("99/99/9999");

            $("#<%= txtDataInicial.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtDataInicial.ClientID %>").val()) == false) {
                    $("#<%= txtDataInicial.ClientID %>").val("");
                    $(ShowMessageData("$Por favor, digite uma data válida." + "#<%= txtDataInicial.ClientID %>"));
                } else {
                    formatDefault("$" + "#<%= txtDataInicial.ClientID %>");
                }
            });
        });

        //Validação Data Final
        $(document).ready(function () {
            $("#<%= txtDataFinal.ClientID %>").mask("99/99/9999");

            $("#<%= txtDataFinal.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtDataFinal.ClientID %>").val()) == false) {
                    $("#<%= txtDataFinal.ClientID %>").val("");
                    $(ShowMessageData("$Por favor, digite uma data válida." + "#<%= txtDataFinal.ClientID %>"));
                } else {
                    formatDefault("$" + "#<%= txtDataFinal.ClientID %>");
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
            else if (dataForm > dataAtual)
                return false;
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

        //Apresenta Mensagens Validação
        function ShowMessageData(message) {
            $(document).ready(function () {
                var lista = message.split('$');

                var bulleTedList = "<ul>";
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "#" + controle[1];
                    bulleTedList += "<li>" + controle[0] + "</li>";
                    $(nomecontrole).css("background-color", "#FAFFBD");
                    $(nomecontrole).css("font-weight", "bold");
                    $(nomecontrole).css("color", "black");

                }
                bulleTedList += "</ul>";
                $("#dialog").html(bulleTedList);
                $("#dialog").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: false
                });
            });
        }

        //Exibe modal de confirmação
        function ShowMessageOK() {
            $(document).ready(function () {
                $("#dialogOK").dialog(
                {
                    title: 'Mensagem',
                    modal: true,
                    resizable: false,
                    draggable: true,
                    height: 180,
                    width: 300
                })
                $("#dialogOK").parent().appendTo($("form:first"));
            });
        };

        //Formata os controle para seu estado default
        function formatDefault(controles) {
            $(document).ready(function () {
                var lista = controles.split('$');
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "#" + controle[1];
                    $(nomecontrole).css("background-color", "white");
                    $(nomecontrole).css("font-weight", "normal");
                    $(nomecontrole).css("color", "black");
                }
            });
        }

        //Apresenta Mensagens Validação
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
    <div id="dialog" style="display: none; width: 300px; height: 300px;">
    </div>
    <div id="dialogLista" style="display: none; width: 800px; height: 600px;">
    </div>
    <div id="dialogOK" style="display: none; width: 300px; height: 180px;">
        <br />
        <table style="width: 100%">
            <tr>
                <td colspan="2" class="editor-field">
                    <center>
                        <asp:Label ID="lblMensagemOK" runat="server" />
                    </center>
                </td>
            </tr>
            <tr style="width: 100%">
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="editor-field">
                    <center>
                        <asp:Button ID="btnOK" runat="server" Text="Confirmar" OnClick="btnOK_Click" />
                    </center>
                </td>
                <td class="editor-field">
                    <center>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    </center>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlConsulta" runat="server" DefaultButton="btnConsultar">
        <fieldset>
            <legend>Extrato Rebate</legend>
            <br />
            <table style="width: 100%" border="0px">
                <tr>
                    <td class="editor-label" style="width: 40px">
                        <asp:Label ID="lblIBM" Text="IBM: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 190px">
                        <asp:TextBox runat="server" ID="txtIBM" MaxLength="10" />
                    </td>
                    <td class="display-label" style="width: 70px">
                        <asp:Label ID="Label6" Text="Data Inicial: " runat="server"></asp:Label>
                    </td>
                    <td class="display-field" style="width: 190px">
                        <asp:TextBox ID="txtDataInicial" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="display-label" style="width: 65px">
                        <asp:Label ID="Label5" Text="Data Final: " runat="server"></asp:Label>
                    </td>
                    <td class="display-field" style="width: 190px">
                        <asp:TextBox ID="txtDataFinal" runat="server" MaxLength="10"></asp:TextBox>
                    </td>
                    <td class="display-field">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <fieldset>
        <legend>Resultado</legend>
        <br />
        <asp:GridView ID="grvExtrato" runat="server" EnableModelValidation="True" GridLines="None"
            BorderStyle="None" RowStyle-Height="26" Width="100%" AutoGenerateColumns="False">
            <EmptyDataTemplate>
                <div style="text-align: center;">
                    Nenhum Registro Encontrado.</div>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField HeaderText="Data Lançamento" DataField="DtLancamentoSic" DataFormatString="{0:dd/MM/yyyy hh:mm}">
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Lançamento" DataField="VlLancamentoSic" DataFormatString="{0:N}">
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Saldo" DataField="VlSaldoAtualSic" DataFormatString="{0:N}">
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Observação" DataField="DsObsComplementoSic">
                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </fieldset>
    <div style="text-align: right">
        <asp:Button ID="btnGerarExcel" runat="server" Text="Gerar Excel" OnClick="btnGerarExcel_Click" />
    </div>
</asp:Content>

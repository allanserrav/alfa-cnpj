<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PagamentoBonificacao.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.PagamentoBonificacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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

        //Definições de carregamento da página
        $(document).ready(function () {
            $("#<%= txtPeriodo.ClientID %>").mask("99/9999");

            $("#<%= txtIBM.ClientID %>").focusout(function () {
                formatIBM("<%= txtIBM.ClientID %>");
            });

            $("#<%= txtIBM.ClientID %>").keypress(function (event) {
                var keycode = (event.keyCode ? event.keyCode : event.which);
                if (keycode == '13') {
                    formatIBM("<%= txtIBM.ClientID %>");
                }
            });

            $("#<%= txtPeriodo.ClientID %>").focusout(function () {
                if (isPeriodo($("#<%= txtPeriodo.ClientID %>").val()) == false) {
                    $("#<%= txtPeriodo.ClientID %>").val("");
                    ShowMessageData("$Por favor, digite uma período válido." + "#<%= txtPeriodo.ClientID %>");
                } else {
                    formatDefault("$" + "#<%= txtPeriodo.ClientID %>");
                }
            });
        });


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

        //Verifica se um periodo informado é valido
        function isPeriodo(txtDate) {
            var currVal = txtDate;
            if (currVal == "__/____")
                return true;
            if (currVal == '')
                return false;

            currVal = "01/" + currVal;
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

            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if (dtYear > dataAtual.getFullYear())
                return false;
            else if (dtMonth > (dataAtual.getMonth() + 1) && dtYear > dataAtual.getFullYear())
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
                        <asp:Button ID="btnOK" runat="server" Text="Confirmar" />
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
    <asp:Panel ID="pnlFiltros" runat="server" DefaultButton="btnGerarExcel">
        <fieldset>
            <legend>Pagamento Bonificação</legend>
            <br />
            <table style="width: 100%" border="0px">
                <tr>
                    <td class="editor-label">
                        <asp:Label ID="lblPeriodoBusca" Text="Período: " runat="server" />
                    </td>
                    <td class="editor-field">
                        &nbsp;<asp:TextBox runat="server" ID="txtPeriodo" MaxLength="7" Width="120px" />
                        <asp:RequiredFieldValidator ErrorMessage="*" runat="server" ValidationGroup="GerarExcel"
                            ControlToValidate="txtPeriodo" />
                    </td>
                    <td class="editor-label">
                        <asp:Label ID="lblIBM" Text="IBM: " runat="server" />
                    </td>
                    <td class="editor-field">
                        &nbsp;<asp:TextBox runat="server" ID="txtIBM" MaxLength="10" Width="120px" />
                    </td>
                    <td class="editor-label">
                        <asp:Label ID="lblSituacao" Text="Situação: " runat="server" />
                    </td>
                    <td class="editor-field">
                        <asp:DropDownList ID="ddlSituacao" runat="server" Width="320px" AutoPostBack="False">
                            <asp:ListItem Text="SELECIONE" Value="0" />
                            <asp:ListItem Text="Bonificação Pendente de Pagto" Value="1" />
                            <asp:ListItem Text="Pago" Value="3" />
                            <asp:ListItem Text="Rebate com Débito" Value="2" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        <asp:Label ID="Label2" Text="Canal: " runat="server" />
                    </td>
                    <td class="editor-field">
                        <asp:DropDownList ID="ddlCanal" runat="server" Width="130px" AutoPostBack="False">
                            <asp:ListItem Text="SELECIONE" Value="0" />
                            <asp:ListItem Text="A" Value="A" />
                            <asp:ListItem Text="C" Value="C" />
                            <asp:ListItem Text="V" Value="V" />
                        </asp:DropDownList>
                    </td>
                    <td class="editor-label">
                        <asp:Label ID="lblGA" Text="GA: " runat="server" />
                    </td>
                    <td class="editor-field">
                        <asp:DropDownList ID="ddlGA" runat="server" AutoPostBack="False" Width="130px">
                        </asp:DropDownList>
                    </td>
                    <td class="editor-label">
                        <asp:Label ID="lblGT" Text="GT:" runat="server" />&nbsp;
                    </td>
                    <td colspan="3">
                        <asp:ListBox runat="server" ID="lstGT" Rows="6" Width="320px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td class="editor-label">
                        Tipo Rebate:
                    </td>
                    <td colspan="5">
                        <asp:CheckBox ID="chkEscalonado" runat="server" Text="Escalonado" Checked="true" />&nbsp;&nbsp;
                        <asp:CheckBox ID="chkFaixaVolume" runat="server" Text="Faixa Volume" Checked="true" />&nbsp;&nbsp;
                        <asp:CheckBox ID="chkMediaVolume" runat="server" Text="Global Média Volume" Checked="true" />&nbsp;&nbsp;
                        <asp:CheckBox ID="chkSomaVolume" runat="server" Text="Global Soma Volume" Checked="true" />
                    </td>
                </tr>
            </table>
            <div style="text-align: right">
                <asp:Button ID="btnLimparFiltros" runat="server" Text="Limpar Filtros" OnClick="btnLimparFiltros_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnGerarExcel" runat="server" Text="Gerar Excel" OnClick="btnGerarExcel_Click"
                    ValidationGroup="GerarExcel" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </fieldset>
    </asp:Panel>
</asp:Content>

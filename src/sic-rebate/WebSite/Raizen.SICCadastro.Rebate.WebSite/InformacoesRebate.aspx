<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InformacoesRebate.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.InformacoesRebate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        //Validação IBM
        $(document).ready(function () {
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
            <legend>Informações Rebate</legend>
            <br />
            <table style="width: 850px" border="0px">
                <tr>
                    <td class="editor-field" style="width: 40px">
                        <asp:Label ID="lblIBM" Text="IBM Cliente: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px" colspan="2">
                        <asp:TextBox runat="server" ID="txtIBM" MaxLength="10" />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="editor-field" style="width: 40px">
                        <asp:Label ID="Label1" Text="Tipo Rebate: " runat="server" />
                        <br />
                        <br />
                    </td>
                    <td class="editor-field" style="width: 120px" colspan="2">
                        <asp:CheckBox ID="chkEscalonado" runat="server" Text="Escalonado" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chkFaixaVolume" runat="server" Text="Faixa Volume" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chkMediaVolume" runat="server" Text="Global Média Volume" Checked="true" />
                        <br />
                        <asp:CheckBox ID="chkSomaVolume" runat="server" Text="Global Soma Volume" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td class="editor-field" style="width: 40px">
                        <br />
                        <asp:Label ID="Label2" Text="Status Cliente: " runat="server" />
                    </td>
                    <td class="editor-field" style="width: 120px" colspan="2">
                        <br />
                        <asp:CheckBox ID="chkCorrecao" runat="server" Text="Correção" Checked="false" />&nbsp;
                        <asp:CheckBox ID="chkAnalise" runat="server" Text="Análise" Checked="false" />&nbsp;
                        <asp:CheckBox ID="chkAceito" runat="server" Text="Aceito" Checked="true" />
                    </td>
                </tr>
                <tr>
                    <td class="editor-field" style="width: 100%; text-align: right" colspan="3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
    <fieldset>
        <legend>Resultado</legend>
        <br />
        <asp:GridView ID="grvResultado" runat="server" EnableModelValidation="True" GridLines="None"
            BorderStyle="None" RowStyle-Height="26" Width="100%" AutoGenerateColumns="False">
            <EmptyDataTemplate>
                <div style="text-align: center;">
                    Nenhum Registro Encontrado.</div>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField HeaderText="IBM" DataField="NrIbmClienteSic">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Razão Social" DataField="NmRazsociallojaFranquiaSic">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Tipo" DataField="NmTiporebateSic">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="CEGR" DataField="NrCegrpostoClienteSic">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Fornecedor" DataField="NrCodigofornecedorRebateSic">
                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="GA" DataField="NmGalojaClienteSic">
                    <HeaderStyle HorizontalAlign="Center" Width="20px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="GT" DataField="NmGtlojaClienteSic">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Dt. Inicio" DataField="DtIniciovigenciaRebateSic" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Dt. Fim" DataField="DtFimvigenciaRebateSic" DataFormatString="{0:dd/MM/yyyy}">
                    <HeaderStyle HorizontalAlign="Center" Width="50px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </fieldset>
    <div style="text-align: right">
        <asp:Button ID="btnGerarExcel" runat="server" Text="Gerar Excel" OnClick="btnGerarExcel_Click" />
    </div>
</asp:Content>

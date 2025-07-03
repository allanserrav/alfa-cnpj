<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="Restricao.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.Restricao" %>

<%@ Register Src="Controls/ucPaginacaoRodape.ascx" TagPrefix="RZ" TagName="ucPaginacaoRodape" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <script type="text/javascript">
      
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

        function ShowMessageLista(message) {
            $(document).ready(function () {
                var lista = message.split('$');
                var bulleTedList = "<ul>";
                for (var i = 1; i < lista.length; i++) {
                    var controle = lista[i].split('#');
                    var nomecontrole = "#ctl00_cph_ctl00_" + controle[1];
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
                        draggable: true,
                        height: 300,
                        width: 600

                    });
            });
        }

        function Deletar() {
            $("#confirmacao").dialog(
                {
                    title: 'Confirmação de exclusão',
                    modal: true,
                    resizable: false,
                    draggable: false,
                    width: 300
                });
            $("#confirmacao").parent().appendTo($("form:first"));
        }

    </script>
    <div id="dialog" style="display: none;">
    </div>
    <div id="confirmacao" style="display: none;">
        <table>
            <tr>
                <td colspan="2">
                    <center>
                        <h3>
                            Tem certeza que deseja excluir?
                        </h3>
                    </center>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSimExcluir" Text="Sim" runat="server" OnClick="btnSimExcluir_OnClick" />
                </td>
                <td>
                    <asp:Button ID="btnNaoExcluir" Text="Não" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    

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
    <asp:Panel ID="pnlConsulta" runat="server" DefaultButton="btnBuscar">
        <fieldset>
            <legend>Consulta Restrições</legend>
        <br />
            <asp:Panel runat="server" DefaultButton="btnBuscar">
                <table>                    
                    <tr>
                        <td style="width: 80px">
                            <span>Ibm:</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtIbm" Width="120px" CssClass="campo-ibm" maxlength="15" oninput="this.value = this.value.replace(/[^0-9]/g, '')"/>
                        </td>
                        <td style="width: 80px">
                            <span>&nbsp;</span>
                        </td>
                        <td style="width: 80px">
                            <span>Motivo:</span>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtMotivo" Width="360px" CssClass="campo-ibm"  maxlength="50"/>
                        </td>
                    </tr>
                </table>

                <br />
                <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click"/>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
            </asp:Panel>
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
                        <asp:BoundField DataField="NrSeqRestricao" Visible="false" />

                        <asp:BoundField HeaderText="IBM" DataField="DsIbm">
                            <HeaderStyle HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Motivo" DataField="DsMotivo">
                            <HeaderStyle HorizontalAlign="Left" Width="500px" />
                        </asp:BoundField>                        

                        <asp:TemplateField HeaderText="Alterar">
                            <ItemTemplate>
                                <asp:HyperLink ID="hplAlterar" runat="server" NavigateUrl='<%# Eval("NrSeqRestricao","~/cadastrorestricao.aspx?restricao_id={0}") %>' ImageUrl="~/images/icons/note_edit.png" Style="margin: 0 auto; display: table" ToolTip="Alterar" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Excluir">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnExcluir" ImageUrl="~/images/icons/delete.png" runat="server" ToolTip="Excluir" OnClick="btnExcluir_Click" CommandArgument='<%# Eval("NrSeqRestricao")%>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
    <div style="text-align: right">
        <asp:Button ID="btnGerarExcel" runat="server" Text="Gerar Excel com Todos" OnClick="btnGerarExcel_Click" />
    </div>
</asp:Content>
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

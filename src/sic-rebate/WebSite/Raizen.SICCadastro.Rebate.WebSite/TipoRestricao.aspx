<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true"
    CodeBehind="TipoRestricao.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.TipoRestricao" %>

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
    <fieldset>
        <legend>Cadastrar Tipo de Restrição</legend>
        <div class="editor-field">
            <table>
                <tr>
                    <td class="editor-field" style="width: 120px">
                        <asp:Label ID="lblTipoRestricao" runat="server" Text="Tipo Restrição :" />
                    </td>
                    <td class="editor-field">
                        <asp:TextBox runat="server" ID="txtDsTipoRestricao" Width="450px" MaxLength="100"  />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ControlToValidate="txtDsTipoRestricao"
                            runat="server" ValidationGroup="validarRepasseExcecao" />
                    </td>                    
                </tr>
               
            </table>
        </div>
        <br />
        <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click"
            ValidationGroup="validarTipoRestricao" />
    </fieldset>
    <fieldset>
        <legend>Resultado</legend>
        <br />
        <asp:GridView ID="grvTipoRestricao" runat="server" GridLines="None" BorderStyle="None"
            RowStyle-Height="26" AutoGenerateColumns="false" EnableModelValidation="True" Width="600px"
            AllowPaging="true" PageSize="20"
            EmptyDataText="Nenhum Registro Encontrado." OnDataBound="grvTipoRestricao_DataBound">
            <RowStyle Height="26px"></RowStyle>
            <PagerTemplate>
                <hr style="width: 100%;">
                <table border="0" width="100%">
                    <tr>
                        <td style="text-align: left; vertical-align: middle;">
                            <asp:Label ID="Label1" Text="Página: " runat="server"></asp:Label>
                            <asp:DropDownList ID="ddCurrentPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddCurrentPage_SelectedIndexChanged"
                                Width="15px">
                            </asp:DropDownList>
                            <asp:Label ID="lblOf" runat="server" Style="text-align: center;" Text="de"></asp:Label>
                            <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right; vertical-align: middle;">
                            <asp:ImageButton ID="imgPageFirst" runat="server" CommandArgument="First" CommandName="Page"
                                ImageUrl="~/images/icons/resultset_first.png" OnCommand="imgPageFirst_Command" />
                            <asp:ImageButton ID="imgPagePrevious" runat="server" CommandArgument="Prev" CommandName="Page"
                                ImageUrl="~/images/icons/resultset_previous.png" OnCommand="imgPagePrevious_Command" />
                            <asp:ImageButton ID="imgPageNext" runat="server" CommandArgument="Next" CommandName="Page"
                                ImageUrl="~/images/icons/resultset_next.png" OnCommand="imgPageNext_Command" />
                            <asp:ImageButton ID="imgPageLast" runat="server" CommandArgument="Last" CommandName="Page"
                                ImageUrl="~/images/icons/resultset_last.png" OnCommand="imgPageLast_Command" />
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
            <EmptyDataTemplate>
                <div style="text-align: center;">
                    Nenhum registro encontrado.</div>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField HeaderText="Tipo de Restrição" DataField="DsTipoRestricao">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>              
                <asp:TemplateField HeaderText="Excluir" HeaderStyle-Width="50px">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/images/icons/delete.png"
                            OnClick="btnExcluir_Click" ToolTip="Excluir" CommandArgument=' <%# Eval("NrSeqTipoRestricao")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>
</asp:Content>

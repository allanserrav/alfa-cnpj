<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="logintegracao.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.logintegracao"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //Disable Element
        function disableElement(elem) {
            elem.disabled = true;
        }

        //Definições de carregamento da página
        $(document).ready(function () {
            $("#<%= txtPeriodoIni.ClientID %>").mask("99/99/9999");
            $("#<%= txtPeriodoFim.ClientID %>").mask("99/99/9999");
        });

        //Verifica se um periodo informado é valido
        function isPeriodo(txtDate) {
            var currVal = txtDate;
            if (currVal == "__/__/____")
                return true;
            if (currVal == '')
                return false;

            currVal = currVal;
            //Declare Regex 
            var rxDatePattern = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/;
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

    <div>
        <asp:Panel ID="pnlDefault" DefaultButton="btnBuscar" runat="server">
            <fieldset>
                <legend>Buscar Log de Integração</legend>
                <br />
                <table style="width: 100%" border="0px">
                    <tr>
                        <td class="editor-label" style="width: 65px">
                            <asp:Label ID="lblPeriodoBusca" Text="Período de " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 20px">
                            &nbsp;<asp:TextBox runat="server" ID="txtPeriodoIni" MaxLength="10" />
                        </td>
                        <td class="editor-label" style="width: 65px">
                            <asp:Label ID="Label2" Text="até " runat="server" />
                        </td>
                        <td class="editor-field" style="width: 20px">
                            &nbsp;<asp:TextBox runat="server" ID="txtPeriodoFim" MaxLength="10" />
                        </td>
                        <td class="editor-field" style="width: 30px">
                            <asp:Button Text="Consultar" runat="server" ID="btnBuscar" ValidationGroup="Buscar"
                                CausesValidation="false" OnClick="btnBuscar_Click" OnClientClick="disableElement(this);"
                                UseSubmitBehavior="false" />
                        </td>
                    </tr>
 
                </table>
            </fieldset>
            <fieldset>
                <legend>Resultado</legend>
                <br />
                <asp:GridView ID="grvResultado" runat="server" GridLines="None" BorderStyle="None"
                    RowStyle-Height="26" AutoGenerateColumns="False" EnableModelValidation="True"
                    DataKeyNames="NrSeqLogIntegracaoSic" OnRowCreated="grvResultado_RowCreated" Width="880px"
                    AllowPaging="true" PageSize="50" EmptyDataText="No Record Found" 
                    OnPageIndexChanging="grvResultado_PageIndexChanging"
                    OnDataBound="grvResultado_DataBound" 
                    OnRowDataBound="grvResultado_RowDataBound"
                    AllowSorting="true" 
                    OnSorting="grvResultado_Sorting">
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
                            Nenhum Registro Encontrado.</div>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderText="Data ação" DataField="DtAcaoSic">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Descrição da ação" DataField="DsAcaoSic">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Método" DataField="NmMetodoSic">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Página" DataField="NmPaginaSic">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Usuário" DataField="NmUsuarioSic">
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <br />
            </fieldset>
            <div style="float: right">
                <table>
                    <tr>
                        <td id="tdExportar" runat="server">
                            <div style="margin:5px 5px 0px 5px;">
                                <asp:Button ID="btnExportar" Text="Exportar Excel" runat="server" 
                                    onclick="btnExportar_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

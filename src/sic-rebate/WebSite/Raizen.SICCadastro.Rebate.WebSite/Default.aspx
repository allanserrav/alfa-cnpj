<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#selecionarTodos').click(function () {
                if (this.checked == true) {
                    $("input[type=checkbox]").each(function () {
                        this.checked = true;
                    });
                    $("#ctl00_cph_btnExcluirSelecionados").focus();
                } else {
                    $("input[type=checkbox]").each(function () {
                        this.checked = false;
                    });
                }
            });
        });
    </script>
    <fieldset>
        <legend>Acontece hoje no SIC - Rebate</legend>
        <br />
        <table style="width: 100%">
            <tr style="width: 850px">
                <th class="th" style="width: 600px">
                    <b>Tipo Mensagem</b>
                </th>
                <th class="th" style="width: 200px">
                    <b>Filtrar</b>
                </th>
            </tr>
            <tr style="width: 850px">
                <td class="th" style="width: 600px">
                    <asp:DropDownList runat="server" ID="ddlFiltrar">
                        <asp:ListItem Text="Rebates que terminam a vigência em 60 dias" Value="6" />
                        <asp:ListItem Text="Rebate que a vigência terminou" Value="7" />
                        <asp:ListItem Text="Reajuste 1 ano após a assinatura do contrato" Value="8" />
                    </asp:DropDownList>
                </td>
                <td class="th" style="width: 200px">
                    <asp:Button Text="Filtrar" ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" />
                </td>
            </tr>
        </table>
        <br />
        <legend>Resultado</legend>
        <div>
            <center>
                <asp:Label ID="lblRetorno" runat="server" />
            </center>
        </div>
        <asp:Repeater runat="server" ID="rptAvisos">
            <HeaderTemplate>
                <table style="width: 100%">
                    <tr style="width: 850px">
                        <th class="th" style="width: 50px">
                            <input type="checkbox" value="0" style="margin-left: 30px;" id="selecionarTodos" />
                        </th>
                        <th class="th" style="width: 450px">
                            <b>Mensagem</b>
                        </th>
                        <th class="th" style="width: 70px">
                            <b>IBM</b>
                        </th>
                        <th class="th" style="width: 50px">
                            <center>
                                <b>Excluir</b>
                            </center>
                        </th>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table style="width: 100%">
                    <tr style="width: 850px">
                        <td style="width: 50px">
                            <center>
                                <asp:CheckBox ID="chkExcluir" runat="server" />
                                <asp:Label Text='<%# Eval("NrSeqAvisoSic")%>' runat="server" ID="lblNrSeqAvisoSic"
                                    Visible="false" />
                            </center>
                        </td>
                        <td style="width: 450px">
                            <asp:Label ID="lblNmTipoenderecoSic" runat="server" Width="450px" Text='<%# DataBinder.Eval(Container.DataItem, "DsAvisoSic")%>' />
                        </td>
                        <td style="width: 70px">
                            <asp:Label ID="Label1" runat="server" Width="50px" Text='<%# DataBinder.Eval(Container.DataItem, "NrIbmAvisoSic")%>' />
                        </td>
                        <td style="width: 50px">
                            <center>
                                <asp:ImageButton ID="Excluir" ImageUrl="~/images/icons/delete.png" runat="server"
                                    OnClick="imgExcluir_Click" ToolTip="Excluir Aviso" Width="20px" Height="20px"
                                    CommandArgument='<%# Eval("NrSeqAvisoSic")%>' />
                            </center>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <div style="text-align: right">
            <br />
            <asp:Button Text="Excluir Avisos Selecionados" ID="btnExcluirSelecionados" runat="server"
                OnClick="btnExcluirSelecionados_Click" />
        </div>
    </fieldset>
</asp:Content>

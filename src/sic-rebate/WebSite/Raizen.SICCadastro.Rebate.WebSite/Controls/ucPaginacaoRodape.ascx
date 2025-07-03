<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPaginacaoRodape.ascx.cs"
    Inherits="Raizen.SICCadastro.Rebate.WebSite.Controls.ucPaginacaoRodape" %>
<style type="text/css">
    .botao-paginacao:disabled
    {
        -moz-opacity: 0.50;
        opacity: 0.50;
        filter: alpha(opacity=50);
        cursor: default;
    }
    .drop-paginacao
    {
        min-width: 80px !important;
    }
</style>
<table border="0" style="width: 100%;">
    <tr>
        <td style="text-align: left; vertical-align: middle;">
            <asp:Label ID="lblPagina" Text="Página: " runat="server" />
            <asp:DropDownList ID="ddlPagina" runat="server" AutoPostBack="True" CssClass="drop-paginacao"
                OnSelectedIndexChanged="ddlPagina_SelectedIndexChanged" />
            <span style="text-align: center;">de</span>
            <asp:Label ID="lblTotalPagina" runat="server" />
        </td>
        <td style="text-align: right; vertical-align: middle;">
            <asp:ImageButton ID="imgPrimeiraPagina" runat="server" ImageUrl="~/images/icons/resultset_first.png"
                CssClass="botao-paginacao" OnCommand="imgPrimeiraPagina_Command" />
            <asp:ImageButton ID="imgAnteriorPagina" runat="server" ImageUrl="~/images/icons/resultset_previous.png"
                CssClass="botao-paginacao" OnCommand="imgAnteriorPagina_Command" />
            <asp:ImageButton ID="imgProximaPagina" runat="server" ImageUrl="~/images/icons/resultset_next.png"
                CssClass="botao-paginacao" OnCommand="imgProximaPagina_Command" />
            <asp:ImageButton ID="imgUltimaPagina" runat="server" ImageUrl="~/images/icons/resultset_last.png"
                CssClass="botao-paginacao" OnCommand="imgUltimaPagina_Command" />
        </td>
    </tr>
</table>

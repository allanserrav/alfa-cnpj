<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.Controls.MessageBox" %>
<style type="text/css">
    .MessageBox {
        position: relative;
    }

        .MessageBox #TextoMensagem {
            text-align: justify;
        }

        .MessageBox .Acao {
            text-align: center;
            position: absolute;
            width: 96%;
            padding: 10px 0 10px 0;
        }

            .MessageBox .Acao .detalhe {
                display: block;
                margin-bottom: 15px;
            }

    #textoMensagem {
        min-height: 70%;
    }
</style>

<div class="MessageBox" style="display: none">
    <div id="textoMensagem"></div>
    <div class="Acao">
<%--        <asp:HyperLink ID="btnErro" NavigateUrl="~/Erro.aspx" runat="server" CssClass="detalhe" Target="_blank">Ver Detalhes</asp:HyperLink>--%>
        <asp:Button ID="btnOk" Text="OK" runat="server" OnClick="btnOk_Click" />
        <asp:Button ID="btnNao" Text="Não" runat="server" OnClick="btnNao_Click" />
        <asp:Button ID="btnSim" Text="Sim" runat="server" OnClick="btnSim_Click" />
        <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />

    </div>
</div>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Erro.aspx.cs" Inherits="Raizen.SICCadastro.Rebate.WebSite.Erro" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <fieldset>
        <legend>Oops ocorreu um erro...</legend>
        <div>
            <br />
            Infelizmente, <b>apesar de todos nossos esforcos</b>, algo ocorreu ao processar
            sua solicitação.<br />
            <b>Lamentamos muito</b> a inconveniência.
            <br />
            Por favor, tire um print dessa tela, copie a mensagem abaixo e envie ao responsável
            pelo sistema.
        </div>
        <br />
        <legend>Mensagem.</legend>
        <div>
            <asp:TextBox runat="server" ID="txtErro" TextMode="MultiLine" Height="250px" Width="850px" />
        </div>
    </fieldset>
</asp:Content>
